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
    public partial class loglar : Form
    {
        public loglar()
        {
            InitializeComponent();
        }

        SqlConn baglan = new SqlConn();

        void Log()
        {
            try
            {

                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM log ORDER BY id DESC", baglan.baglan());
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].HeaderText = "Gerçekleştirilen İşlem";
                dataGridView1.Columns[2].HeaderText = "İpi Adresi";
                dataGridView1.Columns[3].HeaderText = "TC Numarası";
                dataGridView1.Columns[4].HeaderText = "İşlem Açıklaması";
                dataGridView1.Columns[5].HeaderText = "İşlem Tarihi";
                dataGridView1.Columns[1].Width = 130;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 130;
                dataGridView1.Columns[4].Width = 145;
                dataGridView1.Columns[5].Width = 130;
            }
            catch
            {
                ;
            }
        }







        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM log WHERE islem LIKE'%" + textBox1.Text + "%' or ip LIKE '%" + textBox1.Text + "%' or tc LIKE '%" + textBox1.Text + "%'or aciklama LIKE '%" + textBox1.Text + "%'OR tarih LIKE '%" + textBox1.Text + "%' ", baglan.baglan());
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void loglar_Load(object sender, EventArgs e)
        {
            Log();
        }

        private void loglar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminMenu menu = new adminMenu();
            menu.Show();
            this.Hide();
        }
    }
}
