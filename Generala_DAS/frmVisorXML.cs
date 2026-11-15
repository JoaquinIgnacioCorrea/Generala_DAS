using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BE;
using BLL;

namespace Generala_DAS
{
    public partial class frmVisorXML : Form
    {
        private readonly PARTIDA_GENERALA_BLL partida_bll = new PARTIDA_GENERALA_BLL();

        private class ArchivoXmlItem
        {
            public string Nombre { get; set; }
            public string RutaCompleta { get; set; }
            public override string ToString() => Nombre;
        }

        public frmVisorXML()
        {
            InitializeComponent();
        }

        private void frmVisorXML_Load(object sender, EventArgs e)
        {
            CargarListaArchivosXml();
        }

        private void CargarListaArchivosXml()
        {
            cmbArchivosXml.Items.Clear();
            string carpeta = partida_bll.ObtenerCarpetaPartidasXml();
            if (Directory.Exists(carpeta))
            {
                string[] archivos = Directory.GetFiles(carpeta, "*.xml");
                foreach (string archivo in archivos)
                {
                    cmbArchivosXml.Items.Add(new ArchivoXmlItem
                    {
                        Nombre = Path.GetFileName(archivo),
                        RutaCompleta = archivo
                    });
                }
            }

            if (cmbArchivosXml.Items.Count > 0)
            {
                cmbArchivosXml.SelectedIndex = 0;
            }
            else
            {
                dgvMovimientos.DataSource = null;
            }
        }

        private void cmbArchivosXml_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArchivosXml.SelectedItem is ArchivoXmlItem item)
            {
                MostrarMovimientosDeArchivo(item.RutaCompleta);
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = partida_bll.ObtenerCarpetaPartidasXml();
                ofd.Filter = "Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
                ofd.Title = "Seleccionar archivo XML de partida";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ArchivoXmlItem nuevoItem = new ArchivoXmlItem
                    {
                        Nombre = Path.GetFileName(ofd.FileName),
                        RutaCompleta = ofd.FileName
                    };
                    cmbArchivosXml.Items.Add(nuevoItem);
                    cmbArchivosXml.SelectedItem = nuevoItem;
                }
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarListaArchivosXml();
        }

        private void MostrarMovimientosDeArchivo(string rutaArchivo)
        {
            try
            {
                List<MOVIMIENTO_XML_BE> movimientos = partida_bll.LeerMovimientosXml(rutaArchivo);
                dgvMovimientos.DataSource = null;
                dgvMovimientos.DataSource = movimientos;

                if (dgvMovimientos.Columns["IdPartida"] != null)
                    dgvMovimientos.Columns["IdPartida"].HeaderText = "Partida";

                if (dgvMovimientos.Columns["FechaHora"] != null)
                {
                    dgvMovimientos.Columns["FechaHora"].HeaderText = "Fecha / Hora";
                    dgvMovimientos.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }

                if (dgvMovimientos.Columns["Jugador"] != null)
                    dgvMovimientos.Columns["Jugador"].HeaderText = "Jugador";

                if (dgvMovimientos.Columns["Ronda"] != null)
                    dgvMovimientos.Columns["Ronda"].HeaderText = "Ronda";

                if (dgvMovimientos.Columns["ValoresDados"] != null)
                    dgvMovimientos.Columns["ValoresDados"].HeaderText = "Dados";

                if (dgvMovimientos.Columns["CategoriaAnotada"] != null)
                    dgvMovimientos.Columns["CategoriaAnotada"].HeaderText = "Categoría / Acción";

                if (dgvMovimientos.Columns["PuntajeObtenido"] != null)
                    dgvMovimientos.Columns["PuntajeObtenido"].HeaderText = "Puntaje";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al leer el archivo XML: " + ex.Message,
                    "Visor de Movimientos XML",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
