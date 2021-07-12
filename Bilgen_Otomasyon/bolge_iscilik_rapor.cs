using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
namespace Bilgen_Otomasyon
{
    public partial class bolge_iscilik_rapor : Form
    {
        public bolge_iscilik_rapor()
        {
            InitializeComponent();
        }
        sqlbaglantisi bag = new sqlbaglantisi();
        public DataTable tablo = new DataTable();
        public DataTable tablo2 = new DataTable();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public SqlCommand kmt = new SqlCommand();
        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void bolgedoldur()
        {
            comboBox1.Items.Clear();
            SqlCommand kdvlistele = new SqlCommand("select * from bolge_gider ", bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["bolge"].ToString());

            }

        }

        public void doldurocak()
        {

            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(isci_sayisi),sum(net_ucret),sum(sgk_primi),sum(sgd_primi),sum(gelir_vergisi),sum(damga_vergisi),sum(issizlik_sigorta_kesintisi),sum(toplam) From bolge_iscilik_gider where  bolge='" + comboBox1.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox4.Text = oku[0].ToString() + " Kişi";
                    textBox1.Text = oku[1].ToString() + " TL";
                    textBox24.Text = oku[2].ToString() + " TL";
                    textBox36.Text = oku[3].ToString() + " TL";
                    textBox2.Text = oku[4].ToString() + " TL";//gelir vergisi
                    textBox7.Text = oku[5].ToString() + " TL";
                    textBox8.Text = oku[6].ToString() + " TL";
                    textBox3.Text = oku[7].ToString() + " TL";
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }

        private void bolge_iscilik_rapor_Load(object sender, EventArgs e)
        {
            bolgedoldur();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            doldurocak();
            try
            {
                ArrayList oranlar = new ArrayList();
                ArrayList down = new ArrayList();

                oranlar.Add("Net Ücret");
                oranlar.Add("SGK Primi");
                oranlar.Add("SGD Primi");
                oranlar.Add("i.S.Kesintisi");
                oranlar.Add("Damga Vergisi");
                oranlar.Add("Gelir Vergisi");
               


                down.Add(textBox1.Text);
                down.Add(textBox24.Text);
                down.Add(textBox36.Text);
                down.Add(textBox8.Text);
                down.Add(textBox7.Text);
                down.Add(textBox2.Text);
                this.chart1.Titles.Clear();
                this.chart1.Series.Clear();
                this.chart1.Series.Add("Bölge İşçilik Gider Grafiği");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                for (int i = 0; i < 6; i++)
                {
                    this.chart1.Series[0].Points.AddXY(oranlar[i].ToString(), double.Parse(down[i].ToString().Substring(0, down[i].ToString().Length - 3)));

                }



            }
            catch
            {

                ;
            }
        }
    }
}
