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

namespace GorselProgramlamaOdev
{
  
    public partial class Form2 : Form
    {
        private MySqlConnection connection;
       
      
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string ConStr = "Server=localhost;DATABASE=ogrenci1;UID=root;PWD=12345";
            connection = new MySqlConnection(ConStr);
        }



    



        private void button1_Click(object sender, EventArgs e)
        {
    


            string adi = textBox1.Text;
            string soyadi = textBox2.Text;
            string numara = maskedTextBox1.Text;
            if (numara.Length == 10) {
              try
            {
                connection.Open();
                string query = $"INSERT INTO ogrenciler (adi, soyadi, numarasi) VALUES ('{adi}', '{soyadi}', '{numara}')";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Öğrenci başarıyla eklendi.");

            }
            catch (Exception exception)
            {
                MessageBox.Show("Hata: ", exception.Message);
            }
            finally
            {
                connection.Close();
            }


            }
            else
            {
                MessageBox.Show("Lütfen 10 haneli okul numaranızı Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

    }
    }
    

