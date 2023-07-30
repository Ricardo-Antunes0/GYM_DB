using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Workouts_Interface
{
    public partial class Dados : Form
    {
        public string username;
        public Dados(string username)
        {
            this.username = username;
            InitializeComponent();

            this.Load += Dados_Load;
        }


        private void Dados_Load(object sender, EventArgs e)
        {
                listBox1.Items.Add(username);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlanoTreino planoTreino = new PlanoTreino(username);
            planoTreino.ShowDialog();
            this.Hide();   
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            PlanoTreino planoTreino = new PlanoTreino(username);
            planoTreino.ShowDialog();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MainPage form = new MainPage();
            form.ShowDialog();
            this.Close();

        }
    }
}
