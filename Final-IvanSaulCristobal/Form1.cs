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
        int barcoImgCount = 0;
        


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
            PictureBox clickedBox1 = (PictureBox)sender;


            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Primero debes seleccionar que barco deseas colocar...");
            }
            if(!radioButtonHorizontal.Checked && !radioButtonVertical.Checked && comboBox1.SelectedIndex != -1)
            {
                MessageBox.Show("Primero debes seleccionar si quieres los barcos en horizontal o en vertical...");
            }


            if (comboBox1.SelectedIndex == 0 && barco1count > 0)
            {
                if((int)clickedBox1.Tag == 0)
                {
                    ponerEnHorizontal(clickedBox1);
                    ponerEnVertical(clickedBox1);
                    label1.Text = "Te quedan " + barco1count + " barcos pequeños.";
                }
                else
                {
                    MessageBox.Show("No pongas barcos adyacentes!");
                }
            }
            else if (comboBox1.SelectedIndex == 0 && barco1count == 0)
            {
                MessageBox.Show("No te quedan barcos pequeños!");
            }
            if (comboBox1.SelectedIndex == 1 && barco2count > 0)
            {
                if ((int)clickedBox1.Tag == 0)
                {
                    ponerEnHorizontal(clickedBox1);
                    ponerEnVertical(clickedBox1);
                    label1.Text = "Te quedan " + barco1count + " barcos medianos.";
                }
                else
                {
                    MessageBox.Show("No pongas barcos adyacentes!");
                }
            }
            else if (comboBox1.SelectedIndex == 1 && barco2count == 0)
            {
                MessageBox.Show("No te quedan barcos medianos!");
            }
            if (comboBox1.SelectedIndex == 2 && barco3count > 0)
            {
                if ((int)clickedBox1.Tag  == 0)
                {
                    ponerEnHorizontal(clickedBox1);
                    ponerEnVertical(clickedBox1);
                    label1.Text = "Te quedan " + barco1count + " barcos grandes.";
                }
                else
                {
                    MessageBox.Show("No pongas barcos adyacentes!");
                }
            }
            else if (comboBox1.SelectedIndex == 2 && barco3count == 0)
            {
                MessageBox.Show("No te quedan barcos grandes!");
            }
            if (comboBox1.SelectedIndex == 3 && barco4count > 0)
            {
                if ((int)clickedBox1.Tag == 0)
                {
                    ponerEnHorizontal(clickedBox1);
                    ponerEnVertical(clickedBox1);
                    label1.Text = "Te quedan " + barco1count + " destructores.";
                }
                else
                {
                    MessageBox.Show("No pongas barcos adyacentes!");
                }
            }
            else if (comboBox1.SelectedIndex == 3 && barco4count == 0)
            {
                MessageBox.Show("No te quedan destructores!");
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
                label1.Text = "Te quedan " + barco1count + " barcos pequeños.";
            } else if (comboBox1.SelectedIndex == 1)
            {
                pictureBox1.Image = Properties.Resources.BarcoMediano2;
                label1.Text = "Te quedan " + barco2count + " barcos medianos.";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                pictureBox1.Image = Properties.Resources.BarcoDe3;
                label1.Text = "Te quedan " + barco3count + " barcos grandes.";
            } else
            {
                pictureBox1.Image = Properties.Resources.BarcoGrande4;
                label1.Text = "Te quedan " + barco4count + " destructores.";
            }
        }

        private void ponerEnHorizontal(PictureBox clickedBox2)
        {
            posiconActual = Convert.ToInt32(clickedBox2.Name);
            decenaActual = (int)(posiconActual / 10);
            decenaParaComprobar = (int)((posiconActual + (comboBox1.SelectedIndex)) / 10);
            valorParaComprobar = (posiconActual + (comboBox1.SelectedIndex * 10));

            if (radioButtonHorizontal.Checked && (decenaParaComprobar == decenaActual))
            {

                for (int i = 0; i < comboBox1.SelectedIndex; i++)
                {
                    if ((int)Marea[posiconActual + i].Tag != 0)
                    {
                        MessageBox.Show("No puedes meter un barco aquí!");
                        return;
                    }
                }
                if (comboBox1.SelectedIndex == 0)
                {
                    Marea[posiconActual].Tag = barco1colocado;

                    if (((posiconActual - 1) - decenaActual * 10) >= 0)
                    {
                        Marea[posiconActual - 1].Tag = 1;
                    }
                    if (((posiconActual - 1) - decenaActual * 10) >= 0 && decenaActual > 0)
                    {
                        Marea[posiconActual - 1 - 10].Tag = 1;
                        Marea[posiconActual - 10].Tag = 1;
                    }
                    if (((posiconActual - 1) - decenaActual * 10) >= 0 && decenaActual < 9)
                    {

                        Marea[posiconActual - 1 + 10].Tag = 1;
                        Marea[posiconActual + 10].Tag = 1;
                    }

                    else
                    {
                        if (decenaActual > 0)
                        {
                            Marea[posiconActual + 1 - 10].Tag = 1;
                        }
                        if (decenaActual < 9)
                        {
                            Marea[posiconActual + 1 + 10].Tag = 1;
                        }
                        if (((posiconActual + 1) - decenaActual * 10) < 10)
                        {
                            Marea[posiconActual + 1].Tag = 1;
                        }
                    }
                    clickedBox2.Image = Properties.Resources.BarcoPequeño1;
                    clickedBox2.Dock = DockStyle.Fill;
                }
                for (int i = 0; i < comboBox1.SelectedIndex; i++)
                {
                    if (i == 0)
                    {
                        if (((posiconActual + i-1) - decenaActual * 10) >= 0)
                        {
                            Marea[posiconActual + i-1].Tag = 1;
                        }
                        if (((posiconActual + i - 1) - decenaActual * 10) >= 0 && decenaActual > 0)
                        {
                            Marea[posiconActual + i - 1 - 10].Tag = 1;
                            Marea[posiconActual + i - 10].Tag = 1;
                        }
                        if (((posiconActual + i - 1) - decenaActual * 10) >= 0 && decenaActual < 9)
                        {

                            Marea[posiconActual + i - 1 + 10].Tag = 1;
                            Marea[posiconActual + i + 10].Tag = 1;
                        }
                    }
                    else if (i == comboBox1.SelectedIndex - 1)
                    {
                        if (((posiconActual + i + 1) - decenaActual * 10) < 10)
                        {
                            Marea[posiconActual + i + 1].Tag = 1;
                            Marea[posiconActual + i + 2].Tag = 1;
                        }
                        if (((posiconActual + i + 1) - decenaActual * 10) >= 0 && decenaActual > 0)
                        {
                            Marea[posiconActual + i + 2 - 10].Tag = 1;
                            Marea[posiconActual + i + 1 - 10].Tag = 1;
                            Marea[posiconActual + i - 10].Tag = 1;
                        }
                        if (((posiconActual + i + 1) - decenaActual * 10) >= 0 && decenaActual < 9)
                        {
                            Marea[posiconActual + i + 2 + 10].Tag = 1;
                            Marea[posiconActual + i + 1 + 10].Tag = 1;
                            Marea[posiconActual + i + 10].Tag = 1;
                        }
                    }
                    else
                    {
                        if (decenaActual > 0)
                        {
                            Marea[posiconActual + i - 10].Tag = 1;
                        }
                        if (decenaActual < 9)
                        {
                            Marea[posiconActual + i + 10].Tag = 1;
                        }
                    }
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            Marea[posiconActual + i].Tag = barco1colocado;
                            break;
                        case 1:
                            Marea[posiconActual+i].Tag = barco2colocado;
                            if(i == 0)
                            {
                                Marea[posiconActual + i].Image = Properties.Resources.BarcoMediano2_1;
                                Marea[posiconActual + (i+1)].Image = Properties.Resources.BarcoMediano2_2;
                            }
                            break;
                        case 2:
                            Marea[posiconActual+i].Tag = barco3colocado;
                            if (i == 0)
                            {
                                Marea[posiconActual + i].Image = Properties.Resources.BarcoDe3_1;
                                Marea[posiconActual + i + 1].Image = Properties.Resources.BarcoDe3_2;
                                Marea[posiconActual + i + 2].Image = Properties.Resources.BarcoDe3_3;
                            }
                            break;
                        case 3:
                            Marea[posiconActual+i].Tag = barco4colocado;
                            if (i == 0)
                            {
                                Marea[posiconActual + i].Image = Properties.Resources.BarcoGrande4_1;
                                Marea[posiconActual + i + 1].Image = Properties.Resources.BarcoGrande4_2;
                                Marea[posiconActual + i + 2].Image = Properties.Resources.BarcoGrande4_3;
                                Marea[posiconActual + i + 3].Image = Properties.Resources.BarcoGrande4_4;
                            }
                            break;
                        default:
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
                    default:
                        break;
                }
            }
        }

        private void ponerEnVertical(PictureBox clickedBox3)
        {

            posiconActual = Convert.ToInt32(clickedBox3.Name);
            decenaActual = (int)(posiconActual / 10);
            decenaParaComprobar = (int)((posiconActual + (comboBox1.SelectedIndex)) / 10);
            valorParaComprobar = (posiconActual + (comboBox1.SelectedIndex * 10));

            if (radioButtonVertical.Checked && (valorParaComprobar < 100))
            {
                for (int i = 0; i < comboBox1.SelectedIndex; i++)
                {
                    if ((int)Marea[posiconActual + (i*10)].Tag != 0)
                    {
                        MessageBox.Show("No puedes meter un barco aquí!");
                        return;
                    }
                }
                clickedBox3.Image = null;
                if (comboBox1.SelectedIndex == 0)
                {
                    Marea[posiconActual].Tag = barco1colocado;

                    if (((posiconActual - (1 * 10)) - decenaActual * 10) >= 0)
                    {
                        Marea[posiconActual - (1 * 10)].Tag = 1;
                    }
                    if (((posiconActual - (1 * 10)) - decenaActual * 10) >= 0 && decenaActual > 0)
                    {
                        Marea[posiconActual - (1 * 10) - 10].Tag = 1;
                        Marea[posiconActual - 10].Tag = 1;
                    }
                    if (((posiconActual - (1 * 10)) - decenaActual * 10) >= 0 && decenaActual < 9)
                    {

                        Marea[posiconActual - (1 * 10) + 10].Tag = 1;
                        Marea[posiconActual + 10].Tag = 1;
                    }

                    else
                    {
                        if (decenaActual > 0)
                        {
                            Marea[posiconActual + 1 - 10].Tag = 1;
                        }
                        if (decenaActual < 9)
                        {
                            Marea[posiconActual + 1 + 10].Tag = 1;
                        }
                        if (((posiconActual + 1) - decenaActual * 10) < 10)
                        {
                            Marea[posiconActual + 1].Tag = 1;
                        }
                    }
                }
                for (int i = 0; i < comboBox1.SelectedIndex; i++)
                {
                    Marea[posiconActual + ((i + 1) * 10)].Image = null;
                    //Marea[posiconActual + (i + 1)].Image = null;
                    if (i == 0)
                    {
                        if ((posiconActual + (i * 10) - decenaActual * 10) >= 0)
                        {
                            Marea[posiconActual + (i * 10)].Tag = 1;
                        }
                        if ((posiconActual + (i * 10)) - decenaActual * 10 >= 0 && decenaActual > 0)
                        {
                            Marea[posiconActual + (i * 10) - 10].Tag = 1;
                            Marea[posiconActual + ((i + 1) * 10) - 10].Tag = 1;
                        }
                        if ((posiconActual + ((i + i) * 10) + 10) < 100 && decenaActual < 9)
                        {

                            Marea[posiconActual + (i * 10) + 10].Tag = 1;
                            Marea[posiconActual + ((i + 1) * 10) + 10].Tag = 1;
                        }
                    }
                    else if (i == comboBox1.SelectedIndex - 1)
                    {
                        if (((posiconActual + ((i + 2) * 10)) - decenaActual * 10) < 10)
                        {
                            Marea[posiconActual + ((i + 2) * 10)].Tag = 1;
                        }
                        if (((posiconActual + ((i + 2) * 10)) - decenaActual * 10) >= 0 && decenaActual > 0)
                        {
                            Marea[posiconActual + ((i + 2) * 10) - 10].Tag = 1;
                            Marea[posiconActual + ((i + 1) * 10) - 10].Tag = 1;
                        }
                        if ((posiconActual + ((i + 2) * 10) + 10) < 100 && decenaActual < 9)
                        {
                            //MessageBox.Show((posiconActual + ((i + 2) * 10) + 10).ToString());
                            Marea[posiconActual + ((i + 2) * 10) + 10].Tag = 1;
                            Marea[posiconActual + ((i + 1) * 10) + 10].Tag = 1;
                        }
                    }
                    else
                    {
                        if (decenaActual > 0)
                        {
                            Marea[posiconActual + ((i + 1) * 10) - 10].Tag = 1;
                        }
                        if (decenaActual < 9)
                        {
                            Marea[posiconActual + ((i + 1) * 10) + 10].Tag = 1;
                        }
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
                        default:
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
                    default:
                        break;
                }
            }
        }
    }
}
