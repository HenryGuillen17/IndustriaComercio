using System.Collections.Generic;

namespace IndustriaComercio.Entidades.UsuarioPermisos
{
    public class PerfilSubMenu 
    {
        public byte PerfilId { get; set; }
        public byte MenuId { get; set; }
        public byte SubMenuId { get; set; }
        public bool Permiso { get; set; }
        
        //_____ Propiedades de navegacion

        public virtual OpcionesSubMenu SubMenu { get; set; } // Nombre
        public virtual PerfilMenu PerfilMenu { get; set; }
        public virtual ICollection<PerfilPermiso> PerfilPermisos { get; set; } 

    }
}
