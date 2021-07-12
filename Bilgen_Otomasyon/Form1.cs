using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bilgen_Otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kayitformu firma = new kayitformu();
            firma.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            malzeme_cinsi_tanimlama malzeme = new malzeme_cinsi_tanimlama();
            malzeme.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tanimlama bolge = new tanimlama();
            bolge.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kayit fatura = new Kayit();
            fatura.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fatura_Bilgi fatura_rapor = new Fatura_Bilgi();
            fatura_rapor.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            malzeme_alim_takibi mal = new malzeme_alim_takibi();
            mal.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            odeme_takip odeme = new odeme_takip();
            odeme.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
