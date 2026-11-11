using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generala_DAS
{
    public partial class ucTableroPuntaje : UserControl
    {

        private BE.PARTIDA_GENERALA_BE partida_be;
        private BLL.PARTIDA_GENERALA_BLL partida_bll;


        public ucTableroPuntaje()
        {
            InitializeComponent();
            CrearColumnas();
            AsignarTagsADados();
            
            partida_bll = new BLL.PARTIDA_GENERALA_BLL();
            partida_bll.AgregarJugador(partida_be,"Jugador 1");
            partida_bll.AgregarJugador(partida_be,"Jugador 2");
            partida_bll.Iniciar(partida_be);

            CrearFilas();
        }

        private void AsignarTagsADados()
        {
            dado1.Tag = 0;
            dado2.Tag = 1;
            dado3.Tag = 2;
            dado4.Tag = 3;
            dado5.Tag = 4;
        }

        private void CrearColumnas()
        {
            string[] valEnum = Enum.GetNames(typeof(BE.CATEGORIAS));

            foreach (string val in valEnum)
            {
                Tablero.Columns.Add(val, val.Replace("_", ""));
            }
        }

        private void CrearFilas()
        {
            Tablero.Rows.Clear();
            foreach (var jugador  in partida_be.Jugadores)
            {
                Tablero.Rows.Add();
            }
        }

        private void dado_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox dadoClick && dadoClick.Tag is int indice)
            {
                try
                {
                    partida_bll.AlternarBloqueo(partida_be,indice);
                    BE.DADO_BE dadoActual = partida_be.Cubilete.Dados[indice];
                    dadoClick.BackColor = dadoActual.Bloqueado ? Color.Red : SystemColors.Control;
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void btn_tirar_dados_Click(object sender, EventArgs e)
        {
            try
            {
                partida_bll.TirarDados(partida_be);
                ActualizarInterfazDados();
                btn_tirar_dados.Enabled = partida_be.TurnoActual.SePuedeLanzar;
                lbl_mensaje_select_casilla.Text = partida_be.TurnoActual.SePuedeLanzar ? "" : "Seleccione una celda para terminar su turno";
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Tirada no permitida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_bloquear_dados_Click(object sender, EventArgs e)
        {
            BloquearTodosLosDadosLibres();
        }

        public void BloquearTodosLosDadosLibres()
        {
            try
            {
                for (int i = 0; i < partida_be.Cubilete.Dados.Count; i++)
                {
                    BE.DADO_BE dado = partida_be.Cubilete.Dados[i];

                    if (!dado.Bloqueado)
                    {
                        partida_bll.AlternarBloqueo(partida_be,i);

                        Control[] encontrados = this.Controls.Find($"dado{i + 1}", true);
                        if (encontrados.Length > 0 && encontrados[0] is PictureBox pbDado)
                        {
                            pbDado.BackColor = Color.Red;
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarInterfazDados()
        {
            for (int i = 0; i < partida_be.Cubilete.Dados.Count; i++)
            {
                BE.DADO_BE dado = partida_be.Cubilete.Dados[i];
                Control[] encontrados = this.Controls.Find($"dado{i + 1}", true);

                if (encontrados.Length > 0 && encontrados[0] is PictureBox pbDado)
                {
                    pbDado.Image = Image.FromFile($"Sprites/dado_cara_{dado.Valor}.png");

                    pbDado.BackColor = dado.Bloqueado ? Color.Red : SystemColors.Control;
                }
            }
        }

        private void btn_terminar_turno_Click(object sender, EventArgs e)
        {
            if (Tablero.CurrentCell == null)
            {
                MessageBox.Show("Por favor, selecciona una casilla en el tablero para anotar tu puntaje.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreColumna = Tablero.CurrentCell.OwningColumn.Name;

            if (Enum.TryParse(nombreColumna, out BE.CATEGORIAS categoriaSeleccionada))
            {
                try
                {
                    int filaIndex = partida_be.IndiceJugadorActual;
                    partida_bll.AnotarJugada(partida_be, categoriaSeleccionada);

                    BE.TABLERO_BE tablero_be = partida_be.Jugadores[filaIndex].Tablero;
                    BLL.TABLERO_BLL tablero_bll= new BLL.TABLERO_BLL();
                    int puntosAnotados = tablero_bll.ObtenerPuntaje(tablero_be, categoriaSeleccionada);
                    Tablero.Rows[filaIndex].Cells[nombreColumna].Value = puntosAnotados;

                    LimpiarInterfazNuevoTurno();
                    MessageBox.Show($"¡Puntaje registrado exitosamente en {categoriaSeleccionada.ToString().Replace("_", " ")}!",
                                    "Turno Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Acción no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No se pudo identificar la categoría de la casilla seleccionada.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarInterfazNuevoTurno()
        {
            btn_tirar_dados.Enabled = true;

            for (int i = 1; i <= 5; i++)
            {
                Control[] encontrados = this.Controls.Find($"dado{i}", true);
                if (encontrados.Length > 0 && encontrados[0] is PictureBox pbDado)
                {
                    pbDado.BackColor = SystemColors.Control;

                    string rutaInicial = System.IO.Path.Combine(Application.StartupPath, "Sprites", "dado_cara_1.png");
                    if (System.IO.File.Exists(rutaInicial))
                    {
                        pbDado.Image = Image.FromFile(rutaInicial);
                    }
                }
            }
        }


    }

}
