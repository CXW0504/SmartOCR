namespace GoogleCaptche
{
    partial class GoogleCaptche
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtImageFileName = new System.Windows.Forms.TextBox();
            this.btnImgFileName = new System.Windows.Forms.Button();
            this.picSource = new System.Windows.Forms.PictureBox();
            this.picCaptche = new System.Windows.Forms.PictureBox();
            this.rtxCaptche = new System.Windows.Forms.RichTextBox();
            this.btnCaptche = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptche)).BeginInit();
            this.SuspendLayout();
            // 
            // txtImageFileName
            // 
            this.txtImageFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageFileName.Location = new System.Drawing.Point(12, 12);
            this.txtImageFileName.Name = "txtImageFileName";
            this.txtImageFileName.Size = new System.Drawing.Size(243, 21);
            this.txtImageFileName.TabIndex = 0;
            // 
            // btnImgFileName
            // 
            this.btnImgFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImgFileName.Location = new System.Drawing.Point(261, 12);
            this.btnImgFileName.Name = "btnImgFileName";
            this.btnImgFileName.Size = new System.Drawing.Size(75, 23);
            this.btnImgFileName.TabIndex = 1;
            this.btnImgFileName.Text = "选择";
            this.btnImgFileName.UseVisualStyleBackColor = true;
            this.btnImgFileName.Click += new System.EventHandler(this.btnImgFileName_Click);
            // 
            // picSource
            // 
            this.picSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSource.Location = new System.Drawing.Point(12, 39);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(200, 70);
            this.picSource.TabIndex = 2;
            this.picSource.TabStop = false;
            // 
            // picCaptche
            // 
            this.picCaptche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCaptche.Location = new System.Drawing.Point(217, 39);
            this.picCaptche.Name = "picCaptche";
            this.picCaptche.Size = new System.Drawing.Size(200, 70);
            this.picCaptche.TabIndex = 2;
            this.picCaptche.TabStop = false;
            this.picCaptche.Click += new System.EventHandler(this.picCaptche_Click);
            // 
            // rtxCaptche
            // 
            this.rtxCaptche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxCaptche.Location = new System.Drawing.Point(12, 115);
            this.rtxCaptche.Name = "rtxCaptche";
            this.rtxCaptche.Size = new System.Drawing.Size(405, 158);
            this.rtxCaptche.TabIndex = 3;
            this.rtxCaptche.Text = "";
            // 
            // btnCaptche
            // 
            this.btnCaptche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCaptche.Location = new System.Drawing.Point(342, 12);
            this.btnCaptche.Name = "btnCaptche";
            this.btnCaptche.Size = new System.Drawing.Size(75, 23);
            this.btnCaptche.TabIndex = 1;
            this.btnCaptche.Text = "识别";
            this.btnCaptche.UseVisualStyleBackColor = true;
            this.btnCaptche.Click += new System.EventHandler(this.btnCaptche_Click);
            // 
            // GoogleCaptche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 285);
            this.Controls.Add(this.rtxCaptche);
            this.Controls.Add(this.picCaptche);
            this.Controls.Add(this.picSource);
            this.Controls.Add(this.btnCaptche);
            this.Controls.Add(this.btnImgFileName);
            this.Controls.Add(this.txtImageFileName);
            this.Name = "GoogleCaptche";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Google验证码";
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImageFileName;
        private System.Windows.Forms.Button btnImgFileName;
        private System.Windows.Forms.PictureBox picSource;
        private System.Windows.Forms.PictureBox picCaptche;
        private System.Windows.Forms.RichTextBox rtxCaptche;
        private System.Windows.Forms.Button btnCaptche;
    }
}

