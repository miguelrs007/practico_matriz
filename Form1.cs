using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._1_practico_matricez
{
    public partial class Form1 : Form
    {
        matriz x1, x2, x3;
        private void cARGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox5.Text = x1.descargar();
        }

        private void dESCARGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox5.Text = x1.descargar();
        }

        private void eJERCICIO1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(x1.ej1acumprimos());
        }

        private void eJERCICIO2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(x1.ej2elemnorepcont());
        }

        private void cARGARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            x2.cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox6.Text = x2.descargar();
        }

        private void eJERCICIO3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(x1.ej3xsubdex2(x2));
        }

        private void dESCARGARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox6.Text = x2.descargar();
        }

        private void eJERCICIO4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.ej4interfilsmayprim(); textBox6.Text = x1.descargar();
        }

        private void eJERCICIO10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.ej10mayfils(); textBox6.Text = x1.descargar();
        }

        private void eJERCICIO6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.ej6intercalarfibo(); textBox6.Text = x1.descargar();
        }

        private void eJERCICIO7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.ej7ordenarTSD1(); textBox6.Text = x1.descargar();
        }

        private void eJERCICIO8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.ej8segmTIDparimpar(); textBox6.Text = x1.descargar();
        }

        private void eJERCICIO9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.ej9orddiagonaSECdesc(); textBox6.Text = x1.descargar();
        }

        private void cARGARRAPIDO4X4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.cargar(4,4,1,11); textBox5.Text = x1.descargar();
        }

        private void eJERCICIO5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1.ej5ordporfrecuencia(); textBox6.Text = x1.descargar();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x1 = new matriz();
            x2 = new matriz();
            x3 = new matriz();
        }
    }
}
