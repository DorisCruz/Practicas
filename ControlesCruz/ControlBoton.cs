using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ControlesCruz
{
    public partial class ControlBoton : UserControl
    {
        private Color _colorHover = Color.LightBlue;
        private Color _colorNormal = SystemColors.Control;

        private int clickCount = 0;
        private Timer clickTimer;

        public ControlBoton()
        {
            InitializeComponent();
            BotonInterno.BackColor = _colorNormal;

            BotonInterno.MouseEnter += BotonInterno_MouseEnter;
            BotonInterno.MouseLeave += BotonInterno_MouseLeave;
            BotonInterno.MouseClick += BotonInterno_MouseClick;

            clickTimer = new Timer();
            clickTimer.Interval = SystemInformation.DoubleClickTime; 
            clickTimer.Tick += ClickTimer_Tick;
        }

        public Button BotonInterno => button1;
        public Color ColorHover
        {
            get => _colorHover;
            set => _colorHover = value;
        }

        public Color ColorNormal
        {
            get => _colorNormal;
            set
            {
                _colorNormal = value;
                BotonInterno.BackColor = _colorNormal;
            }
        }

        public event EventHandler BotonClick;
        public event EventHandler BotonDobleClickConfirmado;

        private void BotonInterno_MouseClick(object sender, MouseEventArgs e)
        {
            clickCount++;
            clickTimer.Start();
        }

        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            clickTimer.Stop();

            if (clickCount == 1)
            {
                BotonClick?.Invoke(this, EventArgs.Empty);
            }
            else if (clickCount == 2)
            {
                var confirmacion = MessageBox.Show(
                    "¿Estás seguro de que deseas realizar esta acción?",
                    "Confirmar doble clic",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    BotonDobleClickConfirmado?.Invoke(this, EventArgs.Empty);
                }
            }

            clickCount = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BotonClick?.Invoke(this, e);
        }

        private void BotonInterno_MouseEnter(object sender, EventArgs e)
        {
            BotonInterno.BackColor = _colorHover;
        }

        private void BotonInterno_MouseLeave(object sender, EventArgs e)
        {
            BotonInterno.BackColor = _colorNormal;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
