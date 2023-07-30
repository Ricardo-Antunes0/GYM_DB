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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Workouts_Interface
{
    public partial class PlanoTreino : Form
    {
        private string username;
        public PlanoTreino(string username)
        {
            BackButton();
            InitializeComponent();
            this.username = username;
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=" + AppData.serverName + ";Initial Catalog=" + AppData.databaseName + ";Integrated Security=True;User ID=" + AppData.username + ";");
        }

        private void BackButton(){
            Button buttonVoltar = new Button();
            buttonVoltar.Width = 30; // Defina a largura desejada
            buttonVoltar.Height = 30; // Defina a altura desejada
            buttonVoltar.FlatStyle = FlatStyle.Flat;
            buttonVoltar.FlatAppearance.BorderSize = 0;
            buttonVoltar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonVoltar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonVoltar.BackColor = Color.Transparent;
            buttonVoltar.BackgroundImage = Properties.Resources.backButton; // Substitua pelo caminho da imagem da seta
            buttonVoltar.BackgroundImageLayout = ImageLayout.Zoom;
            buttonVoltar.Click += button1_Click;
            buttonVoltar.Location = new Point(20, 20);
            Controls.Add(buttonVoltar);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlanoTreino_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                tableLayoutPanel1.Controls.Add(new Label() { Text = AppData.dias_semana[i] }, i, 0);
            }

            using (SqlConnection conn = getSGBDConnection())
            {
                try
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand("SELECT dia_semana,Treino FROM Treinos", conn))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dia_semana = reader["dia_semana"].ToString();
                            string treino = reader["Treino"].ToString();

                            int coluna = Array.IndexOf(AppData.dias_semana, dia_semana);
                            tableLayoutPanel1.Controls.Add(new Label() { Text = treino }, coluna, 0);
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Erro: ", ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}