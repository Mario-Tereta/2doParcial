namespace Proyct2doParcial
{
    partial class EditarCantidadForm
    {
        private NumericUpDown numCantidad;
        private Button btnAceptar;
        private Button btnCancelar;

        private void InitializeComponent()
        {
            this.numCantidad = new NumericUpDown();
            this.btnAceptar = new Button();
            this.btnCancelar = new Button();
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new Point(20, 20);
            this.numCantidad.Size = new Size(200, 25);
            this.numCantidad.Minimum = 1;
            this.numCantidad.Maximum = 1000;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Location = new Point(50, 60);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new Point(140, 60);
            // 
            // EditarCantidadForm
            // 
            this.ClientSize = new Size(240, 120);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
        }
    }
}