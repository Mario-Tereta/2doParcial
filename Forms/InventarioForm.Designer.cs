namespace Proyct2doParcial
{
    partial class InventarioForm
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
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnRegresar = new Button();
            lblTotal = new Label();
            dgvInventario = new DataGridView();
            txtBuscar = new TextBox();
            cmbJugador = new ComboBox();
            cmbBloque = new ComboBox();
            txtCantidad = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(58, 328);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "button1";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += BtnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(262, 328);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "button2";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += BtnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(362, 327);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "button3";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(464, 327);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "button4";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += BtnActualizar_Click;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(574, 327);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(75, 23);
            btnRegresar.TabIndex = 4;
            btnRegresar.Text = "button5";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += BtnRegresar_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(671, 333);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(38, 15);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "label1";
            // 
            // dgvInventario
            // 
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(55, 51);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.Size = new Size(688, 260);
            dgvInventario.TabIndex = 6;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(59, 17);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(223, 23);
            txtBuscar.TabIndex = 7;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            // 
            // cmbJugador
            // 
            cmbJugador.FormattingEnabled = true;
            cmbJugador.Location = new Point(59, 368);
            cmbJugador.Name = "cmbJugador";
            cmbJugador.Size = new Size(121, 23);
            cmbJugador.TabIndex = 8;
            // 
            // cmbBloque
            // 
            cmbBloque.FormattingEnabled = true;
            cmbBloque.Location = new Point(216, 368);
            cmbBloque.Name = "cmbBloque";
            cmbBloque.Size = new Size(121, 23);
            cmbBloque.TabIndex = 9;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(143, 330);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(100, 23);
            txtCantidad.TabIndex = 10;
            // 
            // InventarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtCantidad);
            Controls.Add(cmbBloque);
            Controls.Add(cmbJugador);
            Controls.Add(txtBuscar);
            Controls.Add(dgvInventario);
            Controls.Add(lblTotal);
            Controls.Add(btnRegresar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Name = "InventarioForm";
            Text = "Inventario";
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnRegresar;
        private Label lblTotal;
        private DataGridView dgvInventario;
        private TextBox txtBuscar;
        private ComboBox cmbJugador;
        private ComboBox cmbBloque;
        private TextBox txtCantidad;
    }
}