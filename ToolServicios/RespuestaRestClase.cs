using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolServicios
{
    public class RespuestaRestClase<T>
    {
        public int respuesta { get; set; }
        public string aviso { get; set; }
        public T mensaje { get; set; }
    }
}
