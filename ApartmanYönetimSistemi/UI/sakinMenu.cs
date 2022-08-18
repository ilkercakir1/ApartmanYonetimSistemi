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
using ApartmanYönetimSistemi.DL;

namespace ApartmanYönetimSistemi.UI
{
    public partial class sakinMenu : Form
    {
        public sakinMenu()
        {
            InitializeComponent();
        }
        







        private string password = "1";
        string toplammaas = "";
        string _odenen ="";
        SqlCommand komut;
        SqlConn baglan = new SqlConn();

        SqlDataReader oku;
        public static string rol = "";


        public void rolsec()
        {
            SqlCommand cmd = new SqlCommand("select * from kullanici where tc_no='" + Giris.giris + "'", baglan.baglan());
            oku=cmd.ExecuteReader();
            if (oku.Read())
            {
                rol = oku["rol"].ToString();
            }
        }

        void toplama()
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Select SUM(tutar)From borclar where kullanici='" + Giris.giris + "'", baglan.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;

                toplammaas = dataGridView1.Rows[0].Cells[0].Value.ToString();

                label2.Text = String.Format("{0:0.00}", double.Parse(toplammaas)) + " TL";

            }
            catch 
            {

                ;
            }
        }

        void odenen()
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Select SUM(miktar)From odenen  where odeyen='" + Giris.giris + "' ", baglan.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView2.DataSource = dt;

                _odenen = dataGridView2.Rows[0].Cells[0].Value.ToString();

                label1.Text = String.Format("{0:0.00}", double.Parse(_odenen)) + " TL";
            }
            catch 
            {

                ;
            }
        }

        void borclarim()
        {
            try
            {

                SqlDataAdapter ad = new SqlDataAdapter("Select * From borclar where kullanici='" + Giris.giris + "'", baglan.baglan());
                DataTable dt = new DataTable();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ad.Fill(dt);
                dataGridView3.DataSource = dt;

                dataGridView3.Columns[0].Visible = false;
                dataGridView3.Columns[1].HeaderText = "Borç Kategorisi";
                dataGridView3.Columns[2].HeaderText = "TC Kimlik No";
                dataGridView3.Columns[3].HeaderText = "Borç Tutarı";
                dataGridView3.Columns[4].HeaderText = "Borç Açıklaması";
                dataGridView3.Columns[5].HeaderText = "Borç Tarihi";
                dataGridView3.Columns[1].Width = 110;
                dataGridView3.Columns[2].Width = 110;
                dataGridView3.Columns[3].Width = 110;
                dataGridView3.Columns[4].Width = 110;
                dataGridView3.Columns[5].Width = 110;
            }
            catch
            {
                ;
            }
        }

        void odedigim()
        {
            try
            {

                SqlDataAdapter ad = new SqlDataAdapter("Select * From odenen where odeyen='" + Giris.giris + "'", baglan.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView4.DataSource = dt;

                dataGridView4.Columns[0].Visible = false;
                dataGridView4.Columns[1].HeaderText = "Ödeyenin TC NO";
                dataGridView4.Columns[2].HeaderText = "Ödenen Miktar";
                dataGridView4.Columns[3].HeaderText = "Ödeme Türü";
                dataGridView4.Columns[1].Width = 120;
                dataGridView4.Columns[2].Width = 120;
                dataGridView4.Columns[3].Width = 118;
            }
            catch
            {
                ;
            }
        }







        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage3);
            tabControl1.SelectedTab = tabPage3;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.SelectedTab = tabPage2;
        }

        private void sakinMenu_Load(object sender, EventArgs e)
        {
            rolsec();
            odedigim();
            borclarim();
            toplama();
            odenen();
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);

        }

        private void sakinMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tabPage2_Leave(object sender, EventArgs e)
        {
          //  tabControl1.TabPages.Remove(tabPage2);
        }

        private void tabPage3_Leave(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
        }
        private void tabPage4_Leave(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.SelectedTab = tabPage1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.SelectedTab = tabPage1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM borclar WHERE kategori LIKE'%" + textBox1.Text + "%' and kullanici='" + Giris.giris + "'or aciklama LIKE '%" + textBox1.Text + "' and kullanici='" + Giris.giris + "'or tutar LIKE '%" + textBox1.Text + "' and kullanici='" + Giris.giris + "'", baglan.baglan());
            ad.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ffff)
        {
            try
            {
                //ÇİZİM BAŞLANGICI
                Font myFont = new Font("Calibri", 9); //font oluşturduk
                SolidBrush sbrush = new SolidBrush(Color.Black);//fırça oluşturduk
                Pen myPen = new Pen(Color.Black); //kalem oluşturduk

                ffff.Graphics.DrawString("Düzenlenme Tarihi: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString(), myFont, sbrush, 50, 25);
                ffff.Graphics.DrawLine(myPen, 25, 45, 770, 45); // Çizgi çizdik... 1. Kalem, 2. X, 3. Y Koordinatı, 4. Uzunluk, 5. BitişX

                myFont = new Font("Calibri", 10, FontStyle.Bold);//Fatura başlığı yazacağımız için fontu kalın yaptık ve puntoyu büyütüp 15 yaptık.
                ffff.Graphics.DrawString("Borç Listesi", myFont, sbrush, 175, 65);
                ffff.Graphics.DrawLine(myPen, 25, 95, 770, 95); //çizgi çizdik.

                myFont = new Font("Calibri", 10, FontStyle.Bold); //Detay başlığını yazacağımız için fontu kalın yapıp puntoyu 10 yaptık.
                ffff.Graphics.DrawString("Kategori", myFont, sbrush, 30, 110); //Detay başlığı
                ffff.Graphics.DrawString("TC No", myFont, sbrush, 90, 110); //Detay başlığı
                ffff.Graphics.DrawString("Tutar", myFont, sbrush, 180, 110); // Detay başlığı
                ffff.Graphics.DrawString("Açıklama", myFont, sbrush, 240, 110); //Detay başlığı
                ffff.Graphics.DrawString("Tarih", myFont, sbrush, 330, 110); //Detay başlığı
                ffff.Graphics.DrawLine(myPen, 25, 130, 770, 125); //Çizgi çizdik.

                int y = 150; //y koordinatının yerini belirledik.(Verilerin yazılmaya başlanacağı yer)

                myFont = new Font("Calibri", 10); //fontu 10 yaptık.

                int i = 0;//satır sayısı için değişken tanımladık.

                while (i <= dataGridView3.Rows.Count)//döngüyü son satırda sonlandıracağız.
                {

                    ffff.Graphics.DrawString(dataGridView3[1, i].Value?.ToString(), myFont, sbrush, 40, y);//1.sütun
                    ffff.Graphics.DrawString(dataGridView3[2, i].Value?.ToString(), myFont, sbrush, 90, y);//2.sütun
                    ffff.Graphics.DrawString(dataGridView3[3, i].Value?.ToString(), myFont, sbrush, 180, y);//3.sütun
                    ffff.Graphics.DrawString(dataGridView3[4, i].Value?.ToString(), myFont, sbrush, 245, y);//4.sütun
                    ffff.Graphics.DrawString(dataGridView3[5, i].Value?.ToString(), myFont, sbrush, 330, y);//5.sütun
                    y += 20; //y koordinatını arttırdık.
                    i += 1; //satır sayısını arttırdık

                    //yeni sayfaya geçme kontrolü
                    if (y > 1000)
                    {
                        ffff.Graphics.DrawString("(Devamı -->)", myFont, sbrush, 700, y + 50);
                        y = 50;
                        break; //burada yazdırma sınırına ulaştığımız için while döngüsünden çıkıyoruz
                               //çıktığımızda while baştan başlıyor i değişkeni değer almaya devam ediyor
                               //yazdırma yeni sayfada başlamış oluyor
                    }
                }
                //çoklu sayfa kontrolü
                if (i < dataGridView3.RowCount - 1)
                {
                    ffff.HasMorePages = true;
                }
                else
                {
                    ffff.HasMorePages = false;
                    i = 0;
                }
                StringFormat myStringFormat = new StringFormat();
                myStringFormat.Alignment = StringAlignment.Far;
            }
            catch
            {
                ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[5];
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

            printDocument1.Print();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (rol == "Apartman Yöneticisi")
            {
                yoneticiMenu menu = new yoneticiMenu();
                menu.Show();
                this.Hide();
            }
            else if (rol == "Sakin")
            {
                Giris menu = new Giris();
                menu.Show();
                this.Hide();
            }
            else if (rol == "Admin")
            {
                adminMenu menu = new adminMenu();
                menu.Show();
                this.Hide();
            }
        }





        private void button5_Click(object sender, EventArgs e)
        {

            tabControl1.TabPages.Add(tabPage4);
            borcdoldur();
            tabControl1.SelectedTab=tabPage4;


        }

        private void button8_Click(object sender, EventArgs e)
        {
            //tabControl1.TabPages.Add(tabPage2);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.SelectedTab = tabPage2;
        }



        public void borcdoldur()
        {

            textBox3.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            textBox7.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            textBox8.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            int kredi = Convert.ToInt16(textBox9.Text);
            int borc = Convert.ToInt32(textBox6.Text);


            if (kredi >= borc)
                {
                    komut = new SqlCommand("insert into odenen (odeyen,	miktar, tarih) values ('" + Giris.giris + "','" + textBox6.Text + "','" + DateTime.Now.ToString() + "')",baglan.baglan());
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Ödeme İşlemi Tamamlandı");
                }
           

        }
    }

}
