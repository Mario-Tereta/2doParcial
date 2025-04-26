using Proyect2doParcial.Services;
using Proyect2doParcial.Utils;

namespace Proyct2doParcial
{
    public partial class MainForm : Form
    {
        private readonly DatabaseManager _dbManager;
        private readonly JugadorService _jugadorService;
        private readonly BloqueService _bloqueService;
        private readonly InventarioService _inventarioService;

        public MainForm()
        {
            InitializeComponent();

            _dbManager = new DatabaseManager();
            _jugadorService = new JugadorService(_dbManager);
            _bloqueService = new BloqueService(_dbManager);
            _inventarioService = new InventarioService(_dbManager, _jugadorService, _bloqueService);

            if (!_dbManager.TestConnection())
            {
                MessageBox.Show("No se pudo conectar a la base de datos. Verifique la conexión.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void btnGestionJugadores_Click_1(object sender, EventArgs e)
        {
            var form = new JugadoresForm(_jugadorService);
            form.ShowDialog();

        }

        private void btnGestionBloques_Click_1(object sender, EventArgs e)
        {
            var form = new BloquesForm(_bloqueService);
            form.ShowDialog();
        }

        private void btnGestionInventario_Click_1(object sender, EventArgs e)
        {
            var form = new InventarioForm(_inventarioService, _jugadorService, _bloqueService);
            form.ShowDialog();
        }
    }
}
