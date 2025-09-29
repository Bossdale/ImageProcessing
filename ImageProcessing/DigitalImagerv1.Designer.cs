namespace ImageProcessing
{
    partial class DigitalImagerv1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBoxProcessed = new System.Windows.Forms.PictureBox();
            this.chartHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convultionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanRemovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossLaplascianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossHorizontalVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossAllDirectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossLossyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossHorizontalOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossVerticalOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeEnhanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webcamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadWebCamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWebcamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopWebcamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liveWebcamFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxSubtraction = new System.Windows.Forms.PictureBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.panelWebcamHost = new System.Windows.Forms.Panel();
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogram)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSubtraction)).BeginInit();
            this.panelWebcamHost.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(69, 52);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxOriginal.TabIndex = 1;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxProcessed
            // 
            this.pictureBoxProcessed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProcessed.Location = new System.Drawing.Point(415, 52);
            this.pictureBoxProcessed.Name = "pictureBoxProcessed";
            this.pictureBoxProcessed.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxProcessed.TabIndex = 2;
            this.pictureBoxProcessed.TabStop = false;
            // 
            // chartHistogram
            // 
            chartArea1.Name = "ChartArea1";
            this.chartHistogram.ChartAreas.Add(chartArea1);
            this.chartHistogram.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.Name = "Legend1";
            this.chartHistogram.Legends.Add(legend1);
            this.chartHistogram.Location = new System.Drawing.Point(0, 570);
            this.chartHistogram.Name = "chartHistogram";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartHistogram.Series.Add(series1);
            this.chartHistogram.Size = new System.Drawing.Size(1084, 111);
            this.chartHistogram.TabIndex = 3;
            this.chartHistogram.Text = "chart1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processingToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.subtractionToolStripMenuItem,
            this.webcamToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // processingToolStripMenuItem
            // 
            this.processingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.sepiaToolStripMenuItem,
            this.convultionToolStripMenuItem});
            this.processingToolStripMenuItem.Name = "processingToolStripMenuItem";
            this.processingToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.processingToolStripMenuItem.Text = "Processing";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sepiaToolStripMenuItem.Text = "Sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);
            // 
            // convultionToolStripMenuItem
            // 
            this.convultionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smoothToolStripMenuItem,
            this.gaussianBlurToolStripMenuItem,
            this.sharpenToolStripMenuItem,
            this.meanRemovalToolStripMenuItem,
            this.embossToolStripMenuItem,
            this.simpleBlurToolStripMenuItem,
            this.edgeEnhanceToolStripMenuItem});
            this.convultionToolStripMenuItem.Name = "convultionToolStripMenuItem";
            this.convultionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.convultionToolStripMenuItem.Text = "Convolution";
            // 
            // smoothToolStripMenuItem
            // 
            this.smoothToolStripMenuItem.Name = "smoothToolStripMenuItem";
            this.smoothToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.smoothToolStripMenuItem.Text = "Smooth";
            this.smoothToolStripMenuItem.Click += new System.EventHandler(this.smoothToolStripMenuItem_Click);
            // 
            // gaussianBlurToolStripMenuItem
            // 
            this.gaussianBlurToolStripMenuItem.Name = "gaussianBlurToolStripMenuItem";
            this.gaussianBlurToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.gaussianBlurToolStripMenuItem.Text = "Gaussian Blur";
            this.gaussianBlurToolStripMenuItem.Click += new System.EventHandler(this.gaussianBlurToolStripMenuItem_Click);
            // 
            // sharpenToolStripMenuItem
            // 
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.sharpenToolStripMenuItem.Text = "Sharpen";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
            // 
            // meanRemovalToolStripMenuItem
            // 
            this.meanRemovalToolStripMenuItem.Name = "meanRemovalToolStripMenuItem";
            this.meanRemovalToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.meanRemovalToolStripMenuItem.Text = "Mean Removal";
            this.meanRemovalToolStripMenuItem.Click += new System.EventHandler(this.meanRemovalToolStripMenuItem_Click);
            // 
            // embossToolStripMenuItem
            // 
            this.embossToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.embossLaplascianToolStripMenuItem,
            this.embossHorizontalVerticalToolStripMenuItem,
            this.embossAllDirectionToolStripMenuItem,
            this.embossLossyToolStripMenuItem,
            this.embossHorizontalOnlyToolStripMenuItem,
            this.embossVerticalOnlyToolStripMenuItem});
            this.embossToolStripMenuItem.Name = "embossToolStripMenuItem";
            this.embossToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.embossToolStripMenuItem.Text = "Emboss";
            // 
            // embossLaplascianToolStripMenuItem
            // 
            this.embossLaplascianToolStripMenuItem.Name = "embossLaplascianToolStripMenuItem";
            this.embossLaplascianToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.embossLaplascianToolStripMenuItem.Text = "Emboss Laplascian";
            this.embossLaplascianToolStripMenuItem.Click += new System.EventHandler(this.embossLaplascianToolStripMenuItem_Click);
            // 
            // embossHorizontalVerticalToolStripMenuItem
            // 
            this.embossHorizontalVerticalToolStripMenuItem.Name = "embossHorizontalVerticalToolStripMenuItem";
            this.embossHorizontalVerticalToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.embossHorizontalVerticalToolStripMenuItem.Text = "Emboss Horizontal/Vertical";
            this.embossHorizontalVerticalToolStripMenuItem.Click += new System.EventHandler(this.embossHorizontalVerticalToolStripMenuItem_Click);
            // 
            // embossAllDirectionToolStripMenuItem
            // 
            this.embossAllDirectionToolStripMenuItem.Name = "embossAllDirectionToolStripMenuItem";
            this.embossAllDirectionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.embossAllDirectionToolStripMenuItem.Text = "Emboss All Direction";
            this.embossAllDirectionToolStripMenuItem.Click += new System.EventHandler(this.embossAllDirectionToolStripMenuItem_Click);
            // 
            // embossLossyToolStripMenuItem
            // 
            this.embossLossyToolStripMenuItem.Name = "embossLossyToolStripMenuItem";
            this.embossLossyToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.embossLossyToolStripMenuItem.Text = "Emboss Lossy";
            this.embossLossyToolStripMenuItem.Click += new System.EventHandler(this.embossLossyToolStripMenuItem_Click);
            // 
            // embossHorizontalOnlyToolStripMenuItem
            // 
            this.embossHorizontalOnlyToolStripMenuItem.Name = "embossHorizontalOnlyToolStripMenuItem";
            this.embossHorizontalOnlyToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.embossHorizontalOnlyToolStripMenuItem.Text = "Emboss Horizontal Only";
            this.embossHorizontalOnlyToolStripMenuItem.Click += new System.EventHandler(this.embossHorizontalOnlyToolStripMenuItem_Click);
            // 
            // embossVerticalOnlyToolStripMenuItem
            // 
            this.embossVerticalOnlyToolStripMenuItem.Name = "embossVerticalOnlyToolStripMenuItem";
            this.embossVerticalOnlyToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.embossVerticalOnlyToolStripMenuItem.Text = "Emboss Vertical Only";
            this.embossVerticalOnlyToolStripMenuItem.Click += new System.EventHandler(this.embossVerticalOnlyToolStripMenuItem_Click);
            // 
            // simpleBlurToolStripMenuItem
            // 
            this.simpleBlurToolStripMenuItem.Name = "simpleBlurToolStripMenuItem";
            this.simpleBlurToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.simpleBlurToolStripMenuItem.Text = "Simple Blur";
            this.simpleBlurToolStripMenuItem.Click += new System.EventHandler(this.simpleBlurToolStripMenuItem_Click);
            // 
            // edgeEnhanceToolStripMenuItem
            // 
            this.edgeEnhanceToolStripMenuItem.Name = "edgeEnhanceToolStripMenuItem";
            this.edgeEnhanceToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.edgeEnhanceToolStripMenuItem.Text = "Edge Enhance";
            this.edgeEnhanceToolStripMenuItem.Click += new System.EventHandler(this.edgeEnhanceToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // subtractionToolStripMenuItem
            // 
            this.subtractionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageAToolStripMenuItem,
            this.loadImageBToolStripMenuItem,
            this.subtractToolStripMenuItem});
            this.subtractionToolStripMenuItem.Name = "subtractionToolStripMenuItem";
            this.subtractionToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.subtractionToolStripMenuItem.Text = "Subtraction";
            // 
            // loadImageAToolStripMenuItem
            // 
            this.loadImageAToolStripMenuItem.Name = "loadImageAToolStripMenuItem";
            this.loadImageAToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.loadImageAToolStripMenuItem.Text = "Load Image Background";
            this.loadImageAToolStripMenuItem.Click += new System.EventHandler(this.loadImageAToolStripMenuItem_Click);
            // 
            // loadImageBToolStripMenuItem
            // 
            this.loadImageBToolStripMenuItem.Name = "loadImageBToolStripMenuItem";
            this.loadImageBToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.loadImageBToolStripMenuItem.Text = "Load Image ";
            this.loadImageBToolStripMenuItem.Click += new System.EventHandler(this.loadImageBToolStripMenuItem_Click);
            // 
            // subtractToolStripMenuItem
            // 
            this.subtractToolStripMenuItem.Name = "subtractToolStripMenuItem";
            this.subtractToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.subtractToolStripMenuItem.Text = "Subtract";
            this.subtractToolStripMenuItem.Click += new System.EventHandler(this.subtractToolStripMenuItem_Click);
            // 
            // webcamToolStripMenuItem
            // 
            this.webcamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadWebCamToolStripMenuItem,
            this.startWebcamToolStripMenuItem,
            this.stopWebcamToolStripMenuItem,
            this.captureToolStripMenuItem,
            this.liveWebcamFiltersToolStripMenuItem});
            this.webcamToolStripMenuItem.Name = "webcamToolStripMenuItem";
            this.webcamToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.webcamToolStripMenuItem.Text = "Webcam";
            // 
            // loadWebCamToolStripMenuItem
            // 
            this.loadWebCamToolStripMenuItem.Name = "loadWebCamToolStripMenuItem";
            this.loadWebCamToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.loadWebCamToolStripMenuItem.Text = "Load Webcam";
            this.loadWebCamToolStripMenuItem.Click += new System.EventHandler(this.loadWebcamToolStripMenuItem_Click);
            // 
            // startWebcamToolStripMenuItem
            // 
            this.startWebcamToolStripMenuItem.Name = "startWebcamToolStripMenuItem";
            this.startWebcamToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.startWebcamToolStripMenuItem.Text = "Start Webcam";
            this.startWebcamToolStripMenuItem.Click += new System.EventHandler(this.startWebcamToolStripMenuItem_Click);
            // 
            // stopWebcamToolStripMenuItem
            // 
            this.stopWebcamToolStripMenuItem.Name = "stopWebcamToolStripMenuItem";
            this.stopWebcamToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.stopWebcamToolStripMenuItem.Text = "Stop Webcam";
            this.stopWebcamToolStripMenuItem.Click += new System.EventHandler(this.stopWebcamToolStripMenuItem_Click);
            // 
            // captureToolStripMenuItem
            // 
            this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            this.captureToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.captureToolStripMenuItem.Text = "Capture Webcam";
            this.captureToolStripMenuItem.Click += new System.EventHandler(this.captureToolStripMenuItem_Click);
            // 
            // liveWebcamFiltersToolStripMenuItem
            // 
            this.liveWebcamFiltersToolStripMenuItem.Name = "liveWebcamFiltersToolStripMenuItem";
            this.liveWebcamFiltersToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.liveWebcamFiltersToolStripMenuItem.Text = "Live Webcam Filters";
            this.liveWebcamFiltersToolStripMenuItem.Click += new System.EventHandler(this.liveWebcamFiltersToolStripMenuItem_Click);
            // 
            // pictureBoxSubtraction
            // 
            this.pictureBoxSubtraction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSubtraction.Location = new System.Drawing.Point(746, 52);
            this.pictureBoxSubtraction.Name = "pictureBoxSubtraction";
            this.pictureBoxSubtraction.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxSubtraction.TabIndex = 5;
            this.pictureBoxSubtraction.TabStop = false;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // panelWebcamHost
            // 
            this.panelWebcamHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWebcamHost.Controls.Add(this.comboBoxDevices);
            this.panelWebcamHost.Location = new System.Drawing.Point(415, 365);
            this.panelWebcamHost.Name = "panelWebcamHost";
            this.panelWebcamHost.Size = new System.Drawing.Size(250, 200);
            this.panelWebcamHost.TabIndex = 6;
            this.panelWebcamHost.Visible = false;
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(0, 0);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDevices.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Original Image/ Image B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(410, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Processed Image/ Image A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(781, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Subtraction Image";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // DigitalImagerv1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1084, 681);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelWebcamHost);
            this.Controls.Add(this.pictureBoxSubtraction);
            this.Controls.Add(this.chartHistogram);
            this.Controls.Add(this.pictureBoxProcessed);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DigitalImagerv1";
            this.Text = "Digital Imager v1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogram)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSubtraction)).EndInit();
            this.panelWebcamHost.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxProcessed;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHistogram;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxSubtraction;
        private System.Windows.Forms.ToolStripMenuItem subtractionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtractToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.ToolStripMenuItem loadImageAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webcamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadWebCamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWebcamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopWebcamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
        private System.Windows.Forms.Panel panelWebcamHost;
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem convultionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meanRemovalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossLaplascianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossHorizontalVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossAllDirectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossLossyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossHorizontalOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossVerticalOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeEnhanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liveWebcamFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}

