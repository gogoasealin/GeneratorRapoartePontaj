
namespace GeneratorRaportPontaje
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generareRaportNouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upload_raport_access = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.raport_pontaje_nume_fisier = new System.Windows.Forms.Label();
            this.upload_raport_angajati = new System.Windows.Forms.Button();
            this.raport_angajati_nume_fisier = new System.Windows.Forms.Label();
            this.generator_raport = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(465, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generareRaportNouToolStripMenuItem,
            this.exitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // generareRaportNouToolStripMenuItem
            // 
            this.generareRaportNouToolStripMenuItem.Name = "generareRaportNouToolStripMenuItem";
            this.generareRaportNouToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.generareRaportNouToolStripMenuItem.Text = "Restarteaza Aplicatia";
            this.generareRaportNouToolStripMenuItem.Click += new System.EventHandler(this.generareRaportNouToolStripMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(232, 26);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exit_MenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about_MenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // about_MenuItem
            // 
            this.about_MenuItem.Name = "about_MenuItem";
            this.about_MenuItem.Size = new System.Drawing.Size(139, 26);
            this.about_MenuItem.Text = "Despre";
            this.about_MenuItem.Click += new System.EventHandler(this.about_MenuItem_Click);
            // 
            // upload_raport_access
            // 
            this.upload_raport_access.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upload_raport_access.Location = new System.Drawing.Point(106, 83);
            this.upload_raport_access.Margin = new System.Windows.Forms.Padding(4);
            this.upload_raport_access.Name = "upload_raport_access";
            this.upload_raport_access.Size = new System.Drawing.Size(253, 62);
            this.upload_raport_access.TabIndex = 2;
            this.upload_raport_access.Text = "Upload Raport Access";
            this.upload_raport_access.UseVisualStyleBackColor = true;
            this.upload_raport_access.Click += new System.EventHandler(this.upload_raport_access_Click);
            // 
            // raport_pontaje_nume_fisier
            // 
            this.raport_pontaje_nume_fisier.AutoSize = true;
            this.raport_pontaje_nume_fisier.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raport_pontaje_nume_fisier.Location = new System.Drawing.Point(12, 159);
            this.raport_pontaje_nume_fisier.Name = "raport_pontaje_nume_fisier";
            this.raport_pontaje_nume_fisier.Size = new System.Drawing.Size(126, 22);
            this.raport_pontaje_nume_fisier.TabIndex = 3;
            this.raport_pontaje_nume_fisier.Text = "Nume Raport: ";
            this.raport_pontaje_nume_fisier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upload_raport_angajati
            // 
            this.upload_raport_angajati.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upload_raport_angajati.Location = new System.Drawing.Point(106, 204);
            this.upload_raport_angajati.Margin = new System.Windows.Forms.Padding(4);
            this.upload_raport_angajati.Name = "upload_raport_angajati";
            this.upload_raport_angajati.Size = new System.Drawing.Size(253, 62);
            this.upload_raport_angajati.TabIndex = 4;
            this.upload_raport_angajati.Text = "Upload Raport Angajati";
            this.upload_raport_angajati.UseVisualStyleBackColor = true;
            this.upload_raport_angajati.Click += new System.EventHandler(this.upload_raport_angajati_Click);
            // 
            // raport_angajati_nume_fisier
            // 
            this.raport_angajati_nume_fisier.AutoSize = true;
            this.raport_angajati_nume_fisier.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raport_angajati_nume_fisier.Location = new System.Drawing.Point(12, 288);
            this.raport_angajati_nume_fisier.Name = "raport_angajati_nume_fisier";
            this.raport_angajati_nume_fisier.Size = new System.Drawing.Size(126, 22);
            this.raport_angajati_nume_fisier.TabIndex = 5;
            this.raport_angajati_nume_fisier.Text = "Nume Raport: ";
            this.raport_angajati_nume_fisier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // generator_raport
            // 
            this.generator_raport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generator_raport.Location = new System.Drawing.Point(106, 336);
            this.generator_raport.Margin = new System.Windows.Forms.Padding(4);
            this.generator_raport.Name = "generator_raport";
            this.generator_raport.Size = new System.Drawing.Size(253, 62);
            this.generator_raport.TabIndex = 6;
            this.generator_raport.Text = "Genereaza Raport";
            this.generator_raport.UseVisualStyleBackColor = true;
            this.generator_raport.Click += new System.EventHandler(this.generator_raport_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 411);
            this.Controls.Add(this.generator_raport);
            this.Controls.Add(this.raport_angajati_nume_fisier);
            this.Controls.Add(this.upload_raport_angajati);
            this.Controls.Add(this.raport_pontaje_nume_fisier);
            this.Controls.Add(this.upload_raport_access);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Generator Rapoarte Pontaj - Alexandru Parvu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generareRaportNouToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem about_MenuItem;
        private System.Windows.Forms.Button upload_raport_access;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label raport_pontaje_nume_fisier;
        private System.Windows.Forms.Button upload_raport_angajati;
        private System.Windows.Forms.Label raport_angajati_nume_fisier;
        private System.Windows.Forms.Button generator_raport;
    }
}

