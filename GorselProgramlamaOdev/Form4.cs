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
    public partial class Form4 : Form
    {
        private MySqlConnection connection;


        public Form4()
        {
            InitializeComponent();

            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            string Constr = "Server=localhost;DATABASE=ogrenci1;UID=root;PWD=12345";
            connection = new MySqlConnection(Constr);
        }



        private void Form4_Load(object sender, EventArgs e)
        {

            try
            {
                connection.Open();
                string query = "SELECT adi,soyadi FROM ogrenciler";
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    string ogrenci = $"{dataReader["adi"].ToString()} {dataReader["soyadi"].ToString()}";
                    listBox1.Items.Add(ogrenci);
                }
                dataReader.Close();

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
   

        private void button1_Click(object sender, EventArgs e)
        {

           




            if (listBox1.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Seçili öğrenciyi silmek istediğinize emin misiniz?", "Öğrenci Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string secilenOgrenci = listBox1.SelectedItem.ToString();
                    string[] ogrenciBilgileri = secilenOgrenci.Split('-');
                    string[] adSoyad = ogrenciBilgileri[0].Trim().Split(' ');

                    string ad = adSoyad[0];
                    string soyad = adSoyad[1];

                    try
                    {
                        connection.Open();
                        string query = $"DELETE FROM ogrenciler WHERE adi = '{ad}' AND soyadi = '{soyad}'";

                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        int secilenSatir = cmd.ExecuteNonQuery();

                        if (secilenSatir > 0)
                        {
                            MessageBox.Show("Öğrenci başarıyla silindi.");
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex); // ListBox içeriğini güncelle
                        }
                        else
                        {
                            MessageBox.Show("Öğrenci silinemedi.");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"Hata: {exception.Message}");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
          


        }
    } }
