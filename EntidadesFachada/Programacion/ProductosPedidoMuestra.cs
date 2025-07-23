using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesFachada.Programacion
{
//pe.pres_productoestiloid
// , p.prod_codigo
// , pe.pres_codSicy
// , m.marc_descripcion
// , cl.cole_descripcion
// , pl.piel_descripcion
// , c.color_descripcion
// , t.talla_descripcion
// , t.talla_tallacentral
// , pe.pres_estatus
// , n.nave_nombre
    public class ProductosPedidoMuestra
    {
        public int pres_productoestiloid { get; set; }
        public string prod_codigo { get; set; }
        public string pres_codSicy { get; set; }
        public string marc_descripcion { get; set; }
        public string cole_descripcion { get; set; }
        public string piel_descripcion { get; set; }
        public string color_descripcion { get; set; }
        public string talla_descripcion { get; set; }
        public string talla_tallacentral { get; set; }
        public int pres_estatus { get; set; }
        public string nave_nombre { get; set; }
    }
}
