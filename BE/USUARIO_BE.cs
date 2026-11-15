using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class USUARIO_BE
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}
		private string usuario;

		public string Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}
		private string pass;

		public string Pass
		{
			get { return pass; }
			set { pass = value; }
		}

		private int id_jugador;

		public int Id_jugador
		{
			get { return id_jugador; }
			set { id_jugador = value; }
		}
	}
}
