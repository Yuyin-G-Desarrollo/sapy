using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesFachada.Programacion
{
   public  class AgenteFachada
    {
        public AgenteFachada()
        { }

        public AgenteFachada(int id, string nombre)
        {
            this.cmfa_colaboradorid_agente = id;
            this.codr_nombre = nombre;
        }
        public int cmfa_colaboradorid_agente { get; set; }
        public string codr_nombre { get; set; }
    }
}
