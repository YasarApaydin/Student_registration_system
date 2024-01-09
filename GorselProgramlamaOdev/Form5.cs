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
    public partial class Form5 : Form
    {

        private MySqlConnection connection;
        private int ogrNo;

        public Form5()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            string Constr = "Server=localhost;DATABASE=ogrenci1;UID=root;PWD=12345";
            connection = new MySqlConnection(Constr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            if (listBox1.SelectedIndex != -1)
            {
                string secilenOgrenci = listBox1.SelectedItem.ToString();

                string[] ogrenciBilgileri = secilenOgrenci.Split('-');
                string[] adSoyad = ogrenciBilgileri[0].Trim().Split(' ');

                ogrNo = Convert.ToInt16(adSoyad[0]);
                Form6 frm6 = new Form6(ogrNo);
                frm6.Show();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz öğeyi seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



      


        private void Form5_Load(object sender, EventArgs e)
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
    }
}
