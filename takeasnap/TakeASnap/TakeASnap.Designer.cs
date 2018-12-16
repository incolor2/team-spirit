namespace TakeASnap
{
    partial class TakeASnap
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
            this.components = new System.ComponentModel.Container();
            this.FindFacesViewPictureBox = new System.Windows.Forms.PictureBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.lblFps = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDetectedFaces = new System.Windows.Forms.CheckBox();
            this.chkSendToS3 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.FindFacesViewPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FindFacesViewPictureBox
            // 
            this.FindFacesViewPictureBox.Location = new System.Drawing.Point(18, 18);
            this.FindFacesViewPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FindFacesViewPictureBox.Name = "FindFacesViewPictureBox";
            this.FindFacesViewPictureBox.Size = new System.Drawing.Size(729, 425);
            this.FindFacesViewPictureBox.TabIndex = 0;
            this.FindFacesViewPictureBox.TabStop = false;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 42;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Location = new System.Drawing.Point(72, 66);
            this.lblFps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(51, 20);
            this.lblFps.TabIndex = 1;
            this.lblFps.Text = "lblFps";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(72, 35);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(58, 20);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "lblTime";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(118, 98);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(59, 20);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "lblTotal";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.lblFps);
            this.groupBox1.Location = new System.Drawing.Point(766, 302);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(255, 142);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frame information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total frames:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fps:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time:";
            // 
            // chkDetectedFaces
            // 
            this.chkDetectedFaces.AutoSize = true;
            this.chkDetectedFaces.Location = new System.Drawing.Point(766, 18);
            this.chkDetectedFaces.Name = "chkDetectedFaces";
            this.chkDetectedFaces.Size = new System.Drawing.Size(126, 24);
            this.chkDetectedFaces.TabIndex = 5;
            this.chkDetectedFaces.Text = "Detect faces";
            this.chkDetectedFaces.UseVisualStyleBackColor = true;
            // 
            // chkSendToS3
            // 
            this.chkSendToS3.AutoSize = true;
            this.chkSendToS3.Location = new System.Drawing.Point(766, 61);
            this.chkSendToS3.Name = "chkSendToS3";
            this.chkSendToS3.Size = new System.Drawing.Size(128, 24);
            this.chkSendToS3.TabIndex = 6;
            this.chkSendToS3.Text = "Upload to S3";
            this.chkSendToS3.UseVisualStyleBackColor = true;
            // 
            // TakeASnap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 477);
            this.Controls.Add(this.chkSendToS3);
            this.Controls.Add(this.chkDetectedFaces);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FindFacesViewPictureBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TakeASnap";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TakeASnap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FindFacesViewPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FindFacesViewPictureBox;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDetectedFaces;
        private System.Windows.Forms.CheckBox chkSendToS3;
    }
}

