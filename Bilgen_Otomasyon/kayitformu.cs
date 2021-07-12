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
    public partial class kayitformu : Form
    {
        public kayitformu()
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

                SqlDataAdapter adtr = new SqlDataAdapter("select * From firma order by id desc", bag.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.RowHeadersVisible = false;

                dataGridView1.Columns[1].HeaderText = "Firma Adı";
                dataGridView1.Columns[2].HeaderText = "Firma Kategorisi";
                dataGridView1.Columns[3].HeaderText = "Açıklama";
              
                dataGridView1.Columns[1].Width = 105;
                dataGridView1.Columns[2].Width = 145;
                dataGridView1.Columns[3].Width = 374;
             

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                throw;
            }

        }

        public void malzeme()
        {
            comboBox1.Items.Clear();
            SqlCommand MALZEME = new SqlCommand("select * from malzeme_cinsi ", bag.baglan());
            SqlDataReader oku = MALZEME.ExecuteReader();

            while (oku.Read())
            {


                comboBox1.Items.Add(oku[1]);

            }

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void kayitformu_Load(object sender, EventArgs e)
        {
            doldur();
            malzeme();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand ekle = new SqlCommand("insert into firma(firma_adi,kategori,aciklama) values('"+textBox1.Text+"','"+comboBox1.Text+"','"+textBox2.Text+"')", bag.baglan());
            ekle.ExecuteNonQuery();
            MessageBox.Show("Ekleme İşlemi Başarılı !");
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            doldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sil = new SqlCommand("delete from firma where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
                sil.ExecuteNonQuery();
                doldur();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand guncelle = new SqlCommand("update firma set firma_adi='"+textBox1.Text+ "',kategori='"+comboBox1.Text+ "',aciklama='"+textBox2.Text+ "' where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", bag.baglan());
                guncelle.ExecuteNonQuery();
                MessageBox.Show("Güncelleme işlemini başarıyla gerçekleştirdiniz");
                doldur();
                textBox1.Text = "";
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

            SqlDataAdapter adtr = new SqlDataAdapter("select * From firma where firma_adi like'%" + textBox3.Text + "%'", bag.baglan());
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";

        }
    }
}
