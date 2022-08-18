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
    public partial class kulanıcıEklemePaneli : Form
    {
        public kulanıcıEklemePaneli()
        {
            InitializeComponent();
        }

        SqlConn bag = new SqlConn();
        SqlCommand komut;
        string secili_apartman_id = "0";
        private string password = "1";


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

        public string TextSifrele(string sifrelenecekMetin)

        {

            byte[] sifrelenecekByteDizisi = System.Text.Encoding.Unicode.GetBytes(sifrelenecekMetin);



            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,



            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});



            byte[] SifrelenmisVeri = Sifrele(sifrelenecekByteDizisi,



                 pdb.GetBytes(32), pdb.GetBytes(16));



            return Convert.ToBase64String(SifrelenmisVeri);

        }





        public void doldurApartman()
        {

            try
            {


                SqlCommand com = new SqlCommand("Select apartman_adi from apartman_islemleri", bag.baglan());

                SqlDataReader oku = com.ExecuteReader();
                while (oku.Read())
                {
                    comboApartman.Items.Add(oku["apartman_adi"].ToString());
                }
            }

            catch (Exception hata)
            {

                MessageBox.Show("Apartman Listeleme Hatası ! " + hata.Message);
            }
        }

        public void doldurDaire()
        {
            SqlCommand com = new SqlCommand("Select daire_sayisi from apartman_islemleri where apartman_adi='" + comboApartman.Text + "'", bag.baglan());

            SqlDataReader oku = com.ExecuteReader();
            oku.Read();

            int dairesayisi = Convert.ToInt32(oku["daire_sayisi"]);

            for (int seciliDaire = 1; seciliDaire < dairesayisi; seciliDaire++)
            {

                SqlCommand dairegetir = new SqlCommand("select daire_no from kullanici where daire_no=" + seciliDaire, bag.baglan());
                SqlDataReader daireler = dairegetir.ExecuteReader();

                //daire sayısı for içinde döndürülerek kontrol sağlanacak. eğer o daire sayısına sahip sakin yoska comboboxa eklenecek.
                if (daireler.Read())
                {

                }
                else
                {
                    comboDaire.Items.Add(seciliDaire);
                }

            }

            try
            {
                SqlCommand apt = new SqlCommand("Select id from apartman_islemleri where apartman_adi='" + comboApartman.Text + "'", bag.baglan());

                SqlDataReader yap = apt.ExecuteReader();
                if (yap.Read())
                {
                    secili_apartman_id = yap["id"].ToString();
                }


            }
            catch (Exception hata)
            {
                MessageBox.Show("Apartman Listeleme Hatası ! " + hata.Message);
            }



        }





        private void kulanıcıEklemePaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void kulanıcıEklemePaneli_Load(object sender, EventArgs e)
        {
            doldurApartman();
        }

        private void comboApartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboDaire.Items.Clear();
            doldurDaire();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == txtPassAgain.Text)
            {
                string sifrelisifre = TextSifrele(txtPass.Text);
                komut = new SqlCommand("insert into kullanici(tc_no,ad,soyisim,email,telefon,daire_no,ev_durumu,rol,sifre,apartman_id) values('" + maskedTxtTc.Text + "','" + txtIsim.Text + "','" + txtSoyisim.Text + "','" + txtEmail.Text + "','" + maskedTxtTel.Text + "','" + comboDaire.Text + "','" + comboDurum.Text + "','" + comboRol.Text + "','" + sifrelisifre + "','" + secili_apartman_id + "')", bag.baglan());
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Ekleme Başarılı");
            }
            else
            {
                MessageBox.Show("Şifreler Eşleşmiyor !");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yoneticiMenu menu = new yoneticiMenu();
            menu.Show();
            this.Hide();
        }
    }
}
