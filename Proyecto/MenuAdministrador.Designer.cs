namespace Proyecto
{
    partial class MenuAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdministrador));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.doctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.individualesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recepcionistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.individualesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.generalesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.administradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altasToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.CierreDeSesion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSlateGray;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doctorToolStripMenuItem,
            this.recepcionistaToolStripMenuItem,
            this.administradorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 40);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // doctorToolStripMenuItem
            // 
            this.doctorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altasToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.doctorToolStripMenuItem.Name = "doctorToolStripMenuItem";
            this.doctorToolStripMenuItem.Size = new System.Drawing.Size(98, 36);
            this.doctorToolStripMenuItem.Text = "Doctor";
            // 
            // altasToolStripMenuItem
            // 
            this.altasToolStripMenuItem.Name = "altasToolStripMenuItem";
            this.altasToolStripMenuItem.Size = new System.Drawing.Size(191, 36);
            this.altasToolStripMenuItem.Text = "Altas";
            this.altasToolStripMenuItem.Click += new System.EventHandler(this.altasToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.individualesToolStripMenuItem,
            this.generalesToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(191, 36);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // individualesToolStripMenuItem
            // 
            this.individualesToolStripMenuItem.Name = "individualesToolStripMenuItem";
            this.individualesToolStripMenuItem.Size = new System.Drawing.Size(215, 36);
            this.individualesToolStripMenuItem.Text = "Individuales";
            this.individualesToolStripMenuItem.Click += new System.EventHandler(this.individualesToolStripMenuItem_Click);
            // 
            // generalesToolStripMenuItem
            // 
            this.generalesToolStripMenuItem.Name = "generalesToolStripMenuItem";
            this.generalesToolStripMenuItem.Size = new System.Drawing.Size(215, 36);
            this.generalesToolStripMenuItem.Text = "Generales";
            this.generalesToolStripMenuItem.Click += new System.EventHandler(this.generalesToolStripMenuItem_Click);
            // 
            // recepcionistaToolStripMenuItem
            // 
            this.recepcionistaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altasToolStripMenuItem1,
            this.consultasToolStripMenuItem1});
            this.recepcionistaToolStripMenuItem.Name = "recepcionistaToolStripMenuItem";
            this.recepcionistaToolStripMenuItem.Size = new System.Drawing.Size(171, 36);
            this.recepcionistaToolStripMenuItem.Text = "Recepcionista";
            // 
            // altasToolStripMenuItem1
            // 
            this.altasToolStripMenuItem1.Name = "altasToolStripMenuItem1";
            this.altasToolStripMenuItem1.Size = new System.Drawing.Size(191, 36);
            this.altasToolStripMenuItem1.Text = "Altas";
            this.altasToolStripMenuItem1.Click += new System.EventHandler(this.altasToolStripMenuItem1_Click);
            // 
            // consultasToolStripMenuItem1
            // 
            this.consultasToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.individualesToolStripMenuItem1,
            this.generalesToolStripMenuItem1});
            this.consultasToolStripMenuItem1.Name = "consultasToolStripMenuItem1";
            this.consultasToolStripMenuItem1.Size = new System.Drawing.Size(191, 36);
            this.consultasToolStripMenuItem1.Text = "Consultas";
            this.consultasToolStripMenuItem1.Click += new System.EventHandler(this.consultasToolStripMenuItem1_Click);
            // 
            // individualesToolStripMenuItem1
            // 
            this.individualesToolStripMenuItem1.Name = "individualesToolStripMenuItem1";
            this.individualesToolStripMenuItem1.Size = new System.Drawing.Size(215, 36);
            this.individualesToolStripMenuItem1.Text = "Individuales";
            this.individualesToolStripMenuItem1.Click += new System.EventHandler(this.individualesToolStripMenuItem1_Click);
            // 
            // generalesToolStripMenuItem1
            // 
            this.generalesToolStripMenuItem1.Name = "generalesToolStripMenuItem1";
            this.generalesToolStripMenuItem1.Size = new System.Drawing.Size(215, 36);
            this.generalesToolStripMenuItem1.Text = "Generales";
            this.generalesToolStripMenuItem1.Click += new System.EventHandler(this.generalesToolStripMenuItem1_Click);
            // 
            // administradorToolStripMenuItem
            // 
            this.administradorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altasToolStripMenuItem2});
            this.administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            this.administradorToolStripMenuItem.Size = new System.Drawing.Size(176, 36);
            this.administradorToolStripMenuItem.Text = "Administrador";
            // 
            // altasToolStripMenuItem2
            // 
            this.altasToolStripMenuItem2.Name = "altasToolStripMenuItem2";
            this.altasToolStripMenuItem2.Size = new System.Drawing.Size(139, 36);
            this.altasToolStripMenuItem2.Text = "Altas";
            this.altasToolStripMenuItem2.Click += new System.EventHandler(this.altasToolStripMenuItem2_Click);
            // 
            // CierreDeSesion
            // 
            this.CierreDeSesion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CierreDeSesion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CierreDeSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CierreDeSesion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CierreDeSesion.Location = new System.Drawing.Point(680, 447);
            this.CierreDeSesion.Name = "CierreDeSesion";
            this.CierreDeSesion.Size = new System.Drawing.Size(145, 33);
            this.CierreDeSesion.TabIndex = 5;
            this.CierreDeSesion.Text = "Cerrar Sesión";
            this.CierreDeSesion.UseVisualStyleBackColor = false;
            this.CierreDeSesion.Click += new System.EventHandler(this.CierreDeSesion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(212, 637);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "\r\n\r\n\r\nEsta es la clave para \r\nla gestión del tiempo; \r\nVer el valor de \r\ncada mom" +
    "ento";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MenuAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(867, 509);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CierreDeSesion);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "MenuAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Administrador";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem doctorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem individualesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recepcionistaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem individualesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem generalesToolStripMenuItem1;
        private System.Windows.Forms.Button CierreDeSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem administradorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altasToolStripMenuItem2;
    }
}