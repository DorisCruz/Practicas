using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ControlesCruz
{
    public partial class ControlTextBox : UserControl
    {
        public System.Windows.Forms.TextBox TextBox { get; private set; }
        public string TipoEntrada { get; set; }

        public ControlTextBox()
        {
            InitializeComponent();
            TextBox = textBox1; 
        }

        public void ValidarTexto()
        {
            string texto = TextBox.Text;

            if (Regex.IsMatch(texto, @"^\d*$")) 
            {
                TextBox.BackColor = Color.LightGreen; 
            }
            else
            {
                TextBox.BackColor = Color.LightPink;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidarTexto();
        }
    }
}

