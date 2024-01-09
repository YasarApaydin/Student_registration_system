using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace GorselProgramlamaOdev
{
    public partial class Form6 : Form
    {
        private int ogrNo;
        private MySqlConnection connection;
        public Form6(int ogrNo)
        {
            InitializeComponent();
          
            this.ogrNo = ogrNo;

        }

     
            string Constr = "Server=localhost;DATABASE=ogrenci1;UID=root;PWD=12345";
           

        private void Form6_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string isim = textBox1.Text;
            string soyIsim = textBox2.Text;
            string OgrenciNo = maskedTextBox1.Text;
            if (OgrenciNo.Length == 10)
            {
                string query = $"UPDATE ogrenciler SET adi = '{isim}', soyadi = '{soyIsim}', numarasi = '{OgrenciNo}' WHERE id = '{ogrNo}'";
                connection = new MySqlConnection(Constr);


                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int etkilenenSatir = cmd.ExecuteNonQuery();

                    if (etkilenenSatir > 0)
                    {
                        // Güncelleme başarılı oldu
                        MessageBox.Show("Veritabanı güncellendi!");
                    }
                    else
                    {
                        // Güncelleme başarısız oldu
                        MessageBox.Show("Güncelleme yapılamadı!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı Hatası: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen 10 haneli okul numaranızı Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }
    }
}
