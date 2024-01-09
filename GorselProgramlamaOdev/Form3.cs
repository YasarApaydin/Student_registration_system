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


namespace GorselProgramlamaOdev
{
    public partial class Form3 : Form
    {
        private MySqlConnection connection;
        

        public Form3()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            string Constr = "Server=localhost;DATABASE=ogrenci1;UID=root;PWD=12345";
            connection = new MySqlConnection(Constr);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            try
            {
                connection.Open();
                string query = "SELECT id,adi FROM ogrenciler";
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    string ogrenci = $"{dataReader["id"].ToString()} {dataReader["adi"].ToString()}";
                    
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
                string secilenOgrenci = listBox1.SelectedItem.ToString();

                string[] ogrenciBilgileri = secilenOgrenci.Split('-');
                string[] adSoyad = ogrenciBilgileri[0].Trim().Split(' ');

                int ogrNo = Convert.ToInt16(adSoyad[0]);
              
                try
                {
                    

                    connection.Open();
                    string query = $"SELECT id,adi,soyadi,numarasi FROM ogrenciler WHERE id='{ogrNo}'";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        listBox3.Items.Clear();
                        string ogrenci = $"{dataReader["id"].ToString()} {dataReader["adi"].ToString()} {dataReader["soyadi"].ToString()} {dataReader["numarasi"].ToString()}";
                        listBox3.Items.Add(ogrenci);
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



// listBox3.Items.Clear();



        }

     
        
    }
}
