using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolServicios
{
    public class RespuestaRestLista<T>
    {
        public int respuesta { get; set; }
        public string aviso { get; set; }
        public List<T> mensaje { get; set; }
    }
}
