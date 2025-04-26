using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyct2doParcial
{
    public partial class EditarCantidadForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Cantidad { get; private set; }

        public EditarCantidadForm(int cantidadActual)
        {
            InitializeComponent();
            this.Cantidad = cantidadActual;
            numCantidad.Value = cantidadActual;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Cantidad = (int)numCantidad.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
