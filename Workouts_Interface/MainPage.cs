using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Workouts_Interface;

namespace Workouts_Interface
{
    public partial class MainPage : Form
    {
        public string username;
        public string Username { get { return username; } }

        public static SqlConnection conect;
        public MainPage()
        {
            InitializeComponent();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=" + AppData.serverName + ";Initial Catalog=" + AppData.databaseName + ";Integrated Security=True;User ID=" + AppData.username + ";");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            username = textBox1.Text;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register form = new Register();
            form.ShowDialog();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            string password = textBox2.Text;
            int loginResult = 0;

            using (SqlConnection connection = getSGBDConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("VerifyLogin", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.Add("@valid", SqlDbType.Int).Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        loginResult = Convert.ToInt32(command.Parameters["@valid"].Value);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao verificar as credenciais: " + ex.Message);
                    return;
                }
            }

            if (loginResult == 0)
            {
                MessageBox.Show("Credenciais inválidas. Tente novamente.");
                return;
            }

            MessageBox.Show("Login bem sucedido");

            if (loginResult != 0)
            {
                Dados at = new Dados(username);
                at.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciais inválidas. Por favor, insira novamente.");
            }
        }
    }
}

