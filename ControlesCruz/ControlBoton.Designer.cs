namespace ControlesCruz
{
    partial class ControlBoton
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button button1;

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            

            this.button1.Dock = System.Windows.Forms.DockStyle.Fill; 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Click";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Name = "ControlBoton";
            this.Size = new System.Drawing.Size(79, 26); 
            this.ResumeLayout(false);
        }
    }
}