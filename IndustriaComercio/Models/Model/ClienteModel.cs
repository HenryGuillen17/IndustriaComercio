using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace IndustriaComercio.Models.Model
{
   public class ClienteModel : PersonaModel
    {

        public string Nota { get; set; }
        [Required(ErrorMessage = "Numero Establecimientos es Requerido")]
        [Display(
            Name = "Numero Establecimientos",
            Description = "Lorem ipsum"
        )]
        [Range(1, 999)]
        public int NumeroEstablecimientos { get; set; }
        public Estado Estado { get; set; }
    }
}