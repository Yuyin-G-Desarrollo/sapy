using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesFachada.Programacion
{
    public class EstatusMuestra
    {
        public int esta_estatusid { get; set; }
        public string esta_nombre { get; set; }

        public EstatusMuestra() { }
        public EstatusMuestra(int idEstatus, string nombre)
        {
            this.esta_estatusid = idEstatus;
            this.esta_nombre = nombre;
        }
    }
}
