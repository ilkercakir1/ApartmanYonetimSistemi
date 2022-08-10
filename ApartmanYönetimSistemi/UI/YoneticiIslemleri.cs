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
using System.IO;
using System.Security.Cryptography;
using System.Net;
using ApartmanYönetimSistemi.DL;
using System.Collections;

namespace ApartmanYönetimSistemi.UI
{
    public partial class YoneticiIslemleri : Form
    {

        public YoneticiIslemleri()
        {
            InitializeComponent();
        }



        private void YoneticiIslemleri_Load(object sender, EventArgs e)
        {
            kullaniciDoldur();
            doldurApartman();
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
        }


        int apartman_id;
        int daire_no;
        int yonetici_id;
        SqlCommand komut;
        string kontrol = "";
        DataSet dset = new DataSet();
        string yetki_gelir = "0";
        string yetki_gider = "0";
        string yetki_kasa = "0";
        string yetki_borc = "0";
        string yetki_daire = "0";
        string yetki_kullanici = "0";
        string bilgisayarAdi = Dns.GetHostName();
        string toplammaas = "";
        string _odenen = "";
        string _borc = "";
        string toplamgelir = "";
        string toplamgider = "";
        double bakiye = 0;
        string secilen = "";
        string _hesaplama = "";
        int hesapla;
        string secili_tc;
        private string password = "1";
        SqlConn bag = new SqlConn();
        string secili_apartman_id = "0";

        void temizle()
        {
            maskedTxtTc.Text = "";
            maskedTxtTel.Text = "";
            txtIsim.Text = "";
            txtSoyisim.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtPassAgain.Text = "";
        }



        void kullaniciDoldur()//gridView Doldurma
        {
            try
            {

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM kullanici", bag.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].HeaderText = "TC Kimlik No";
                dataGridView1.Columns[10].HeaderText = "İsim";
                dataGridView1.Columns[2].HeaderText = "Soyisim";
                dataGridView1.Columns[3].HeaderText = "Email Adresi";
                dataGridView1.Columns[4].HeaderText = "Telefon No";
                dataGridView1.Columns[5].HeaderText = "Apartman No";
                dataGridView1.Columns[6].HeaderText = "Daire";
                dataGridView1.Columns[7].HeaderText = "Ev Durumu";


                dataGridView1.Columns[2].Width = 75;
                dataGridView1.Columns[3].Width = 62;
                dataGridView1.Columns[4].Width = 62;
                dataGridView1.Columns[5].Width = 75;
                dataGridView1.Columns[6].Width = 75;
                dataGridView1.Columns[7].Width = 75;
                dataGridView1.Columns[10].Width = 80;

            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }

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









        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Contains("@") && txtEmail.Text.Contains(".com"))
                {
                    if (txtPass.Text == txtPassAgain.Text)
                    {

                        string sifrelisifre = TextSifrele(txtPassAgain.Text);
                        komut = new SqlCommand("insert into kullanici(tc_no,ad,soyisim,email,telefon,daire_no,ev_durumu,rol,sifre,apartman_id) values('" + maskedTxtTc.Text + "','" + txtIsim.Text + "','" + txtSoyisim.Text + "','" + txtEmail.Text + "','" + maskedTxtTel.Text + "','" + comboDaire.Text + "','" + comboDurum.Text + "','" + comboRol.Text + "','" + sifrelisifre + "','" + secili_apartman_id + "')", bag.baglan());
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Ekleme Başarılı");


                        if (comboRol.Text == "Admin" || comboRol.Text == "Apartman Yöneticisi")
                        {
                            if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked)
                            {
                                yetki_gelir = "1";
                            }
                            else
                            {
                                yetki_gelir = "0";
                            }

                            if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
                            {
                                yetki_gider = "1";
                            }
                            else
                            {
                                yetki_gider = "0";
                            }
                            if (checkedListBox1.GetItemCheckState(2) == CheckState.Checked)
                            {
                                yetki_kasa = "1";
                            }
                            else
                            {
                                yetki_kasa = "0";
                            }
                            if (checkedListBox1.GetItemCheckState(3) == CheckState.Checked)
                            {
                                yetki_borc = "1";
                            }
                            else
                            {
                                yetki_borc = "0";
                            }
                            if (checkedListBox1.GetItemCheckState(4) == CheckState.Checked)
                            {
                                yetki_daire = "1";
                            }
                            else
                            {
                                yetki_daire = "0";
                            }
                            if (checkedListBox1.GetItemCheckState(5) == CheckState.Checked)
                            {
                                yetki_kullanici = "1";
                            }
                            else
                            {
                                yetki_kullanici = "0";
                            }



                            komut = new SqlCommand("insert into yetki(tc,gelir_isleri,gider_isleri,kasa_isleri,borc_isleri,daire_isleri,kullanici_isleri) values('" + maskedTxtTc.Text + "','" + yetki_gelir + "','" + yetki_gider + "','" + yetki_kasa + "','" + yetki_borc + "','" + yetki_daire + "','" + yetki_kullanici + "')", bag.baglan());
                            komut.ExecuteNonQuery();

                            temizle();

                        }


                        kullaniciDoldur();
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Eşleşmiyor");
                    }


                }
                else
                {
                    MessageBox.Show("Lütfen Gerçek Bir Email Giriniz");
                }



            }
            catch (Exception hata)
            {

                MessageBox.Show("Bir hatanız var ! " + hata.Message);
            }
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
                    //comboBox1.Items.Add(oku["apartman_adi"].ToString());
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

                SqlCommand dairegetir = new SqlCommand("select daire_no from kullanici where daire_no="+seciliDaire, bag.baglan());
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





        private void textBox1_TextChanged(object sender, EventArgs e)//arama kutusu
        {
            try
            {

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM kullanici where tc_no LIKE '%" + textBox1.Text + "%'", bag.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.RowHeadersVisible = false; //Gizlenmesini sağlar 
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].HeaderText = "TC Kimlik No";
                dataGridView1.Columns[10].HeaderText = "İsim";
                dataGridView1.Columns[2].HeaderText = "Soyisim";
                dataGridView1.Columns[3].HeaderText = "Email Adresi";
                dataGridView1.Columns[4].HeaderText = "Telefon No";
                dataGridView1.Columns[5].HeaderText = "Apartman No";
                dataGridView1.Columns[6].HeaderText = "Daire";
                dataGridView1.Columns[7].HeaderText = "Ev Durumu";


                dataGridView1.Columns[2].Width = 75;
                dataGridView1.Columns[3].Width = 62;
                dataGridView1.Columns[4].Width = 62;
                dataGridView1.Columns[5].Width = 75;
                dataGridView1.Columns[6].Width = 75;
                dataGridView1.Columns[7].Width = 75;
                dataGridView1.Columns[10].Width = 80;



            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }
        }





        private void YoneticiIslemleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboApartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboDaire.Items.Clear();
            doldurDaire();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komutt = new SqlCommand("delete from kullanici where tc_no='" + dataGridView1.CurrentRow.Cells["tc_no"].Value.ToString() + "'", bag.baglan());
            komutt.ExecuteNonQuery();
            MessageBox.Show("Silme İşlemi Başarılı");

            kullaniciDoldur();
        }

        private void btnKulDuzenle_Click(object sender, EventArgs e)
        {

            string apartadi = "";
            try
            {
                comboDaire.Items.Clear();
                SqlCommand com = new SqlCommand("Select apartman_adi from apartman_islemleri where id='" + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "'", bag.baglan());

                SqlDataReader oku = com.ExecuteReader();
                if (oku.Read())
                {
                    apartadi = oku["apartman_adi"].ToString();


                }


            }
            catch (Exception hata)
            {

                MessageBox.Show("Apartman Listeleme Hatası ! " + hata.Message);
            }

            MaskedTxtTcDuz.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();   //tc
            txtIsimDuz.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();   //isim
            txtSoyisimDuz.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); //soyisim
            txtEmailDuz.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString(); //email
            maskedTxtTelDuz.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); //telefon
                                                                                       //  textBox34.Text = ""; //daire no
            comboApartDuz.Text = apartadi; //apartman adi
            comboDaireDuz.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();//daire no
            comboDurumDuz.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();//durum
            comboRolDuz.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();//rol
            txtPassDuz.Text = TextSifreCoz(dataGridView1.CurrentRow.Cells[9].Value.ToString());//şifreler
            txtPassAgainDuz.Text = TextSifreCoz(dataGridView1.CurrentRow.Cells[9].Value.ToString());// şifreler

            tabControl1.TabPages.Add(tabPage4);
            tabControl1.SelectedTab = tabPage4;
        }

        private void btnYetkiDuzenle_Click(object sender, EventArgs e)
        {
            secili_tc = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtYetkiTc.Text = secili_tc;


            tabControl1.TabPages.Add(tabPage3);
            tabControl1.SelectedTab = tabPage3;
        }

        private void btnYetkiOk_Click(object sender, EventArgs e)
        {
            try
            {
                string yetki_gelir1 = "0";
                string yetki_gider1 = "0";
                string yetki_kasa1 = "0";
                string yetki_borc1 = "0";
                string yetki_daire1 = "0";
                string yetki_kullanici1 = "0";
                if (checkedListBox2.GetItemCheckState(0) == CheckState.Checked)
                {
                    yetki_gelir1 = "1";
                }
                else
                {
                    yetki_gelir1 = "0";
                }

                if (checkedListBox2.GetItemCheckState(1) == CheckState.Checked)
                {
                    yetki_gider1 = "1";
                }
                else
                {
                    yetki_gider1 = "0";
                }
                if (checkedListBox2.GetItemCheckState(2) == CheckState.Checked)
                {
                    yetki_kasa1 = "1";
                }
                else
                {
                    yetki_kasa1 = "0";
                }
                if (checkedListBox2.GetItemCheckState(3) == CheckState.Checked)
                {
                    yetki_borc1 = "1";
                }
                else
                {
                    yetki_borc1 = "0";
                }
                if (checkedListBox2.GetItemCheckState(4) == CheckState.Checked)
                {
                    yetki_daire1 = "1";
                }
                else
                {
                    yetki_daire1 = "0";
                }
                if (checkedListBox2.GetItemCheckState(5) == CheckState.Checked)
                {
                    yetki_kullanici1 = "1";
                }
                else
                {
                    yetki_kullanici1 = "0";
                }



                SqlCommand komutum = new SqlCommand("update yetki set gelir_isleri = '" + yetki_gelir1 + "',gider_isleri = '" + yetki_gider1 + "',kasa_isleri = '" + yetki_kasa1 + "',borc_isleri='" + yetki_borc1 + "',daire_isleri='" + yetki_daire1 + "',kullanici_isleri='" + yetki_kullanici1 + "'  where tc='" + txtYetkiTc.Text + "'", bag.baglan());
                komutum.ExecuteNonQuery();

                MessageBox.Show("Yetkiler Başarıyla Değiştirildi");

                temizle();
                kullaniciDoldur();
                tabControl1.SelectedTab = tabPage2;
                tabControl1.TabPages.Remove(tabPage3);

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void btnDüzenleOk_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand com = new SqlCommand("Select id from apartman_islemleri where apartman_adi='" + comboApartDuz.Text + "'", bag.baglan());

                SqlDataReader oku = com.ExecuteReader();
                if (oku.Read())
                {
                    secili_apartman_id = oku["id"].ToString();


                }


            }
            catch (Exception hata)
            {

                MessageBox.Show("Apartman Listeleme Hatası ! " + hata.Message);
            }

            string sifrelisifre = TextSifrele(txtPassDuz.Text);
            SqlCommand komutum = new SqlCommand("update kullanici set tc_no = '" + MaskedTxtTcDuz.Text + "', ad = '" + txtIsimDuz.Text + "',soyisim = '" + txtSoyisimDuz.Text + "',email='" + txtEmailDuz.Text + "',telefon='" + maskedTxtTelDuz.Text + "',daire_no='" + comboDaireDuz.Text + "',ev_durumu='" + comboDurumDuz.Text + "',rol='" + comboRolDuz.Text + "',sifre='" + sifrelisifre + "',apartman_id='" + secili_apartman_id + "'  where tc_no='" + dataGridView1.CurrentRow.Cells["tc_no"].Value.ToString() + "'", bag.baglan());
            komutum.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşlemi Başarılı");

            kullaniciDoldur();
            MaskedTxtTcDuz.Text = "";   //tc
            txtIsimDuz.Text = "";   //isim
            txtSoyisimDuz.Text = ""; //soyisim
            txtEmailDuz.Text = ""; //email
            maskedTxtTelDuz.Text = ""; //telefon
            comboApartDuz.Text = "";//apartman
            comboDaireDuz.Text = "";//daire no
            comboDurumDuz.Text = "";//durum
            comboRolDuz.Text = "";//rol
            txtPassDuz.Text = "";//şifreler
            txtPassAgainDuz.Text = "";// şifreler

            tabControl1.SelectedTab = tabPage2;
            tabControl1.TabPages.Remove(tabPage4);
        }

        private void tabPage3_Leave(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
        }

        private void tabPage4_Leave(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage4);
        }
    }
}

