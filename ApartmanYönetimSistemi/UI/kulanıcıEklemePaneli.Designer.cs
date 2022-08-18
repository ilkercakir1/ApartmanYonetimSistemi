namespace ApartmanYönetimSistemi.UI
{
    partial class kulanıcıEklemePaneli
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboRol = new System.Windows.Forms.ComboBox();
            this.comboDurum = new System.Windows.Forms.ComboBox();
            this.comboDaire = new System.Windows.Forms.ComboBox();
            this.comboApartman = new System.Windows.Forms.ComboBox();
            this.maskedTxtTel = new System.Windows.Forms.MaskedTextBox();
            this.maskedTxtTc = new System.Windows.Forms.MaskedTextBox();
            this.txtPassAgain = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoyisim = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIsim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboRol);
            this.groupBox1.Controls.Add(this.comboDurum);
            this.groupBox1.Controls.Add(this.comboDaire);
            this.groupBox1.Controls.Add(this.comboApartman);
            this.groupBox1.Controls.Add(this.maskedTxtTel);
            this.groupBox1.Controls.Add(this.maskedTxtTc);
            this.groupBox1.Controls.Add(this.txtPassAgain);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSoyisim);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIsim);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 381);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kullanıcı Ekleme Paneli";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ApartmanYönetimSistemi.Properties.Resources.logo_transparent;
            this.pictureBox1.Location = new System.Drawing.Point(232, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 237);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(232, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 69);
            this.button1.TabIndex = 47;
            this.button1.Text = "Kullanıcı Ekle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboRol
            // 
            this.comboRol.Enabled = false;
            this.comboRol.FormattingEnabled = true;
            this.comboRol.Items.AddRange(new object[] {
            "Admin",
            "Apartman Yöneticisi",
            "Sakin"});
            this.comboRol.Location = new System.Drawing.Point(115, 279);
            this.comboRol.Name = "comboRol";
            this.comboRol.Size = new System.Drawing.Size(89, 23);
            this.comboRol.TabIndex = 38;
            this.comboRol.Text = "Sakin";
            // 
            // comboDurum
            // 
            this.comboDurum.FormattingEnabled = true;
            this.comboDurum.Items.AddRange(new object[] {
            "Ev Sahibi",
            "Kiracı",
            "Aprtman Görevlisi"});
            this.comboDurum.Location = new System.Drawing.Point(115, 250);
            this.comboDurum.Name = "comboDurum";
            this.comboDurum.Size = new System.Drawing.Size(89, 23);
            this.comboDurum.TabIndex = 36;
            // 
            // comboDaire
            // 
            this.comboDaire.FormattingEnabled = true;
            this.comboDaire.Location = new System.Drawing.Point(115, 221);
            this.comboDaire.Name = "comboDaire";
            this.comboDaire.Size = new System.Drawing.Size(89, 23);
            this.comboDaire.TabIndex = 35;
            // 
            // comboApartman
            // 
            this.comboApartman.FormattingEnabled = true;
            this.comboApartman.Location = new System.Drawing.Point(115, 192);
            this.comboApartman.Name = "comboApartman";
            this.comboApartman.Size = new System.Drawing.Size(89, 23);
            this.comboApartman.TabIndex = 33;
            this.comboApartman.SelectedIndexChanged += new System.EventHandler(this.comboApartman_SelectedIndexChanged);
            // 
            // maskedTxtTel
            // 
            this.maskedTxtTel.Location = new System.Drawing.Point(115, 163);
            this.maskedTxtTel.Mask = "(999) 0000000";
            this.maskedTxtTel.Name = "maskedTxtTel";
            this.maskedTxtTel.Size = new System.Drawing.Size(89, 23);
            this.maskedTxtTel.TabIndex = 32;
            // 
            // maskedTxtTc
            // 
            this.maskedTxtTc.Location = new System.Drawing.Point(115, 48);
            this.maskedTxtTc.Mask = "00000000000";
            this.maskedTxtTc.Name = "maskedTxtTc";
            this.maskedTxtTc.Size = new System.Drawing.Size(89, 23);
            this.maskedTxtTc.TabIndex = 26;
            // 
            // txtPassAgain
            // 
            this.txtPassAgain.Location = new System.Drawing.Point(115, 337);
            this.txtPassAgain.Name = "txtPassAgain";
            this.txtPassAgain.Size = new System.Drawing.Size(89, 23);
            this.txtPassAgain.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 340);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 46;
            this.label9.Text = "Şifre Tekrarı:";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(115, 308);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(89, 23);
            this.txtPass.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(71, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 45;
            this.label10.Text = "Şifre:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(77, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 15);
            this.label11.TabIndex = 44;
            this.label11.Text = "Rol:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 43;
            this.label5.Text = "Durum:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 42;
            this.label6.Text = "Daire No:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 40;
            this.label7.Text = "Apartman Adı:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 37;
            this.label8.Text = "Telefon:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(115, 134);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(89, 23);
            this.txtEmail.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Email:";
            // 
            // txtSoyisim
            // 
            this.txtSoyisim.Location = new System.Drawing.Point(115, 105);
            this.txtSoyisim.Name = "txtSoyisim";
            this.txtSoyisim.Size = new System.Drawing.Size(89, 23);
            this.txtSoyisim.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "Soyisim:";
            // 
            // txtIsim
            // 
            this.txtIsim.Location = new System.Drawing.Point(115, 76);
            this.txtIsim.Name = "txtIsim";
            this.txtIsim.Size = new System.Drawing.Size(89, 23);
            this.txtIsim.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "İsim:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tc No:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(440, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 30);
            this.button2.TabIndex = 49;
            this.button2.Text = "Geri Dön";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // kulanıcıEklemePaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 405);
            this.Controls.Add(this.groupBox1);
            this.Name = "kulanıcıEklemePaneli";
            this.Text = "kulanıcıEklemePaneli";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.kulanıcıEklemePaneli_FormClosing);
            this.Load += new System.EventHandler(this.kulanıcıEklemePaneli_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private ComboBox comboRol;
        private ComboBox comboDurum;
        private ComboBox comboDaire;
        private ComboBox comboApartman;
        private MaskedTextBox maskedTxtTel;
        private MaskedTextBox maskedTxtTc;
        private TextBox txtPassAgain;
        private Label label9;
        private TextBox txtPass;
        private Label label10;
        private Label label11;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtSoyisim;
        private Label label4;
        private TextBox txtIsim;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Button button2;
    }
}