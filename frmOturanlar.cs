using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysql
{
    public partial class frmOturanlar : Form
    {
        MySqlConnection conn = new MySqlConnection("Server = localhost; Database=hafta09; user=root;");

        public frmOturanlar()
        {
            InitializeComponent();
        }

        private void listele()
        {
            conn.Open();
            MySqlDataAdapter adaptor = new MySqlDataAdapter("SELECT * FROM oturanlar ORDER BY daireNo", conn);
            DataTable dt = new DataTable();
            dt.Clear();
            adaptor.Fill(dt);
            dataGridView1.DataSource = dt;
            adaptor.Dispose();

            conn.Close();
        }

        private void frmOturanlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32 satir;
            conn.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "INSERT INTO Oturanlar (TCNo, ad, soyad, daireNo, pozisyon)" + "VALUES (@pTCNo, @pad, @psoyad ,@pdaireNo , @ppozisyon)";

            komut.Parameters.AddWithValue("@pTCNo", textBox6.Text);
            komut.Parameters.AddWithValue("@pad", textBox2.Text);
            komut.Parameters.AddWithValue("@psoyad", textBox3.Text);
            komut.Parameters.AddWithValue("@pdaireNo", textBox4.Text);
            komut.Parameters.AddWithValue("@ppozisyon", textBox5.Text);

            komut.Connection = conn;
            satir = komut.ExecuteNonQuery();
            MessageBox.Show(satir + "satir eklendi");
            komut.Dispose();
            conn.Close();
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 satir;
            conn.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "UPDATE Oturanlar SET ad=@pad, soyad=@psoyad, " + "daireNo=@pdaireNo, pozisyon=@ppozisyon  " + "WHERE TCNo=@pTCNo";


            komut.Parameters.AddWithValue("@pad", textBox2.Text);
            komut.Parameters.AddWithValue("@psoyad", textBox3.Text);
            komut.Parameters.AddWithValue("@pdaireNo", textBox4.Text);
            komut.Parameters.AddWithValue("@ppozisyon", textBox5.Text);
            komut.Parameters.AddWithValue("@pTCNo", textBox6.Text);

            komut.Connection = conn;
            satir = komut.ExecuteNonQuery();
            MessageBox.Show(satir + "satir degisti");
            komut.Dispose();
            conn.Close();
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            Int32 satir;
            cevap = MessageBox.Show("Silmek istediğinizden emin misini?", "Uyari!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                conn.Open();
                MySqlCommand komut = new MySqlCommand();
                komut.CommandText = "DELETE FROM Oturanlar WHERE TCNo=@pTCNo";
                komut.Parameters.AddWithValue("@pTCNo", textBox6.Text);
                komut.Connection = conn;

                satir = komut.ExecuteNonQuery();
                MessageBox.Show(satir + "satir silindi");
                komut.Dispose();
                conn.Close();
                listele();
            }
        }
    }

}
