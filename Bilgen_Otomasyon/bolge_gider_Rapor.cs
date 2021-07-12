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
    public partial class bolge_gider_Rapor : Form
    {
        public bolge_gider_Rapor()
        {
            InitializeComponent();
        }

        sqlbaglantisi bag = new sqlbaglantisi();
        public DataTable tablo = new DataTable();
        public DataTable tablo2 = new DataTable();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public SqlCommand kmt = new SqlCommand();
        string iscilik, elektrik, su;



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

                SqlCommand adtr = new SqlCommand("select sum(iscilik),sum(elektirik),sum(su),sum(diger_giderler),sum(toplam) From bolge_gider where  bolge='" + comboBox1.Text  + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox1.Text = oku[0].ToString() + " TL";
                    textBox24.Text = oku[1].ToString() + " TL";
                    textBox36.Text = oku[2].ToString() + " TL";
                    textBox2.Text = oku[3].ToString()+" TL";
                    textBox3.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            doldurocak();
            try
            {
                ArrayList oranlar = new ArrayList();
                ArrayList down = new ArrayList();

                oranlar.Add("İşçilik");
                oranlar.Add("Elektrik");
                oranlar.Add("Su");
                oranlar.Add("Diğer");

                down.Add(textBox1.Text);
                down.Add(textBox24.Text);
                down.Add(textBox36.Text);
                down.Add(textBox2.Text);
                this.chart1.Titles.Clear();
                this.chart1.Series.Clear();
                this.chart1.Series.Add("Genel Gider Grafiği");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                for (int i = 0; i < 4; i++)
                {
                    this.chart1.Series[0].Points.AddXY(oranlar[i].ToString(), double.Parse(down[i].ToString().Substring(0, down[i].ToString().Length - 3)));

                }



            }
            catch
            {

                ;
            }
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bolge_gider_Rapor_Load(object sender, EventArgs e)
        {
            bolgedoldur();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
