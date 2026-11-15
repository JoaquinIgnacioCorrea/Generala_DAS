using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using BE;

namespace DAL
{
    public class XML_MOVIMIENTOS
    {
        public string ObtenerCarpetaPartidas()
        {
            string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PartidasXML");
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }
            return carpeta;
        }

        public string ObtenerRutaArchivo(int idPartida)
        {
            return Path.Combine(ObtenerCarpetaPartidas(), $"partida_{idPartida}.xml");
        }

        public void GuardarMovimiento(MOVIMIENTO_XML_BE mov, string rutaArchivo)
        {
            if (mov == null)
                throw new ArgumentNullException(nameof(mov));

            if (string.IsNullOrWhiteSpace(rutaArchivo))
                rutaArchivo = ObtenerRutaArchivo(mov.IdPartida);

            string directorio = Path.GetDirectoryName(rutaArchivo);
            if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            List<MOVIMIENTO_XML_BE> movimientos = LeerMovimientos(rutaArchivo);
            movimientos.Add(mov);

            XmlSerializer serializer = new XmlSerializer(typeof(List<MOVIMIENTO_XML_BE>));
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, movimientos);
            }
        }

        public List<MOVIMIENTO_XML_BE> LeerMovimientos(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo) || !File.Exists(rutaArchivo))
            {
                return new List<MOVIMIENTO_XML_BE>();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<MOVIMIENTO_XML_BE>));
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            {
                return (List<MOVIMIENTO_XML_BE>)serializer.Deserialize(fs);
            }
        }
    }
}
