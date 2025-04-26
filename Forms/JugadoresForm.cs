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
    public partial class JugadoresForm : Form
    {
        private readonly JugadorService _jugadorService;
        private List<Jugador> _jugadores;
        private List<Jugador> _jugadoresFiltrados;
        public JugadoresForm(JugadorService jugadorService)
        {
            InitializeComponent();
            _jugadorService = jugadorService;

            // Configuración inicial
            ConfigurarDataGridView();
            ConfigurarControles();

            // Cargar datos
            CargarJugadores();
        }
        private void ConfigurarDataGridView()
        {
            // Configuración básica
            dgvJugadores.AutoGenerateColumns = false;
            dgvJugadores.AllowUserToAddRows = false;
            dgvJugadores.AllowUserToDeleteRows = false;
            dgvJugadores.ReadOnly = true;
            dgvJugadores.MultiSelect = false;
            dgvJugadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Estilo visual
            dgvJugadores.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvJugadores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvJugadores.EnableHeadersVisualStyles = false;
            dgvJugadores.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvJugadores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvJugadores.RowsDefaultCellStyle.BackColor = Color.White;
            dgvJugadores.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Configurar columnas
            var columnas = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    DataPropertyName = "Id",
                    HeaderText = "ID",
                    Width = 50,
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colNombre",
                    DataPropertyName = "Nombre",
                    HeaderText = "Nombre",
                    Width = 180,
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colNivel",
                    DataPropertyName = "Nivel",
                    HeaderText = "Nivel",
                    Width = 80,
                    ReadOnly = true,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colFechaCreacion",
                    DataPropertyName = "FechaCreacion",
                    HeaderText = "Fecha Creación",
                    Width = 120,
                    ReadOnly = true,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy",
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                }
            };

            dgvJugadores.Columns.AddRange(columnas);
        }

        private void ConfigurarControles()
        {
            // Configurar barra de búsqueda
            txtBuscar.PlaceholderText = "Buscar jugadores...";
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            // Configurar botones
            btnAgregar.Text = "Agregar Jugador";
           // btnAgregar.Image = Properties.Resources.add_icon; // Añade un icono si lo tienes
            btnAgregar.Click += btnAgregar_Click;

            btnEditar.Text = "Editar";
            btnEditar.Enabled = false;
            btnEditar.Click += btnEditar_Click;

            btnEliminar.Text = "Eliminar";
            btnEliminar.Enabled = false;
            btnEliminar.Click += btnEliminar_Click;

            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += BtnActualizar_Click;

            btnRegresar.Text = "Regresar";
            btnRegresar.Click += btnRegresar_Click;

            // Evento de selección
            dgvJugadores.SelectionChanged += DgvJugadores_SelectionChanged;
            //dgvJugadores.CellDoubleClick += dataGridView1_CellDoubleClick;
            dgvJugadores.CellContentClick += DgvJugadores_CellContentClick;
        }

        private void CargarJugadores()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _jugadores = _jugadorService.ObtenerTodos();
                _jugadoresFiltrados = new List<Jugador>(_jugadores);

                dgvJugadores.DataSource = _jugadoresFiltrados;
                lblTotal.Text = $"Mostrando {_jugadoresFiltrados.Count} de {_jugadores.Count} jugadores";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar jugadores: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void FiltrarJugadores(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
            {
                _jugadoresFiltrados = new List<Jugador>(_jugadores);
            }
            else
            {
                criterio = criterio.ToLower();
                _jugadoresFiltrados = _jugadores.FindAll(j =>
                    j.Nombre.ToLower().Contains(criterio) ||
                    j.Nivel.ToString().Contains(criterio) ||
                    j.FechaCreacion.ToString("dd/MM/yyyy").Contains(criterio));
            }

            dgvJugadores.DataSource = _jugadoresFiltrados;
            lblTotal.Text = $"Mostrando {_jugadoresFiltrados.Count} de {_jugadores.Count} jugadores";
        }

        #region Event Handlers

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarJugadores(txtBuscar.Text);
        }
        private void DgvJugadores_SelectionChanged(object sender, EventArgs e)
        {
            bool haySeleccion = dgvJugadores.SelectedRows.Count > 0;
            btnEditar.Enabled = haySeleccion;
            btnEliminar.Enabled = haySeleccion;
        }
        private void DgvJugadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, e);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = new JugadorDetalleForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _jugadorService.Crear(form.Jugador);
                    CargarJugadores();
                    MessageBox.Show("Jugador agregado con éxito", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar jugador: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvJugadores.SelectedRows.Count == 0) return;

            var jugador = (Jugador)dgvJugadores.SelectedRows[0].DataBoundItem;
            var form = new JugadorDetalleForm(jugador);

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _jugadorService.Actualizar(form.Jugador);
                    CargarJugadores();
                    MessageBox.Show("Jugador actualizado con éxito", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar jugador: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvJugadores.SelectedRows.Count == 0) return;

            var jugador = (Jugador)dgvJugadores.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Está seguro de eliminar al jugador {jugador.Nombre}?", "Confirmar eliminación",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _jugadorService.Eliminar(jugador.Id);
                    CargarJugadores();
                    MessageBox.Show("Jugador eliminado con éxito", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar jugador: {ex.Message}\n\n{ex.InnerException?.Message}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarJugadores();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }

}
