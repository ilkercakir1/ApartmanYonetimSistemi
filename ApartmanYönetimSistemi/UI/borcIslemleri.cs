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
using System.Net;
using ApartmanYönetimSistemi.DL;

namespace ApartmanYönetimSistemi.UI
{
    public partial class borcIslemleri : Form
    {
        public borcIslemleri()
        {
            InitializeComponent();
        }
        SqlConn baglan = new SqlConn();
        SqlCommand komut;

        SqlDataReader oku;
        public static string rol = "";

        string bilgisayarAdi = Dns.GetHostName();

        public void rolsec()
        {
            SqlCommand cmd = new SqlCommand("select * from kullanici where tc_no='" + Giris.giris + "'", baglan.baglan());
            oku = cmd.ExecuteReader();
            if (oku.Read())
            {
                rol = oku["rol"].ToString();
            }
        }


        public void temizle()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }


        public void combodoldur()
        {

            komut = new SqlCommand("select * from borc_tipi", baglan.baglan());
            komut.ExecuteNonQuery();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["borc_tipi"].ToString());

                comboBox4.Items.Add(dr["borc_tipi"].ToString());
            }


            SqlCommand komutt = new SqlCommand("select * from kullanici where rol = 'Apartman Yöneticisi' or rol = 'Sakin'", baglan.baglan());
            komutt.ExecuteNonQuery();
            SqlDataReader drr = komutt.ExecuteReader();
            while (drr.Read())
            {
                comboBox2.Items.Add(drr["tc_no"].ToString());
                comboBox3.Items.Add(drr["tc_no"].ToString());
            }
        }

        void Borclar()
        {
            try
            {

                SqlDataAdapter ad = new SqlDataAdapter("Select borclar.id, borclar.kategori, borclar.kullanici, borclar.tutar, borclar.aciklama, borclar.tarih From borclar inner join kullanici on borclar.kullanici = kullanici.tc_no where rol = 'Apartman Yöneticisi' or  rol = 'Sakin' order by borclar.id desc", baglan.baglan());
                
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].HeaderText = "Borç Kategorisi";
                dataGridView1.Columns[2].HeaderText = "TC Numarası";
                dataGridView1.Columns[3].HeaderText = "Borç Tutarı";
                dataGridView1.Columns[4].HeaderText = "Borç Açıklaması";
                dataGridView1.Columns[5].HeaderText = "Borç Tarihi";
                dataGridView1.Columns[1].Width = 97;
                dataGridView1.Columns[2].Width = 97;
                dataGridView1.Columns[3].Width = 90;
                dataGridView1.Columns[4].Width = 105;
                dataGridView1.Columns[5].Width = 103;
            }
            catch
            {
                ;
            }
        }





        private void borcIslemleri_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
            Borclar();
            combodoldur();
            rolsec();
        }

        private void borcIslemleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM borclar WHERE kategori LIKE'%" + textBox1.Text + "%' or kullanici LIKE '%" + textBox1.Text + "%'or aciklama LIKE '%" + textBox1.Text + "%'OR tutar LIKE '%" + textBox1.Text + "%' ", baglan.baglan());
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                komut = new SqlCommand("insert into borclar(kategori,kullanici,tutar,aciklama,tarih) values('" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + DateTime.Now.ToString() + "')", baglan.baglan());
                komut.ExecuteNonQuery();
                Borclar();
                temizle();
                MessageBox.Show("Borçlandırma İşlemi Başarılı");

            }
            catch
            {

                ;
            }

            SqlCommand log = new SqlCommand("insert into log(islem,ip,tc,aciklama,tarih)values('" + "Borçlandırma İşlemi" + "','" + Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString() + "','" + Giris.giris + "','" + textBox3.Text + "','" + DateTime.Now.ToString() + "')", baglan.baglan());
            log.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komutt = new SqlCommand("delete from borclar where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglan.baglan());
            komutt.ExecuteNonQuery();
            MessageBox.Show("Silme İşlemi Başarılı");


            //log'a ekliyoruz

            SqlCommand log = new SqlCommand("insert into log(islem,ip,tc,aciklama,tarih)values('" + "Borç Silme" + "','" + Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString() + "','" + Giris.giris + "','" + "Borç Silme İşlemi Başarıyla Gerçekleşti." + "','" + DateTime.Now.ToString() + "')", baglan.baglan());
            log.ExecuteNonQuery();

            Borclar();
            temizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _borc;
            comboBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            _borc = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = String.Format("{0:0}", Math.Round(double.Parse(_borc), 0));

            tabControl1.TabPages.Add(tabPage3);
            tabControl1.SelectedTab = tabPage3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand("update borclar set kategori ='" + comboBox4.Text + "',kullanici='" + comboBox3.Text + "',tutar='" + textBox5.Text + "',aciklama='" + textBox4.Text + "'where id = '" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", baglan.baglan());
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşlemi Başarılı");

            //sira loga eklemede hepsi

            SqlCommand log = new SqlCommand("insert into log(islem,ip,tc,aciklama,tarih)values('" + "Borç Güncelleme" + "','" + Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString() + "','" + Giris.giris + "','" + "Borç Güncelleme İşlemi Başarıyla Gerçekleşti." + "','" + DateTime.Now.ToString() + "')", baglan.baglan());
            log.ExecuteNonQuery();

            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.SelectedTab = tabPage1;


            Borclar();
            temizle();
        }

        private void tabPage3_Leave(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
        }

        private void button5_Click(object sender, EventArgs e)
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
    }
}
