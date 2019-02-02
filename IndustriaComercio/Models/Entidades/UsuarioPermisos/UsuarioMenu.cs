using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndustriaComercio.Entidades.UsuarioPermisos
{
    public class UsuarioMenu
    {
        public int PersonaId { get; set; }
        public byte MenuId { get; set; }
        [NotMapped]
        public string Descripcion { get; set; }
        public bool Permiso { get; set; }

        // _______ Propiedades de Navegacion
        public virtual OpcionesMenu Menu { get; set; } // Nombre
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<UsuarioSubMenu> UsuarioSubMenus { get; set; }

    }
}
