namespace PruebaControles
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ControlesCruz.ControlBoton controlBoton1;
        private ControlesCruz.ControlTextBox controlTextBox1;
        private System.Windows.Forms.Label lblResultado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.controlBoton1 = new ControlesCruz.ControlBoton();
            this.controlTextBox1 = new ControlesCruz.ControlTextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // controlBoton1
            // 
            this.controlBoton1.ColorHover = System.Drawing.Color.LightBlue;
            this.controlBoton1.ColorNormal = System.Drawing.SystemColors.Control;
            this.controlBoton1.Location = new System.Drawing.Point(117, 136);
            this.controlBoton1.Name = "controlBoton1";
            this.controlBoton1.Size = new System.Drawing.Size(149, 49);
            this.controlBoton1.TabIndex = 0;
            // 
            // controlTextBox1
            // 
            this.controlTextBox1.Location = new System.Drawing.Point(97, 90);
            this.controlTextBox1.Name = "controlTextBox1";
            this.controlTextBox1.Size = new System.Drawing.Size(199, 19);
            this.controlTextBox1.TabIndex = 1;
            this.controlTextBox1.TipoEntrada = null;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(97, 239);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 13);
            this.lblResultado.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Numero de control:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.controlTextBox1);
            this.Controls.Add(this.controlBoton1);
            this.Name = "Form1";
            this.Text = "Prueba de Controles Personalizados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
    }
}