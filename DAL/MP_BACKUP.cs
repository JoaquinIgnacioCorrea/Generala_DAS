using Generala_DAS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_BACKUP
    {
        public void RealizarBackup()
        {
            ACCESO acceso = new ACCESO();
            string carpeta = @"C:\BackupsGenerala";
            
            if(!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

            string ruta = @"C:\BackupsGenerala\backup.bak";
            string cmd = $"BACKUP DATABASE [Generala] TO DISK = '{ruta}' WITH INIT";
            acceso.Abrir();
            acceso.EscribirBU(cmd);
            acceso.Cerrar();
        }
        public void RestaurarBackup()
        {
            ACCESO acceso = new ACCESO();
            string ruta = @"C:\BackupsGenerala\backup.bak";
            string cmd = $@"
                            USE master;
                            IF EXISTS (SELECT name FROM sys.databases WHERE name = N'Generala')
                            BEGIN
                            ALTER DATABASE [Generala] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                            END
                            RESTORE DATABASE [Generala] FROM DISK = '{ruta}' WITH REPLACE;
                            ALTER DATABASE [Generala] SET MULTI_USER;";
            acceso.AbrirMaster();
            acceso.EscribirBU(cmd);
            acceso.Cerrar();
        }
    }
}
