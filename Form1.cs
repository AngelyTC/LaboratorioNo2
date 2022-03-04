using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace LaboratorioNo2
{
    public partial class Form1 : Form
    {
        int veces = 0;
        List<string> fav = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIr_Click(object sender, EventArgs e)
        {
            String uri = cmbBuscar.Text;

            //Angely Esmeralda Thomas Cortéz -  202108047 - Ingeniería en Sistemas 
            //Tercer Semestre Universidad Mesoamericana, Programación

            //condicion para url
            if (uri.Contains("."))
            {
                if (uri.Contains("https://"))
                {
                    //Buscar lo seleccionado en el combobox
                    webBrowser1.Navigate(new Uri(cmbBuscar.Text));
                }
                else
                {
                    webBrowser1.Navigate(new Uri("https://" + cmbBuscar.Text));
                    cmbBuscar.Text = "https://" + cmbBuscar.Text;
                }
            }
            else
            {
                uri = "http://www.google.com/search?q=" + uri;
                webBrowser1.Navigate(new Uri(uri));
            }

            //Para guardar urls sin repetir            
            for (int i = 0; i < cmbBuscar.Items.Count; i++)
            {
                if (cmbBuscar.Items[i].ToString() == uri)
                {
                    veces++;
                }
            }
            if (veces == 0)
            {
                cmbBuscar.Items.Add(uri);
                Guardar(@"C:\ArchivoLab3.txt", uri);
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
            cmbBuscar.SelectedIndex = 0;
            webBrowser1.GoHome();
            string nombreArchivo = @"C:\ArchivoLab3.txt";

            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                string texto = reader.ReadLine();
                cmbBuscar.Items.Add(texto);
            }
            reader.Close();
        }

        private void Guardar(string nombreArchivo, string texto)
        {
            FileStream stream = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(texto);

            writer.Close();
        }

     
        private void másVisitadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fav.Add(webBrowser1.Url.ToString());
            actualizar();
        }

        private void actualizar()
        {
            cmbBuscar.Items.Clear();
            foreach(string direccion in fav)
            {
                cmbBuscar.Items.Add(direccion);
            }
        }
    }
}
