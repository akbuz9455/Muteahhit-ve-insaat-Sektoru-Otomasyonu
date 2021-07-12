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
    public partial class tanimlama : Form
    {
        public tanimlama()
        {
            InitializeComponent();
        }
        sqlbaglantisi bag = new sqlbaglantisi();
        public DataTable tablo = new DataTable();
        public DataTable tablo2 = new DataTable();
        public DataTable tablo3 = new DataTable();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public SqlCommand kmt = new SqlCommand();



        public void doldur()
        {

            try
            {
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From bolge_malzeme_kayit order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.RowHeadersVisible = false;

                dataGridView1.Columns[1].HeaderText = "Bölge Adı";
                dataGridView1.Columns[2].HeaderText = "Malzeme Cinsi";
                dataGridView1.Columns[3].HeaderText = "Malzeme Özelliği";
                dataGridView1.Columns[4].HeaderText = "Malzeme Miktar";
                dataGridView1.Columns[5].HeaderText = "Miktar Türü";

                dataGridView1.Columns[1].Width = 140;
                dataGridView1.Columns[2].Width = 140;
                dataGridView1.Columns[3].Width = 140;
                dataGridView1.Columns[4].Width = 140;
                dataGridView1.Columns[5].Width = 133;
               
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                throw;
            }

        }
        public void doldur2()
        {

            try
            {
                tablo2.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From bolge_gider order by id desc", bag.baglan());
                adtr.Fill(tablo2);
                dataGridView2.DataSource = tablo2;
                adtr.Dispose();


                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView2.Columns[0].Visible = false;

                dataGridView2.RowHeadersVisible = false;

                dataGridView2.Columns[1].HeaderText = "Bölge Adı";
                dataGridView2.Columns[2].HeaderText = "İşçilik Masrafı";
                dataGridView2.Columns[3].HeaderText = "Elektirik Masrafı";
                dataGridView2.Columns[4].HeaderText = "Su Masrafı";
               

                dataGridView2.Columns[1].Width = 190;
                dataGridView2.Columns[2].Width = 165;
                dataGridView2.Columns[3].Width = 165;
                dataGridView2.Columns[4].Width = 165;
              

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                throw;
            }

        }
        public void doldur3()
        {
            try
            {
                tablo3.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From bolge_listesi order by id desc", bag.baglan());
                adtr.Fill(tablo3);
                dataGridView3.DataSource = tablo3;
                adtr.Dispose();


                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dataGridView3.Columns[0].Visible = false;

                dataGridView3.RowHeadersVisible = false;

                dataGridView3.Columns[1].HeaderText = "Bölge Adı";
                dataGridView3.Columns[2].HeaderText = "Bölge Adresi";
                dataGridView3.Columns[3].HeaderText = "Açıklama";


                dataGridView3.Columns[1].Width = 140;
                dataGridView3.Columns[2].Width = 300;
                dataGridView3.Columns[3].Width = 240;

            }
            catch
            {
                ;
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
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tanimlama_Load(object sender, EventArgs e)
        {
            doldur3();
            birimdoldur();
               doldur();
            doldur2();
            malzeme();
            bolge();
        }
        public void bolge()
        {
            comboBox5.Items.Clear();
            comboBox1.Items.Clear();
            SqlCommand bolge = new SqlCommand("select * from bolge_listesi ", bag.baglan());
            SqlDataReader oku = bolge.ExecuteReader();

            while (oku.Read())
            {

                comboBox5.Items.Add(oku[1]);
                comboBox1.Items.Add(oku[1]);

            }

        }
        public void malzeme()
        {
          
            comboBox2.Items.Clear();
            SqlCommand MALZEME = new SqlCommand("select * from malzeme_cinsi ", bag.baglan());
            SqlDataReader oku = MALZEME.ExecuteReader();

            while (oku.Read())
            {


                comboBox2.Items.Add(oku[1]);
                
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                kmt = new SqlCommand("insert into bolge_malzeme_kayit(bolge,malzeme_cinsi,malzeme_ozellik,miktar,miktar_turu) values('" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox1.Text.Replace(",", ".") + "','" + comboBox4.Text + "')", bag.baglan());
                kmt.ExecuteNonQuery();
                doldur();
                textBox1.Text = "";
                comboBox1.Text = "";
                comboBox3.Text = "";
                comboBox2.Text = "";
                comboBox4.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sil = new SqlCommand("delete from bolge_malzeme_kayit where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
                sil.ExecuteNonQuery();
                doldur();
                textBox1.Text = "";
                comboBox1.Text = "";
                comboBox3.Text = "";
                comboBox2.Text = "";
                comboBox4.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            comboBox3.Items.Clear();
            SqlCommand kdvlistele = new SqlCommand("select * from malzeme_table where adi='" + comboBox2.Text + "' ", bag.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();

            while (oku.Read())
            {


                comboBox3.Items.Add(oku[2]);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand guncelle = new SqlCommand("update bolge_malzeme_kayit set bolge='" + comboBox1.Text + "',malzeme_cinsi='" + comboBox2.Text + "',malzeme_ozellik='"+comboBox3.Text+ "',miktar='"+textBox1.Text.Replace(",", ".") + "',miktar_turu='"+comboBox4.Text+"' where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
                guncelle.ExecuteNonQuery();
                MessageBox.Show("Güncelleme işlemini başarıyla gerçekleştirdiniz");
                doldur();
                textBox1.Text = "";
                comboBox1.Text = "";
                comboBox3.Text = "";
                comboBox2.Text = "";
                comboBox4.Text = "";
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();

            SqlDataAdapter adtr = new SqlDataAdapter("select * From bolge_malzeme_kayit where bolge like'%" + textBox5.Text + "%'", bag.baglan());
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            tablo3.Clear();

            SqlDataAdapter adtr = new SqlDataAdapter("select * From bolge_listesi where bolge_adi like'%" + textBox7.Text + "%'", bag.baglan());
            adtr.Fill(tablo3);
            dataGridView3.DataSource = tablo3;
            adtr.Dispose();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            tablo2.Clear();

            SqlDataAdapter adtr = new SqlDataAdapter("select * From bolge_gider where bolge like'%" + textBox6.Text + "%'", bag.baglan());
            adtr.Fill(tablo2);
            dataGridView2.DataSource = tablo2;
            adtr.Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sil = new SqlCommand("delete from bolge_listesi where id='" + dataGridView3.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
                sil.ExecuteNonQuery();
                doldur3();
                bolge();
                textBox9.Text = "";
                textBox8.Text = "";
                textBox10.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox9.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                textBox8.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                textBox10.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
         
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand ekle = new SqlCommand("insert into bolge_listesi(bolge_adi,adresi,aciklama) values('" + textBox9.Text + "','" + textBox8.Text + "','" + textBox10.Text + "')", bag.baglan());
                ekle.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşlemi Başarılı !");
                textBox9.Text = "";
                textBox8.Text = "";
                textBox10.Text = "";
                doldur3();
                bolge();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
            textBox8.Text = "";
            textBox10.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand guncelle = new SqlCommand("update bolge_listesi set bolge_adi='" + textBox9.Text + "',adresi='" + textBox8.Text + "',aciklama='" + textBox10.Text + "' where id='" + dataGridView3.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
                guncelle.ExecuteNonQuery();
                MessageBox.Show("Güncelleme işlemini başarıyla gerçekleştirdiniz");
                textBox9.Text = "";
                textBox8.Text = "";
                textBox10.Text = "";
                doldur3();
                bolge();
            }
            catch
            {
                ;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                kmt = new SqlCommand("insert into bolge_gider(bolge,iscilik,elektirik,su) values('" + comboBox5.Text + "','" + textBox2.Text.Replace(",", ".") + "','" + textBox3.Text.Replace(",", ".") + "','" + textBox4.Text.Replace(",", ".")+ "')", bag.baglan());
                kmt.ExecuteNonQuery();
                doldur2();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox5.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sil = new SqlCommand("delete from bolge_gider where id='" + dataGridView2.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
                sil.ExecuteNonQuery();
                doldur2();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox5.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                comboBox5.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand guncelle = new SqlCommand("update bolge_gider set bolge='" + comboBox5.Text + "',iscilik='" + textBox2.Text.Replace(",", ".") + "',elektirik='" + textBox3.Text.Replace(",", ".") + "',su='"+textBox4.Text.Replace(",", ".") + "' where id='" + dataGridView2.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
                guncelle.ExecuteNonQuery();
                MessageBox.Show("Güncelleme işlemini başarıyla gerçekleştirdiniz");
                doldur2();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox5.Text = "";
            }
            catch(Exception hatam)
            {
                MessageBox.Show(hatam.Message);
            }
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void çıkışlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
