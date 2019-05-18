using IndustriaComercio.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace IndustriaComercio.Entidades.UsuarioPermisos
{
    
    public class Usuario
    {
        public int PersonaId { get; set; }
        public string Login { get; set; }

        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }

        public Estado Estado { get; set; }

        [Display(Name = "Perfil")]
        public byte? PerfilId { get; set; }


        // Propiedades 
        public virtual Persona.Persona Persona { get; set; }
        public virtual Perfil Perfil { get; set; }

        public virtual ICollection<UsuarioMenu> UsuarioMenus { get; set; }

    }
}
