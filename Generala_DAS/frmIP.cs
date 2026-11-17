using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generala_DAS
{
    public partial class frmIP : Form
    {
        public string ip => txtIP.Text;
        public frmIP()
        {
            InitializeComponent();
            btnIPOK.DialogResult = DialogResult.OK;
            btnIPCancelar.DialogResult = DialogResult.Cancel;
        }

        private void frmIP_Load(object sender, EventArgs e)
        {

        }
    }
}
