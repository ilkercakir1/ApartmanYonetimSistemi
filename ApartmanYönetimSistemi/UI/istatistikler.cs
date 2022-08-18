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
    public partial class istatistikler : Form
    {
        public istatistikler()
        {
            InitializeComponent();
        }


        SqlConn baglan = new SqlConn();
        string toplammaas = "";
        string _odenen = "";

        void kullanici()
        {
            try
            {

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM kullanici", baglan.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        void odenen()
        {
            try
            {

                SqlDataAdapter ad = new SqlDataAdapter("Select SUM(miktar)From odenen", baglan.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView2.DataSource = dt;

                _odenen = dataGridView2.Rows[0].Cells[0].Value.ToString();

                label2.Text = String.Format("{0:0.00}", double.Parse(_odenen)) + " TL";
            }
            catch 
            {
                ;
            }
        }
        void toplama()
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Select SUM(tutar)From borclar", baglan.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView3.DataSource = dt;

                toplammaas = dataGridView3.Rows[0].Cells[0].Value.ToString();

                label1.Text = String.Format("{0:0.00}", double.Parse(toplammaas)) + " TL";
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Aldınız : " + hata.Message);
            }

        }










        private void istatistikler_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void istatistikler_Load(object sender, EventArgs e)
        {
            kullanici();
            toplama();
            odenen();
            int kayitsayisi = dataGridView1.RowCount - 1;
            String.Format("{0:0.##}", label3.Text = kayitsayisi.ToString() + " Kullanıcı");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminMenu menu = new adminMenu();
            menu.Show();
            this.Hide();
        }


    }
}
