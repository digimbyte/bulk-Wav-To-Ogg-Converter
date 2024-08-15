namespace Batch_WAV_to_OGG_Converter
{
    partial class frmMain
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
			this.group_step1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSource = new System.Windows.Forms.TextBox();
			this.btnChooseSource = new System.Windows.Forms.Button();
			this.group_step4 = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.convertProgress = new System.Windows.Forms.ProgressBar();
			this.label3 = new System.Windows.Forms.Label();
			this.btnConvert = new System.Windows.Forms.Button();
			this.group_step2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.target_label = new System.Windows.Forms.Label();
			this.txtTarget = new System.Windows.Forms.TextBox();
			this.btnChooseTarget = new System.Windows.Forms.Button();
			this.group_step3 = new System.Windows.Forms.GroupBox();
			this.boolOverride = new System.Windows.Forms.CheckBox();
			this.boolRecursive = new System.Windows.Forms.CheckBox();
			this.boolDelete = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.group_step1.SuspendLayout();
			this.group_step4.SuspendLayout();
			this.group_step2.SuspendLayout();
			this.group_step3.SuspendLayout();
			this.SuspendLayout();
			// 
			// group_step1
			// 
			this.group_step1.Controls.Add(this.label1);
			this.group_step1.Controls.Add(this.label2);
			this.group_step1.Controls.Add(this.txtSource);
			this.group_step1.Controls.Add(this.btnChooseSource);
			this.group_step1.Location = new System.Drawing.Point(5, 2);
			this.group_step1.Name = "group_step1";
			this.group_step1.Size = new System.Drawing.Size(380, 67);
			this.group_step1.TabIndex = 5;
			this.group_step1.TabStop = false;
			this.group_step1.Text = "Step 1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(293, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select the target folder to read the wav files";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Source:";
			// 
			// txtSource
			// 
			this.txtSource.Location = new System.Drawing.Point(57, 35);
			this.txtSource.Name = "txtSource";
			this.txtSource.Size = new System.Drawing.Size(242, 20);
			this.txtSource.TabIndex = 0;
			this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
			// 
			// btnChooseSource
			// 
			this.btnChooseSource.Location = new System.Drawing.Point(305, 33);
			this.btnChooseSource.Name = "btnChooseSource";
			this.btnChooseSource.Size = new System.Drawing.Size(69, 23);
			this.btnChooseSource.TabIndex = 2;
			this.btnChooseSource.Text = "Browse";
			this.btnChooseSource.UseVisualStyleBackColor = true;
			this.btnChooseSource.Click += new System.EventHandler(this.btnChooseSource_Click);
			// 
			// group_step4
			// 
			this.group_step4.Controls.Add(this.btnCancel);
			this.group_step4.Controls.Add(this.lblStatus);
			this.group_step4.Controls.Add(this.convertProgress);
			this.group_step4.Controls.Add(this.label3);
			this.group_step4.Controls.Add(this.btnConvert);
			this.group_step4.Location = new System.Drawing.Point(5, 234);
			this.group_step4.Name = "group_step4";
			this.group_step4.Size = new System.Drawing.Size(380, 83);
			this.group_step4.TabIndex = 6;
			this.group_step4.TabStop = false;
			this.group_step4.Text = "Step 4";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(305, 50);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(69, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(22, 55);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(50, 13);
			this.lblStatus.TabIndex = 4;
			this.lblStatus.Text = "STATUS";
			this.lblStatus.Click += new System.EventHandler(this.label5_Click_1);
			// 
			// convertProgress
			// 
			this.convertProgress.Location = new System.Drawing.Point(6, 50);
			this.convertProgress.Name = "convertProgress";
			this.convertProgress.Size = new System.Drawing.Size(293, 23);
			this.convertProgress.TabIndex = 3;
			this.convertProgress.Visible = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(368, 31);
			this.label3.TabIndex = 1;
			this.label3.Text = "Click the button below to begin. Your wav files will be moved into a new folder a" +
    "nd replaced with .ogg files.";
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(161, 50);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(69, 23);
			this.btnConvert.TabIndex = 2;
			this.btnConvert.Text = "Convert";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// group_step2
			// 
			this.group_step2.Controls.Add(this.label4);
			this.group_step2.Controls.Add(this.target_label);
			this.group_step2.Controls.Add(this.txtTarget);
			this.group_step2.Controls.Add(this.btnChooseTarget);
			this.group_step2.Location = new System.Drawing.Point(5, 75);
			this.group_step2.Name = "group_step2";
			this.group_step2.Size = new System.Drawing.Size(380, 65);
			this.group_step2.TabIndex = 6;
			this.group_step2.TabStop = false;
			this.group_step2.Text = "Step 2";
			this.group_step2.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(287, 18);
			this.label4.TabIndex = 1;
			this.label4.Text = "Select the destination folder to write the ogg files";
			// 
			// target_label
			// 
			this.target_label.AutoSize = true;
			this.target_label.Location = new System.Drawing.Point(7, 34);
			this.target_label.Name = "target_label";
			this.target_label.Size = new System.Drawing.Size(41, 13);
			this.target_label.TabIndex = 3;
			this.target_label.Text = "Target:\r\n";
			this.target_label.Click += new System.EventHandler(this.label5_Click);
			// 
			// txtTarget
			// 
			this.txtTarget.Location = new System.Drawing.Point(57, 34);
			this.txtTarget.Name = "txtTarget";
			this.txtTarget.Size = new System.Drawing.Size(242, 20);
			this.txtTarget.TabIndex = 0;
			this.txtTarget.TextChanged += new System.EventHandler(this.txtTarget_TextChanged);
			// 
			// btnChooseTarget
			// 
			this.btnChooseTarget.Location = new System.Drawing.Point(305, 31);
			this.btnChooseTarget.Name = "btnChooseTarget";
			this.btnChooseTarget.Size = new System.Drawing.Size(69, 23);
			this.btnChooseTarget.TabIndex = 2;
			this.btnChooseTarget.Text = "Browse";
			this.btnChooseTarget.UseVisualStyleBackColor = true;
			this.btnChooseTarget.Click += new System.EventHandler(this.btnChooseTarget_Click);
			// 
			// group_step3
			// 
			this.group_step3.Controls.Add(this.boolOverride);
			this.group_step3.Controls.Add(this.boolRecursive);
			this.group_step3.Controls.Add(this.boolDelete);
			this.group_step3.Controls.Add(this.label6);
			this.group_step3.Location = new System.Drawing.Point(11, 146);
			this.group_step3.Name = "group_step3";
			this.group_step3.Size = new System.Drawing.Size(380, 82);
			this.group_step3.TabIndex = 7;
			this.group_step3.TabStop = false;
			this.group_step3.Text = "Step 3";
			// 
			// boolOverride
			// 
			this.boolOverride.AutoSize = true;
			this.boolOverride.Location = new System.Drawing.Point(269, 37);
			this.boolOverride.Name = "boolOverride";
			this.boolOverride.Size = new System.Drawing.Size(71, 17);
			this.boolOverride.TabIndex = 4;
			this.boolOverride.Text = "Overwrite";
			this.boolOverride.UseVisualStyleBackColor = true;
			this.boolOverride.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// boolRecursive
			// 
			this.boolRecursive.AutoSize = true;
			this.boolRecursive.Location = new System.Drawing.Point(145, 37);
			this.boolRecursive.Name = "boolRecursive";
			this.boolRecursive.Size = new System.Drawing.Size(79, 17);
			this.boolRecursive.TabIndex = 3;
			this.boolRecursive.Text = "SubFolders";
			this.boolRecursive.UseVisualStyleBackColor = true;
			// 
			// boolDelete
			// 
			this.boolDelete.AutoSize = true;
			this.boolDelete.Location = new System.Drawing.Point(9, 37);
			this.boolDelete.Name = "boolDelete";
			this.boolDelete.Size = new System.Drawing.Size(95, 17);
			this.boolDelete.TabIndex = 2;
			this.boolDelete.Text = "Delete Original";
			this.boolDelete.UseVisualStyleBackColor = true;
			this.boolDelete.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(281, 18);
			this.label6.TabIndex = 1;
			this.label6.Text = "Select options when you convert";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(397, 329);
			this.Controls.Add(this.group_step3);
			this.Controls.Add(this.group_step2);
			this.Controls.Add(this.group_step4);
			this.Controls.Add(this.group_step1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "Batch WAV to OGG Converter";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.group_step1.ResumeLayout(false);
			this.group_step1.PerformLayout();
			this.group_step4.ResumeLayout(false);
			this.group_step4.PerformLayout();
			this.group_step2.ResumeLayout(false);
			this.group_step2.PerformLayout();
			this.group_step3.ResumeLayout(false);
			this.group_step3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_step1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnChooseSource;
        private System.Windows.Forms.GroupBox group_step4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar convertProgress;
		private System.Windows.Forms.GroupBox group_step2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label target_label;
		private System.Windows.Forms.TextBox txtTarget;
		private System.Windows.Forms.Button btnChooseTarget;
		private System.Windows.Forms.GroupBox group_step3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox boolDelete;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox boolOverride;
		private System.Windows.Forms.CheckBox boolRecursive;
	}
}

