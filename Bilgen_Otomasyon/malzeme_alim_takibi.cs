using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Bilgen_Otomasyon
{
    public partial class malzeme_alim_takibi : Form
    {
        public malzeme_alim_takibi()
        {
            InitializeComponent();
        }
        sqlbaglantisi bag = new sqlbaglantisi();
        public DataTable tablo = new DataTable();
        public DataTable tablo2 = new DataTable();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public SqlCommand kmt = new SqlCommand();
        private void malzeme_alim_takibi_Load(object sender, EventArgs e)
        {
            firmadoldur(); 
            malzeme();
        }
        public void malzeme()
        {
            comboBox8.Items.Clear();
            comboBox4.Items.Clear();
            SqlCommand kdvlistele = new SqlCommand("select * from malzeme_cinsi ", bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();

            while (oku.Read())
            {
                comboBox8.Items.Add(oku[1]);

                comboBox4.Items.Add(oku[1]);

            }

        }
        public void firmadoldur()
        {
            comboBox5.Items.Clear();
            comboBox1.Items.Clear();
            SqlCommand kdvlistele = new SqlCommand("select * from firma ", bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["firma_adi"].ToString());
                comboBox5.Items.Add(oku["firma_adi"].ToString());
            }

        }
        public void cek()
        {
            SqlCommand adtr = new SqlCommand("select * From fatura", bag.baglan());
            SqlDataReader oku = adtr.ExecuteReader();
            while (oku.Read())
            {

              

            }
        }
        public void doldur()
        {
            try
            {

                string ay = "";
                switch (comboBox3.Text)
                {
                    case "Ocak":
                        ay = "1";
                        break;
                    case "Şubat":
                        ay = "2";
                        break;
                    case "Mart":
                        ay = "3";
                        break;
                    case "Nisan":
                        ay = "4";
                        break;

                    case "Mayıs":
                        ay = "5";
                        break;
                    case "Haziran":
                        ay = "6";
                        break;
                    case "Temmuz":
                        ay = "7";
                        break;
                    case "Ağustos":
                        ay = "8";
                        break;
                    case "Eylül":
                        ay = "9";
                        break;
                    case "Ekim":
                        ay = "10";
                        break;
                    case "Kasım":
                        ay = "11";
                        break;
                    case "Aralık":
                        ay = "12";
                        break;

                }

                tablo.Clear();

                SqlCommand adtr = new SqlCommand("select sum(miktar) From fatura where month(fatura_tarihi)='" + ay + "' and firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'", bag.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {

                    label6.Text = oku[0].ToString();
                }


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }
        public void dolduryilagore()
        {
            SqlCommand adtr = new SqlCommand("select sum(miktar) From fatura where  firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "'" , bag.baglan());
            SqlDataReader oku = adtr.ExecuteReader();
            while (oku.Read())
            {

               label7.Text = oku[0].ToString();
            }
        }
        public void doldur2()
        {
            SqlCommand adtr = new SqlCommand("select sum(miktar) From fatura where  firma='" + comboBox1.Text + "' and YEAR(fatura_tarihi)='" + comboBox2.Text + "' and malzeme_cinsi='" + comboBox4.Text + "'", bag.baglan());
            SqlDataReader oku = adtr.ExecuteReader();
            while (oku.Read())
            {

                label2.Text = oku[0].ToString();
            }
        }
        public void doldur3()
        {
            try
            {
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where firma='" + comboBox5.Text + "' order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.RowHeadersVisible = false;


                dataGridView1.Columns[6].HeaderText = "Malzeme Cinsi";
                dataGridView1.Columns[7].HeaderText = "Malzeme Özelliği";
                dataGridView1.Columns[8].HeaderText = "Malzeme Miktarı";
                dataGridView1.Columns[9].HeaderText = "Malzeme Birimi";
                dataGridView1.Columns[10].HeaderText = "Birim Fiyatı";
           
                dataGridView1.Columns[6].Width = 138;
                dataGridView1.Columns[7].Width = 138;
                dataGridView1.Columns[8].Width = 138;
                dataGridView1.Columns[9].Width = 138;
                dataGridView1.Columns[10].Width = 138;
                
           
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text=="" || comboBox2.Text=="" ||  comboBox4.Text=="")
            {

                MessageBox.Show("Gerekli Alanları doldurunuz");
            }
            else
            {
           
                doldur2();
                label14.Text = "Seçili Yıl = " + comboBox2.Text + " Seçili Firma = " + comboBox1.Text+" Seçili Malzeme = "+comboBox4.Text;
                try
                {
                    tablo.Clear();

                    SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where firma ='" + comboBox1.Text + "'and YEAR(fatura_tarihi)='" + comboBox2.Text + "'and malzeme_cinsi='" + comboBox4.Text + "' order by id desc", bag.baglan());
                    adtr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    adtr.Dispose();


                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //datagridview1'deki tüm satırı seç    
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[16].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.Columns[14].Visible = false;
                    dataGridView1.Columns[13].Visible = false;
                    dataGridView1.Columns[15].Visible = false;
                    dataGridView1.RowHeadersVisible = false;


                    dataGridView1.Columns[6].HeaderText = "Malzeme Cinsi";
                    dataGridView1.Columns[7].HeaderText = "Malzeme Özelliği";
                    dataGridView1.Columns[8].HeaderText = "Malzeme Miktarı";
                    dataGridView1.Columns[9].HeaderText = "Malzeme Birimi";
                    dataGridView1.Columns[10].HeaderText = "Birim Fiyatı";

                    dataGridView1.Columns[6].Width = 138;
                    dataGridView1.Columns[7].Width = 138;
                    dataGridView1.Columns[8].Width = 138;
                    dataGridView1.Columns[9].Width = 138;
                    dataGridView1.Columns[10].Width = 138;


                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);

                }


            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            doldur3();
            label14.Text ="Seçili Firma = "+comboBox5.Text;
            ufaktantemizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where YEAR(fatura_tarihi)='" + comboBox6.Text+"' order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.RowHeadersVisible = false;


                dataGridView1.Columns[6].HeaderText = "Malzeme Cinsi";
                dataGridView1.Columns[7].HeaderText = "Malzeme Özelliği";
                dataGridView1.Columns[8].HeaderText = "Malzeme Miktarı";
                dataGridView1.Columns[9].HeaderText = "Malzeme Birimi";
                dataGridView1.Columns[10].HeaderText = "Birim Fiyatı";

                dataGridView1.Columns[6].Width = 138;
                dataGridView1.Columns[7].Width = 138;
                dataGridView1.Columns[8].Width = 138;
                dataGridView1.Columns[9].Width = 138;
                dataGridView1.Columns[10].Width = 138;


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
            label14.Text = "Seçili Yıl = " + comboBox6.Text;
            ufaktantemizle();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string ay = "";
            switch (comboBox7.Text)
            {
                case "Ocak":
                    ay = "1";
                    break;
                case "Şubat":
                    ay = "2";
                    break;
                case "Mart":
                    ay = "3";
                    break;
                case "Nisan":
                    ay = "4";
                    break;

                case "Mayıs":
                    ay = "5";
                    break;
                case "Haziran":
                    ay = "6";
                    break;
                case "Temmuz":
                    ay = "7";
                    break;
                case "Ağustos":
                    ay = "8";
                    break;
                case "Eylül":
                    ay = "9";
                    break;
                case "Ekim":
                    ay = "10";
                    break;
                case "Kasım":
                    ay = "11";
                    break;
                case "Aralık":
                    ay = "12";
                    break;
            }

                    try
            {
               

                    
                    tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where  month(fatura_tarihi)='" + ay + "' order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.RowHeadersVisible = false;


                dataGridView1.Columns[6].HeaderText = "Malzeme Cinsi";
                dataGridView1.Columns[7].HeaderText = "Malzeme Özelliği";
                dataGridView1.Columns[8].HeaderText = "Malzeme Miktarı";
                dataGridView1.Columns[9].HeaderText = "Malzeme Birimi";
                dataGridView1.Columns[10].HeaderText = "Birim Fiyatı";

                dataGridView1.Columns[6].Width = 138;
                dataGridView1.Columns[7].Width = 138;
                dataGridView1.Columns[8].Width = 138;
                dataGridView1.Columns[9].Width = 138;
                dataGridView1.Columns[10].Width = 138;


                }
            
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
            label14.Text = "Seçili Ay = " + comboBox7.Text;
            ufaktantemizle();
            /* try
             {
                 tablo.Clear();

                 SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where firma='" + comboBox1.Text + "'and YEAR(fatura_tarihi)='" + comboBox2.Text + "'and monts order by id desc", bag.baglan());
                 adtr.Fill(tablo);
                 dataGridView1.DataSource = tablo;
                 adtr.Dispose();


                 dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                 //datagridview1'deki tüm satırı seç    
                 dataGridView1.Columns[0].Visible = false;
                 dataGridView1.Columns[16].Visible = false;
                 dataGridView1.Columns[17].Visible = false;
                 dataGridView1.Columns[17].Visible = false;
                 dataGridView1.Columns[1].Visible = false;
                 dataGridView1.Columns[2].Visible = false;
                 dataGridView1.Columns[3].Visible = false;
                 dataGridView1.Columns[4].Visible = false;
                 dataGridView1.Columns[5].Visible = false;
                 dataGridView1.Columns[11].Visible = false;
                 dataGridView1.Columns[12].Visible = false;
                 dataGridView1.Columns[14].Visible = false;
                 dataGridView1.Columns[13].Visible = false;
                 dataGridView1.Columns[15].Visible = false;
                 dataGridView1.RowHeadersVisible = false;


                 dataGridView1.Columns[6].HeaderText = "Malzeme Cinsi";
                 dataGridView1.Columns[7].HeaderText = "Malzeme Özelliği";
                 dataGridView1.Columns[8].HeaderText = "Malzeme Miktarı";
                 dataGridView1.Columns[9].HeaderText = "Malzeme Birimi";
                 dataGridView1.Columns[10].HeaderText = "Birim Fiyatı";

                 dataGridView1.Columns[6].Width = 138;
                 dataGridView1.Columns[7].Width = 138;
                 dataGridView1.Columns[8].Width = 138;
                 dataGridView1.Columns[9].Width = 138;
                 dataGridView1.Columns[10].Width = 138;


             }
             catch (Exception hata)
             {

                 MessageBox.Show(hata.Message);

             }
             */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dolduryilagore();
            try
            {
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where firma ='"+comboBox1.Text+"'and YEAR(fatura_tarihi)='" + comboBox2.Text + "' order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.RowHeadersVisible = false;


                dataGridView1.Columns[6].HeaderText = "Malzeme Cinsi";
                dataGridView1.Columns[7].HeaderText = "Malzeme Özelliği";
                dataGridView1.Columns[8].HeaderText = "Malzeme Miktarı";
                dataGridView1.Columns[9].HeaderText = "Malzeme Birimi";
                dataGridView1.Columns[10].HeaderText = "Birim Fiyatı";

                dataGridView1.Columns[6].Width = 138;
                dataGridView1.Columns[7].Width = 138;
                dataGridView1.Columns[8].Width = 138;
                dataGridView1.Columns[9].Width = 138;
                dataGridView1.Columns[10].Width = 138;


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
            label14.Text = "Seçili Yıl = " + comboBox2.Text+" Seçili Firma = " + comboBox1.Text;

        }
        public void ufaktantemizle()
        {
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where malzeme_cinsi='" + comboBox8.Text + "' order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.RowHeadersVisible = false;


                dataGridView1.Columns[6].HeaderText = "Malzeme Cinsi";
                dataGridView1.Columns[7].HeaderText = "Malzeme Özelliği";
                dataGridView1.Columns[8].HeaderText = "Malzeme Miktarı";
                dataGridView1.Columns[9].HeaderText = "Malzeme Birimi";
                dataGridView1.Columns[10].HeaderText = "Birim Fiyatı";

                dataGridView1.Columns[6].Width = 138;
                dataGridView1.Columns[7].Width = 138;
                dataGridView1.Columns[8].Width = 138;
                dataGridView1.Columns[9].Width = 138;
                dataGridView1.Columns[10].Width = 138;


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
            label14.Text = "Seçili Malzeme =" + comboBox8.Text;
            ufaktantemizle();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[17].Visible = false;
               
                dataGridView1.Columns[2].Visible = false;
             
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.RowHeadersVisible = false;

                dataGridView1.Columns[1].HeaderText = "Firma Adı";
                dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
                dataGridView1.Columns[6].HeaderText = "Malzeme Cinsi";
                dataGridView1.Columns[7].HeaderText = "Malzeme Özelliği";
                dataGridView1.Columns[8].HeaderText = "Malzeme Miktarı";
                dataGridView1.Columns[9].HeaderText = "Malzeme Birimi";
                dataGridView1.Columns[10].HeaderText = "Birim Fiyatı";

                dataGridView1.Columns[1].Width = 96;
                dataGridView1.Columns[3].Width = 96;
                dataGridView1.Columns[6].Width = 96;
                dataGridView1.Columns[7].Width = 96;
                dataGridView1.Columns[8].Width = 96;
                dataGridView1.Columns[9].Width = 96;
                dataGridView1.Columns[10].Width = 96;

            }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ay = "";
            switch (comboBox3.Text)
            {
                case "Ocak":
                    ay = "1";
                    break;
                case "Şubat":
                    ay = "2";
                    break;
                case "Mart":
                    ay = "3";
                    break;
                case "Nisan":
                    ay = "4";
                    break;

                case "Mayıs":
                    ay = "5";
                    break;
                case "Haziran":
                    ay = "6";
                    break;
                case "Temmuz":
                    ay = "7";
                    break;
                case "Ağustos":
                    ay = "8";
                    break;
                case "Eylül":
                    ay = "9";
                    break;
                case "Ekim":
                    ay = "10";
                    break;
                case "Kasım":
                    ay = "11";
                    break;
                case "Aralık":
                    ay = "12";
                    break;
            }
            doldur();

            try
            {
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where firma ='" + comboBox1.Text + "'and YEAR(fatura_tarihi)='" + comboBox2.Text + "'and month(fatura_tarihi)='" + ay + "' order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.RowHeadersVisible = false;


                dataGridView1.Columns[6].HeaderText = "Malzeme Cinsi";
                dataGridView1.Columns[7].HeaderText = "Malzeme Özelliği";
                dataGridView1.Columns[8].HeaderText = "Malzeme Miktarı";
                dataGridView1.Columns[9].HeaderText = "Malzeme Birimi";
                dataGridView1.Columns[10].HeaderText = "Birim Fiyatı";

                dataGridView1.Columns[6].Width = 138;
                dataGridView1.Columns[7].Width = 138;
                dataGridView1.Columns[8].Width = 138;
                dataGridView1.Columns[9].Width = 138;
                dataGridView1.Columns[10].Width = 138;


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
            label14.Text = "Seçili Yıl = " + comboBox2.Text + " Seçili Firma = " + comboBox1.Text+" Seçili Ay= "+comboBox3.Text;
        }
    }
    }

   
