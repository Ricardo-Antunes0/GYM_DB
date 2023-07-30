using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workouts_Interface
{
    public partial class Register : Form
    {

        public string username;
        public string Username { get { return username; } }
        public Register()
        {
            BackButton();
            InitializeComponent();
        }

        private void BackButton()
        {
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
            buttonVoltar.Click += ButtonVoltar_Click;
            buttonVoltar.Location = new Point(20, 20);
            Controls.Add(buttonVoltar);
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=" + AppData.serverName + ";Initial Catalog=" + AppData.databaseName + ";Integrated Security=True;User ID=" + AppData.username + ";");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Introduza um username válido!");
                return;
            }

            if (!VerificarSenha(password))
            {
                MessageBox.Show("A senha deve atender aos seguintes critérios:\n" +
                         "- Pelo menos uma letra maiúscula\n" +
                         "- Pelo menos um número\n" +
                         "- Pelo menos um caractere especial (!@$-_=~.,;:/?)\n" +
                         "- Ter no mínimo 8 caracteres.");
                return;
            }

            int count;

            using (SqlConnection connection = getSGBDConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users Where username = @username;", connection))
                    {
                        command.Parameters.AddWithValue("username", username);
                        count = (int)command.ExecuteScalar();
                    }

                    if(count != 0) {
                        MessageBox.Show("Username já existe. \t Por favor escolha outro.");
                    }
                    else
                    {
                        using (SqlCommand InsertComm = new SqlCommand("INSERT INTO Users VALUES (@Username, @Password)", connection))
                        {
                            InsertComm.Parameters.AddWithValue("username", username);
                            InsertComm.Parameters.AddWithValue("password", password);
                            InsertComm.ExecuteNonQuery();
                        }

                        Dados form = new Dados(username);
                        form.ShowDialog();
                        this.Hide();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                    return;
                }



            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private bool VerificarSenha(string senha)
        {
            string padraoLetraMaiuscula = "[A-Z]";
            string padraoNumero = "[0-9]";
            string padraoCaracterEspecial = @"[!@#$%^&*()\-_=+{}[\]|\\:;""'<>,.?/~`]";

            bool temLetraMaiuscula = Regex.IsMatch(senha, padraoLetraMaiuscula);
            bool temNumero = Regex.IsMatch(senha, padraoNumero);
            bool temCaracterEspecial = Regex.IsMatch(senha, padraoCaracterEspecial);

            bool temTamanhoMinimo = senha.Length >= 8;

            // Retorna true se a senha tiver todos os criterios, caso contrário retorna falso
            return temLetraMaiuscula && temNumero && temCaracterEspecial && temTamanhoMinimo;
        }

        private void ButtonVoltar_Click(object sender, EventArgs e)
        {
            // Coloque o código que deseja executar quando o botão for clicado aqui.
            // Por exemplo, para fechar o formulário atual:
            this.Close();
        }
    }
}
