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
    public partial class Borc : Form
    {
        MySqlConnection conn = new MySqlConnection("Server = localhost; Database=hafta09; user=root;");

        public Borc()
        {
            InitializeComponent();
        }

        private void Borc_Load(object sender, EventArgs e)
        {
            listele("hepsi");
        }

        private void listele(string secim="hepsi")
        {
            conn.Open();
            string sql = null;
            DataTable dt = new DataTable();
            switch(secim)
            {
                case "odenmemis":
                    sql = "SELECT * FROM borclar WHERE odemeTarihi IS NULL ORDER BY sonOdemeTarihi DESC";
                    break;
                case "odenmis":
                    sql = "SELECT * FROM borclar WHERE odemeTarihi IS NOT NULL ORDER BY odemeTarihi DESC";
                    break;
                case "hepsi":
                    sql = "SELECT * FROM borclar ORDER BY sonOdemeTarihi DESC";
                    break;


            }
            MySqlDataAdapter adaptor = new MySqlDataAdapter(sql, conn);
           
            dt.Clear();
            adaptor.Fill(dt);
            dataGridView1.DataSource = dt;
            adaptor.Dispose();

            conn.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listele("hepsi");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listele("odenmemis");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listele("odenmis");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int toplamOdeme = 0;
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                MySqlCommand komut = new MySqlCommand("UPDATE borclar SET odemeTarihi = NOW() " +
                                                      "WHERE daireNo = @daireNo AND borcAd = @borcAd", conn);
                komut.Parameters.AddWithValue("@daireNo", drow.Cells[0].Value.ToString());
                komut.Parameters.AddWithValue("@borcAd", drow.Cells[1].Value.ToString());
                conn.Open();
                toplamOdeme += komut.ExecuteNonQuery();
                conn.Close();
                komut.Dispose();
            }
            MessageBox.Show(toplamOdeme.ToString() + ".satır borcunu ödedi.");
            listele("odenmis");
            rbOdenmis.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int toplamOdenmedi = 0;
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                MySqlCommand komut = new MySqlCommand("UPDATE borclar SET odemeTarihi = NULL " +
                                                      "WHERE daireNo = @daireNo AND borcAd = @borcAd", conn);
                komut.Parameters.AddWithValue("@daireNo", drow.Cells[0].Value.ToString());
                komut.Parameters.AddWithValue("@borcAd", drow.Cells[1].Value.ToString());
                conn.Open();
                toplamOdenmedi += komut.ExecuteNonQuery();
                conn.Close();
                komut.Dispose();
            }
            MessageBox.Show(toplamOdenmedi.ToString() + ". satır borcunu ödemedi.");
            listele("odenmemis");
            rbOdenmemis.Checked = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
