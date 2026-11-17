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
    public partial class Form1 : Form
    {
        private ServidorGenerala enlace;
        public Form1()
        {
            InitializeComponent();
            
        }
        public Form1(ServidorGenerala e)
        {
            InitializeComponent();
            enlace = e;
            
        }

        private void ucTableroPuntaje2_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (enlace != null) { ucTableroPuntaje2.ConfigurarRed(enlace); }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            enlace?.cerrar();

        }
    }
}
