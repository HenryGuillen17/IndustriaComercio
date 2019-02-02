using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndustriaComercio.Entidades.UsuarioPermisos
{
    public class UsuarioSubMenu 
    {
        public int PersonaId { get; set; }
        public byte MenuId { get; set; }
        public byte SubMenuId { get; set; }
        [NotMapped]
        public string Descripcion { get; set; }
        public bool Permiso { get; set; }

        //_________ Propiedades de navegacion
        public virtual OpcionesSubMenu OpcionesSubMenu { get; set; } //Nombre
        public virtual UsuarioMenu UsuarioMenu { get; set; }
        public virtual ICollection<UsuarioPermiso> UsuarioPermisos { get; set; }

    }
}
