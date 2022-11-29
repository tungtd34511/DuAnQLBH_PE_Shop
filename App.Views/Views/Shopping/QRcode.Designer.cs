namespace App.Views.Views.Shopping
{
    partial class QRcode
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
            this.picVideo = new System.Windows.Forms.PictureBox();
            this.combCam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQR = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnStart = new App.Views.Models.Controls.VBButton();
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // picVideo
            // 
            this.picVideo.BackColor = System.Drawing.Color.White;
            this.picVideo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picVideo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picVideo.Location = new System.Drawing.Point(0, 0);
            this.picVideo.Name = "picVideo";
            this.picVideo.Size = new System.Drawing.Size(500, 446);
            this.picVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVideo.TabIndex = 0;
            this.picVideo.TabStop = false;
            // 
            // combCam
            // 
            this.combCam.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.combCam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(219)))));
            this.combCam.FormattingEnabled = true;
            this.combCam.Location = new System.Drawing.Point(337, 452);
            this.combCam.Name = "combCam";
            this.combCam.Size = new System.Drawing.Size(151, 36);
            this.combCam.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(251, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Camera";
            // 
            // txtQR
            // 
            this.txtQR.Location = new System.Drawing.Point(12, 459);
            this.txtQR.Name = "txtQR";
            this.txtQR.Size = new System.Drawing.Size(91, 27);
            this.txtQR.TabIndex = 3;
            this.txtQR.Visible = false;
            this.txtQR.TextChanged += new System.EventHandler(this.txtQR_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnStart.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnStart.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnStart.BorderRadius = 5;
            this.BtnStart.BorderSize = 0;
            this.BtnStart.FlatAppearance.BorderSize = 0;
            this.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStart.ForeColor = System.Drawing.Color.White;
            this.BtnStart.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnStart.IconColor = System.Drawing.Color.Black;
            this.BtnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnStart.Location = new System.Drawing.Point(149, 452);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(96, 41);
            this.BtnStart.TabIndex = 4;
            this.BtnStart.Text = "Start";
            this.BtnStart.TextColor = System.Drawing.Color.White;
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // QRcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.txtQR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combCam);
            this.Controls.Add(this.picVideo);
            this.Name = "QRcode";
            this.Text = "QRcode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QRcode_FormClosing);
            this.Load += new System.EventHandler(this.QRcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picVideo;
        private ComboBox combCam;
        private Label label1;
        private TextBox txtQR;
        private System.Windows.Forms.Timer timer1;
        private Models.Controls.VBButton BtnStart;
    }
}