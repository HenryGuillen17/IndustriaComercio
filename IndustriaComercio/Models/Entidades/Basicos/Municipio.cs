using IndustriaComercio.Entidades.Persona;
using System.Collections.Generic;

namespace IndustriaComercio.Models.Entidades.Basicos
{
    public class Municipio
    {
        public int MunicipioId { get; set; }
        public string Descripcion { get; set; }
        public int DepartamentoId { get; set; }



        public virtual Departamento Departamento { get; set; }

        public ICollection<Persona> Personas { get; set; }

    }
}