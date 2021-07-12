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
namespace Bilgen_Otomasyon
{
    public partial class Fatura_Bilgi : Form
    {
        public Fatura_Bilgi()
        {
            InitializeComponent();
        }



        sqlbaglantisi bag = new sqlbaglantisi();
        public DataTable tablo = new DataTable();
        public DataTable tablo2 = new DataTable();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public SqlCommand kmt = new SqlCommand();
        string matrah, kdv_tutari, toplam, odenen, kalan_borc;
        private void chart1_Click(object sender, EventArgs e)
        {

        }
        public void firmadoldur()
        {
            comboBox1.Items.Clear();
            SqlCommand kdvlistele = new SqlCommand("select * from firma ", bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["firma_adi"].ToString());

            }

        }
        public void doldurocak()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "1" + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='"+comboBox2.Text+"'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                     textBox1.Text = oku[0].ToString() + " TL";
                    textBox24.Text = oku[1].ToString() + " TL";
                    textBox36.Text = oku[2].ToString() + " TL";
                    textBox48.Text = oku[3].ToString() + " TL";
                    textBox60.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }
        public void doldursubat()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "2" + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox2.Text = oku[0].ToString() + " TL";
                    textBox23.Text = oku[1].ToString() + " TL";
                    textBox35.Text = oku[2].ToString() + " TL";
                    textBox47.Text = oku[3].ToString() + " TL";
                    textBox59.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }
        public void doldurmart()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "3" + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox3.Text = oku[0].ToString() + " TL";
                    textBox22.Text = oku[1].ToString() + " TL";
                    textBox34.Text = oku[2].ToString() + " TL";
                    textBox46.Text = oku[3].ToString() + " TL";
                    textBox58.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }
        public void doldurNisan()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "4" + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox6.Text = oku[0].ToString() + " TL";
                    textBox21.Text = oku[1].ToString() + " TL";
                    textBox33.Text = oku[2].ToString() + " TL";
                    textBox45.Text = oku[3].ToString() + " TL";
                    textBox57.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }
        public void doldurMayıs()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "5" + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox5.Text = oku[0].ToString() + " TL";
                    textBox20.Text = oku[1].ToString() + " TL";
                    textBox32.Text = oku[2].ToString() + " TL";
                    textBox44.Text = oku[3].ToString() + " TL";
                    textBox56.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }
        public void doldurhaziran()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "6" + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox4.Text = oku[0].ToString() + " TL";
                    textBox19.Text = oku[1].ToString() + " TL";
                    textBox31.Text = oku[2].ToString() + " TL";
                    textBox43.Text = oku[3].ToString() + " TL";
                    textBox55.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }

        public void doldurtemmuzz()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "7" + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox9.Text = oku[0].ToString() + " TL";
                    textBox18.Text = oku[1].ToString() + " TL";
                    textBox30.Text = oku[2].ToString() + " TL";
                    textBox42.Text = oku[3].ToString() + " TL";
                    textBox54.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }
        public void dolduraustos()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "8" + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox8.Text = oku[0].ToString() + " TL";
                    textBox17.Text = oku[1].ToString() + " TL";
                    textBox29.Text = oku[2].ToString() + " TL";
                    textBox41.Text = oku[3].ToString() + " TL";
                    textBox53.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }
        public void doldureylul()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "9" + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox7.Text = oku[0].ToString() + " TL";
                    textBox16.Text = oku[1].ToString() + " TL";
                    textBox28.Text = oku[2].ToString() + " TL";
                    textBox40.Text = oku[3].ToString() + " TL";
                    textBox52.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }
        public void doldurekim()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "10" + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox12.Text = oku[0].ToString() + " TL";
                    textBox15.Text = oku[1].ToString() + " TL";
                    textBox27.Text = oku[2].ToString() + " TL";
                    textBox39.Text = oku[3].ToString() + " TL";
                    textBox51.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }
        public void doldurkasim()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "11" + "' and firma='" + comboBox1.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox11.Text = oku[0].ToString() + " TL";
                    textBox14.Text = oku[1].ToString() + " TL";
                    textBox26.Text = oku[2].ToString() + " TL";
                    textBox38.Text = oku[3].ToString() + " TL";
                    textBox50.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            doldurocak();
            doldursubat();
            doldurmart();
            doldurNisan();
            doldurMayıs();
            doldurhaziran();
            doldurtemmuzz();
            dolduraustos();
            doldureylul();
            doldurekim();
            doldurkasim();
            doldurAralık();
            yillik();
            try
            {
                ArrayList oranlar = new ArrayList();
                ArrayList down = new ArrayList();
             
                oranlar.Add("Ödenen");
                oranlar.Add("Kalan Borç");
          
             
                down.Add(odenen);
                down.Add(kalan_borc);

                this.chart1.Titles.Clear();
                this.chart1.Series.Clear();
                this.chart1.Series.Add("Yıllık Bazlı Grafik");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                for (int i = 0; i < 2; i++)
                {
                    this.chart1.Series[0].Points.AddXY(oranlar[i].ToString(), double.Parse(down[i].ToString().Substring(0, down[i].ToString().Length - 3)));

                }



            }
            catch 
            {

                ;
            }
        }

        public void doldurAralık()
        {
            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where month(fatura_tarihi)='" + "11" + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    textBox10.Text = oku[0].ToString() + " TL";
                    textBox13.Text = oku[1].ToString() + " TL";
                    textBox25.Text = oku[2].ToString() + " TL";
                    textBox37.Text = oku[3].ToString() + " TL";
                    textBox49.Text = oku[4].ToString() + " TL";

                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

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

        public void yillik()
        {

            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(matrah),sum(kdv_tutari),sum(toplam),sum(odenen),sum(kalan_borc) From fatura where  firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                    matrah = oku[0].ToString().Replace(".", ",");
                    kdv_tutari = oku[1].ToString().Replace(".", ",");
                    toplam = oku[2].ToString().Replace(".", ",");
                    odenen = oku[3].ToString().Replace(".", ",");
                    kalan_borc = oku[4].ToString().Replace(".", ",");

                }
                label22.Text = matrah+" TL";
                label23.Text = kdv_tutari+" TL";
                label24.Text = toplam + " TL";
                label25.Text = odenen + " TL";
                label26.Text = kalan_borc + " TL";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
        }
        public void yillik2()
        {

            try
            {
                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(toplam),sum(odenen),sum(kalan_borc) From fatura where YEAR(fatura_tarihi)='" + DateTime.Now.Year.ToString() + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {
                  
                    textBox61.Text = oku[0].ToString().Replace(".", ",");
                    textBox62.Text = oku[1].ToString().Replace(".", ",");
                    textBox63.Text = oku[2].ToString().Replace(".", ",");

                }
                label32.Text = DateTime.Now.Year.ToString();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
        }
        private void Fatura_Bilgi_Load(object sender, EventArgs e)
        {
            yillik2();
            firmadoldur();
            yillik();
        
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {/*
            doldurocak();
            doldursubat();
            doldurmart();
            doldurNisan();
            doldurMayıs();
            doldurhaziran();
            doldurtemmuzz();
            dolduraustos();
            doldureylul();
            doldurekim();
            doldurkasim();
            doldurAralık();    */           
        }
    }
}
