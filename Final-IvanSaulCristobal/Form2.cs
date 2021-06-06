using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_IvanSaulCristobal
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            InitializeComponent();
            wplay.URL = (@"C:\Users\furia_000\source\repos\Final-IvanSaulCristobal3\Final-IvanSaulCristobal\Resources\menu.mp3");
            wplay.controls.play();
            axWindowsMediaPlayer1.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public static WMPLib.WindowsMediaPlayer wplay = new WMPLib.WindowsMediaPlayer();
        private void btn_jugar_Hover(object sender,EventArgs e)
        {
            btn_jugar.Image = Properties.Resources.jugarON;
        }
        private void btn_option_Hover(object sender, EventArgs e)
        {
            btn_option.Image = Properties.Resources.optionsON;
        }

        private void btn_salir_Hover(object sender, EventArgs e)
        {
            btn_salir.Image = Properties.Resources.salirON;
        }
        private void btn_jugar_Leave(object sender, EventArgs e)
        {
            btn_jugar.Image = Properties.Resources.jugarOFF;
        }
        private void btn_option_Leave(object sender,EventArgs e)
        {
            btn_option.Image = Properties.Resources.optionsOFF;
        }
        private void btn_salir_Leave(object sender, EventArgs e)
        {
            btn_salir.Image = Properties.Resources.salirOFF;
        }
        private void btn_jugar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 juego = new Form1();
            juego.Show();
        }
        private void btn_option_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 option = new Form3();
            option.Show();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
