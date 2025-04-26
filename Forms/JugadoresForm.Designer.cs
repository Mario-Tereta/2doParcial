namespace Proyct2doParcial
{
    partial class JugadoresForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvJugadores = new DataGridView();
            txtBuscar = new TextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnRegresar = new Button();
            lblTotal = new Label();
            panelControles = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).BeginInit();
            panelControles.SuspendLayout();
            SuspendLayout();
            // 
            // dgvJugadores
            // 
            dgvJugadores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJugadores.Location = new Point(12, 50);
            dgvJugadores.Name = "dgvJugadores";
            dgvJugadores.Size = new Size(760, 400);
            dgvJugadores.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(12, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(760, 25);
            txtBuscar.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(19, 15);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(131, 15);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(239, 15);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(521, 15);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(337, 15);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(75, 23);
            btnRegresar.TabIndex = 4;
            btnRegresar.Text = "Regregar";
            btnRegresar.Click += btnRegresar_Click;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(615, 15);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 23);
            lblTotal.TabIndex = 5;
            lblTotal.Click += lblTotal_Click;
            // 
            // panelControles
            // 
            panelControles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelControles.Controls.Add(btnAgregar);
            panelControles.Controls.Add(btnEditar);
            panelControles.Controls.Add(btnEliminar);
            panelControles.Controls.Add(btnRegresar);
            panelControles.Controls.Add(btnActualizar);
            panelControles.Controls.Add(lblTotal);
            panelControles.Location = new Point(12, 460);
            panelControles.Name = "panelControles";
            panelControles.Size = new Size(760, 50);
            panelControles.TabIndex = 2;
            // 
            // JugadoresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 521);
            Controls.Add(panelControles);
            Controls.Add(txtBuscar);
            Controls.Add(dgvJugadores);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(800, 560);
            Name = "JugadoresForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Jugadores";
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).EndInit();
            panelControles.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvJugadores;
        private TextBox txtBuscar;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnRegresar;
        private Label lblTotal;
        private Panel panelControles;
    }
}