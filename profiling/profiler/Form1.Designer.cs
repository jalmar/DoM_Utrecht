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
            this.labelTransformation = new System.Windows.Forms.Label();
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
            this.groupBoxSingleFile.SuspendLayout();
            this.groupBoxMultipleFiles.SuspendLayout();
            this.groupBoxRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlatformCombox
            // 
            this.PlatformCombox.FormattingEnabled = true;
            this.PlatformCombox.Location = new System.Drawing.Point(12, 53);
            this.PlatformCombox.Name = "PlatformCombox";
            this.PlatformCombox.Size = new System.Drawing.Size(323, 21);
            this.PlatformCombox.TabIndex = 0;
            this.PlatformCombox.SelectedIndexChanged += new System.EventHandler(this.PlatformCombox_SelectedIndexChanged);
            // 
            // DeviceCombox
            // 
            this.DeviceCombox.FormattingEnabled = true;
            this.DeviceCombox.Location = new System.Drawing.Point(12, 115);
            this.DeviceCombox.Name = "DeviceCombox";
            this.DeviceCombox.Size = new System.Drawing.Size(323, 21);
            this.DeviceCombox.TabIndex = 1;
            this.DeviceCombox.SelectedIndexChanged += new System.EventHandler(this.DeviceCombox_SelectedIndexChanged);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(298, 468);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(100, 45);
            this.buttonCalculate.TabIndex = 2;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonSelectSourceFile
            // 
            this.buttonSelectSourceFile.Location = new System.Drawing.Point(6, 19);
            this.buttonSelectSourceFile.Name = "buttonSelectSourceFile";
            this.buttonSelectSourceFile.Size = new System.Drawing.Size(98, 23);
            this.buttonSelectSourceFile.TabIndex = 3;
            this.buttonSelectSourceFile.Text = "Select source file";
            this.buttonSelectSourceFile.UseVisualStyleBackColor = true;
            this.buttonSelectSourceFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // labelSelectPlatform
            // 
            this.labelSelectPlatform.AutoSize = true;
            this.labelSelectPlatform.Location = new System.Drawing.Point(9, 28);
            this.labelSelectPlatform.Name = "labelSelectPlatform";
            this.labelSelectPlatform.Size = new System.Drawing.Size(78, 13);
            this.labelSelectPlatform.TabIndex = 5;
            this.labelSelectPlatform.Text = "Select Platform";
            // 
            // labelSelectDevice
            // 
            this.labelSelectDevice.AutoSize = true;
            this.labelSelectDevice.Location = new System.Drawing.Point(9, 87);
            this.labelSelectDevice.Name = "labelSelectDevice";
            this.labelSelectDevice.Size = new System.Drawing.Size(74, 13);
            this.labelSelectDevice.TabIndex = 6;
            this.labelSelectDevice.Text = "Select Device";
            // 
            // buttonSelectSourceDir
            // 
            this.buttonSelectSourceDir.Location = new System.Drawing.Point(6, 19);
            this.buttonSelectSourceDir.Name = "buttonSelectSourceDir";
            this.buttonSelectSourceDir.Size = new System.Drawing.Size(98, 23);
            this.buttonSelectSourceDir.TabIndex = 7;
            this.buttonSelectSourceDir.Text = "Select source dir";
            this.buttonSelectSourceDir.UseVisualStyleBackColor = true;
            this.buttonSelectSourceDir.Click += new System.EventHandler(this.buttonSelectDir_Click);
            // 
            // TextBoxImageDimensionX
            // 
            this.TextBoxImageDimensionX.Location = new System.Drawing.Point(34, 164);
            this.TextBoxImageDimensionX.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxImageDimensionX.Name = "TextBoxImageDimensionX";
            this.TextBoxImageDimensionX.Size = new System.Drawing.Size(68, 20);
            this.TextBoxImageDimensionX.TabIndex = 8;
            this.TextBoxImageDimensionX.Text = "128";
            // 
            // labelImagedimension
            // 
            this.labelImagedimension.AutoSize = true;
            this.labelImagedimension.Location = new System.Drawing.Point(13, 146);
            this.labelImagedimension.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelImagedimension.Name = "labelImagedimension";
            this.labelImagedimension.Size = new System.Drawing.Size(86, 13);
            this.labelImagedimension.TabIndex = 10;
            this.labelImagedimension.Text = "Image dimension";
            // 
            // labelDimX
            // 
            this.labelDimX.AutoSize = true;
            this.labelDimX.Location = new System.Drawing.Point(19, 163);
            this.labelDimX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDimX.Name = "labelDimX";
            this.labelDimX.Size = new System.Drawing.Size(12, 13);
            this.labelDimX.TabIndex = 11;
            this.labelDimX.Text = "x";
            // 
            // labelDimY
            // 
            this.labelDimY.AutoSize = true;
            this.labelDimY.Location = new System.Drawing.Point(19, 184);
            this.labelDimY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDimY.Name = "labelDimY";
            this.labelDimY.Size = new System.Drawing.Size(12, 13);
            this.labelDimY.TabIndex = 12;
            this.labelDimY.Text = "y";
            // 
            // labelTransformation
            // 
            this.labelTransformation.AutoSize = true;
            this.labelTransformation.Location = new System.Drawing.Point(217, 146);
            this.labelTransformation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTransformation.Name = "labelTransformation";
            this.labelTransformation.Size = new System.Drawing.Size(100, 13);
            this.labelTransformation.TabIndex = 13;
            this.labelTransformation.Text = "Transformation type";
            // 
            // comboBoxTransform
            // 
            this.comboBoxTransform.FormattingEnabled = true;
            this.comboBoxTransform.Items.AddRange(new object[] {
            "transformation A = 1",
            "transformation B = 2",
            "transformation C = 3",
            "transformation D = 4"});
            this.comboBoxTransform.Location = new System.Drawing.Point(219, 163);
            this.comboBoxTransform.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTransform.Name = "comboBoxTransform";
            this.comboBoxTransform.Size = new System.Drawing.Size(179, 21);
            this.comboBoxTransform.TabIndex = 14;
            // 
            // TextBoxImageDimensionY
            // 
            this.TextBoxImageDimensionY.Location = new System.Drawing.Point(34, 185);
            this.TextBoxImageDimensionY.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxImageDimensionY.Name = "TextBoxImageDimensionY";
            this.TextBoxImageDimensionY.Size = new System.Drawing.Size(68, 20);
            this.TextBoxImageDimensionY.TabIndex = 15;
            this.TextBoxImageDimensionY.Text = "128";
            // 
            // TextBoxImageDimensionZ
            // 
            this.TextBoxImageDimensionZ.Location = new System.Drawing.Point(34, 206);
            this.TextBoxImageDimensionZ.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxImageDimensionZ.Name = "TextBoxImageDimensionZ";
            this.TextBoxImageDimensionZ.Size = new System.Drawing.Size(68, 20);
            this.TextBoxImageDimensionZ.TabIndex = 16;
            this.TextBoxImageDimensionZ.Text = "128";
            // 
            // labelDimZ
            // 
            this.labelDimZ.AutoSize = true;
            this.labelDimZ.Location = new System.Drawing.Point(19, 208);
            this.labelDimZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDimZ.Name = "labelDimZ";
            this.labelDimZ.Size = new System.Drawing.Size(12, 13);
            this.labelDimZ.TabIndex = 17;
            this.labelDimZ.Text = "z";
            // 
            // buttonSaveOutputFile
            // 
            this.buttonSaveOutputFile.Location = new System.Drawing.Point(6, 48);
            this.buttonSaveOutputFile.Name = "buttonSaveOutputFile";
            this.buttonSaveOutputFile.Size = new System.Drawing.Size(98, 23);
            this.buttonSaveOutputFile.TabIndex = 19;
            this.buttonSaveOutputFile.Text = "Save output file";
            this.buttonSaveOutputFile.UseVisualStyleBackColor = true;
            this.buttonSaveOutputFile.Click += new System.EventHandler(this.buttonSaveOutputFile_Click);
            // 
            // buttonSaveOutputDir
            // 
            this.buttonSaveOutputDir.Location = new System.Drawing.Point(6, 48);
            this.buttonSaveOutputDir.Name = "buttonSaveOutputDir";
            this.buttonSaveOutputDir.Size = new System.Drawing.Size(98, 23);
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
            this.groupBoxSingleFile.Location = new System.Drawing.Point(40, 243);
            this.groupBoxSingleFile.Name = "groupBoxSingleFile";
            this.groupBoxSingleFile.Size = new System.Drawing.Size(358, 100);
            this.groupBoxSingleFile.TabIndex = 21;
            this.groupBoxSingleFile.TabStop = false;
            this.groupBoxSingleFile.Text = "Single file";
            // 
            // textBoxSelectSourceFile
            // 
            this.textBoxSelectSourceFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.textBoxSelectSourceFile.Location = new System.Drawing.Point(110, 21);
            this.textBoxSelectSourceFile.MaximumSize = new System.Drawing.Size(238, 23);
            this.textBoxSelectSourceFile.Name = "textBoxSelectSourceFile";
            this.textBoxSelectSourceFile.ReadOnly = true;
            this.textBoxSelectSourceFile.Size = new System.Drawing.Size(235, 20);
            this.textBoxSelectSourceFile.TabIndex = 20;
            this.textBoxSelectSourceFile.Text = "...";
            // 
            // labelSaveOutputFile
            // 
            this.labelSaveOutputFile.Location = new System.Drawing.Point(110, 48);
            this.labelSaveOutputFile.MaximumSize = new System.Drawing.Size(238, 23);
            this.labelSaveOutputFile.Name = "labelSaveOutputFile";
            this.labelSaveOutputFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelSaveOutputFile.Size = new System.Drawing.Size(238, 23);
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
            this.groupBoxMultipleFiles.Location = new System.Drawing.Point(40, 362);
            this.groupBoxMultipleFiles.Name = "groupBoxMultipleFiles";
            this.groupBoxMultipleFiles.Size = new System.Drawing.Size(358, 100);
            this.groupBoxMultipleFiles.TabIndex = 22;
            this.groupBoxMultipleFiles.TabStop = false;
            this.groupBoxMultipleFiles.Text = "Multiple files";
            // 
            // labelSaveOutputDir
            // 
            this.labelSaveOutputDir.AutoSize = true;
            this.labelSaveOutputDir.Location = new System.Drawing.Point(111, 57);
            this.labelSaveOutputDir.Name = "labelSaveOutputDir";
            this.labelSaveOutputDir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelSaveOutputDir.Size = new System.Drawing.Size(16, 13);
            this.labelSaveOutputDir.TabIndex = 22;
            this.labelSaveOutputDir.Text = "...";
            // 
            // labelSelectSourceDir
            // 
            this.labelSelectSourceDir.AutoSize = true;
            this.labelSelectSourceDir.Location = new System.Drawing.Point(111, 28);
            this.labelSelectSourceDir.Name = "labelSelectSourceDir";
            this.labelSelectSourceDir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelSelectSourceDir.Size = new System.Drawing.Size(16, 13);
            this.labelSelectSourceDir.TabIndex = 21;
            this.labelSelectSourceDir.Text = "...";
            // 
            // groupBoxRadioButtons
            // 
            this.groupBoxRadioButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBoxRadioButtons.Controls.Add(this.radioButtonMultipleFiles);
            this.groupBoxRadioButtons.Controls.Add(this.radioButtonSingleFile);
            this.groupBoxRadioButtons.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxRadioButtons.Location = new System.Drawing.Point(12, 243);
            this.groupBoxRadioButtons.Name = "groupBoxRadioButtons";
            this.groupBoxRadioButtons.Size = new System.Drawing.Size(22, 219);
            this.groupBoxRadioButtons.TabIndex = 23;
            this.groupBoxRadioButtons.TabStop = false;
            // 
            // radioButtonMultipleFiles
            // 
            this.radioButtonMultipleFiles.AutoSize = true;
            this.radioButtonMultipleFiles.Location = new System.Drawing.Point(4, 155);
            this.radioButtonMultipleFiles.Name = "radioButtonMultipleFiles";
            this.radioButtonMultipleFiles.Size = new System.Drawing.Size(14, 13);
            this.radioButtonMultipleFiles.TabIndex = 1;
            this.radioButtonMultipleFiles.UseVisualStyleBackColor = true;
            this.radioButtonMultipleFiles.CheckedChanged += new System.EventHandler(this.radioButtonMultipleFiles_CheckedChanged);
            // 
            // radioButtonSingleFile
            // 
            this.radioButtonSingleFile.AutoSize = true;
            this.radioButtonSingleFile.Checked = true;
            this.radioButtonSingleFile.Location = new System.Drawing.Point(4, 48);
            this.radioButtonSingleFile.Name = "radioButtonSingleFile";
            this.radioButtonSingleFile.Size = new System.Drawing.Size(14, 13);
            this.radioButtonSingleFile.TabIndex = 0;
            this.radioButtonSingleFile.TabStop = true;
            this.radioButtonSingleFile.UseVisualStyleBackColor = true;
            this.radioButtonSingleFile.CheckedChanged += new System.EventHandler(this.radioButtonSingleFile_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 521);
            this.Controls.Add(this.groupBoxRadioButtons);
            this.Controls.Add(this.groupBoxMultipleFiles);
            this.Controls.Add(this.groupBoxSingleFile);
            this.Controls.Add(this.labelDimZ);
            this.Controls.Add(this.TextBoxImageDimensionZ);
            this.Controls.Add(this.TextBoxImageDimensionY);
            this.Controls.Add(this.comboBoxTransform);
            this.Controls.Add(this.labelTransformation);
            this.Controls.Add(this.labelDimY);
            this.Controls.Add(this.labelDimX);
            this.Controls.Add(this.labelImagedimension);
            this.Controls.Add(this.TextBoxImageDimensionX);
            this.Controls.Add(this.labelSelectDevice);
            this.Controls.Add(this.labelSelectPlatform);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.DeviceCombox);
            this.Controls.Add(this.PlatformCombox);
            this.Name = "Form1";
            this.Text = "Select platform/device";
            this.groupBoxSingleFile.ResumeLayout(false);
            this.groupBoxSingleFile.PerformLayout();
            this.groupBoxMultipleFiles.ResumeLayout(false);
            this.groupBoxMultipleFiles.PerformLayout();
            this.groupBoxRadioButtons.ResumeLayout(false);
            this.groupBoxRadioButtons.PerformLayout();
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
        private System.Windows.Forms.Label labelTransformation;
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
    }
}