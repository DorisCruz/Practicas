using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesCruz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            controlBoton1.BotonInterno.Text = "Haz clic";
            controlBoton1.BotonClick += ControlBoton1_BotonClick;
        }

        private void ControlBoton1_BotonClick(object sender, EventArgs e)
        {
            MessageBox.Show("¡Botón clickeado!");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void controlBoton1_Load(object sender, EventArgs e)
        {

        }
    }
}
