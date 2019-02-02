using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace IndustriaComercio.Entidades.Persona
{
   public class Cliente 
    {
        public int PersonaId { get; set; }
        [Required]
        [Display(Name = "Tipo Cliente")]
        public int TipoClienteId { get; set; }
        public string Nota { get; set; }
        public Estado Estado { get; set; }

        public virtual Persona Persona { get; set; }
        //public virtual ICollection<Declaracion> Declaraciones { get; set; }
    }
}