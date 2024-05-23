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
    public partial class frmDaireler : Form
    {

        MySqlConnection conn = new MySqlConnection("Server = localhost; Database=hafta09; user=root;");

        public frmDaireler()
        {
            InitializeComponent();
        }

        private void listele()
        {
            conn.Open();
            MySqlDataAdapter adaptor = new MySqlDataAdapter("SELECT * FROM daireler ORDER BY numara" , conn );
            DataTable dt = new DataTable();
            dt.Clear();
            adaptor.Fill( dt );
            dataGridView1.DataSource = dt;
            adaptor.Dispose();

            conn.Close();
        }
        private void frmDaireler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Focus();
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
                komut.CommandText = "DELETE FROM Daireler WHERE tapuSahibiTC=@ptapuSahibiTC";
                komut.Parameters.AddWithValue("@ptapuSahibiTC", textBox4.Text);
                komut.Connection = conn;

                satir = komut.ExecuteNonQuery();
                MessageBox.Show(satir + "satir silindi");
                komut.Dispose();
                conn.Close();
                listele();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32 satir;
            conn.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "INSERT INTO Daireler (numara,metrekare,tapuSahibi, tapuSahibiTC, tapuSahibiTelefon)" + "VALUES (@pnumara, @pmetrekare, @ptapuSahibi ,@ptapuSahibiTC , @ptapuSahibiTelefon)";

            komut.Parameters.AddWithValue("@pnumara", textBox1.Text);
            komut.Parameters.AddWithValue("@pmetrekare", textBox2.Text);
            komut.Parameters.AddWithValue("@ptapuSahibi", textBox3.Text);
            komut.Parameters.AddWithValue("@ptapuSahibiTC", textBox4.Text);
            komut.Parameters.AddWithValue("@ptapuSahibiTelefon", textBox5.Text);

            komut.Connection = conn;
            satir = komut.ExecuteNonQuery();
            MessageBox.Show(satir + " satir eklendi :D");
            komut.Dispose();
            conn.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 satir;
            conn.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "UPDATE Daireler SET metrekare=@pmetrekare, tapusahibi=@ptapuSahibi, " + "tapuSahibiTC=@ptapuSahibiTC, tapuSahibiTelefon=@ptapuSaihibiTelefon  " + "WHERE numara=@pnumara";


            komut.Parameters.AddWithValue("@pmetrekare", textBox2.Text);
            komut.Parameters.AddWithValue("@ptapuSahibi", textBox3.Text);
            komut.Parameters.AddWithValue("@ptapuSahibiTC", textBox4.Text);
            komut.Parameters.AddWithValue("@ptapuSahibiTelefon", textBox5.Text);
            komut.Parameters.AddWithValue("@pnumara", textBox1.Text);

            komut.Connection = conn;
            satir = komut.ExecuteNonQuery();
            MessageBox.Show(satir + "satir degisti");
            komut.Dispose();
            conn.Close();
            listele();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "tapuSahibi LIKE '%" + txtArama.Text + "%'";
            dataGridView1.DataSource = bs;
        }
    }
}
