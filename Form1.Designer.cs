namespace AITest1
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
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnAL = new System.Windows.Forms.Button();
            this.btnBD = new System.Windows.Forms.Button();
            this.btnTX = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "待识别图像";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "图片文件|*.jpg";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(492, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(411, 246);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "识别信息";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(46, 326);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "名片";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(46, 350);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.Text = "车牌";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnAL
            // 
            this.btnAL.Image = global::AITest1.Properties.Resources.al;
            this.btnAL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAL.Location = new System.Drawing.Point(632, 326);
            this.btnAL.Name = "btnAL";
            this.btnAL.Size = new System.Drawing.Size(196, 40);
            this.btnAL.TabIndex = 9;
            this.btnAL.Text = "阿里云识别(WebApi)";
            this.btnAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAL.UseVisualStyleBackColor = true;
            this.btnAL.Click += new System.EventHandler(this.btnAL_Click);
            // 
            // btnBD
            // 
            this.btnBD.Image = global::AITest1.Properties.Resources.bd;
            this.btnBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBD.Location = new System.Drawing.Point(399, 326);
            this.btnBD.Name = "btnBD";
            this.btnBD.Size = new System.Drawing.Size(182, 40);
            this.btnBD.TabIndex = 3;
            this.btnBD.Text = "百度AI识别(WebApi)";
            this.btnBD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBD.UseVisualStyleBackColor = true;
            this.btnBD.Click += new System.EventHandler(this.btnBD_Click);
            // 
            // btnTX
            // 
            this.btnTX.Image = global::AITest1.Properties.Resources.tx;
            this.btnTX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTX.Location = new System.Drawing.Point(181, 326);
            this.btnTX.Name = "btnTX";
            this.btnTX.Size = new System.Drawing.Size(177, 40);
            this.btnTX.TabIndex = 2;
            this.btnTX.Text = "腾讯AI识别(WebApi)";
            this.btnTX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTX.UseVisualStyleBackColor = true;
            this.btnTX.Click += new System.EventHandler(this.btnTX_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(46, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 246);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 517);
            this.Controls.Add(this.btnAL);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnBD);
            this.Controls.Add(this.btnTX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "AITest1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnTX;
        private System.Windows.Forms.Button btnBD;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button btnAL;
    }
}

