
namespace YouGoGetData
{
    partial class ShopSearchForm
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
            FontAwesome.Sharp.IconButton iconButton1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopSearchForm));
            this.shopNameList = new System.Windows.Forms.ComboBox();
            this.searchText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // iconButton1
            // 
            resources.ApplyResources(iconButton1, "iconButton1");
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.SmileWink;
            iconButton1.IconColor = System.Drawing.Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 40;
            iconButton1.Name = "iconButton1";
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // shopNameList
            // 
            resources.ApplyResources(this.shopNameList, "shopNameList");
            this.shopNameList.FormattingEnabled = true;
            this.shopNameList.Name = "shopNameList";
            this.shopNameList.SelectedIndexChanged += new System.EventHandler(this.shopName_SelectedIndexChanged);
            // 
            // searchText
            // 
            resources.ApplyResources(this.searchText, "searchText");
            this.searchText.Name = "searchText";
            this.searchText.TextChanged += new System.EventHandler(this.searchText_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Name = "label2";
            // 
            // iconButton2
            // 
            resources.ApplyResources(this.iconButton2, "iconButton2");
            this.iconButton2.BackColor = System.Drawing.Color.Transparent;
            this.iconButton2.CausesValidation = false;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.iconButton2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton2.IconSize = 60;
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // ShopSearchForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(iconButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.shopNameList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShopSearchForm";
            this.Load += new System.EventHandler(this.shopSearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox shopNameList;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}