namespace profiler
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PlatformCombox = new System.Windows.Forms.ComboBox();
            this.DeviceCombox = new System.Windows.Forms.ComboBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonSelectSourceFile = new System.Windows.Forms.Button();
            this.labelSelectPlatform = new System.Windows.Forms.Label();
            this.labelSelectDevice = new System.Windows.Forms.Label();
            this.buttonSelectSourceDir = new System.Windows.Forms.Button();
            this.TextBoxImageDimensionX = new System.Windows.Forms.TextBox();
            this.labelImagedimension = new System.Windows.Forms.Label();
            this.labelDimX = new System.Windows.Forms.Label();
            this.labelDimY = new System.Windows.Forms.Label();
            this.labelTransformationType = new System.Windows.Forms.Label();
            this.comboBoxTransform = new System.Windows.Forms.ComboBox();
            this.TextBoxImageDimensionY = new System.Windows.Forms.TextBox();
            this.TextBoxImageDimensionZ = new System.Windows.Forms.TextBox();
            this.labelDimZ = new System.Windows.Forms.Label();
            this.buttonSaveOutputFile = new System.Windows.Forms.Button();
            this.buttonSaveOutputDir = new System.Windows.Forms.Button();
            this.groupBoxSingleFile = new System.Windows.Forms.GroupBox();
            this.textBoxSelectSourceFile = new System.Windows.Forms.TextBox();
            this.labelSaveOutputFile = new System.Windows.Forms.Label();
            this.groupBoxMultipleFiles = new System.Windows.Forms.GroupBox();
            this.labelSaveOutputDir = new System.Windows.Forms.Label();
            this.labelSelectSourceDir = new System.Windows.Forms.Label();
            this.groupBoxRadioButtons = new System.Windows.Forms.GroupBox();
            this.radioButtonMultipleFiles = new System.Windows.Forms.RadioButton();
            this.radioButtonSingleFile = new System.Windows.Forms.RadioButton();
            this.labelPixelSize = new System.Windows.Forms.Label();
            this.textBoxPixelSize = new System.Windows.Forms.TextBox();
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.labelShiftZ = new System.Windows.Forms.Label();
            this.textBoxShiftX = new System.Windows.Forms.TextBox();
            this.textBoxShiftY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelShift = new System.Windows.Forms.Label();
            this.buttonListDeviceInfo = new System.Windows.Forms.Button();
            this.textBoxShiftZ = new System.Windows.Forms.TextBox();
            this.groupBoxSingleFile.SuspendLayout();
            this.groupBoxMultipleFiles.SuspendLayout();
            this.groupBoxRadioButtons.SuspendLayout();
            this.groupBoxParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlatformCombox
            // 
            this.PlatformCombox.FormattingEnabled = true;
            this.PlatformCombox.Location = new System.Drawing.Point(18, 63);
            this.PlatformCombox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PlatformCombox.Name = "PlatformCombox";
            this.PlatformCombox.Size = new System.Drawing.Size(482, 28);
            this.PlatformCombox.TabIndex = 0;
            this.PlatformCombox.SelectedIndexChanged += new System.EventHandler(this.PlatformCombox_SelectedIndexChanged);
            // 
            // DeviceCombox
            // 
            this.DeviceCombox.FormattingEnabled = true;
            this.DeviceCombox.Location = new System.Drawing.Point(18, 152);
            this.DeviceCombox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeviceCombox.Name = "DeviceCombox";
            this.DeviceCombox.Size = new System.Drawing.Size(482, 28);
            this.DeviceCombox.TabIndex = 1;
            this.DeviceCombox.SelectedIndexChanged += new System.EventHandler(this.DeviceCombox_SelectedIndexChanged);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(447, 783);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(150, 69);
            this.buttonCalculate.TabIndex = 2;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonSelectSourceFile
            // 
            this.buttonSelectSourceFile.Location = new System.Drawing.Point(9, 29);
            this.buttonSelectSourceFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSelectSourceFile.Name = "buttonSelectSourceFile";
            this.buttonSelectSourceFile.Size = new System.Drawing.Size(147, 35);
            this.buttonSelectSourceFile.TabIndex = 3;
            this.buttonSelectSourceFile.Text = "Select source file";
            this.buttonSelectSourceFile.UseVisualStyleBackColor = true;
            this.buttonSelectSourceFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // labelSelectPlatform
            // 
            this.labelSelectPlatform.AutoSize = true;
            this.labelSelectPlatform.Location = new System.Drawing.Point(14, 31);
            this.labelSelectPlatform.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectPlatform.Name = "labelSelectPlatform";
            this.labelSelectPlatform.Size = new System.Drawing.Size(117, 20);
            this.labelSelectPlatform.TabIndex = 5;
            this.labelSelectPlatform.Text = "Select Platform";
            // 
            // labelSelectDevice
            // 
            this.labelSelectDevice.AutoSize = true;
            this.labelSelectDevice.Location = new System.Drawing.Point(14, 115);
            this.labelSelectDevice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectDevice.Name = "labelSelectDevice";
            this.labelSelectDevice.Size = new System.Drawing.Size(106, 20);
            this.labelSelectDevice.TabIndex = 6;
            this.labelSelectDevice.Text = "Select Device";
            // 
            // buttonSelectSourceDir
            // 
            this.buttonSelectSourceDir.Location = new System.Drawing.Point(9, 29);
            this.buttonSelectSourceDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSelectSourceDir.Name = "buttonSelectSourceDir";
            this.buttonSelectSourceDir.Size = new System.Drawing.Size(147, 35);
            this.buttonSelectSourceDir.TabIndex = 7;
            this.buttonSelectSourceDir.Text = "Select source dir";
            this.buttonSelectSourceDir.UseVisualStyleBackColor = true;
            this.buttonSelectSourceDir.Click += new System.EventHandler(this.buttonSelectDir_Click);
            // 
            // TextBoxImageDimensionX
            // 
            this.TextBoxImageDimensionX.Location = new System.Drawing.Point(39, 58);
            this.TextBoxImageDimensionX.Name = "TextBoxImageDimensionX";
            this.TextBoxImageDimensionX.Size = new System.Drawing.Size(103, 26);
            this.TextBoxImageDimensionX.TabIndex = 8;
            this.TextBoxImageDimensionX.Text = "128";
            // 
            // labelImagedimension
            // 
            this.labelImagedimension.AutoSize = true;
            this.labelImagedimension.Location = new System.Drawing.Point(8, 31);
            this.labelImagedimension.Name = "labelImagedimension";
            this.labelImagedimension.Size = new System.Drawing.Size(183, 20);
            this.labelImagedimension.TabIndex = 10;
            this.labelImagedimension.Text = "Image dimension (pixels)";
            // 
            // labelDimX
            // 
            this.labelDimX.AutoSize = true;
            this.labelDimX.Location = new System.Drawing.Point(16, 62);
            this.labelDimX.Name = "labelDimX";
            this.labelDimX.Size = new System.Drawing.Size(16, 20);
            this.labelDimX.TabIndex = 11;
            this.labelDimX.Text = "x";
            // 
            // labelDimY
            // 
            this.labelDimY.AutoSize = true;
            this.labelDimY.Location = new System.Drawing.Point(16, 94);
            this.labelDimY.Name = "labelDimY";
            this.labelDimY.Size = new System.Drawing.Size(16, 20);
            this.labelDimY.TabIndex = 12;
            this.labelDimY.Text = "y";
            // 
            // labelTransformationType
            // 
            this.labelTransformationType.AutoSize = true;
            this.labelTransformationType.Location = new System.Drawing.Point(405, 31);
            this.labelTransformationType.Name = "labelTransformationType";
            this.labelTransformationType.Size = new System.Drawing.Size(184, 20);
            this.labelTransformationType.TabIndex = 13;
            this.labelTransformationType.Text = "TransformationType type";
            // 
            // comboBoxTransform
            // 
            this.comboBoxTransform.FormattingEnabled = true;
            this.comboBoxTransform.Items.AddRange(new object[] {
            "transformation A = 1",
            "transformation B = 2",
            "transformation C = 3",
            "transformation D = 4"});
            this.comboBoxTransform.Location = new System.Drawing.Point(410, 58);
            this.comboBoxTransform.Name = "comboBoxTransform";
            this.comboBoxTransform.Size = new System.Drawing.Size(148, 28);
            this.comboBoxTransform.TabIndex = 14;
            this.comboBoxTransform.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransform_SelectedIndexChanged);
            // 
            // TextBoxImageDimensionY
            // 
            this.TextBoxImageDimensionY.Location = new System.Drawing.Point(39, 91);
            this.TextBoxImageDimensionY.Name = "TextBoxImageDimensionY";
            this.TextBoxImageDimensionY.Size = new System.Drawing.Size(103, 26);
            this.TextBoxImageDimensionY.TabIndex = 15;
            this.TextBoxImageDimensionY.Text = "128";
            // 
            // TextBoxImageDimensionZ
            // 
            this.TextBoxImageDimensionZ.Location = new System.Drawing.Point(39, 123);
            this.TextBoxImageDimensionZ.Name = "TextBoxImageDimensionZ";
            this.TextBoxImageDimensionZ.Size = new System.Drawing.Size(103, 26);
            this.TextBoxImageDimensionZ.TabIndex = 16;
            this.TextBoxImageDimensionZ.Text = "1";
            this.TextBoxImageDimensionZ.Visible = false;
            // 
            // labelDimZ
            // 
            this.labelDimZ.AutoSize = true;
            this.labelDimZ.Location = new System.Drawing.Point(16, 131);
            this.labelDimZ.Name = "labelDimZ";
            this.labelDimZ.Size = new System.Drawing.Size(17, 20);
            this.labelDimZ.TabIndex = 17;
            this.labelDimZ.Text = "z";
            this.labelDimZ.Visible = false;
            // 
            // buttonSaveOutputFile
            // 
            this.buttonSaveOutputFile.Location = new System.Drawing.Point(9, 74);
            this.buttonSaveOutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSaveOutputFile.Name = "buttonSaveOutputFile";
            this.buttonSaveOutputFile.Size = new System.Drawing.Size(147, 35);
            this.buttonSaveOutputFile.TabIndex = 19;
            this.buttonSaveOutputFile.Text = "Save output file";
            this.buttonSaveOutputFile.UseVisualStyleBackColor = true;
            this.buttonSaveOutputFile.Click += new System.EventHandler(this.buttonSaveOutputFile_Click);
            // 
            // buttonSaveOutputDir
            // 
            this.buttonSaveOutputDir.Location = new System.Drawing.Point(9, 74);
            this.buttonSaveOutputDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSaveOutputDir.Name = "buttonSaveOutputDir";
            this.buttonSaveOutputDir.Size = new System.Drawing.Size(147, 35);
            this.buttonSaveOutputDir.TabIndex = 20;
            this.buttonSaveOutputDir.Text = "Save output dir";
            this.buttonSaveOutputDir.UseVisualStyleBackColor = true;
            this.buttonSaveOutputDir.Click += new System.EventHandler(this.buttonSaveOutputDir_Click);
            // 
            // groupBoxSingleFile
            // 
            this.groupBoxSingleFile.Controls.Add(this.textBoxSelectSourceFile);
            this.groupBoxSingleFile.Controls.Add(this.labelSaveOutputFile);
            this.groupBoxSingleFile.Controls.Add(this.buttonSaveOutputFile);
            this.groupBoxSingleFile.Controls.Add(this.buttonSelectSourceFile);
            this.groupBoxSingleFile.Location = new System.Drawing.Point(60, 457);
            this.groupBoxSingleFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSingleFile.Name = "groupBoxSingleFile";
            this.groupBoxSingleFile.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSingleFile.Size = new System.Drawing.Size(537, 154);
            this.groupBoxSingleFile.TabIndex = 21;
            this.groupBoxSingleFile.TabStop = false;
            this.groupBoxSingleFile.Text = "Single file";
            // 
            // textBoxSelectSourceFile
            // 
            this.textBoxSelectSourceFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.textBoxSelectSourceFile.Location = new System.Drawing.Point(165, 32);
            this.textBoxSelectSourceFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxSelectSourceFile.MaximumSize = new System.Drawing.Size(355, 23);
            this.textBoxSelectSourceFile.Name = "textBoxSelectSourceFile";
            this.textBoxSelectSourceFile.ReadOnly = true;
            this.textBoxSelectSourceFile.Size = new System.Drawing.Size(350, 26);
            this.textBoxSelectSourceFile.TabIndex = 20;
            this.textBoxSelectSourceFile.Text = "...";
            // 
            // labelSaveOutputFile
            // 
            this.labelSaveOutputFile.Location = new System.Drawing.Point(165, 74);
            this.labelSaveOutputFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSaveOutputFile.MaximumSize = new System.Drawing.Size(357, 35);
            this.labelSaveOutputFile.Name = "labelSaveOutputFile";
            this.labelSaveOutputFile.Size = new System.Drawing.Size(357, 35);
            this.labelSaveOutputFile.TabIndex = 4;
            this.labelSaveOutputFile.Text = "...";
            this.labelSaveOutputFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxMultipleFiles
            // 
            this.groupBoxMultipleFiles.Controls.Add(this.labelSaveOutputDir);
            this.groupBoxMultipleFiles.Controls.Add(this.labelSelectSourceDir);
            this.groupBoxMultipleFiles.Controls.Add(this.buttonSelectSourceDir);
            this.groupBoxMultipleFiles.Controls.Add(this.buttonSaveOutputDir);
            this.groupBoxMultipleFiles.Enabled = false;
            this.groupBoxMultipleFiles.Location = new System.Drawing.Point(60, 620);
            this.groupBoxMultipleFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxMultipleFiles.Name = "groupBoxMultipleFiles";
            this.groupBoxMultipleFiles.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxMultipleFiles.Size = new System.Drawing.Size(537, 154);
            this.groupBoxMultipleFiles.TabIndex = 22;
            this.groupBoxMultipleFiles.TabStop = false;
            this.groupBoxMultipleFiles.Text = "Multiple files";
            // 
            // labelSaveOutputDir
            // 
            this.labelSaveOutputDir.AutoSize = true;
            this.labelSaveOutputDir.Location = new System.Drawing.Point(166, 88);
            this.labelSaveOutputDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSaveOutputDir.Name = "labelSaveOutputDir";
            this.labelSaveOutputDir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelSaveOutputDir.Size = new System.Drawing.Size(21, 20);
            this.labelSaveOutputDir.TabIndex = 22;
            this.labelSaveOutputDir.Text = "...";
            // 
            // labelSelectSourceDir
            // 
            this.labelSelectSourceDir.AutoSize = true;
            this.labelSelectSourceDir.Location = new System.Drawing.Point(166, 43);
            this.labelSelectSourceDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectSourceDir.Name = "labelSelectSourceDir";
            this.labelSelectSourceDir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelSelectSourceDir.Size = new System.Drawing.Size(21, 20);
            this.labelSelectSourceDir.TabIndex = 21;
            this.labelSelectSourceDir.Text = "...";
            // 
            // groupBoxRadioButtons
            // 
            this.groupBoxRadioButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBoxRadioButtons.Controls.Add(this.radioButtonMultipleFiles);
            this.groupBoxRadioButtons.Controls.Add(this.radioButtonSingleFile);
            this.groupBoxRadioButtons.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxRadioButtons.Location = new System.Drawing.Point(18, 457);
            this.groupBoxRadioButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxRadioButtons.Name = "groupBoxRadioButtons";
            this.groupBoxRadioButtons.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxRadioButtons.Size = new System.Drawing.Size(33, 317);
            this.groupBoxRadioButtons.TabIndex = 23;
            this.groupBoxRadioButtons.TabStop = false;
            // 
            // radioButtonMultipleFiles
            // 
            this.radioButtonMultipleFiles.AutoSize = true;
            this.radioButtonMultipleFiles.Location = new System.Drawing.Point(6, 238);
            this.radioButtonMultipleFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonMultipleFiles.Name = "radioButtonMultipleFiles";
            this.radioButtonMultipleFiles.Size = new System.Drawing.Size(21, 20);
            this.radioButtonMultipleFiles.TabIndex = 1;
            this.radioButtonMultipleFiles.UseVisualStyleBackColor = true;
            this.radioButtonMultipleFiles.CheckedChanged += new System.EventHandler(this.radioButtonMultipleFiles_CheckedChanged);
            // 
            // radioButtonSingleFile
            // 
            this.radioButtonSingleFile.AutoSize = true;
            this.radioButtonSingleFile.Checked = true;
            this.radioButtonSingleFile.Location = new System.Drawing.Point(6, 74);
            this.radioButtonSingleFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonSingleFile.Name = "radioButtonSingleFile";
            this.radioButtonSingleFile.Size = new System.Drawing.Size(21, 20);
            this.radioButtonSingleFile.TabIndex = 0;
            this.radioButtonSingleFile.TabStop = true;
            this.radioButtonSingleFile.UseVisualStyleBackColor = true;
            this.radioButtonSingleFile.CheckedChanged += new System.EventHandler(this.radioButtonSingleFile_CheckedChanged);
            // 
            // labelPixelSize
            // 
            this.labelPixelSize.AutoSize = true;
            this.labelPixelSize.Location = new System.Drawing.Point(248, 31);
            this.labelPixelSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPixelSize.Name = "labelPixelSize";
            this.labelPixelSize.Size = new System.Drawing.Size(109, 20);
            this.labelPixelSize.TabIndex = 24;
            this.labelPixelSize.Text = "Pixel size (nm)";
            // 
            // textBoxPixelSize
            // 
            this.textBoxPixelSize.Location = new System.Drawing.Point(272, 58);
            this.textBoxPixelSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPixelSize.Name = "textBoxPixelSize";
            this.textBoxPixelSize.Size = new System.Drawing.Size(103, 26);
            this.textBoxPixelSize.TabIndex = 25;
            this.textBoxPixelSize.Text = "64";
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.labelShiftZ);
            this.groupBoxParameters.Controls.Add(this.textBoxShiftX);
            this.groupBoxParameters.Controls.Add(this.textBoxShiftY);
            this.groupBoxParameters.Controls.Add(this.label3);
            this.groupBoxParameters.Controls.Add(this.label4);
            this.groupBoxParameters.Controls.Add(this.labelShift);
            this.groupBoxParameters.Controls.Add(this.labelImagedimension);
            this.groupBoxParameters.Controls.Add(this.textBoxPixelSize);
            this.groupBoxParameters.Controls.Add(this.TextBoxImageDimensionX);
            this.groupBoxParameters.Controls.Add(this.labelPixelSize);
            this.groupBoxParameters.Controls.Add(this.labelDimX);
            this.groupBoxParameters.Controls.Add(this.labelDimY);
            this.groupBoxParameters.Controls.Add(this.labelTransformationType);
            this.groupBoxParameters.Controls.Add(this.comboBoxTransform);
            this.groupBoxParameters.Controls.Add(this.labelDimZ);
            this.groupBoxParameters.Controls.Add(this.TextBoxImageDimensionY);
            this.groupBoxParameters.Controls.Add(this.TextBoxImageDimensionZ);
            this.groupBoxParameters.Location = new System.Drawing.Point(18, 212);
            this.groupBoxParameters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxParameters.Size = new System.Drawing.Size(579, 235);
            this.groupBoxParameters.TabIndex = 26;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Parameters";
            // 
            // labelShiftZ
            // 
            this.labelShiftZ.AutoSize = true;
            this.labelShiftZ.Location = new System.Drawing.Point(248, 197);
            this.labelShiftZ.Name = "labelShiftZ";
            this.labelShiftZ.Size = new System.Drawing.Size(17, 20);
            this.labelShiftZ.TabIndex = 31;
            this.labelShiftZ.Text = "z";
            this.labelShiftZ.Visible = false;
            // 
            // textBoxShiftX
            // 
            this.textBoxShiftX.Location = new System.Drawing.Point(272, 129);
            this.textBoxShiftX.Name = "textBoxShiftX";
            this.textBoxShiftX.Size = new System.Drawing.Size(103, 26);
            this.textBoxShiftX.TabIndex = 29;
            this.textBoxShiftX.Text = "0";
            // 
            // textBoxShiftY
            // 
            this.textBoxShiftY.Location = new System.Drawing.Point(272, 162);
            this.textBoxShiftY.Name = "textBoxShiftY";
            this.textBoxShiftY.Size = new System.Drawing.Size(103, 26);
            this.textBoxShiftY.TabIndex = 30;
            this.textBoxShiftY.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "y";
            // 
            // labelShift
            // 
            this.labelShift.AutoSize = true;
            this.labelShift.Location = new System.Drawing.Point(248, 106);
            this.labelShift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelShift.Name = "labelShift";
            this.labelShift.Size = new System.Drawing.Size(140, 20);
            this.labelShift.TabIndex = 26;
            this.labelShift.Text = "Translation (pixels)";
            // 
            // buttonListDeviceInfo
            // 
            this.buttonListDeviceInfo.Location = new System.Drawing.Point(512, 152);
            this.buttonListDeviceInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonListDeviceInfo.Name = "buttonListDeviceInfo";
            this.buttonListDeviceInfo.Size = new System.Drawing.Size(86, 32);
            this.buttonListDeviceInfo.TabIndex = 27;
            this.buttonListDeviceInfo.Text = "List info";
            this.buttonListDeviceInfo.UseVisualStyleBackColor = true;
            this.buttonListDeviceInfo.Click += new System.EventHandler(this.buttonListDeviceInfo_Click);
            // 
            // textBoxShiftZ
            // 
            this.textBoxShiftZ.Location = new System.Drawing.Point(290, 406);
            this.textBoxShiftZ.Name = "textBoxShiftZ";
            this.textBoxShiftZ.Size = new System.Drawing.Size(103, 26);
            this.textBoxShiftZ.TabIndex = 32;
            this.textBoxShiftZ.Text = "0.0";
            this.textBoxShiftZ.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(638, 865);
            this.Controls.Add(this.textBoxShiftZ);
            this.Controls.Add(this.buttonListDeviceInfo);
            this.Controls.Add(this.groupBoxParameters);
            this.Controls.Add(this.groupBoxRadioButtons);
            this.Controls.Add(this.groupBoxMultipleFiles);
            this.Controls.Add(this.groupBoxSingleFile);
            this.Controls.Add(this.labelSelectDevice);
            this.Controls.Add(this.labelSelectPlatform);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.DeviceCombox);
            this.Controls.Add(this.PlatformCombox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1300, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Convolve & Transform  Fluorophores";
            this.groupBoxSingleFile.ResumeLayout(false);
            this.groupBoxSingleFile.PerformLayout();
            this.groupBoxMultipleFiles.ResumeLayout(false);
            this.groupBoxMultipleFiles.PerformLayout();
            this.groupBoxRadioButtons.ResumeLayout(false);
            this.groupBoxRadioButtons.PerformLayout();
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxParameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PlatformCombox;
        private System.Windows.Forms.ComboBox DeviceCombox;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonSelectSourceFile;
        private System.Windows.Forms.Label labelSelectPlatform;
        private System.Windows.Forms.Label labelSelectDevice;
        private System.Windows.Forms.Button buttonSelectSourceDir;
        private System.Windows.Forms.TextBox TextBoxImageDimensionX;
        private System.Windows.Forms.Label labelImagedimension;
        private System.Windows.Forms.Label labelDimX;
        private System.Windows.Forms.Label labelDimY;
        private System.Windows.Forms.Label labelTransformationType;
        private System.Windows.Forms.ComboBox comboBoxTransform;
        private System.Windows.Forms.TextBox TextBoxImageDimensionY;
        private System.Windows.Forms.TextBox TextBoxImageDimensionZ;
        private System.Windows.Forms.Label labelDimZ;
        private System.Windows.Forms.Button buttonSaveOutputFile;
        private System.Windows.Forms.Button buttonSaveOutputDir;
        private System.Windows.Forms.GroupBox groupBoxSingleFile;
        private System.Windows.Forms.GroupBox groupBoxMultipleFiles;
        private System.Windows.Forms.GroupBox groupBoxRadioButtons;
        private System.Windows.Forms.RadioButton radioButtonMultipleFiles;
        private System.Windows.Forms.RadioButton radioButtonSingleFile;
        private System.Windows.Forms.Label labelSaveOutputDir;
        private System.Windows.Forms.Label labelSelectSourceDir;
        private System.Windows.Forms.Label labelSaveOutputFile;
        private System.Windows.Forms.TextBox textBoxSelectSourceFile;
        private System.Windows.Forms.Label labelPixelSize;
        private System.Windows.Forms.TextBox textBoxPixelSize;
        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.TextBox textBoxShiftX;
        private System.Windows.Forms.TextBox textBoxShiftY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelShift;
        private System.Windows.Forms.Button buttonListDeviceInfo;
        private System.Windows.Forms.Label labelShiftZ;
        private System.Windows.Forms.TextBox textBoxShiftZ;
    }
}