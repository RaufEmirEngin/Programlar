namespace deneme2
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.ÇİZ = new System.Windows.Forms.Button();
            this.Point2X = new System.Windows.Forms.TextBox();
            this.Point3X = new System.Windows.Forms.TextBox();
            this.Point2Y = new System.Windows.Forms.TextBox();
            this.Point3Y = new System.Windows.Forms.TextBox();
            this.Point1Y = new System.Windows.Forms.TextBox();
            this.Point0Y = new System.Windows.Forms.TextBox();
            this.Point1X = new System.Windows.Forms.TextBox();
            this.Point0X = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ÇİZ
            // 
            this.ÇİZ.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ÇİZ.ForeColor = System.Drawing.Color.Black;
            this.ÇİZ.Location = new System.Drawing.Point(536, 182);
            this.ÇİZ.Name = "ÇİZ";
            this.ÇİZ.Size = new System.Drawing.Size(140, 70);
            this.ÇİZ.TabIndex = 0;
            this.ÇİZ.Text = "BEZİERİ ÇİZ";
            this.ÇİZ.UseVisualStyleBackColor = false;
            this.ÇİZ.Click += new System.EventHandler(this.ÇİZ_Click);
            // 
            // Point2X
            // 
            this.Point2X.Location = new System.Drawing.Point(569, 110);
            this.Point2X.Multiline = true;
            this.Point2X.Name = "Point2X";
            this.Point2X.Size = new System.Drawing.Size(45, 30);
            this.Point2X.TabIndex = 4;
            // 
            // Point3X
            // 
            this.Point3X.Location = new System.Drawing.Point(569, 146);
            this.Point3X.Multiline = true;
            this.Point3X.Name = "Point3X";
            this.Point3X.Size = new System.Drawing.Size(45, 32);
            this.Point3X.TabIndex = 5;
            // 
            // Point2Y
            // 
            this.Point2Y.Location = new System.Drawing.Point(630, 109);
            this.Point2Y.Multiline = true;
            this.Point2Y.Name = "Point2Y";
            this.Point2Y.Size = new System.Drawing.Size(46, 30);
            this.Point2Y.TabIndex = 6;
            // 
            // Point3Y
            // 
            this.Point3Y.Location = new System.Drawing.Point(630, 148);
            this.Point3Y.Multiline = true;
            this.Point3Y.Name = "Point3Y";
            this.Point3Y.Size = new System.Drawing.Size(46, 30);
            this.Point3Y.TabIndex = 7;
            // 
            // Point1Y
            // 
            this.Point1Y.Location = new System.Drawing.Point(630, 71);
            this.Point1Y.Multiline = true;
            this.Point1Y.Name = "Point1Y";
            this.Point1Y.Size = new System.Drawing.Size(46, 30);
            this.Point1Y.TabIndex = 11;
            // 
            // Point0Y
            // 
            this.Point0Y.Location = new System.Drawing.Point(630, 32);
            this.Point0Y.Multiline = true;
            this.Point0Y.Name = "Point0Y";
            this.Point0Y.Size = new System.Drawing.Size(46, 30);
            this.Point0Y.TabIndex = 10;
            // 
            // Point1X
            // 
            this.Point1X.Location = new System.Drawing.Point(569, 69);
            this.Point1X.Multiline = true;
            this.Point1X.Name = "Point1X";
            this.Point1X.Size = new System.Drawing.Size(45, 32);
            this.Point1X.TabIndex = 9;
            // 
            // Point0X
            // 
            this.Point0X.Location = new System.Drawing.Point(569, 33);
            this.Point0X.Multiline = true;
            this.Point0X.Name = "Point0X";
            this.Point0X.Size = new System.Drawing.Size(45, 30);
            this.Point0X.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(543, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "P0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(544, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "P1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "P2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "P3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(584, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(645, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Point1Y);
            this.Controls.Add(this.Point0Y);
            this.Controls.Add(this.Point1X);
            this.Controls.Add(this.Point0X);
            this.Controls.Add(this.Point3Y);
            this.Controls.Add(this.Point2Y);
            this.Controls.Add(this.Point3X);
            this.Controls.Add(this.Point2X);
            this.Controls.Add(this.ÇİZ);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ÇİZ;
        private System.Windows.Forms.TextBox Point2X;
        private System.Windows.Forms.TextBox Point3X;
        private System.Windows.Forms.TextBox Point2Y;
        private System.Windows.Forms.TextBox Point3Y;
        private System.Windows.Forms.TextBox Point1Y;
        private System.Windows.Forms.TextBox Point0Y;
        private System.Windows.Forms.TextBox Point1X;
        private System.Windows.Forms.TextBox Point0X;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

