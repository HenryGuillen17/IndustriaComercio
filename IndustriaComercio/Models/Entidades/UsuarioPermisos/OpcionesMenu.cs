using System.Collections.Generic;

namespace IndustriaComercio.Entidades.UsuarioPermisos
{
    public class OpcionesMenu 
    {
        public byte MenuId { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

        //
        public virtual ICollection<OpcionesSubMenu> OpcionesSubMenus { get; set; }
        public virtual ICollection<PerfilMenu> PerfilMenus { get; set; }
        public virtual ICollection<UsuarioMenu> UsuarioMenus { get; set; } 
    }
}
