using System.Collections.Generic;

namespace IndustriaComercio.Entidades.UsuarioPermisos
{
    public class OpcionesSubMenu 
    {
        public byte MenuId { get; set; }
        public byte SubMenuId { get; set; }       
        public string Url { get; set; }
        public string Descripcion { get; set; }

        public virtual OpcionesMenu OpcionesMenu { get; set; }
        public virtual ICollection<OpcionesPermiso> OpcionesPermisos { get; set; }
        public virtual ICollection<PerfilSubMenu> PerfilSubMenus { get; set; }
        public virtual ICollection<UsuarioSubMenu> UsuarioSubMenus { get; set; }
    }
}
