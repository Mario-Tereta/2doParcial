namespace Proyct2doParcial
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnGestionJugadores = new Button();
            btnGestionBloques = new Button();
            btnGestionInventario = new Button();
            SuspendLayout();
            // 
            // btnGestionJugadores
            // 
            btnGestionJugadores.Location = new Point(93, 233);
            btnGestionJugadores.Name = "btnGestionJugadores";
            btnGestionJugadores.Size = new Size(129, 39);
            btnGestionJugadores.TabIndex = 0;
            btnGestionJugadores.Text = "Jugadores";
            btnGestionJugadores.UseVisualStyleBackColor = true;
            btnGestionJugadores.Click += btnGestionJugadores_Click_1;
            // 
            // btnGestionBloques
            // 
            btnGestionBloques.Location = new Point(307, 233);
            btnGestionBloques.Name = "btnGestionBloques";
            btnGestionBloques.Size = new Size(129, 39);
            btnGestionBloques.TabIndex = 1;
            btnGestionBloques.Text = "Bloques";
            btnGestionBloques.UseVisualStyleBackColor = true;
            btnGestionBloques.Click += btnGestionBloques_Click_1;
            // 
            // btnGestionInventario
            // 
            btnGestionInventario.Location = new Point(530, 233);
            btnGestionInventario.Name = "btnGestionInventario";
            btnGestionInventario.Size = new Size(129, 39);
            btnGestionInventario.TabIndex = 2;
            btnGestionInventario.Text = "Inventario";
            btnGestionInventario.UseVisualStyleBackColor = true;
            btnGestionInventario.Click += btnGestionInventario_Click_1;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(btnGestionInventario);
            Controls.Add(btnGestionBloques);
            Controls.Add(btnGestionJugadores);
            Name = "Main";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGestionJugadores;
        private Button btnGestionBloques;
        private Button btnGestionInventario;
    }
}
