using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Imaging;
using WebCamLib;          // Device, DeviceManager
using System.Threading;   // for short wait while clipboard fills (used below)


namespace ImageProcessing
{
    public partial class DigitalImagerv1 : Form
    {
        private Bitmap originalBitmap = null;
        private Bitmap processedBitmap = null;
        private Bitmap imageB, imageA, resultImage;
        // webcam fields
        private Device[] webcamDevices = new Device[0];
        private Device currentDevice = null;

        private System.Windows.Forms.Timer liveTimer; 
        private bool liveMode = false; 
        private string currentLiveFilter = "None";


        public DigitalImagerv1()
        {
            InitializeComponent();
            SetupHistogramChart();
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog1.FileName;
                DisposeBitmaps();
                originalBitmap = new Bitmap(path);

                pictureBoxOriginal.Image = originalBitmap;
                pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;

                processedBitmap = null;
                pictureBoxProcessed.Image = null;
                pictureBoxProcessed.SizeMode = PictureBoxSizeMode.Zoom;

                chartHistogram.Series["Red"].Points.Clear();
                chartHistogram.Series["Green"].Points.Clear();
                chartHistogram.Series["Blue"].Points.Clear();

                // Enable processing buttons
                SetProcessingButtonsEnabled(true);
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processedBitmap == null) return;
            saveFileDialog1.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap|*.bmp";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                ImageFormat fmt = ImageFormat.Png;
                string ext = System.IO.Path.GetExtension(path).ToLower();
                if (ext == ".jpg" || ext == ".jpeg") fmt = ImageFormat.Jpeg;
                else if (ext == ".bmp") fmt = ImageFormat.Bmp;
                processedBitmap.Save(path, fmt);
                MessageBox.Show("Saved: " + path, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisposeBitmaps();

            pictureBoxOriginal.Image = null;
            pictureBoxProcessed.Image = null;
            pictureBoxSubtraction.Image = null;

            chartHistogram.Series["Red"].Points.Clear();
            chartHistogram.Series["Green"].Points.Clear();
            chartHistogram.Series["Blue"].Points.Clear();

            SetProcessingButtonsEnabled(false);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = (Bitmap)originalBitmap.Clone();
            pictureBoxProcessed.Image = processedBitmap;

            SetProcessingButtonsEnabled(true);
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;

            ApplyPixelOperation((c) =>
            {
                int gray = (int)(c.R + c.G + c.B) / 3;
                return Color.FromArgb(c.A, gray, gray, gray);
            });

            SetProcessingButtonsEnabled(true);
            currentLiveFilter = "Grayscale";
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            ApplyPixelOperation((c) =>
            {
                return Color.FromArgb(c.A, 255 - c.R, 255 - c.G, 255 - c.B);
            });

            SetProcessingButtonsEnabled(true);
            currentLiveFilter = "Invert";
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            ApplyPixelOperation((c) =>
            {
                // sepia formula (common simple version)
                int r = Clamp((int)(0.393 * c.R + 0.769 * c.G + 0.189 * c.B));
                int g = Clamp((int)(0.349 * c.R + 0.686 * c.G + 0.168 * c.B));
                int b = Clamp((int)(0.272 * c.R + 0.534 * c.G + 0.131 * c.B));
                return Color.FromArgb(c.A, r, g, b);
            });

            SetProcessingButtonsEnabled(true);
            currentLiveFilter = "Sepia";
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (originalBitmap == null && processedBitmap == null) return;
            Bitmap src = processedBitmap ?? originalBitmap;
            BuildAndShowHistogram(src);

        }
        // Helper: applies a pixel transform using GetPixel/SetPixel
        private void ApplyPixelOperation(Func<Color, Color> pixelFunc)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height, originalBitmap.PixelFormat);

            for (int y = 0; y < originalBitmap.Height; y++)
            {
                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    Color c = originalBitmap.GetPixel(x, y);
                    Color nc = pixelFunc(c);
                    processedBitmap.SetPixel(x, y, nc);
                }
            }

            pictureBoxProcessed.Image = processedBitmap;
        }

        private int Clamp(int v)
        {
            if (v < 0) return 0;
            if (v > 255) return 255;
            return v;
        }

        private void DisposeBitmaps()
        {
            originalBitmap?.Dispose();
            processedBitmap?.Dispose();
            originalBitmap = null;
            processedBitmap = null;
        }

        // Histogram setup & drawing using Chart control
        private void SetupHistogramChart()
        {
            chartHistogram.Series.Clear();
            chartHistogram.ChartAreas.Clear();

            ChartArea ca = new ChartArea("CA");
            ca.AxisX.Minimum = 0;
            ca.AxisX.Maximum = 255;
            ca.AxisX.Title = "Intensity (0-255)";
            ca.AxisY.Title = "Pixels";

            chartHistogram.ChartAreas.Add(ca);

            var sr = new Series("Red") { ChartType = SeriesChartType.Column, ChartArea = "CA" };
            var sg = new Series("Green") { ChartType = SeriesChartType.Column, ChartArea = "CA" };
            var sb = new Series("Blue") { ChartType = SeriesChartType.Column, ChartArea = "CA" };

            // make columns slightly transparent so they overlap nicely
            sr["PixelPointWidth"] = "1";
            sg["PixelPointWidth"] = "1";
            sb["PixelPointWidth"] = "1";

            chartHistogram.Series.Add(sr);
            chartHistogram.Series.Add(sg);
            chartHistogram.Series.Add(sb);

            // Optional: clear legend
            chartHistogram.Legends.Clear();
        }

        private void BuildAndShowHistogram(Bitmap bmp)
        {
            int[] r = new int[256], g = new int[256], b = new int[256];
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    r[c.R]++;
                    g[c.G]++;
                    b[c.B]++;
                }

            chartHistogram.Series["Red"].Points.Clear();
            chartHistogram.Series["Green"].Points.Clear();
            chartHistogram.Series["Blue"].Points.Clear();

            for (int i = 0; i < 256; i++)
            {
                chartHistogram.Series["Red"].Points.AddXY(i, r[i]);
                chartHistogram.Series["Green"].Points.AddXY(i, g[i]);
                chartHistogram.Series["Blue"].Points.AddXY(i, b[i]);
            }
        }

        // Dispose bitmaps on close
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (currentDevice != null)
                {
                    currentDevice.Stop();
                    currentDevice = null;
                }
            }
            catch { }

            DisposeBitmaps();
            base.OnFormClosing(e);
        }

        // Menu: Load Image B (green background)
        private void loadImageBToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                imageB = new Bitmap(openFileDialog2.FileName);
                pictureBoxOriginal.Image = imageB;
                pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
                return;
            }

            imageB = new Bitmap(pictureBoxProcessed.Image);
        }

        // Menu: Load Image A (original background)
        private void loadImageAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                imageA = new Bitmap(openFileDialog3.FileName);
                pictureBoxProcessed.Image = imageA;
                pictureBoxProcessed.SizeMode = PictureBoxSizeMode.Zoom;
                return;
            }

            imageA = new Bitmap(pictureBoxProcessed.Image);
        }


        private void subtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageA == null || imageB == null)
            {
                MessageBox.Show("Please load both Image A and Image B first!");
                return;
            }

            if (imageA.Width != imageB.Width || imageA.Height != imageB.Height)
            {
                imageA = ResizeImage(imageA, imageB.Width, imageB.Height);
                pictureBoxProcessed.Image = imageA; // update display so you see the resized version
            }

            resultImage = new Bitmap(imageB.Width, imageB.Height);

            //// Define "green" reference
            Color mygreen = Color.FromArgb(0, 255, 0);

            for (int x = 0; x < imageB.Width; x++)
            {
                for (int y = 0; y < imageB.Height; y++)
                {
                    Color pixel = imageB.GetPixel(x, y);
                    Color backpixel = imageA.GetPixel(x, y);

                    // Compute difference from pure green
                    int diffR = Math.Abs(pixel.R - mygreen.R);
                    int diffG = Math.Abs(pixel.G - mygreen.G);
                    int diffB = Math.Abs(pixel.B - mygreen.B);

                    // if the pixel is "close enough" to green, treat as green
                    if (diffR < 60 && diffG < 60 && diffB < 60)
                        resultImage.SetPixel(x, y, backpixel);
                    else
                        resultImage.SetPixel(x, y, pixel);
                }
            }

            pictureBoxSubtraction.Image = resultImage;
            pictureBoxSubtraction.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void startWebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Always refresh device list before starting
                webcamDevices = DeviceManager.GetAllDevices();  // <-- or your enumeration method
                comboBoxDevices.Items.Clear();
                foreach (var dev in webcamDevices)
                {
                    comboBoxDevices.Items.Add(dev.Name);
                }

                if (webcamDevices == null || webcamDevices.Length == 0)
                {
                    MessageBox.Show("No webcam devices available.");
                    return;
                }

                // Stop previous device (if any)
                if (currentDevice != null)
                {
                    currentDevice.Stop();
                    currentDevice = null;
                }

                // Choose selected device
                int idx = comboBoxDevices.SelectedIndex;
                if (idx < 0 || idx >= webcamDevices.Length) idx = 0;
                currentDevice = webcamDevices[idx];

                // Show live preview inside the panel (host control)
                currentDevice.ShowWindow(panelWebcamHost);

                startWebcamToolStripMenuItem.Enabled = false;
                captureToolStripMenuItem.Enabled = true; // enable only after starts
                stopWebcamToolStripMenuItem.Enabled = true; //hello
                
                comboBoxDevices.SelectedIndex = idx;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting webcam: " + ex.Message);
            }
        }

        private void stopWebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentDevice != null)
                {
                    currentDevice.Stop();
                    currentDevice = null;
                }

                panelWebcamHost.Visible = false;
                comboBoxDevices.Visible = false;

                startWebcamToolStripMenuItem.Enabled = true;
                captureToolStripMenuItem.Enabled = false; // enable only after start
                stopWebcamToolStripMenuItem.Enabled = false;

                // Optionally clear the panel (will remove child window)
                panelWebcamHost.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping webcam: " + ex.Message);
            }
        }

        private void captureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDevice == null)
            {
                MessageBox.Show("Start the webcam first.");
                return;
            }

            try
            {
                // Ask the driver to copy current frame to clipboard
                currentDevice.Sendmessage(); // WM_CAP_EDIT_COPY

                // Wait briefly for the clipboard to receive the image.
                // We'll try a few times (non-blocking UI by using small sleeps + DoEvents).
                Image captured = null;
                int attempts = 0;
                const int maxAttempts = 10;
                while (attempts < maxAttempts)
                {
                    if (Clipboard.ContainsImage())
                    {
                        captured = Clipboard.GetImage();
                        break;
                    }
                    Thread.Sleep(50);
                    Application.DoEvents();
                    attempts++;
                }

                if (captured == null)
                {
                    MessageBox.Show("Capture failed — clipboard has no image. Try again.");
                    return;
                }

                // Put captured image into your processing pipeline:
                // dispose existing bitmaps safely (uses your DisposeBitmaps helper)
                DisposeBitmaps(); // (from your original code: disposes originalBitmap & processedBitmap)

                originalBitmap = new Bitmap(captured);   // set original image for processing
                processedBitmap = null;

                pictureBoxOriginal.Image = originalBitmap;
                pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxProcessed.Image = null;
                pictureBoxProcessed.SizeMode = PictureBoxSizeMode.Zoom;

                // enable processing buttons
                SetProcessingButtonsEnabled(true);

                // If you only allow Save after processing, ensure btnSaveImage.Enabled = false;
                saveImageToolStripMenuItem.Enabled = false;

                // Clear histogram (if you have it)
                if (chartHistogram != null)
                {
                    chartHistogram.Series["Red"].Points.Clear();
                    chartHistogram.Series["Green"].Points.Clear();
                    chartHistogram.Series["Blue"].Points.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Capture error: " + ex.Message);
            }
        }

        private void loadWebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Populate webcams once
            try
            {
                webcamDevices = DeviceManager.GetAllDevices(); // returns Device[]
            }
            catch
            {
                webcamDevices = new Device[0];
            }
            panelWebcamHost.Visible = true;
            comboBoxDevices.Visible = true;

            comboBoxDevices.Items.Clear();
            if (webcamDevices.Length == 0)
            {
                comboBoxDevices.Items.Add("No video devices found");
                comboBoxDevices.SelectedIndex = 0;
                startWebcamToolStripMenuItem.Enabled = false;
                captureToolStripMenuItem.Enabled = false;
                stopWebcamToolStripMenuItem.Enabled = false;
            }
            else
            {
                foreach (var d in webcamDevices)
                    comboBoxDevices.Items.Add(d.Name);

                comboBoxDevices.SelectedIndex = 0;
                startWebcamToolStripMenuItem.Enabled = true;
                captureToolStripMenuItem.Enabled = false; // enable only after start
                stopWebcamToolStripMenuItem.Enabled = false;
            }
        }

        private void smoothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.Smooth(originalBitmap, nWeight: 1);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;

            currentLiveFilter = "Smooth";
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.GaussianBlur(originalBitmap);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;

            currentLiveFilter = "GaussianBlur";
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.Sharpen(originalBitmap);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;

            currentLiveFilter = "Sharp";
        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.MeanRemoval(originalBitmap);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;
        }

        private void embossLaplascianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.Emboss(originalBitmap);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;

            currentLiveFilter = "EmbossLaplacian";
        }

        private void embossHorizontalVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.EmbossHorzVert(originalBitmap);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;
        }

        private void embossAllDirectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.EmbossAll(originalBitmap);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;
        }

        private void embossLossyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.EmbossLossy(originalBitmap);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;
        }

        private void embossHorizontalOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.EmbossHorizontal(originalBitmap);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;
        }

        private void embossVerticalOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.EmbossVertical(originalBitmap);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;
        }

        private void simpleBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.Blur(originalBitmap);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;
        }

        private void edgeEnhanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null) return;
            processedBitmap?.Dispose();
            processedBitmap = BitmapFilter.EdgeEnhance(originalBitmap);
            pictureBoxProcessed.Image = processedBitmap;
            saveImageToolStripMenuItem.Enabled = true;

            currentLiveFilter = "EdgeEnhance";
        }

        private void liveWebcamFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDevice == null) { MessageBox.Show("Start the webcam first."); return; }
            if (!liveMode)
            { 
                // enable timer loop
                liveTimer = new System.Windows.Forms.Timer(); liveTimer.Interval = 100; // 10 fps, adjust as needed
                liveTimer.Tick += LiveTimer_Tick; 
                liveTimer.Start(); 

                liveMode = true; 
                currentLiveFilter = "None"; // default
            } else { 
                // stop live mode
                liveTimer.Stop(); 
                liveMode = false; 
            }
        }

        // Timer event: grabs frame from webcam and processes it
        private void LiveTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                currentDevice.Sendmessage(); // capture to clipboard
                if (!Clipboard.ContainsImage())
                {
                    StopLiveMode();
                    return;
                }

                using (Image frame = Clipboard.GetImage())
                {
                    if (frame == null)
                    {
                        StopLiveMode();
                        return;
                    }

                    Bitmap liveOriginal = new Bitmap(frame);
                    pictureBoxOriginal.Image = liveOriginal;
                    pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;

                    Bitmap liveProcessed = null;

                    switch (currentLiveFilter)
                    {
                        case "Grayscale": liveProcessed = ApplyGrayscale(liveOriginal); break;
                        case "Invert": liveProcessed = ApplyInvert(liveOriginal); break;
                        case "Sepia": liveProcessed = ApplySepia(liveOriginal); break;
                        case "Blur": liveProcessed = BitmapFilter.Blur(liveOriginal); break;
                        case "Sharp": liveProcessed = BitmapFilter.Sharpen(liveOriginal); break;
                        case "GaussianBlur": liveProcessed = BitmapFilter.GaussianBlur(liveOriginal); break;
                        case "EdgeEnhance": liveProcessed = BitmapFilter.EdgeEnhance(liveOriginal); break;
                        case "EmbossLaplacian": liveProcessed = BitmapFilter.Emboss(liveOriginal); break;
                        default: liveProcessed = (Bitmap)liveOriginal.Clone(); break;
                    }

                    if (liveProcessed != null)
                    {
                        pictureBoxProcessed.Image = liveProcessed;
                        pictureBoxProcessed.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        StopLiveMode();
                    }
                }
            }
            catch
            {
                StopLiveMode(); // ensure it doesn't throw again
            }
        }


        private void StopLiveMode()
        {
            // Stop timer only if it exists
            if (liveTimer != null && liveTimer.Enabled)
            {
                liveTimer.Stop();
            }

            // Reset filter
            currentLiveFilter = null;

            // Dispose safely
            if (pictureBoxOriginal.Image != null)
            {
                pictureBoxOriginal.Image.Dispose();
                pictureBoxOriginal.Image = null;
            }

            if (pictureBoxProcessed.Image != null)
            {
                pictureBoxProcessed.Image.Dispose();
                pictureBoxProcessed.Image = null;
            }

            // Refresh UI
            pictureBoxOriginal.Refresh();
            pictureBoxProcessed.Refresh();

            // If device exists, release it
            if (currentDevice != null)
            {
                try
                {
                    currentDevice.Stop(); // or Dispose() depending on your driver
                    currentDevice = null;
                }
                catch
                {
                    // ignore cleanup error
                }
            }

            // Re-enable normal file operations
            SetProcessingButtonsEnabled(true);
        }



        private Bitmap ApplyGrayscale(Bitmap src)
           {
               Bitmap result = new Bitmap(src.Width, src.Height);

               for (int y = 0; y < src.Height; y++)
               {
                   for (int x = 0; x < src.Width; x++)
                    {
                        Color c = src.GetPixel(x, y);
                        int gray = (c.R + c.G + c.B) / 3;
                        result.SetPixel(x, y, Color.FromArgb(c.A, gray, gray, gray));
                    }
                }

                return result;
            }
        private Bitmap ApplyInvert(Bitmap src)
        {
            Bitmap result = new Bitmap(src.Width, src.Height);

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color c = src.GetPixel(x, y);
                    result.SetPixel(x, y,
                        Color.FromArgb(c.A, 255 - c.R, 255 - c.G, 255 - c.B));
                }
            }

            return result;
        }

        private Bitmap ApplySepia(Bitmap src)
        {
            Bitmap result = new Bitmap(src.Width, src.Height);

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color c = src.GetPixel(x, y);

                    int tr = (int)(0.393 * c.R + 0.769 * c.G + 0.189 * c.B);
                    int tg = (int)(0.349 * c.R + 0.686 * c.G + 0.168 * c.B);
                    int tb = (int)(0.272 * c.R + 0.534 * c.G + 0.131 * c.B);

                    tr = Math.Min(255, tr);
                    tg = Math.Min(255, tg);
                    tb = Math.Min(255, tb);

                    result.SetPixel(x, y, Color.FromArgb(c.A, tr, tg, tb));
                }
            }

            return result;
        }



        private void SetProcessingButtonsEnabled(bool enabled)
        {
            copyToolStripMenuItem.Enabled = enabled;
            grayscaleToolStripMenuItem.Enabled = enabled;
            invertToolStripMenuItem.Enabled = enabled;
            sepiaToolStripMenuItem.Enabled = enabled;
            histogramToolStripMenuItem.Enabled = enabled;

            // Save is only enabled if processedBitmap exists
            saveImageToolStripMenuItem.Enabled = (processedBitmap != null);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshApplication();
        }

        private Bitmap ResizeImage(Bitmap img, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.DrawImage(img, 0, 0, width, height);
            }
            return resized;
        }

        private void RefreshApplication()
        {
            try
            {
                // Stop live mode safely
                if (liveTimer != null && liveTimer.Enabled)
                    liveTimer.Stop();

                currentLiveFilter = null;

                // Dispose bitmaps
                DisposeBitmaps();

                // Clear picture boxes
                if (pictureBoxOriginal.Image != null)
                {
                    pictureBoxOriginal.Image.Dispose();
                    pictureBoxOriginal.Image = null;
                }
                if (pictureBoxProcessed.Image != null)
                {
                    pictureBoxProcessed.Image.Dispose();
                    pictureBoxProcessed.Image = null;
                }

                pictureBoxOriginal.Refresh();
                pictureBoxProcessed.Refresh();

                // Clear histogram if you use one
                if (chartHistogram != null)
                {
                    chartHistogram.Series["Red"].Points.Clear();
                    chartHistogram.Series["Green"].Points.Clear();
                    chartHistogram.Series["Blue"].Points.Clear();
                }

                // Reset device
                if (currentDevice != null)
                {
                    try
                    {
                        currentDevice.Stop();
                        currentDevice = null;
                    }
                    catch { }
                }

                // Reset UI state
                SetProcessingButtonsEnabled(false);
                saveImageToolStripMenuItem.Enabled = false;

                // Reset form title (optional)
                this.Text = "Image Processing App";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing application: " + ex.Message);
            }
        }




    }
}

