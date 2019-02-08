using IndustriaComercio.Entidades.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndustriaComercio.Models.Entidades.Basicos
{
    public class ClasificacionContribuyente
    {
        public int ClasificacionContribuyenteId { get; set; }
        public string Descripcion { get; set; }



        public virtual ICollection<Persona> Personas { get; set; }
    }
}