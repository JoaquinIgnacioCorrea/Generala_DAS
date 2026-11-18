using Generala_DAS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            string ruta = @"C:\BackupsGenerala\backup.bak";
            string cmd = $"BACKUP DATABASE [Generala] TO DISK = '{ruta}' WHIT INIT";
            acceso.Abrir();
            acceso.Escribir(cmd);
            acceso.Cerrar();
        }
        public void RestaurarBackup()
        {
            ACCESO acceso = new ACCESO();
            string ruta = @"C:\BackupsGenerala\backup.bak";
            string cmd = $@"
                            ALTER DATABASE [Generala] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                            RESTORE DATABASE [Generala] FROM DISK = '{ruta}' WITH REPLACE;
                            ALTER DATABASE [Generala] SET MULTI_USER;";
            acceso.Abrir();
            acceso.Escribir(cmd);
            acceso.Cerrar();
        }
    }
}
