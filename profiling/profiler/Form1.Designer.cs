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
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.labelImage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSelectDir = new System.Windows.Forms.Button();
            this.labelDirSelected = new System.Windows.Forms.Label();
            this.KernelComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlatformCombox
            // 
            this.PlatformCombox.FormattingEnabled = true;
            this.PlatformCombox.Location = new System.Drawing.Point(18, 82);
            this.PlatformCombox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PlatformCombox.Name = "PlatformCombox";
            this.PlatformCombox.Size = new System.Drawing.Size(482, 28);
            this.PlatformCombox.TabIndex = 0;
            this.PlatformCombox.SelectedIndexChanged += new System.EventHandler(this.PlatformCombox_SelectedIndexChanged);
            // 
            // DeviceCombox
            // 
            this.DeviceCombox.FormattingEnabled = true;
            this.DeviceCombox.Location = new System.Drawing.Point(18, 177);
            this.DeviceCombox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeviceCombox.Name = "DeviceCombox";
            this.DeviceCombox.Size = new System.Drawing.Size(482, 28);
            this.DeviceCombox.TabIndex = 1;
            this.DeviceCombox.SelectedIndexChanged += new System.EventHandler(this.DeviceCombox_SelectedIndexChanged);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(484, 422);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(112, 35);
            this.buttonCalculate.TabIndex = 2;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(19, 343);
            this.buttonSelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(112, 35);
            this.buttonSelectFile.TabIndex = 3;
            this.buttonSelectFile.Text = "Select file";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // labelImage
            // 
            this.labelImage.AutoSize = true;
            this.labelImage.Location = new System.Drawing.Point(140, 251);
            this.labelImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(0, 20);
            this.labelImage.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Platform";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Device";
            // 
            // buttonSelectDir
            // 
            this.buttonSelectDir.Location = new System.Drawing.Point(19, 388);
            this.buttonSelectDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSelectDir.Name = "buttonSelectDir";
            this.buttonSelectDir.Size = new System.Drawing.Size(112, 35);
            this.buttonSelectDir.TabIndex = 7;
            this.buttonSelectDir.Text = "Select dir";
            this.buttonSelectDir.UseVisualStyleBackColor = true;
            this.buttonSelectDir.Click += new System.EventHandler(this.buttonSelectDir_Click);
            // 
            // labelDirSelected
            // 
            this.labelDirSelected.AutoSize = true;
            this.labelDirSelected.Location = new System.Drawing.Point(141, 297);
            this.labelDirSelected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDirSelected.Name = "labelDirSelected";
            this.labelDirSelected.Size = new System.Drawing.Size(0, 20);
            this.labelDirSelected.TabIndex = 8;
            // 
            // KernelComboBox
            // 
            this.KernelComboBox.FormattingEnabled = true;
            this.KernelComboBox.Location = new System.Drawing.Point(17, 264);
            this.KernelComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KernelComboBox.Name = "KernelComboBox";
            this.KernelComboBox.Size = new System.Drawing.Size(482, 28);
            this.KernelComboBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 226);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Select Kernel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 483);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.KernelComboBox);
            this.Controls.Add(this.labelDirSelected);
            this.Controls.Add(this.buttonSelectDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelImage);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.DeviceCombox);
            this.Controls.Add(this.PlatformCombox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Select platform/device";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PlatformCombox;
        private System.Windows.Forms.ComboBox DeviceCombox;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Label labelImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectDir;
        private System.Windows.Forms.Label labelDirSelected;
        private System.Windows.Forms.ComboBox KernelComboBox;
        private System.Windows.Forms.Label label3;
    }
}