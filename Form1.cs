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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace mysql
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server = localhost; Database=hafta09; user=root;");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String sqlDaireSayisi = "SELECT COUNT(*) AS Adet FROM Daireler";
            String sqlOturanSayisi = "SELECT COUNT(*) AS Adet FROM Oturanlar";

            conn.Open();

            MySqlCommand komut1 = new MySqlCommand(sqlDaireSayisi, conn);
            MySqlDataReader okuyucu = komut1.ExecuteReader();
            if (okuyucu.Read())
                textBox1.Text = okuyucu["Adet"].ToString();
                conn.Close();
            conn.Open();
            MySqlCommand komut2 = new MySqlCommand(sqlOturanSayisi, conn);

            okuyucu = komut2.ExecuteReader();
            if (okuyucu.Read())
                textBox2.Text = okuyucu["Adet"].ToString();
            conn.Close();
        }

        private void toolStripDaire_Click(object sender, EventArgs e)
        {
            frmDaireler frmDaireler = new frmDaireler();
            frmDaireler.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOturanlar frmOturanlar = new frmOturanlar();
            frmOturanlar.ShowDialog();
        }

        private void toolBorc_Click(object sender, EventArgs e)
        {
            Borc borc = new Borc();
            borc.ShowDialog();
        }

        private void borçİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borc borc = new Borc();
            borc.ShowDialog();
        }

        private void borçEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorcEkle borc = new BorcEkle();
            borc.ShowDialog();
        }
    }
}
