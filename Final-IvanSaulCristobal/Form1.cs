using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;


namespace Final_IvanSaulCristobal
{
    public partial class Form1 : Form
    {

        List<string> Marea = new List<string>();

        WindowsMediaPlayer sonido = new WindowsMediaPlayer();
        WindowsMediaPlayer sonido2 = new WindowsMediaPlayer();
        WindowsMediaPlayer sonido3 = new WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
            sonido.settings.volume = 3;
            sonido2.settings.volume = 4;
            AssignIconsToSquares();
            comboBox1.Items.Add("Barco 4");
            comboBox1.Items.Add("Barco 3");
            comboBox1.Items.Add("Barco 2");
            comboBox1.Items.Add("Barco 1");

        }

        private void AssignIconsToSquares()
        {
            tableLayoutPanel1.Controls.Clear();
            Marea = new List<string>();

            int contadorFichas = 1;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PictureBox CartasJuego = new PictureBox();
                    CartasJuego.Name = string.Format("{0}", contadorFichas);
                    CartasJuego.Dock = DockStyle.Fill;
                    CartasJuego.SizeMode = PictureBoxSizeMode.StretchImage;
                    CartasJuego.Image = Properties.Resources.fondoMarea;
                    tableLayoutPanel1.Controls.Add(CartasJuego, j, i);
                    contadorFichas++;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Esto es una prueba 2.0

            // prueba

            //puto github
        }

        private void radioButtonVertical_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonHorizontal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox33_Click_1(object sender, EventArgs e)
        {
            mtrackVolume.Visible = true;
            mtrackVolume.Value = sonido.settings.volume;
        }

        private void mtrackVolume_MouseLeave_1(object sender, EventArgs e)
        {
            mtrackVolume.Visible = false;
        }

        private void mtrackVolume_ValueChanged_1(object sender, EventArgs e)
        {
            sonido.settings.volume = mtrackVolume.Value;
            sonido2.settings.volume = mtrackVolume.Value;
            sonido3.settings.volume = mtrackVolume.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                CuantosBarcosQuendan.Text = "4";
            } else if (comboBox1.SelectedIndex == 1)
            {
                CuantosBarcosQuendan.Text = "3";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                CuantosBarcosQuendan.Text = "2";
            } else
            {
                CuantosBarcosQuendan.Text = "1";
            }
        }
    }
}
