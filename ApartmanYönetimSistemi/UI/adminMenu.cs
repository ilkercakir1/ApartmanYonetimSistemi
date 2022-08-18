using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmanYönetimSistemi.UI
{
    public partial class adminMenu : Form
    {
        public adminMenu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Giris menu = new Giris();
            menu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoneticiIslemleri menu = new YoneticiIslemleri();
            menu.Show();
            this.Hide();
        }

        private void adminMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnApartIslemleri_Click(object sender, EventArgs e)
        {
            ApartmanIslemleri menu = new ApartmanIslemleri();
            menu.Show();
            this.Hide();
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            istatistikler menu = new istatistikler();
            menu.Show();
            this.Hide();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            borcIslemleri menu = new borcIslemleri();
            menu.Show();
            this.Hide();
        }

        private void adminMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnLoglar_Click(object sender, EventArgs e)
        {
            loglar loglar = new loglar();
            loglar.Show();
            this.Hide();
        }
    }
}
