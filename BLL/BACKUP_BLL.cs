using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BACKUP_BLL
    {
        MP_BACKUP mpbackup = new MP_BACKUP();
        public void RealizarBackup()
        {
            mpbackup.RealizarBackup();
        }
        public void RestaurarBackup()
        {
            mpbackup.RestaurarBackup();
        }
    }
}
