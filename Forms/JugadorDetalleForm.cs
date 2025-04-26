using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyect2doParcial.Models;

namespace Proyct2doParcial
{
    public partial class JugadorDetalleForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Jugador Jugador { get; private set; }

        // Constructor para nuevo jugador
        public JugadorDetalleForm()
        {
            InitializeComponent();
            Jugador = new Jugador { Nivel = 1, FechaCreacion = DateTime.Now };
            Text = "Nuevo Jugador";
            ConfigurarControles();
        }

        // Constructor para editar jugador existente
        public JugadorDetalleForm(Jugador jugadorExistente)
        {
            InitializeComponent();
            Jugador = jugadorExistente;
            Text = "Editar Jugador";
            ConfigurarControles();
            CargarDatosExistente();
        }

        private void ConfigurarControles()
        {
            // Configuración básica del formulario
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(350, 200);

            // Etiquetas
            var lblNombre = new Label
            {
                Text = "Nombre:",
                Location = new Point(20, 20),
                Size = new Size(80, 20)
            };

            var lblNivel = new Label
            {
                Text = "Nivel:",
                Location = new Point(20, 60),
                Size = new Size(80, 20)
            };

            // Controles de entrada
            txtNombre = new TextBox
            {
                Location = new Point(100, 20),
                Size = new Size(220, 25),
                MaxLength = 100
            };

            numNivel = new NumericUpDown
            {
                Location = new Point(100, 60),
                Size = new Size(80, 25),
                Minimum = 1,
                Maximum = 1000
            };

            // Botones
            btnAceptar = new Button
            {
                Text = "Aceptar",
                DialogResult = DialogResult.OK,
                Location = new Point(150, 120),
                Size = new Size(80, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Location = new Point(240, 120),
                Size = new Size(80, 30)
            };

            // Eventos
            btnAceptar.Click += BtnAceptar_Click;

            // Agregar controles al formulario
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblNivel);
            this.Controls.Add(numNivel);
            this.Controls.Add(btnAceptar);
            this.Controls.Add(btnCancelar);
        }

        private void CargarDatosExistente()
        {
            txtNombre.Text = Jugador.Nombre;
            numNivel.Value = Jugador.Nivel;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Jugador.Nombre = txtNombre.Text.Trim();
                Jugador.Nivel = (int)numNivel.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del jugador es requerido.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (numNivel.Value < 1)
            {
                MessageBox.Show("El nivel debe ser un número positivo.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numNivel.Focus();
                return false;
            }

            return true;
        }

        // Controles (declarados como miembros de clase)
        private TextBox txtNombre;
        private NumericUpDown numNivel;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}