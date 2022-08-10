using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using ApartmanYönetimSistemi.DL;

namespace ApartmanYönetimSistemi.UI


{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }



        public static string giris = "";
        public static string sifre = "";
        public static string yetki = "";
        public static string apartman_id = "0";
        public static string yetki_kullanici = "0";
        public static string yetki_gider = "0";
        public static string yetki_gelir = "0";
        public static string yetki_kasa = "0";
        public static string yetki_borc = "0";
        public static string yetki_daire = "0";
        private string password = "1";



        SqlConn baglan = new SqlConn();
        void temizle()
        {
            txtAdminPass.Text = "";
            txtAdminTc.Text = "";
            txtSakinPass.Text = "";
            txtSakinTc.Text = "";
            txtYoneticiPass.Text = "";
            txtYoneticiTc.Text = "";
        }

        private byte[] Sifrele(byte[] SifresizVeri, byte[] Key, byte[] IV)

        {

            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();



            alg.Key = Key;

            alg.IV = IV;



            CryptoStream cs = new CryptoStream(ms,



            alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(SifresizVeri, 0, SifresizVeri.Length);

            cs.Close();



            byte[] sifrelenmisVeri = ms.ToArray();

            return sifrelenmisVeri;

        }


        private byte[] SifreCoz(byte[] SifreliVeri, byte[] Key, byte[] IV)

        {

            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();



            alg.Key = Key;

            alg.IV = IV;



            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);



            cs.Write(SifreliVeri, 0, SifreliVeri.Length);

            cs.Close();



            byte[] SifresiCozulmusVeri = ms.ToArray();

            return SifresiCozulmusVeri;

        }


        public string TextSifrele(string sifrelenecekMetin)

        {

            byte[] sifrelenecekByteDizisi = System.Text.Encoding.Unicode.GetBytes(sifrelenecekMetin);



            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,



            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});



            byte[] SifrelenmisVeri = Sifrele(sifrelenecekByteDizisi,



                 pdb.GetBytes(32), pdb.GetBytes(16));



            return Convert.ToBase64String(SifrelenmisVeri);

        }


        public string TextSifreCoz(string text)

        {

            byte[] SifrelenmisByteDizisi = Convert.FromBase64String(text);



            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,



                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65,



            0x64, 0x76, 0x65, 0x64, 0x65, 0x76});



            byte[] SifresiCozulmusVeri = SifreCoz(SifrelenmisByteDizisi,



                pdb.GetBytes(32), pdb.GetBytes(16));



            return System.Text.Encoding.Unicode.GetString(SifresiCozulmusVeri);

        }



        private void frmGiris_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void btnSakin_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }



        private void btnAdminGir_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand com = new SqlCommand("Select * from kullanici where tc_no='" + txtAdminTc.Text.ToString() +
                    "'and sifre='" + TextSifrele(txtAdminPass.Text.ToString()) + "'", baglan.baglan());
                //tc ve şifre veritabanıyla karşılaştırılır

                SqlDataReader oku = com.ExecuteReader();


                if (oku.Read())
                {
                    giris = txtAdminTc.Text;
                    sifre = txtAdminPass.Text;
                    yetki = oku["rol"].ToString();
                    apartman_id = oku["apartman_id"].ToString();

                    //yetki adminse admin paneline yönlendirilir
                    //formlar arası kullanmak amaçlı public değişkenlere girilen değerleri aldık

                    if (yetki == "Admin")
                    {

                        SqlCommand komut = new SqlCommand("Select * from yetki where tc='" + txtAdminTc.Text.ToString() + "'", baglan.baglan());
                        oku = komut.ExecuteReader();
                        if (oku.Read())
                        {
                            yetki_kullanici = oku["kullanici_isleri"].ToString(); ;
                            yetki_gider = oku["gider_isleri"].ToString();
                            yetki_gelir = oku["gelir_isleri"].ToString();
                            yetki_kasa = oku["kasa_isleri"].ToString();
                            yetki_borc = oku["borc_isleri"].ToString();
                            yetki_daire = oku["daire_isleri"].ToString();
                        }//yetkileri program içi değişkenlere aldık


                        adminMenu menu = new adminMenu();
                        menu.Show();
                        this.Hide();//admin paneline geçiş yaptık 

                    }


                    else if (yetki == "Sakin")//girilen kullanıcının rolü sakin ise sakin paneline yönlendirilir
                    {
                        MessageBox.Show("Admin Değilsiniz ! Sakin Girişi Yapınız");
                    }


                    else if (yetki == "Apartman Yöneticisi")//girilen kullanıcının rolü yonetici ise yonetici paneline yönlendirilir
                    {
                        MessageBox.Show("Admin Değilsiniz ! Apartman Yöneticisi Girişi Yapınız");
                    }


                    else
                    {
                        MessageBox.Show("Bu Tür yetkili Kullanıcı Yok");
                    }
                }

                else
                {
                    MessageBox.Show(" Kullanıcı Bulunamadı ");
                }


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);//hata mesajı

            }
        }

        private void btnYoneticiGir_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand com = new SqlCommand("Select * from kullanici where tc_no='" + txtYoneticiTc.Text.ToString() +
                    "'and sifre='" + TextSifrele(txtYoneticiPass.Text.ToString()) + "'", baglan.baglan());
                //tc ve şifre veritabanıyla karşılaştırılır

                SqlDataReader oku = com.ExecuteReader();


                if (oku.Read())
                {
                    giris = txtYoneticiTc.Text;
                    sifre = txtYoneticiPass.Text;
                    yetki = oku["rol"].ToString();
                    apartman_id = oku["apartman_id"].ToString();

                    //yetki adminse admin paneline yönlendirilir
                    //formlar arası kullanmak amaçlı public değişkenlere girilen değerleri aldık

                    if (yetki == "Apartman Yöneticisi")
                    {

                        SqlCommand komut = new SqlCommand("Select * from yetki where tc='" + txtYoneticiTc.Text.ToString() + "'", baglan.baglan());
                        oku = komut.ExecuteReader();
                        if (oku.Read())
                        {
                            yetki_kullanici = oku["kullanici_isleri"].ToString(); ;
                            yetki_gider = oku["gider_isleri"].ToString();
                            yetki_gelir = oku["gelir_isleri"].ToString();
                            yetki_kasa = oku["kasa_isleri"].ToString();
                            yetki_borc = oku["borc_isleri"].ToString();
                            yetki_daire = oku["daire_isleri"].ToString();
                        }//yetkileri program içi değişkenlere aldık


                        yoneticiMenu menu = new yoneticiMenu();
                        menu.Show();
                        this.Hide();//yönetici paneline geçiş yaptık 

                    }


                    else if (yetki == "Sakin")//girilen kullanıcının rolü sakin ise sakin paneline yönlendirilir
                    {
                        MessageBox.Show("Yönetici Değilsiniz ! Sakin Girişi Yapınız");
                    }


                    else if (yetki == "Admin")//girilen kullanıcının rolü yonetici ise yonetici paneline yönlendirilir
                    {
                        MessageBox.Show("Yönetici Değilsiniz ! Admin Girişi Yapınız");
                    }


                    else
                    {
                        MessageBox.Show("Bu Tür yetkili Kullanıcı Yok");
                    }
                }


                else
                {
                    MessageBox.Show(" Kullanıcı Bulunamadı ");
                }


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);//hata mesajı

            }
        }

        private void btnSakinGir_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand com = new SqlCommand("Select * from kullanici where tc_no='" + txtSakinTc.Text.ToString() +
                    "'and sifre='" + TextSifrele(txtSakinPass.Text.ToString()) + "'", baglan.baglan());
                SqlDataReader oku = com.ExecuteReader();
                if (oku.Read())
                {
                    giris = txtSakinTc.Text;
                    sifre = txtSakinPass.Text;
                    yetki = oku["rol"].ToString();
                    apartman_id = oku["apartman_id"].ToString();

                    if (yetki == "Sakin")
                    {

                        SqlCommand komut = new SqlCommand("Select * from yetki where tc='" + txtSakinTc.Text.ToString() + "'", baglan.baglan());
                        oku = komut.ExecuteReader();
                        if (oku.Read())
                        {
                            yetki_kullanici = oku["kullanici_isleri"].ToString(); ;
                            yetki_gider = oku["gider_isleri"].ToString();
                            yetki_gelir = oku["gelir_isleri"].ToString();
                            yetki_kasa = oku["kasa_isleri"].ToString();
                            yetki_borc = oku["borc_isleri"].ToString();
                            yetki_daire = oku["daire_isleri"].ToString();
                        }
                        sakinMenu menu = new sakinMenu();
                        menu.Show();
                        this.Hide();

                    }
                    else if (yetki == "Apartman Yöneticisi")
                    {
                        MessageBox.Show("Apartman Yöneticisi Girişi Yapınız");
                    }
                    else if (yetki == "Admin")
                    {
                        MessageBox.Show("Apartman Sakini Değilsiniz ! Admin Girişi Yapınız");
                    }
                    else
                    {
                        MessageBox.Show("Bu Tür yetkili Kullanıcı Yok");
                    }

                }
                else
                {
                    MessageBox.Show(" Kullanıcı Bulunamadı ");
                }
            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }
        }

        private void frmGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
