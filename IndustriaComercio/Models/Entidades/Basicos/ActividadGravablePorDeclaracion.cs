using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndustriaComercio.Models.Entidades.Basicos
{
    public class ActividadGravablePorDeclaracion
    {
        public double IngresosGravados { get; set; }
        public double Impuesto { get; set; }

        public virtual DeclaracionPrevia DeclaracionPrevia { get; set; }
        public int DeclaracionPreviaId { get; set; }

        public virtual ActividadGravada Actividad { get; set; }
        public int ActividadId { get; set; }
    }
}