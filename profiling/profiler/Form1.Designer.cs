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
            this.buttonCalculate.Location = new System.Drawing.Point(260, 204);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculate.TabIndex = 2;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(12, 158);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFile.TabIndex = 3;
            this.buttonSelectFile.Text = "Select file";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // labelImage
            // 
            this.labelImage.AutoSize = true;
            this.labelImage.Location = new System.Drawing.Point(93, 163);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(0, 13);
            this.labelImage.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Platform";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Device";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelImage);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.DeviceCombox);
            this.Controls.Add(this.PlatformCombox);
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
    }
}