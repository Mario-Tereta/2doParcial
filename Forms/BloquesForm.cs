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
using Proyect2doParcial.Services;

namespace Proyct2doParcial
{
    public partial class BloquesForm : Form
    {
        private readonly BloqueService _bloqueService;
        private List<Bloque> _bloques;
        private List<Bloque> _bloquesFiltrados;

        public BloquesForm(BloqueService bloqueService)
        {
            InitializeComponent();
            _bloqueService = bloqueService;

            ConfigurarDataGridView();
            ConfigurarControles();
            CargarBloques();
        }

        private void ConfigurarDataGridView()
        {
            dgvBloques.AutoGenerateColumns = false;
            dgvBloques.AllowUserToAddRows = false;
            dgvBloques.AllowUserToDeleteRows = false;
            dgvBloques.ReadOnly = true;
            dgvBloques.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBloques.MultiSelect = false;

            // Estilo visual
            dgvBloques.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvBloques.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvBloques.EnableHeadersVisualStyles = false;
            dgvBloques.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvBloques.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBloques.RowsDefaultCellStyle.BackColor = Color.White;
            dgvBloques.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Configurar columnas
            var columnas = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    DataPropertyName = "Id",
                    HeaderText = "ID",
                    Width = 50
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colNombre",
                    DataPropertyName = "Nombre",
                    HeaderText = "Nombre",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colTipo",
                    DataPropertyName = "Tipo",
                    HeaderText = "Tipo",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colRareza",
                    DataPropertyName = "Rareza",
                    HeaderText = "Rareza",
                    Width = 100
                }
            };

            dgvBloques.Columns.AddRange(columnas);
        }

        private void ConfigurarControles()
        {
            // Configurar barra de búsqueda
            txtBuscar.PlaceholderText = "Buscar bloques...";
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Configurar botones
            btnAgregar.Text = "Agregar Bloque";
            btnEditar.Text = "Editar";
            btnEliminar.Text = "Eliminar";
            btnActualizar.Text = "Actualizar";
            btnRegresar.Text = "Regresar";

            // Eventos
            btnAgregar.Click += BtnAgregar_Click_1;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnRegresar.Click += BtnRegresar_Click;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            dgvBloques.SelectionChanged += DgvBloques_SelectionChanged;
            //dgvBloques.CellDoubleClick += DgvBloques_CellDoubleClick;
            dgvBloques.CellContentClick += DgvBloques_CellContentClick;
        }

        private void CargarBloques()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _bloques = _bloqueService.ObtenerTodos();
                _bloquesFiltrados = new List<Bloque>(_bloques);
                dgvBloques.DataSource = _bloquesFiltrados;
                label1.Text = $"Mostrando {_bloquesFiltrados.Count} de {_bloques.Count} bloques";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar bloques: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void FiltrarBloques(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
            {
                _bloquesFiltrados = new List<Bloque>(_bloques);
            }
            else
            {
                criterio = criterio.ToLower();
                _bloquesFiltrados = _bloques.FindAll(b =>
                    b.Nombre.ToLower().Contains(criterio) ||
                    b.Tipo.ToLower().Contains(criterio) ||
                    b.Rareza.ToLower().Contains(criterio));
            }

            dgvBloques.DataSource = _bloquesFiltrados;
            label1.Text = $"Mostrando {_bloquesFiltrados.Count} de {_bloques.Count} bloques";
        }

        #region Event Handlers
        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            var form = new BloqueDetalleForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _bloqueService.Crear(form.Bloque);
                    CargarBloques();
                    MessageBox.Show("Bloque agregado con éxito", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar bloque: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvBloques.SelectedRows.Count == 0) return;

            var bloque = (Bloque)dgvBloques.SelectedRows[0].DataBoundItem;
            var form = new BloqueDetalleForm(bloque);

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _bloqueService.Actualizar(form.Bloque);
                    CargarBloques();
                    MessageBox.Show("Bloque actualizado con éxito", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar bloque: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvBloques.SelectedRows.Count == 0) return;

            var bloque = (Bloque)dgvBloques.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Está seguro de eliminar el bloque {bloque.Nombre}?", "Confirmar eliminación",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _bloqueService.Eliminar(bloque.Id);
                    CargarBloques();
                    MessageBox.Show("Bloque eliminado con éxito", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar bloque: {ex.Message}\n\n{ex.InnerException?.Message}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarBloques();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarBloques(txtBuscar.Text);
        }
        private void DgvBloques_SelectionChanged(object sender, EventArgs e)
        {
            btnEditar.Enabled = dgvBloques.SelectedRows.Count > 0;
            btnEliminar.Enabled = dgvBloques.SelectedRows.Count > 0;
        }
        private void DgvBloques_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEditar_Click(sender, e);
            }
        }
        #endregion
    }
}
