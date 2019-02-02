using System.Collections.Generic;

namespace IndustriaComercio.Entidades.UsuarioPermisos
{
    public class PerfilMenu 
    {
        public byte PerfilId { get; set; }
        public byte MenuId { get; set; }
        public bool Permiso { get; set; }


        // Propiedades de Navegacion
        public virtual OpcionesMenu Menu { get; set; } // Nombre 
        public virtual Perfil Perfil { get; set; }
        public virtual ICollection<PerfilSubMenu> PerfilSubMenus { get; set; }

    }
}
