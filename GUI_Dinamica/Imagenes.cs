using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VisualizadorDeImagenes
{
    public partial class Imagenes : Form
    {
        public Imagenes()
        {
            InitializeComponent();
        }


        private void CargarImagenes(string directoryPath)
        {
            flowLayoutPanel1.Controls.Clear();
            string[] imageFiles = Directory.GetFiles(directoryPath, "*.*")
                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".gif"))
                .ToArray();

            if (imageFiles.Length == 0)
            {
                MessageBox.Show("No se encontraron imágenes en ese directorio.");
                return;
            }

            foreach (string imagePath in imageFiles)
            {
                try
                {
                    PictureBox picBox = new PictureBox();
                    Image img = Image.FromFile(imagePath);
                    picBox.Image = img.GetThumbnailImage(100, 100, null, IntPtr.Zero); 
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    picBox.Width = 100;
                    picBox.Height = 100;
                    picBox.Click += (s, e) => AbrirImagenes(imagePath);
                    flowLayoutPanel1.Controls.Add(picBox);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puedo cargar la imagen: " + ex.Message);
                }

            }
        }
            private void AbrirImagenes(string imagePath)
        {
            Form ventanaImagen = new Form();
            ventanaImagen.Text = Path.GetFileName(imagePath);
            PictureBox picBox = new PictureBox();
            picBox.Image = Image.FromFile(imagePath);
            picBox.SizeMode = PictureBoxSizeMode.AutoSize;
            ventanaImagen.Controls.Add(picBox);
            ventanaImagen.ShowDialog();
        }

        private void btnImagenes_Click_1(object sender, EventArgs e)
        {
            string direccion = txtDireccion.Text;  
            if (Directory.Exists(direccion))
            {
                CargarImagenes(direccion);
            }
            else
            {
                MessageBox.Show("El directorio especificado no existe. Por favor, introduce una ruta válida.");
            }
        }
    }
}
