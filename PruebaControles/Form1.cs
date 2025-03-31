using ControlesCruz;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PruebaControles
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

            controlTextBox1.TipoEntrada = "Numeros";

            controlBoton1.ColorHover = Color.LightGreen; 
            controlBoton1.ColorNormal = Color.LightGray; 

            controlBoton1.BotonClick += ControlBoton1_BotonClick;
            controlBoton1.BotonDobleClickConfirmado += ControlBoton1_BotonDobleClickConfirmado;
        }

        private void ControlBoton1_BotonClick(object sender, EventArgs e)
        {
            string texto = controlTextBox1.TextBox.Text;

            if (InputValidator.EsSoloNumeros(texto))
            {
                lblResultado.Text = "El texto contiene solo números.";
            }
          
            else if (InputValidator.EsSoloLetras(texto))
            {
                lblResultado.Text = "El texto contiene solo letras.";
            }
          
            else if (RFCValidator.EsRFCValido(texto))
            {
                lblResultado.Text = "El texto es un RFC válido.";
            }
            else
            {
                lblResultado.Text = "El texto no cumple con ninguna validación.";
            }
        }

        private void ControlBoton1_BotonDobleClickConfirmado(object sender, EventArgs e)
        {
            MessageBox.Show("¡Doble clic confirmado!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void controlBoton1_Load(object sender, EventArgs e)
        {

        }
    }
}