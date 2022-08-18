namespace ApartmanYönetimSistemi.UI
{
    partial class adminMenu
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnApartIslemleri = new System.Windows.Forms.Button();
            this.btnIstatistik = new System.Windows.Forms.Button();
            this.btnKategori = new System.Windows.Forms.Button();
            this.btnLoglar = new System.Windows.Forms.Button();
            this.btnGeridon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 38);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 112);
            this.button1.TabIndex = 0;
            this.button1.Text = "Apartman Yönetici İşlemleri";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnApartIslemleri
            // 
            this.btnApartIslemleri.Location = new System.Drawing.Point(342, 38);
            this.btnApartIslemleri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApartIslemleri.Name = "btnApartIslemleri";
            this.btnApartIslemleri.Size = new System.Drawing.Size(224, 112);
            this.btnApartIslemleri.TabIndex = 1;
            this.btnApartIslemleri.Text = "Apartman İşlemleri";
            this.btnApartIslemleri.UseVisualStyleBackColor = true;
            this.btnApartIslemleri.Click += new System.EventHandler(this.btnApartIslemleri_Click);
            // 
            // btnIstatistik
            // 
            this.btnIstatistik.Location = new System.Drawing.Point(32, 178);
            this.btnIstatistik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIstatistik.Name = "btnIstatistik";
            this.btnIstatistik.Size = new System.Drawing.Size(224, 112);
            this.btnIstatistik.TabIndex = 2;
            this.btnIstatistik.Text = "İstatistikler";
            this.btnIstatistik.UseVisualStyleBackColor = true;
            this.btnIstatistik.Click += new System.EventHandler(this.btnIstatistik_Click);
            // 
            // btnKategori
            // 
            this.btnKategori.Location = new System.Drawing.Point(342, 178);
            this.btnKategori.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(224, 112);
            this.btnKategori.TabIndex = 3;
            this.btnKategori.Text = "Borç İşlemleri";
            this.btnKategori.UseVisualStyleBackColor = true;
            this.btnKategori.Click += new System.EventHandler(this.btnKategori_Click);
            // 
            // btnLoglar
            // 
            this.btnLoglar.Location = new System.Drawing.Point(32, 318);
            this.btnLoglar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoglar.Name = "btnLoglar";
            this.btnLoglar.Size = new System.Drawing.Size(224, 112);
            this.btnLoglar.TabIndex = 4;
            this.btnLoglar.Text = "Loglar";
            this.btnLoglar.UseVisualStyleBackColor = true;
            this.btnLoglar.Click += new System.EventHandler(this.btnLoglar_Click);
            // 
            // btnGeridon
            // 
            this.btnGeridon.Location = new System.Drawing.Point(342, 318);
            this.btnGeridon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGeridon.Name = "btnGeridon";
            this.btnGeridon.Size = new System.Drawing.Size(224, 112);
            this.btnGeridon.TabIndex = 5;
            this.btnGeridon.Text = "Giriş Sayfasına Geri Dön";
            this.btnGeridon.UseVisualStyleBackColor = true;
            this.btnGeridon.Click += new System.EventHandler(this.button6_Click);
            // 
            // adminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 490);
            this.Controls.Add(this.btnGeridon);
            this.Controls.Add(this.btnLoglar);
            this.Controls.Add(this.btnKategori);
            this.Controls.Add(this.btnIstatistik);
            this.Controls.Add(this.btnApartIslemleri);
            this.Controls.Add(this.button1);
            this.Name = "adminMenu";
            this.Text = "Admin Paneli";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.adminMenu_FormClosing);
            this.Load += new System.EventHandler(this.adminMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button btnApartIslemleri;
        private Button btnIstatistik;
        private Button btnKategori;
        private Button btnLoglar;
        private Button btnGeridon;
    }
}