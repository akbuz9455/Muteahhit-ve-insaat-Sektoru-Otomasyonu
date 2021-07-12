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
    public partial class malzeme_cinsi_tanimlama : Form
    {
        public malzeme_cinsi_tanimlama()
        {
            InitializeComponent();
        }

        sqlbaglantisi bag = new sqlbaglantisi();
        public DataTable tablo = new DataTable();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public SqlCommand kmt = new SqlCommand();

        public void doldur()
        {

            try
            {
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From malzeme_table order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.RowHeadersVisible = false;

                dataGridView1.Columns[1].HeaderText = "Malzeme Adı";
                dataGridView1.Columns[2].HeaderText = "Malzeme Özelliği";


                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 268;
          


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                throw;
            }

        }
        private void malzeme_cinsi_tanimlama_Load(object sender, EventArgs e)
        {
            doldur();
            malzeme();

        }

        public void malzeme()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            SqlCommand MALZEME = new SqlCommand("select * from malzeme_cinsi ", bag.baglan());
            SqlDataReader oku = MALZEME.ExecuteReader();

            while (oku.Read())
            {


                comboBox2.Items.Add(oku[1]);
                comboBox1.Items.Add(oku[1]);

            }

        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand ekle = new SqlCommand("insert into malzeme_cinsi(cins) values('" + textBox1.Text + "')", bag.baglan());
                ekle.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşlemi Başarılı !");
                textBox1.Text = "";
                malzeme();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
   
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand sil = new SqlCommand("delete from malzeme_cinsi where cins='" + comboBox2.Text + "'", bag.baglan());
                sil.ExecuteNonQuery();
                malzeme();
                comboBox2.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand ekle = new SqlCommand("insert into malzeme_table(adi,ozellik) values('" + comboBox1.Text + "','"+textBox2.Text+"')", bag.baglan());
                ekle.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşlemi Başarılı !");
                textBox2.Text = "";
                comboBox1.Text = "";
                malzeme();
                doldur();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand sil = new SqlCommand("delete from malzeme_table where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
                sil.ExecuteNonQuery();
                doldur();
                comboBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

          
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand guncelle = new SqlCommand("update malzeme_table set adi='" + comboBox1.Text + "',ozellik='" + textBox2.Text + "' where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
                guncelle.ExecuteNonQuery();
                MessageBox.Show("Güncelleme işlemini başarıyla gerçekleştirdiniz");
                doldur();
                textBox2.Text = "";
             
                comboBox1.Text = "";
            }
            catch
            {
                ;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            tablo.Clear();

            SqlDataAdapter adtr = new SqlDataAdapter("select * From malzeme_table where adi like'%" + textBox3.Text + "%'", bag.baglan());
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
