namespace AforgeDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cboVideo = new System.Windows.Forms.ComboBox();
            this.cboResolution = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCut = new System.Windows.Forms.Button();
            this.btnPic = new System.Windows.Forms.Button();
            this.vispShoot = new AForge.Controls.VideoSourcePlayer();
            this.picbPreview = new AForge.Controls.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // cboVideo
            // 
            this.cboVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVideo.FormattingEnabled = true;
            this.cboVideo.Location = new System.Drawing.Point(97, 18);
            this.cboVideo.Margin = new System.Windows.Forms.Padding(4);
            this.cboVideo.Name = "cboVideo";
            this.cboVideo.Size = new System.Drawing.Size(185, 23);
            this.cboVideo.TabIndex = 0;
            this.cboVideo.SelectedIndexChanged += new System.EventHandler(this.cboVideo_SelectedIndexChanged);
            // 
            // cboResolution
            // 
            this.cboResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResolution.FormattingEnabled = true;
            this.cboResolution.Location = new System.Drawing.Point(361, 18);
            this.cboResolution.Margin = new System.Windows.Forms.Padding(4);
            this.cboResolution.Name = "cboResolution";
            this.cboResolution.Size = new System.Drawing.Size(173, 23);
            this.cboResolution.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Transparent;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnConnect.Location = new System.Drawing.Point(581, 16);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(61, 29);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCut
            // 
            this.btnCut.BackColor = System.Drawing.Color.Transparent;
            this.btnCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCut.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnCut.Location = new System.Drawing.Point(672, 16);
            this.btnCut.Margin = new System.Windows.Forms.Padding(4);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(61, 29);
            this.btnCut.TabIndex = 2;
            this.btnCut.Text = "断开";
            this.btnCut.UseVisualStyleBackColor = false;
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnPic
            // 
            this.btnPic.BackColor = System.Drawing.Color.Transparent;
            this.btnPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPic.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnPic.Location = new System.Drawing.Point(759, 16);
            this.btnPic.Margin = new System.Windows.Forms.Padding(4);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(61, 29);
            this.btnPic.TabIndex = 2;
            this.btnPic.Text = "拍照";
            this.btnPic.UseVisualStyleBackColor = false;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // vispShoot
            // 
            this.vispShoot.BackColor = System.Drawing.SystemColors.Control;
            this.vispShoot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.vispShoot.Location = new System.Drawing.Point(16, 51);
            this.vispShoot.Margin = new System.Windows.Forms.Padding(4);
            this.vispShoot.Name = "vispShoot";
            this.vispShoot.Size = new System.Drawing.Size(807, 414);
            this.vispShoot.TabIndex = 3;
            this.vispShoot.Text = "videoSourcePlayer1";
            this.vispShoot.VideoSource = null;
            // 
            // picbPreview
            // 
            this.picbPreview.BackColor = System.Drawing.Color.Transparent;
            this.picbPreview.Image = null;
            this.picbPreview.Location = new System.Drawing.Point(633, 470);
            this.picbPreview.Margin = new System.Windows.Forms.Padding(4);
            this.picbPreview.Name = "picbPreview";
            this.picbPreview.Size = new System.Drawing.Size(189, 95);
            this.picbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbPreview.TabIndex = 4;
            this.picbPreview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "摄像头：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(304, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "像素：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(832, 569);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picbPreview);
            this.Controls.Add(this.vispShoot);
            this.Controls.Add(this.btnPic);
            this.Controls.Add(this.btnCut);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cboResolution);
            this.Controls.Add(this.cboVideo);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "摄像头";
            this.TransparencyKey = System.Drawing.Color.White;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboVideo;
        private System.Windows.Forms.ComboBox cboResolution;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCut;
        private System.Windows.Forms.Button btnPic;
        private AForge.Controls.PictureBox picbPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public AForge.Controls.VideoSourcePlayer vispShoot;
    }
}

