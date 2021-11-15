
namespace YouGoGetData
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
            FontAwesome.Sharp.IconButton iconButton5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.password = new System.Windows.Forms.TextBox();
            this.countrySelects = new System.Windows.Forms.ComboBox();
            this.infoWindow = new System.Windows.Forms.RichTextBox();
            iconButton5 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // iconButton5
            // 
            iconButton5.ForeColor = System.Drawing.Color.DarkOrange;
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.Running;
            iconButton5.IconColor = System.Drawing.Color.DarkOrange;
            iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton5.IconSize = 30;
            iconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            iconButton5.Location = new System.Drawing.Point(171, 306);
            iconButton5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            iconButton5.Name = "iconButton5";
            iconButton5.Size = new System.Drawing.Size(165, 40);
            iconButton5.TabIndex = 12;
            iconButton5.Text = "开始执行";
            iconButton5.UseVisualStyleBackColor = true;
            iconButton5.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconButton1.CausesValidation = false;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton1.IconSize = 60;
            this.iconButton1.Location = new System.Drawing.Point(398, 8);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.iconButton1.Size = new System.Drawing.Size(34, 33);
            this.iconButton1.TabIndex = 0;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(204, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 55);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // userName
            // 
            this.userName.BackColor = System.Drawing.Color.White;
            this.userName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userName.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userName.Location = new System.Drawing.Point(171, 195);
            this.userName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(165, 36);
            this.userName.TabIndex = 4;
            this.userName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // iconButton4
            // 
            this.iconButton4.BackColor = System.Drawing.Color.Transparent;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton4.ForeColor = System.Drawing.Color.White;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.ChessRook;
            this.iconButton4.IconColor = System.Drawing.Color.White;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton4.IconSize = 20;
            this.iconButton4.Location = new System.Drawing.Point(72, 129);
            this.iconButton4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(95, 44);
            this.iconButton4.TabIndex = 5;
            this.iconButton4.Text = "国家：";
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton4.UseVisualStyleBackColor = false;
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton2.IconSize = 20;
            this.iconButton2.Location = new System.Drawing.Point(72, 187);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(95, 44);
            this.iconButton2.TabIndex = 5;
            this.iconButton2.Text = "用户：";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // iconButton3
            // 
            this.iconButton3.BackColor = System.Drawing.Color.Transparent;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton3.ForeColor = System.Drawing.Color.White;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconButton3.IconColor = System.Drawing.Color.White;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton3.IconSize = 20;
            this.iconButton3.Location = new System.Drawing.Point(72, 245);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(95, 44);
            this.iconButton3.TabIndex = 7;
            this.iconButton3.Text = "密码：";
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = false;
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.White;
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password.Location = new System.Drawing.Point(171, 254);
            this.password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(165, 36);
            this.password.TabIndex = 4;
            this.password.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // countrySelects
            // 
            this.countrySelects.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.countrySelects.FormattingEnabled = true;
            this.countrySelects.Location = new System.Drawing.Point(171, 133);
            this.countrySelects.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.countrySelects.Name = "countrySelects";
            this.countrySelects.Size = new System.Drawing.Size(166, 43);
            this.countrySelects.TabIndex = 10;
            // 
            // infoWindow
            // 
            this.infoWindow.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.infoWindow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoWindow.ForeColor = System.Drawing.SystemColors.Info;
            this.infoWindow.Location = new System.Drawing.Point(52, 361);
            this.infoWindow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.infoWindow.Name = "infoWindow";
            this.infoWindow.Size = new System.Drawing.Size(349, 75);
            this.infoWindow.TabIndex = 11;
            this.infoWindow.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(177)))), ((int)(((byte)(160)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(440, 454);
            this.Controls.Add(iconButton5);
            this.Controls.Add(this.infoWindow);
            this.Controls.Add(this.countrySelects);
            this.Controls.Add(this.iconButton3);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.iconButton4);
            this.Controls.Add(this.password);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.iconButton1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox userName;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.ComboBox countrySelects;
        private System.Windows.Forms.RichTextBox infoWindow;
    }
}

