using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorioNo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIr_Click(object sender, EventArgs e)
        {
            String uri = cmb1.Text;

            //Angely Esmeralda Thomas Cortéz -  202108047 - Ingeniería en Sistemas 
            //Tercer Semestre Universidad Mesoamericana, Programación

            //condicion para url
            if (uri.Contains("."))
            {
                if (uri.Contains("https://"))
                {
                    //Buscar lo seleccionado en el combobox
                    webBrowser1.Navigate(new Uri(cmb1.Text));
                }
                else
                {
                    //si no tiene https se debera agregar a este
                    webBrowser1.Navigate(new Uri("https://" + cmb1.Text));
                    //agregar https al texto del combobox
                    cmb1.Text = "https://" + cmb1.Text;
                    //demostrar que se ha agregado
                    label1.Text = "Se ha agregado 'https'";
                }
            }
            else
            {
                uri = "http://www.google.com/search?q=" + uri;
                webBrowser1.Navigate(new Uri(uri));
            }
       
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void haciaAtrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void haciaAdelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmb1.SelectedIndex = 0;
            webBrowser1.GoHome();
        }
    }
}
