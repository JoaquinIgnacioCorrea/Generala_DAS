using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;

namespace Generala_DAS
{
    public partial class frmBitacora : Form
    {
        private readonly BITACORA_BLL bitacora_bll = new BITACORA_BLL();

        public frmBitacora()
        {
            InitializeComponent();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            CargarBitacora();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarBitacora();
        }

        private void CargarBitacora()
        {
            try
            {
                List<BITACORA_BE> eventos = bitacora_bll.ListarEventos();
                dgvBitacora.DataSource = null;
                dgvBitacora.DataSource = eventos;

                if (dgvBitacora.Columns["Id_bitacora"] != null)
                    dgvBitacora.Columns["Id_bitacora"].HeaderText = "ID";

                if (dgvBitacora.Columns["Id_jugador"] != null)
                    dgvBitacora.Columns["Id_jugador"].Visible = false;

                if (dgvBitacora.Columns["Usuario"] != null)
                    dgvBitacora.Columns["Usuario"].HeaderText = "Usuario";

                if (dgvBitacora.Columns["Fecha"] != null)
                {
                    dgvBitacora.Columns["Fecha"].HeaderText = "Fecha / Hora";
                    dgvBitacora.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }

                if (dgvBitacora.Columns["Descripcion"] != null)
                    dgvBitacora.Columns["Descripcion"].HeaderText = "Acción";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar la bitácora desde la base de datos: " + ex.Message,
                    "Bitácora de Eventos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
