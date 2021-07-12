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
    public partial class odeme_takip : Form
    {
        public odeme_takip()
        {
            InitializeComponent();
        }

        sqlbaglantisi bag = new sqlbaglantisi();
        public DataTable tablo = new DataTable();
        public DataTable tablo2 = new DataTable();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public SqlCommand kmt = new SqlCommand();
        public void turudoldur()
        {
            comboBox1.Items.Clear();
            SqlCommand kdvlistele = new SqlCommand("select * from odeme_turu ", bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["turu"].ToString());

            }

        }
        public void FATURAdoldur()
        {
            comboBox2.Items.Clear();
            SqlCommand kdvlistele = new SqlCommand("select * from firma ", bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku["firma_adi"].ToString());

            }

        }
        public void firmayafaturadoldur()
        {
           /* comboBox3.Items.Clear();
            SqlCommand kdvlistele = new SqlCommand("select * from fatura where firma='"+comboBox2.Text+"' ", bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();
            while (oku.Read())
            {
                comboBox3.Items.Add(oku["fatura_no"].ToString());

            }
            */
        }
        private void odeme_takip_Load(object sender, EventArgs e)
        {
            turudoldur();
            FATURAdoldur();
            doldurodeme();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");


        }
        public void doldurodeme()
        {
            try
            {
                tablo2.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From odeme order by id desc", bag.baglan());
                adtr.Fill(tablo2);
                dataGridView2.DataSource = tablo2;
                adtr.Dispose();


                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.RowHeadersVisible = false;

                dataGridView2.Columns[1].HeaderText = "Firma";
                dataGridView2.Columns[2].HeaderText = "Fatura No";
                dataGridView2.Columns[3].HeaderText = "Ödeme Tarihi";
                dataGridView2.Columns[4].HeaderText = "Ödeme Tutarı";
                dataGridView2.Columns[5].HeaderText = "Ödeme Şekli";
                dataGridView2.Columns[6].HeaderText = "Banka Adı";
       

                dataGridView2.Columns[1].Width = 75;
                dataGridView2.Columns[2].Width = 75;
                dataGridView2.Columns[3].Width = 105;
                dataGridView2.Columns[4].Width = 75;
                dataGridView2.Columns[5].Width = 105;
                dataGridView2.Columns[6].Width = 75;
                

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
        }   
            

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label20.Text = comboBox2.Text;
                try
                {
                    tablo.Clear();

                    SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where firma='"+comboBox2.Text+"' order by id desc", bag.baglan());
                    adtr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    adtr.Dispose();


                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //datagridview1'deki tüm satırı seç    
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[16].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.RowHeadersVisible = false;

                    dataGridView1.Columns[1].HeaderText = "Firma";
                    dataGridView1.Columns[2].HeaderText = "Fatura No";
                    dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
                    dataGridView1.Columns[4].HeaderText = "İrsaliye No";
                    dataGridView1.Columns[5].HeaderText = "İrsaliye Tarihi";
                    dataGridView1.Columns[11].HeaderText = "Matrah";
                    dataGridView1.Columns[12].HeaderText = "KDV Oranı";
                    dataGridView1.Columns[13].HeaderText = "KDV Tutarı";
                    dataGridView1.Columns[14].HeaderText = "Toplam";
                    dataGridView1.Columns[15].HeaderText = "Fatura Tutarı";

                    dataGridView1.Columns[1].Width = 75;
                    dataGridView1.Columns[2].Width = 75;
                    dataGridView1.Columns[3].Width = 105;
                    dataGridView1.Columns[4].Width = 75;
                    dataGridView1.Columns[5].Width = 105;
                    dataGridView1.Columns[11].Width = 75;
                    dataGridView1.Columns[12].Width = 75;
                    dataGridView1.Columns[13].Width = 75;
                    dataGridView1.Columns[14].Width = 75;
                    dataGridView1.Columns[15].Width = 85;

                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                   
                }

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ay = ""; 
            switch (comboBox4.Text)
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

                    SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where month(fatura_tarihi)='"+ay+"' order by id desc", bag.baglan());
                    adtr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    adtr.Dispose();


                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //datagridview1'deki tüm satırı seç    
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[16].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.RowHeadersVisible = false;

                    dataGridView1.Columns[1].HeaderText = "Firma";
                    dataGridView1.Columns[2].HeaderText = "Fatura No";
                    dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
                    dataGridView1.Columns[4].HeaderText = "İrsaliye No";
                    dataGridView1.Columns[5].HeaderText = "İrsaliye Tarihi";
                    dataGridView1.Columns[11].HeaderText = "Matrah";
                    dataGridView1.Columns[12].HeaderText = "KDV Oranı";
                    dataGridView1.Columns[13].HeaderText = "KDV Tutarı";
                    dataGridView1.Columns[14].HeaderText = "Toplam";
                    dataGridView1.Columns[15].HeaderText = "Fatura Tutarı";

                    dataGridView1.Columns[1].Width = 75;
                    dataGridView1.Columns[2].Width = 75;
                    dataGridView1.Columns[3].Width = 105;
                    dataGridView1.Columns[4].Width = 75;
                    dataGridView1.Columns[5].Width = 105;
                    dataGridView1.Columns[11].Width = 75;
                    dataGridView1.Columns[12].Width = 75;
                    dataGridView1.Columns[13].Width = 75;
                    dataGridView1.Columns[14].Width = 75;
                    dataGridView1.Columns[15].Width = 85;

                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                 
                }

            }


        private void button1_Click(object sender, EventArgs e)
        {
            string ay = "";
            switch (comboBox4.Text)
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

                SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where month(fatura_tarihi)='" + ay + "' and firma='"+comboBox2.Text+"' order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();

              

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.RowHeadersVisible = false;

                dataGridView1.Columns[1].HeaderText = "Firma";
                dataGridView1.Columns[2].HeaderText = "Fatura No";
                dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
                dataGridView1.Columns[4].HeaderText = "İrsaliye No";
                dataGridView1.Columns[5].HeaderText = "İrsaliye Tarihi";
                dataGridView1.Columns[11].HeaderText = "Matrah";
                dataGridView1.Columns[12].HeaderText = "KDV Oranı";
                dataGridView1.Columns[13].HeaderText = "KDV Tutarı";
                dataGridView1.Columns[14].HeaderText = "Toplam";
                dataGridView1.Columns[15].HeaderText = "Fatura Tutarı";

                dataGridView1.Columns[1].Width = 75;
                dataGridView1.Columns[2].Width = 75;
                dataGridView1.Columns[3].Width = 105;
                dataGridView1.Columns[4].Width = 75;
                dataGridView1.Columns[5].Width = 105;
                dataGridView1.Columns[11].Width = 75;
                dataGridView1.Columns[12].Width = 75;
                dataGridView1.Columns[13].Width = 75;
                dataGridView1.Columns[14].Width = 75;
                dataGridView1.Columns[15].Width = 85;

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string ay = "";
                switch (comboBox4.Text)
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


                label12.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                label14.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                label13.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                label15.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                label21.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString() + " ₺";
                label24.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                label25.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                label27.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString() + " ₺";

                //
                label29.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString() + " ₺";
                label31.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString()+ " ₺";
                SqlCommand oku = new SqlCommand("select sum(toplam)  From fatura where month(fatura_tarihi)='" + ay + "' and firma='" + comboBox2.Text + "'", bag.baglan());

                object sum = oku.ExecuteScalar();
                label17.Text = sum.ToString() + " ₺";




            }
            catch
            {

                ;
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand ekle = new SqlCommand("insert into odeme(firma_adi,fatura_no,odeme_tarihi,odeme_tutari,odeme_sekli,banka_adi) values('"+comboBox2.Text+"','"+label12.Text+"','"+textBox2.Text+"','"+textBox1.Text.Replace(",", ".") + "','"+comboBox1.Text+"','"+textBox3.Text+"')", bag.baglan());
            ekle.ExecuteNonQuery();
            MessageBox.Show("Ödeme İşlemi Alınmıştır");
            double kalan = double.Parse(label25.Text) - double.Parse(textBox1.Text);
        SqlCommand guncelle = new SqlCommand("update fatura set kalan_borc='" + kalan.ToString().Replace(",", ".") +"',odenen='"+textBox1.Text.Replace(",", ".") + "'where fatura_no='" + label12.Text + "'", bag.baglan());
                                                         guncelle.ExecuteNonQuery();



          
                label20.Text = comboBox2.Text;
                try
                {
                    tablo.Clear();

                    SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where firma='" + comboBox2.Text + "' order by id desc", bag.baglan());
                    adtr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    adtr.Dispose();


                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //datagridview1'deki tüm satırı seç    
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[16].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.RowHeadersVisible = false;

                    dataGridView1.Columns[1].HeaderText = "Firma";
                    dataGridView1.Columns[2].HeaderText = "Fatura No";
                    dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
                    dataGridView1.Columns[4].HeaderText = "İrsaliye No";
                    dataGridView1.Columns[5].HeaderText = "İrsaliye Tarihi";
                    dataGridView1.Columns[11].HeaderText = "Matrah";
                    dataGridView1.Columns[12].HeaderText = "KDV Oranı";
                    dataGridView1.Columns[13].HeaderText = "KDV Tutarı";
                    dataGridView1.Columns[14].HeaderText = "Toplam";
                    dataGridView1.Columns[15].HeaderText = "Fatura Tutarı";

                    dataGridView1.Columns[1].Width = 75;
                    dataGridView1.Columns[2].Width = 75;
                    dataGridView1.Columns[3].Width = 105;
                    dataGridView1.Columns[4].Width = 75;
                    dataGridView1.Columns[5].Width = 105;
                    dataGridView1.Columns[11].Width = 75;
                    dataGridView1.Columns[12].Width = 75;
                    dataGridView1.Columns[13].Width = 75;
                    dataGridView1.Columns[14].Width = 75;
                    dataGridView1.Columns[15].Width = 85;

                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);

            }


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            doldurodeme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doldurodeme();
            panel1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("delete from odeme where id='" + dataGridView2.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
            sil.ExecuteNonQuery();
            MessageBox.Show("Silme İşlemi Başarılı");
            doldurodeme();
            //veriyi sil
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fatura_Bilgi frm = new Fatura_Bilgi();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where YEAR(fatura_tarihi)='" + comboBox3.Text + "' order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.RowHeadersVisible = false;

                dataGridView1.Columns[1].HeaderText = "Firma";
                dataGridView1.Columns[2].HeaderText = "Fatura No";
                dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
                dataGridView1.Columns[4].HeaderText = "İrsaliye No";
                dataGridView1.Columns[5].HeaderText = "İrsaliye Tarihi";
                dataGridView1.Columns[11].HeaderText = "Matrah";
                dataGridView1.Columns[12].HeaderText = "KDV Oranı";
                dataGridView1.Columns[13].HeaderText = "KDV Tutarı";
                dataGridView1.Columns[14].HeaderText = "Toplam";
                dataGridView1.Columns[15].HeaderText = "Fatura Tutarı";

                dataGridView1.Columns[1].Width = 75;
                dataGridView1.Columns[2].Width = 75;
                dataGridView1.Columns[3].Width = 105;
                dataGridView1.Columns[4].Width = 75;
                dataGridView1.Columns[5].Width = 105;
                dataGridView1.Columns[11].Width = 75;
                dataGridView1.Columns[12].Width = 75;
                dataGridView1.Columns[13].Width = 75;
                dataGridView1.Columns[14].Width = 75;
                dataGridView1.Columns[15].Width = 85;

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }

        }

    }
}
    

