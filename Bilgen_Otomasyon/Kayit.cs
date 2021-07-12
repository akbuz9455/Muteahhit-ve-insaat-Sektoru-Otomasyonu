using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml;

namespace Bilgen_Otomasyon
{
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }

        sqlbaglantisi bag = new sqlbaglantisi();
        public DataTable tablo = new DataTable();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public SqlCommand kmt = new SqlCommand();

        public object DateTimePicker1 { get; private set; }

        void dovizdoldur()
        {
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

            decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));

            decimal Euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));

            label27.Text = dolar.ToString()+" $";
            label28.Text = Euro.ToString()+" Euro";
        }
        public void tertemizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
           /* label19.Text = "";
            label17.Text = "";*/
        }
        public void doldur()
        {

            try
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
                dataGridView1.RowHeadersVisible = false;
              
                dataGridView1.Columns[1].HeaderText = "Firma";
                dataGridView1.Columns[2].HeaderText = "Fatura No";
                dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
                dataGridView1.Columns[4].HeaderText = "İrsaliye No";
                dataGridView1.Columns[5].HeaderText = "İrsaliye Tarihi";
                dataGridView1.Columns[6].HeaderText = "Malzeme Cinsi";
                //
                dataGridView1.Columns[7].HeaderText = "Özellikleri";
                dataGridView1.Columns[8].HeaderText = "Miktarı";
                dataGridView1.Columns[9].HeaderText = "Birimi";
                dataGridView1.Columns[10].HeaderText = "Birim Fiyat";
                dataGridView1.Columns[11].HeaderText = "Matrah";
                dataGridView1.Columns[12].HeaderText = "KDV Oranı";
                //
                dataGridView1.Columns[13].HeaderText = "KDV Tutarı";
                dataGridView1.Columns[14].HeaderText = "Toplam";
                dataGridView1.Columns[15].HeaderText = "Fatura Tutarı";
              
                dataGridView1.Columns[1].Width = 65;
                dataGridView1.Columns[2].Width = 65;
                dataGridView1.Columns[3].Width = 65;
                dataGridView1.Columns[4].Width = 65;
                dataGridView1.Columns[5].Width = 65;
                dataGridView1.Columns[6].Width = 65;
                dataGridView1.Columns[7].Width = 65;
                dataGridView1.Columns[8].Width = 50;
                dataGridView1.Columns[9].Width = 45;
                dataGridView1.Columns[10].Width = 45;
                dataGridView1.Columns[11].Width = 65;
                dataGridView1.Columns[12].Width = 45;
                dataGridView1.Columns[13].Width = 65;
                dataGridView1.Columns[14].Width = 65;
                dataGridView1.Columns[15].Width = 65;

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                throw;
            }

        }



        public void kdvdoldur()
        {
            comboBox5.Items.Clear();

            SqlCommand kdvlistele = new SqlCommand("select * from kdv ",bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();
            while (oku.Read())
            {
                comboBox5.Items.Add(oku["oran"].ToString());
                
            }

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

        public void birimdoldur()
        {
            comboBox4.Items.Clear();
            SqlCommand kdvlistele = new SqlCommand("select * from birim ", bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();
            while (oku.Read())
            {
                comboBox4.Items.Add(oku["birim_adi"].ToString());

            }

        }
        public void malzeme()
        {
            comboBox2.Items.Clear();
            SqlCommand kdvlistele = new SqlCommand("select * from malzeme_cinsi ", bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();
            
            while (oku.Read())
            {


                comboBox2.Items.Add(oku[1]);    

            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Kayit_Load(object sender, EventArgs e)
        {
          
          
            malzeme();
            doldur();
            kdvdoldur();
            dovizdoldur();
            firmadoldur();
            birimdoldur();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                label19.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                comboBox5.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                label17.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
             
              


            }
            catch
            {

                ;
            }

           

        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process Process = new Process();
            ProcessStartInfo ProcessInfo;
            ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + "calc");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;

            Process = Process.Start(ProcessInfo);
            Process.WaitForExit();
            Process.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            SqlCommand kdvlistele = new SqlCommand("select * from malzeme_table where adi='"+comboBox2.Text+"' ", bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();

            while (oku.Read())
            {


                comboBox3.Items.Add(oku[2]);

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
            textBox2.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = dateTimePicker2.Value.Date.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
     
            try
            {
                DateTime tarih = DateTime.Parse(textBox2.Text);
                SqlCommand ekle = new SqlCommand("insert into fatura(firma,fatura_no,fatura_tarihi,irsaliye_no,irsaliye_tarihi,malzeme_cinsi,malzeme_ozellik,miktar,birimi,birim_fiyat,matrah,kdv_orani,kdv_tutari,toplam,fatura_tutari) VALUES ('" + comboBox1.Text + "','" + textBox1.Text + "','" + tarih.ToString("MM/dd/yyyy") + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + int.Parse(textBox5.Text) + "','" + comboBox4.Text + "','" + textBox6.Text + "','" + textBox7.Text.Replace(",", ".") + "','" + comboBox5.Text + "','" + textBox8.Text.Replace(",", ".") + "','" + textBox9.Text.Replace(",", ".") + "','"+label17.Text.Replace(",", ".") + "') ", bag.baglan());
                ekle.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleminiz Başarılı");
               

               


                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
        
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
               
                fatura_tutar();
                doldur();
            }
            catch (Exception hata)
            {
                MessageBox.Show(""+hata.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //oku
                SqlCommand oku = new SqlCommand("select sum(toplam) from fatura where fatura_no='" + textBox1.Text + "'", bag.baglan());

                object sum = oku.ExecuteScalar();
                label17.Text = (double.Parse(sum.ToString()) - double.Parse(textBox9.Text)).ToString().Replace(".", ",");
                //işlem yap
               SqlCommand sil = new SqlCommand("delete from fatura where id='"+ dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'",bag.baglan());
                sil.ExecuteNonQuery();
                //veriyi sil
               SqlCommand guncelle = new SqlCommand("update fatura set fatura_tutari='" + label17.Text.Replace(",", ".") + "'where fatura_no='" + textBox1.Text + "'", bag.baglan());
                guncelle.ExecuteNonQuery();
                //güncellenen fatura tutarını yazdır
                MessageBox.Show("Silme İşleminiz Başarılı");
                doldur();
                //gridwiew yenile
                tertemizle();
                //text kutularını temizle

            }
            catch (Exception hata)
            {
                
                MessageBox.Show("Alttan Geçerli Bir Kayıt Seçtiğinize Emin Olunuz..."+hata.Message);
                //hata durumunda gerçekleşicek mesaj 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                DateTime tarih = DateTime.Parse(textBox2.Text);
                SqlCommand guncelle = new SqlCommand("update fatura set firma='" + comboBox1.Text + "',fatura_no ='" + textBox1.Text + "',fatura_tarihi='" + tarih.ToString("MM/dd/yyyy") + "',irsaliye_no='" + textBox3.Text + "',irsaliye_tarihi='" + textBox4.Text + "',malzeme_cinsi='" + comboBox2.Text + "',malzeme_ozellik='" + comboBox3.Text + "',miktar='" + int.Parse(textBox5.Text) + "',birimi='" + comboBox4.Text + "',birim_fiyat='" + textBox6.Text + "',matrah='" + textBox7.Text.Replace(",", ".") + "',kdv_orani='" + comboBox5.Text + "',kdv_tutari='" + textBox8.Text.Replace(",", ".") + "',toplam='" + textBox9.Text.Replace(",", ".") + "',fatura_tutari='" + label17.Text.Replace(",", ".") + "' where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
                guncelle.ExecuteNonQuery();

                SqlCommand oku = new SqlCommand("select sum(toplam) from fatura where fatura_no='" + textBox1.Text + "'", bag.baglan());

                object sum = oku.ExecuteScalar();
                label17.Text = sum.ToString();
                SqlCommand guncelle2 = new SqlCommand("update fatura set fatura_tutari='" + sum.ToString().Replace(",", ".") + "'where fatura_no='" + textBox1.Text + "'", bag.baglan());
                guncelle2.ExecuteNonQuery();

                doldur();
                MessageBox.Show("Güncelleme İşleminiz Başarı İle Gerçekleşti.");
                tertemizle();

            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata aldınız"+ hata.Message);
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where fatura_tarihi like'%" +textBox12.Text + "%'", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();

            if (textBox12.Text == "")
            {
                doldur();
            }

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();

            SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where firma like'%" + textBox10.Text + "%'", bag.baglan());
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();

           
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();

            SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where malzeme_cinsi like'%" + textBox11.Text + "%'or malzeme_ozellik like '%" + textBox11.Text + "%'or kdv_tutari like '%" + textBox11.Text + "%'or toplam like '%" + textBox11.Text + "%'or fatura_tutari like '%" + textBox11.Text + "%'", bag.baglan());
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tarih = DateTime.Parse(textBox2.Text);

                SqlCommand ekle = new SqlCommand("insert into fatura(firma,fatura_no,fatura_tarihi,irsaliye_no,irsaliye_tarihi,malzeme_cinsi,malzeme_ozellik,miktar,birimi,birim_fiyat,matrah,kdv_orani,kdv_tutari,toplam,fatura_tutari) VALUES ('" + comboBox1.Text + "','" + textBox1.Text + "','" + tarih.ToString("MM/dd/yyyy") + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + int.Parse(textBox5.Text) + "','" + comboBox4.Text + "','" + textBox6.Text + "','" + textBox7.Text.Replace(",", ".") + "','" + comboBox5.Text + "','" + textBox8.Text.Replace(",", ".") + "','" + textBox9.Text.Replace(",", ".") + "','" + label17.Text.Replace(",", ".") + "') ", bag.baglan());
                ekle.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleminiz Başarılı");
               
                fatura_tutar();
                doldur();
                tertemizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show("" + hata.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            matrah();
            if (textBox7.Text != "" && comboBox5.Text != "")
            {
                kdv_hesap();
            }
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                toplam();
            }
        }
        public void matrah()
        {
            try
            {
                if (textBox5.Text != "" && textBox6.Text != "")
                {
                    textBox7.Text = (double.Parse(textBox5.Text.Replace(".", ",")) * double.Parse(textBox6.Text.Replace(".", ","))).ToString();
                }

            }
            catch
            {

                ;
            }

        }
        public void toplam()
        {
            textBox9.Text = (double.Parse(textBox7.Text) + double.Parse(textBox8.Text)).ToString();

        }
        public void kdv_hesap()
        {
            try
            {
                if (textBox7.Text != null)
                {
                    textBox8.Text = (((double.Parse(textBox7.Text.Replace(".", ","))) / 100) * double.Parse(comboBox5.Text.Replace(".", ","))).ToString();
                 
                }
                else
                {
                    MessageBox.Show("Önce Matrah Hesaplatınız");
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show("Hata aldınız"+hata);
            }
           
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            kdv_hesap();
            toplam();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            matrah();
            if (textBox7.Text!="" && comboBox5.Text!="")
            {
                kdv_hesap();
            }
            if (textBox7.Text!=""&& textBox8.Text!="")
            {
                toplam();
            }
        }

        public void fatura_tutar()
        {
            try
            {
                SqlCommand oku = new SqlCommand("select sum(toplam) from fatura where fatura_no='" + textBox1.Text + "'", bag.baglan());

                object sum = oku.ExecuteScalar();
                label17.Text = sum.ToString();

                SqlCommand guncelle = new SqlCommand("update fatura set fatura_tutari='" + sum.ToString().Replace(",", ".") + "'where fatura_no='" + textBox1.Text + "'", bag.baglan());
                guncelle.ExecuteNonQuery();
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata Aldınız",hata.Message);
            }
          
        }

        public void fatura_guncelle()
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tertemizle();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}