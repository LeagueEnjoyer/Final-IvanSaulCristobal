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

        List<PictureBox> Marea = new List<PictureBox>();
        PictureBox barco1 = new PictureBox();

        int posiconActual;
        int decenaActual;
        int decenaParaComprobar;
        int valorParaComprobar;
        int barco4count = 1;
        int barco3count = 2;
        int barco2count = 3;
        int barco1count = 4;

        int barco4colocado = 2;
        int barco3colocado = 3;
        int barco2colocado = 5;
        int barco1colocado = 8;
        


        WindowsMediaPlayer sonido = new WindowsMediaPlayer();
        WindowsMediaPlayer sonido2 = new WindowsMediaPlayer();
        WindowsMediaPlayer sonido3 = new WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
            sonido.settings.volume = 3;
            sonido2.settings.volume = 4;
            AssignIconsToSquares();

        }

        private void AssignIconsToSquares()
        {
            tableLayoutPanel1.Controls.Clear();

            int contadorFichas = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PictureBox CartasJuego = new PictureBox();
                    CartasJuego.Name = string.Format("{0}", contadorFichas);
                    CartasJuego.Dock = DockStyle.Fill;
                    CartasJuego.SizeMode = PictureBoxSizeMode.StretchImage;
                    CartasJuego.Image = Properties.Resources.fondoMarea;
                    CartasJuego.Tag = 0;
                    CartasJuego.Click += btnCarta_Click;
                    tableLayoutPanel1.Controls.Add(CartasJuego, j, i);
                    Marea.Add(CartasJuego);
                    contadorFichas++;
                }
            }
            comboBox1.Items.Add("Barco 1");
            comboBox1.Items.Add("Barco 2");
            comboBox1.Items.Add("Barco 3");
            comboBox1.Items.Add("Barco 4");

        }

        private void btnCarta_Click(object sender, EventArgs e)
        {
            PictureBox clickedBox = (PictureBox)sender;

            posiconActual = Convert.ToInt32(clickedBox.Name);
            decenaActual = (int)(posiconActual / 10);
            decenaParaComprobar = (int)((posiconActual + (comboBox1.SelectedIndex + 1)) / 10);
            valorParaComprobar = (posiconActual + (comboBox1.SelectedIndex * 10));

            if (radioButtonHorizontal.Checked && (decenaParaComprobar == decenaActual)){

                clickedBox.Image = null;
                for(int i = 0; i < comboBox1.SelectedIndex; i++)
                {
                    Marea[posiconActual + (i+1)].Image = null;
                    if(i == 0)
                    {
                        Marea[posiconActual + i].Tag = 1;
                        Marea[posiconActual + i - 10].Tag = 1;
                        Marea[posiconActual + i + 10].Tag = 1;
                        Marea[posiconActual + i + 1 - 10].Tag = 1;
                        Marea[posiconActual + i + 1 + 10].Tag = 1;
                    } else if (i == comboBox1.SelectedIndex)
                    {
                        Marea[posiconActual + i + 1 - 10].Tag = 1;
                        Marea[posiconActual + i + 1 + 10].Tag = 1;
                        if ((posiconActual + i + 2)
                        Marea[posiconActual + i + 2].Tag = 1;
                        Marea[posiconActual + i + 2 - 10].Tag = 1;
                        Marea[posiconActual + i + 2 + 10].Tag = 1;
                    } else
                    {
                        Marea[posiconActual + i + 1 - 10].Tag = 1;
                        Marea[posiconActual + i + 1 + 10].Tag = 1;
                    }
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            Marea[posiconActual].Tag = barco1colocado;
                            break;
                        case 1:
                            Marea[posiconActual].Tag = barco2colocado;
                            break;
                        case 2:
                            Marea[posiconActual].Tag = barco3colocado;
                            break;
                        case 3:
                            Marea[posiconActual].Tag = barco4colocado;
                            break;
                    }
                }
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        barco1count--;
                        break;
                    case 1:
                        barco2count--;
                        barco2colocado++;
                        break;
                    case 2:
                        barco3count--;
                        barco3colocado++;
                        break;
                    case 3:
                        barco4count--;
                        break;
                }
            }

            if (radioButtonVertical.Checked && (valorParaComprobar < 100))
            {

                clickedBox.Image = null;
                for (int i = 0; i < comboBox1.SelectedIndex; i++)
                {
                    Marea[posiconActual + ((i+1)*10)].Image = null;
                }

            }
            if (barco4count == 0)
            {
                comboBox1.Items.Remove("Barco 4");
            }
            if (barco3count == 0)
            {
                comboBox1.Items.Remove("Barco 3");
            }
            if (barco2count == 0)
            {
                comboBox1.Items.Remove("Barco 2");
            }
            if (barco1count == 0)
            {
                comboBox1.Items.Remove("Barco 1");
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
            //pictureBox1.Dock = DockStyle.Fill;
            if (comboBox1.SelectedIndex == 0)
            {
                pictureBox1.Image = Properties.Resources.BarcoPequeño1;
            } else if (comboBox1.SelectedIndex == 1)
            {
                pictureBox1.Image = Properties.Resources.BarcoMediano2;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                pictureBox1.Image = Properties.Resources.BarcoDe3;
            } else
            {
                pictureBox1.Image = Properties.Resources.BarcoGrande4;
            }
        }
    }
}
