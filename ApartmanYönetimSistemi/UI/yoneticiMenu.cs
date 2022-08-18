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
    public partial class yoneticiMenu : Form
    {
        public yoneticiMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kulanıcıEklemePaneli menu = new kulanıcıEklemePaneli();
            menu.Show();
            this.Hide();
        }







        private void yoneticiMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sakinMenu menu = new sakinMenu();
            menu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            borcIslemleri menu = new borcIslemleri();
            menu.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Giris menu = new Giris();
            menu.Show();
            this.Hide();
        }
    }
}
