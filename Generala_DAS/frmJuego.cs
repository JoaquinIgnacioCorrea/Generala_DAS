using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generala_DAS
{
    public partial class frmJuego : Form
    {
        private PARTIDA_GENERALA_BE partida_be;
        private PARTIDA_GENERALA_BLL partida_bll;
        private ServidorGenerala enlace;
        private int miIndice;
        private TABLERO_BLL tablerobll = new TABLERO_BLL();

        public frmJuego()
        {
            InitializeComponent();
            CrearColumnas();
            AsignarTagsADados();

            partida_be = new PARTIDA_GENERALA_BE();
            partida_bll = new PARTIDA_GENERALA_BLL();
            partida_bll.AgregarJugador(partida_be, "Jugador 1");
            partida_bll.AgregarJugador(partida_be, "Jugador 2");
            partida_bll.Iniciar(partida_be);

            CrearFilas();
        }

        public frmJuego(ServidorGenerala e) : this()
        {
            enlace = e;
        }

        private void frmJuego_Load(object sender, EventArgs e)
        {
            if (enlace != null)
            {
                ConfigurarRed(enlace);
            }
        }

        private void frmJuego_FormClosing(object sender, FormClosingEventArgs e)
        {
            enlace?.cerrar();
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
            string[] valEnum = Enum.GetNames(typeof(CATEGORIAS));

            foreach (string val in valEnum)
            {
                Tablero.Columns.Add(val, val.Replace("_", ""));
            }
        }

        private void CrearFilas()
        {
            Tablero.Rows.Clear();
            foreach (var jugador in partida_be.Jugadores)
            {
                Tablero.Rows.Add();
            }
        }

        private void dado_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox dadoClick && dadoClick.Tag is int indice)
            {
                EnviarAccion("BLOQUEAR;" + indice);
            }
        }

        private void btn_tirar_dados_Click(object sender, EventArgs e)
        {
            EnviarAccion("TIRAR");
        }

        private void btn_bloquear_dados_Click(object sender, EventArgs e)
        {
            BloquearTodosLosDadosLibres();
        }

        public void BloquearTodosLosDadosLibres()
        {
            for (int i = 0; i < partida_be.Cubilete.Dados.Count; i++)
            {
                if (!partida_be.Cubilete.Dados[i].Bloqueado)
                {
                    EnviarAccion("BLOQUEAR;" + i);
                }
            }
        }

        private void ActualizarInterfazDados()
        {
            for (int i = 0; i < partida_be.Cubilete.Dados.Count; i++)
            {
                DADO_BE dado = partida_be.Cubilete.Dados[i];
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

            if (Enum.TryParse(nombreColumna, out CATEGORIAS categoriaSeleccionada))
            {
                EnviarAccion("ANOTAR;" + categoriaSeleccionada);
            }
            else
            {
                MessageBox.Show("No se pudo identificar la categoría de la casilla seleccionada.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ConfigurarRed(ServidorGenerala e)
        {
            enlace = e;
            miIndice = enlace.Host ? 0 : 1;
            enlace.MensajeRecibido += AlRecibirMensaje;
            enlace.EmpezarAEscuchar();
            if (enlace.Host) { HostEjecutar(null, 0); }
        }

        private string TableroATexto(TABLERO_BE t)
        {
            List<string> partes = new List<string>();
            foreach (CATEGORIAS cat in Enum.GetValues(typeof(CATEGORIAS)))
            {
                if (!tablerobll.CasilleroDisponible(t, cat))
                {
                    partes.Add(cat + ":" + tablerobll.ObtenerPuntaje(t, cat));
                }
            }
            return string.Join(",", partes);
        }

        private string SerializarEstado()
        {
            List<DADO_BE> dados = partida_be.Cubilete.Dados;
            string valores = string.Join(",", dados.Select(d => d.Valor));
            string bloqueos = string.Join(",", dados.Select(d => d.Bloqueado ? 1 : 0));

            int turno = partida_be.IndiceJugadorActual;
            int puedelanzar = partida_be.TurnoActual.SePuedeLanzar ? 1 : 0;
            int fin = partida_be.PartidaFinalizada ? 1 : 0;
            string t0 = TableroATexto(partida_be.Jugadores[0].Tablero);
            string t1 = TableroATexto(partida_be.Jugadores[1].Tablero);

            return $"ESTADO;{valores};{bloqueos};{turno};{puedelanzar};{fin};{t0};{t1}";
        }

        private void ProcesarComando(string comando, int quienPide)
        {
            if (partida_be.IndiceJugadorActual != quienPide)
            {
                throw new InvalidOperationException("No es tu turno");
            }
            string[] partes = comando.Split(';');

            switch (partes[0])
            {
                case "TIRAR":
                    partida_bll.TirarDados(partida_be);
                    break;
                case "BLOQUEAR":
                    partida_bll.AlternarBloqueo(partida_be, int.Parse(partes[1]));
                    break;
                case "ANOTAR":
                    CATEGORIAS cat = (CATEGORIAS)Enum.Parse(typeof(CATEGORIAS), partes[1]);
                    partida_bll.AnotarJugada(partida_be, cat);
                    break;
                default: throw new InvalidOperationException("No se reconocio el comando");
            }
        }

        private void HostEjecutar(string comando, int quienPide)
        {
            try
            {
                if (comando != null)
                {
                    ProcesarComando(comando, quienPide);
                }
                string estado = SerializarEstado();
                enlace?.Enviar(estado);
                AplicarEstado(estado);
            }
            catch (InvalidOperationException ex)
            {
                if (enlace != null && quienPide != miIndice)
                {
                    enlace.Enviar("ERROR;" + ex.Message);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Accion no permitida.");
                }
            }
        }

        private void EnviarAccion(string comando)
        {
            if (enlace == null)
            {
                HostEjecutar(comando, partida_be.IndiceJugadorActual);
            }
            else if (enlace.Host)
            {
                HostEjecutar(comando, 0);
            }
            else
            {
                enlace.Enviar(comando);
            }
        }

        private void AplicarEstado(string estado)
        {
            string[] s = estado.Split(';');

            int[] valores = s[1].Split(',').Select(int.Parse).ToArray();
            bool[] bloqueos = s[2].Split(',').Select(x => x == "1").ToArray();
            int turno = int.Parse(s[3]);
            bool puede = s[4] == "1";
            bool fin = s[5] == "1";

            for (int i = 0; i < 5; i++)
            {
                partida_be.Cubilete.Dados[i].Valor = valores[i];
                partida_be.Cubilete.Dados[i].Bloqueado = bloqueos[i];
            }
            ActualizarInterfazDados();

            CargarFilas(0, s[6]);
            CargarFilas(1, s[7]);

            bool esMiTurno = (enlace == null || turno == miIndice) && !fin;
            btn_tirar_dados.Enabled = esMiTurno && puede;
            btn_terminar_turno.Enabled = esMiTurno;
            lbl_mensaje_select_casilla.Text =
                fin ? "Partida terminada." :
                !esMiTurno ? "Turno del rival" :
                !puede ? "Seleccione una celda para terminar el turno" : "";
            if (fin)
            {
                MessageBox.Show("Partida Finalizada");
            }
        }

        private void CargarFilas(int fila, string texto)
        {
            string[] s = texto.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string f in s)
            {
                string[] cat = f.Split(':');
                Tablero.Rows[fila].Cells[cat[0]].Value = cat[1];
            }
        }

        private void AlRecibirMensaje(string mensaje)
        {
            if (this.IsDisposed || this.Disposing || !this.IsHandleCreated)
                return;
            this.Invoke((Action)(() =>
            {
                if (mensaje == "DESCONECTADO")
                {
                    MessageBox.Show("El Rival se desconectó.");
                    btn_tirar_dados.Enabled = false;
                    return;
                }
                if (enlace.Host)
                {
                    HostEjecutar(mensaje, 1);
                }
                else if (mensaje.StartsWith("ESTADO"))
                {
                    AplicarEstado(mensaje);
                }
                else if (mensaje.StartsWith("ERROR"))
                {
                    MessageBox.Show(mensaje.Split(';')[1]);
                }
            }));
        }
    }
}
