using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    public partial class Gestion : Form
    {
        public Gestion()
        {
            InitializeComponent();
        }
        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            if (listcontact.SelectedIndex != -1)
            {
                listcontact.Items.RemoveAt(listcontact.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleccione un contacto para eliminar.", "Error");
            }
        }

        private void btnagregar_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtnom.Text) ||
                string.IsNullOrWhiteSpace(txttel.Text) ||
                string.IsNullOrWhiteSpace(txtcorreo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
            else
            {
                string contact = $"  {txtnom.Text}  -  {txttel.Text}  -  {txtcorreo.Text}";

                if (listcontact.Items.Count == 0)
                {
                    listcontact.Items.Add(" "); 
                }
                listcontact.Items.Add(contact);
                MessageBox.Show("Contacto agregado con éxito.");
            }
        }

        private void btnlimpiar_Click_1(object sender, EventArgs e)
        {
            txtnom.Clear();
            txttel.Clear();
            txtcorreo.Clear();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este programa fue creado por Doris Berenice Cruz Hernandez\n Grupo: 4SA\n No.Control: 23760311");
        }
    }

}
