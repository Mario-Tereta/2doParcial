namespace Proyct2doParcial
{
    partial class BloquesForm
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
            dgvBloques = new DataGridView();
            txtBuscar = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBloques).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(24, 384);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += BtnAgregar_Click_1;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(165, 384);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += BtnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(298, 384);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(453, 384);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += BtnActualizar_Click;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(590, 383);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(75, 23);
            btnRegresar.TabIndex = 4;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += BtnRegresar_Click;
            // 
            // dgvBloques
            // 
            dgvBloques.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBloques.Location = new Point(53, 73);
            dgvBloques.Name = "dgvBloques";
            dgvBloques.Size = new Size(675, 291);
            dgvBloques.TabIndex = 5;
            dgvBloques.CellContentClick += DgvBloques_CellContentClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(55, 30);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(300, 23);
            txtBuscar.TabIndex = 6;
            txtBuscar.Text = "Buscar";
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(699, 387);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 7;
            // 
            // BloquesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(txtBuscar);
            Controls.Add(dgvBloques);
            Controls.Add(btnRegresar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Name = "BloquesForm";
            Text = "Bloques";
            ((System.ComponentModel.ISupportInitialize)dgvBloques).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnRegresar;
        private DataGridView dgvBloques;
        private TextBox txtBuscar;
        private System.Windows.Forms.Panel panelControles;
        private Label label1;
    }
}