namespace ControlesCruz
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.controlBoton1 = new ControlesCruz.ControlBoton();
            this.ControlTextBox1 = new ControlesCruz.ControlTextBox();
            this.SuspendLayout();
            // 
            // controlBoton1
            // 
            this.controlBoton1.Location = new System.Drawing.Point(463, 171);
            this.controlBoton1.Name = "controlBoton1";
            this.controlBoton1.Size = new System.Drawing.Size(89, 23);
            this.controlBoton1.TabIndex = 2;
            this.controlBoton1.Load += new System.EventHandler(this.controlBoton1_Load);
            // 
            // ControlTextBox1
            // 
            this.ControlTextBox1.AllowedInput = ControlesCruz.ControlTextBox.InputType.Both;
            this.ControlTextBox1.Location = new System.Drawing.Point(198, 124);
            this.ControlTextBox1.Name = "ControlTextBox1";
            this.ControlTextBox1.Size = new System.Drawing.Size(133, 23);
            this.ControlTextBox1.TabIndex = 1;
            this.ControlTextBox1.TipoEntrada = "Ambos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.controlBoton1);
            this.Controls.Add(this.ControlTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ControlesCruz.ControlTextBox ControlTextBox1;
        private ControlBoton controlBoton1;
    }
}

