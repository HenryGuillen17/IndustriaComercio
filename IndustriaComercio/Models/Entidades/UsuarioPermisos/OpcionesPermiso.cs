using System.Collections.Generic;

namespace IndustriaComercio.Entidades.UsuarioPermisos
{
    public class OpcionesPermiso 
    {        
        public byte MenuId { get; set; }
        public byte SubMenuId { get; set; }
        public byte PermisoId { get; set; }
        public string Descripcion { get; set; }

        public virtual OpcionesSubMenu OpcionesSubMenu { get; set; }

        public virtual ICollection<PerfilPermiso> PerfilPermisos { get; set; }
        public virtual ICollection<UsuarioPermiso> UsuarioPermisos { get; set; }
    }
}
