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
    public partial class InventarioForm : Form
    {
        private readonly InventarioService _inventarioService;
        private readonly JugadorService _jugadorService;
        private readonly BloqueService _bloqueService;
        private List<Inventario> _inventario;
        private List<Inventario> _inventarioFiltrado;

        public InventarioForm(InventarioService inventarioService,
                            JugadorService jugadorService,
                            BloqueService bloqueService)
        {
            InitializeComponent();  
            _inventarioService = inventarioService;
            _jugadorService = jugadorService;
            _bloqueService = bloqueService;
            ConfigurarDataGridView();
            ConfigurarControles();
            CargarInventario();
            CargarCombos();
        }

        private void ConfigurarDataGridView()
        {
            dgvInventario.AutoGenerateColumns = false;
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.ReadOnly = true;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Estilo visual
            dgvInventario.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvInventario.EnableHeadersVisualStyles = false;
            dgvInventario.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvInventario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInventario.RowsDefaultCellStyle.BackColor = Color.White;
            dgvInventario.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

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
                    Name = "colJugador",
                    DataPropertyName = "NombreJugador",
                    HeaderText = "Jugador",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colBloque",
                    DataPropertyName = "NombreBloque",
                    HeaderText = "Bloque",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colCantidad",
                    DataPropertyName = "Cantidad",
                    HeaderText = "Cantidad",
                    Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                }
            };

            dgvInventario.Columns.AddRange(columnas);
        }

        private void ConfigurarControles()
        {
            // Configurar barra de búsqueda
            txtBuscar.PlaceholderText = "Buscar en inventario...";
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Configurar botones
            btnAgregar.Text = "Agregar al Inventario";
            btnEditar.Text = "Editar Cantidad";
            btnEliminar.Text = "Eliminar";
            btnActualizar.Text = "Actualizar";
            btnRegresar.Text = "Regresar";

            // Configurar combos
            cmbJugador.DisplayMember = "Nombre";
            cmbJugador.ValueMember = "Id";

            cmbBloque.DisplayMember = "Nombre";
            cmbBloque.ValueMember = "Id";

            // Eventos
            btnAgregar.Click += BtnAgregar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnRegresar.Click += BtnRegresar_Click;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            dgvInventario.SelectionChanged += DgvInventario_SelectionChanged;
        }

        private void CargarInventario()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _inventario = _inventarioService.ObtenerTodos();
                _inventarioFiltrado = new List<Inventario>(_inventario);
                dgvInventario.DataSource = _inventarioFiltrado;
                lblTotal.Text = $"Mostrando {_inventarioFiltrado.Count} registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inventario: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CargarCombos()
        {
            try
            {
                var jugadores = _jugadorService.ObtenerTodos();
                var bloques = _bloqueService.ObtenerTodos();

                cmbJugador.DataSource = jugadores;
                cmbBloque.DataSource = bloques;

                if (cmbJugador.Items.Count > 0) cmbJugador.SelectedIndex = 0;
                if (cmbBloque.Items.Count > 0) cmbBloque.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarInventario(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
            {
                _inventarioFiltrado = new List<Inventario>(_inventario);
            }
            else
            {
                criterio = criterio.ToLower();
                _inventarioFiltrado = _inventario.FindAll(i =>
                    i.NombreJugador.ToLower().Contains(criterio) ||
                    i.NombreBloque.ToLower().Contains(criterio) ||
                    i.Cantidad.ToString().Contains(criterio));
            }

            dgvInventario.DataSource = _inventarioFiltrado;
            lblTotal.Text = $"Mostrando {_inventarioFiltrado.Count} registros";
        }
        #region Event Handlers
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida (número positivo).", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoItem = new Inventario
            {
                JugadorId = (int)cmbJugador.SelectedValue,
                BloqueId = (int)cmbBloque.SelectedValue,
                Cantidad = cantidad
            };

            try
            {
                _inventarioService.Agregar(nuevoItem);
                CargarInventario();
                MessageBox.Show("Ítem agregado al inventario con éxito!", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar ítem: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count == 0) return;

            var item = (Inventario)dgvInventario.SelectedRows[0].DataBoundItem;

            using (var form = new EditarCantidadForm(item.Cantidad))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        item.Cantidad = form.Cantidad;
                        _inventarioService.Actualizar(item);
                        CargarInventario();
                        MessageBox.Show("Cantidad actualizada con éxito!", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count == 0) return;

            var item = (Inventario)dgvInventario.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Eliminar {item.Cantidad} {item.NombreBloque} de {item.NombreJugador}?",
                               "Confirmar eliminación",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _inventarioService.Eliminar(item.Id);
                    CargarInventario();
                    MessageBox.Show("Ítem eliminado con éxito!", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarInventario();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarInventario(txtBuscar.Text);
        }
        private void DgvInventario_SelectionChanged(object sender, EventArgs e)
        {
            bool haySeleccion = dgvInventario.SelectedRows.Count > 0;
            btnEditar.Enabled = haySeleccion;
            btnEliminar.Enabled = haySeleccion;
        }
        #endregion
    }

}