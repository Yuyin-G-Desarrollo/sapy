using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesFachada.Programacion
{
    public class ClienteFachada
    {
        public ClienteFachada()
        { }

        public ClienteFachada(int id, string nombre)
        {
            this.clie_clienteid = id;
            this.clie_nombregenerico = nombre;
        }

        public int clie_clienteid { get; set; }
        public string clie_nombregenerico { get; set; }
    }
}
