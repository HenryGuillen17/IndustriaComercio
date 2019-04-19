using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Entidades.Basicos;
using IndustriaComercio.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace IndustriaComercio.Entidades.Persona
{
   public class Cliente 
    {
        public int PersonaId { get; set; }

        public string NoPlaca { get; set; }

        public int ClasificacionContribuyenteId { get; set; }

        public string Nota { get; set; }

        [Required(ErrorMessage = "Numero Establecimientos es Requerido")]
        [Display(
            Name = "Numero Establecimientos",
            Description = "Lorem ipsum"
        )]
        [Range(1, 999)]
        public int NumeroEstablecimientos { get; set; }
        public Estado Estado { get; set; }
        public bool RetieneImpIndustriaComercio { get; set; }

        //Propiedades
        public virtual Persona Persona { get; set; }
        public virtual ClasificacionContribuyente ClasificacionContribuyente { get; set; }
        public virtual ICollection<DeclaracionPrevia> DeclaracionesPrevias { get; set; }
        public virtual ICollection<Establecimiento> Establecimientos { get; set; }
    }
}