using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndustriaComercio.Models.Entidades.Basicos
{
    public class ActividadGravada
    {
        public int ActividadId { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<ActividadGravablePorDeclaracion> ActividadesGravadas { get; set; }
    }
}