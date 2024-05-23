using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mysql
{
    public partial class BorcEkle : Form
    {
        MySqlConnection conn = new MySqlConnection("Server = localhost; Database=hafta09; user=root;");

        public BorcEkle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            using (MySqlCommand komut = new MySqlCommand())
            {
                komut.Connection = conn;

                if (rbBorcEkle.Checked == true)
                {
                    int daireno = 0;
                    String sqlDaireSayisi = "SELECT COUNT(*) AS Adet FROM Daireler";
                    MySqlCommand komut2 = new MySqlCommand(sqlDaireSayisi, conn);
                    using (MySqlDataReader okuyucu = komut2.ExecuteReader())
                    {
                        if (okuyucu.Read())
                        {
                            daireno = Convert.ToInt32(okuyucu["Adet"]);
                        }
                    }

                    for (int i = 1; i <= daireno; i++)
                    {
                        komut.CommandText = "INSERT INTO borclar (daireNo, borcAd, miktar, aciklama, sonOdemeTarihi) " + "VALUES (@daieNo, @borcAd, @miktar ,@aciklama , @sonOdemeTarihi)";
                        komut.Parameters.AddWithValue("@daieNo", textBox1.Text);
                        komut.Parameters.AddWithValue("@borcAd", textBox2.Text);
                        komut.Parameters.AddWithValue("@miktar", textBox3.Text);
                        komut.Parameters.AddWithValue("@aciklama", textBox4.Text);
                        komut.Parameters.AddWithValue("@sonOdemeTarihi", textBox5.Text);

                        int satir1 = komut.ExecuteNonQuery();
                        MessageBox.Show(satir1 + " borç eklendi");
                        komut.Parameters.Clear();
                        conn.Close();
                    }
                }
                else if (rbIptal.Checked == true)

                {
                    conn.Open();
                    int toplamMiktar = int.Parse(textBox3.Text);
                    komut.CommandText = "UPDATE borclar SET miktar = @pMiktar";
                    komut.Parameters.AddWithValue("@pMiktar", toplamMiktar);

                    int satir = komut.ExecuteNonQuery();
                    MessageBox.Show(satir + " dairenin borcu güncellendi");
                }
            }

            conn.Close();
        }

    }
}
