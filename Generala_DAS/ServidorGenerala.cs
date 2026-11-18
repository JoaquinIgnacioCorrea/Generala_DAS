using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Generala_DAS
{
    public class ServidorGenerala
    {
        private TcpListener listener;
        private TcpClient cliente;
        private StreamReader sr;
        private StreamWriter sw;
        private bool host;

        public bool Host
        {
            get { return host; }
            set { host = value; }
            
        }

        public event Action<String> MensajeRecibido;

        public async Task hostear(int puerto)
        {
            listener = new TcpListener(IPAddress.Any, puerto);
            listener.Start();
            cliente = await listener.AcceptTcpClientAsync();
            listener.Stop();
            NetworkStream stream = cliente.GetStream();
            sr = new StreamReader(stream);
            sw = new StreamWriter(stream);
            sw.AutoFlush = true;
            Host = true;
        }
        public async Task conectar(string ip, int puerto)
        {
            cliente = new TcpClient();
            await cliente.ConnectAsync(ip, puerto);

            NetworkStream stream = cliente.GetStream();
            sr = new StreamReader(stream);
            sw = new StreamWriter(stream);
            sw.AutoFlush = true;

        }
        public void Enviar(string msj)
        {
            sw.WriteLine(msj);
        }
        public void EmpezarAEscuchar()
        {
            Task.Run(() =>
            {
                while (true) 
                {
                    string linea;
                    try
                    {
                        linea = sr.ReadLine();
                    }
                    catch (Exception ex) { linea = null; }

                    if (linea == null)
                    {
                        MensajeRecibido?.Invoke("DESCONECTADO");
                        break;
                    }
                    MensajeRecibido?.Invoke(linea);

                }
            });

        }
        public void cerrar()
        {
            sr?.Close();
            sw?.Close();
            cliente?.Close();
            listener?.Stop();
        }
        public async Task<string> LeerLineaAsync()
        {
            return await sr.ReadLineAsync();
        }
    }
}