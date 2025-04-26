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
    public partial class BloqueDetalleForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Bloque Bloque { get; private set; }

        // Para nuevo bloque
        public BloqueDetalleForm()
        {
            InitializeComponent();
            Bloque = new Bloque();
            Text = "Nuevo Bloque";
            ConfigurarControles();
        }

        // Para editar bloque existente
        public BloqueDetalleForm(Bloque bloqueExistente)
        {
            InitializeComponent();
            Bloque = bloqueExistente;
            Text = "Editar Bloque";
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
            this.ClientSize = new Size(400, 250);

            // Etiquetas
            var lblNombre = new Label { Text = "Nombre:", Location = new Point(20, 20), Size = new Size(80, 20) };
            var lblTipo = new Label { Text = "Tipo:", Location = new Point(20, 60), Size = new Size(80, 20) };
            var lblRareza = new Label { Text = "Rareza:", Location = new Point(20, 100), Size = new Size(80, 20) };

            // Controles de entrada
            txtNombre = new TextBox { Location = new Point(100, 20), Size = new Size(250, 25), MaxLength = 100 };

            cmbTipo = new ComboBox
            {
                Location = new Point(100, 60),
                Size = new Size(250, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTipo.Items.AddRange(new[] { "Mineral", "Madera", "Piedra", "Decoración", "Tierra", "Planta", "Otro" });

            cmbRareza = new ComboBox
            {
                Location = new Point(100, 100),
                Size = new Size(250, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRareza.Items.AddRange(new[] { "Común", "Poco común", "Raro", "Épico", "Legendario" });

            // Botones
            btnAceptar = new Button
            {
                Text = "Aceptar",
                DialogResult = DialogResult.OK,
                Location = new Point(150, 150),
                Size = new Size(80, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White
            };

            btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Location = new Point(250, 150),
                Size = new Size(80, 30)
            };

            // Eventos
            btnAceptar.Click += BtnAceptar_Click;

            // Agregar controles
            this.Controls.AddRange(new Control[] { lblNombre, txtNombre, lblTipo, cmbTipo,
                                                lblRareza, cmbRareza, btnAceptar, btnCancelar });
        }

        private void CargarDatosExistente()
        {
            txtNombre.Text = Bloque.Nombre;
            cmbTipo.SelectedItem = Bloque.Tipo;
            cmbRareza.SelectedItem = Bloque.Rareza;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Bloque.Nombre = txtNombre.Text.Trim();
                Bloque.Tipo = cmbTipo.SelectedItem.ToString();
                Bloque.Rareza = cmbRareza.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del bloque es requerido.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de bloque.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipo.Focus();
                return false;
            }

            if (cmbRareza.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una rareza.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRareza.Focus();
                return false;
            }

            return true;
        }

        // Controles (declarados como miembros de clase)
        private TextBox txtNombre;
        private ComboBox cmbTipo;
        private ComboBox cmbRareza;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}
