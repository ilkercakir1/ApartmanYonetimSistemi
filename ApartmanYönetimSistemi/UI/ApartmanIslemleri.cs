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
using ApartmanYönetimSistemi.DL;

namespace ApartmanYönetimSistemi.UI
{
    public partial class ApartmanIslemleri : Form
    {
        public ApartmanIslemleri()
        {
            InitializeComponent();
        }

        SqlConn baglan = new SqlConn();
        void temizle()
        {//ekleme silme güncelleme gibi işlemlerden sonra textboxlarımızı boşaltıyoruz

            textBox1.Text = "";

            textBox3.Text = "";

            textBox2.Text = "";

            textBox4.Text = "";
        }


        void apartmandoldur()
        {
            try
            {

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM apartman_islemleri", baglan.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.RowHeadersVisible = false; //Gizlenmesini sağlar 
                dataGridView1.Columns[5].Visible = false;

                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].HeaderText = "Apartman Adı";
                dataGridView1.Columns[2].HeaderText = "Blok";
                dataGridView1.Columns[3].HeaderText = "Apartman Adresi";
                dataGridView1.Columns[4].HeaderText = "Daire Sayısı";



                dataGridView1.Columns[2].Width = 50;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[1].Width = 120;

            }
            catch
            {
                ;
            }
        }

        private void ApartmanIslemleri_Load(object sender, EventArgs e)
        {
            apartmandoldur();
        }

        private void ApartmanIslemleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();   //apartman adı
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();   //blok
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString(); //adres
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); //daire sayisi
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand guncelle = new SqlCommand("update apartman_islemleri set apartman_adi='" + textBox1.Text + "',blok='" + textBox2.Text + "',adres='" + textBox3.Text + "',daire_sayisi='" + textBox4.Text + "' where id ='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglan.baglan());
                guncelle.ExecuteNonQuery();
                temizle();//ekranı temizledik
                MessageBox.Show("Güncelleme İşlemi Başarılı");//başarılı mesajımızı verdik
                apartmandoldur();
            }
            catch (Exception hata)//hata alirsa içeri giricek
            {


                //hata mesajını bırakacak
                MessageBox.Show(hata.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sil = new SqlCommand("delete from apartman_islemleri where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglan.baglan());// sql silme komutumuzu yazdık ve değerlerimizi veritabanından çıkardık
                sil.ExecuteNonQuery();
                temizle();//ekranı temizledik
                MessageBox.Show("Silme İşlemi Başarılı");//başarılı mesajımızı verdik
                apartmandoldur();

            }
            catch (Exception hata)//hata alirsa içeri giricek
            {

                //hata mesajını bırakacak
                MessageBox.Show(hata.Message);
            }
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand ekle = new SqlCommand("insert into apartman_islemleri(apartman_adi,blok,adres,daire_sayisi) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", baglan.baglan());
                ekle.ExecuteNonQuery();//sql ekleme komutumuzu yazdık ve değerlerimizi veritabanına işledik
                temizle();//ekranı temizledik
                MessageBox.Show("Ekleme İşlemi Başarılı");//başarılı mesajımızı verdik
                apartmandoldur();
            }
            catch (Exception hata)//hata alirsa içeri giricek
            {
                //hata mesajını bırakacak
                MessageBox.Show(hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminMenu menu = new adminMenu();
            menu.Show();
            this.Hide();
        }
    }
}
