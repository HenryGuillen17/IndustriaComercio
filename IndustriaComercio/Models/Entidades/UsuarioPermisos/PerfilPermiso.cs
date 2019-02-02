

namespace IndustriaComercio.Entidades.UsuarioPermisos
{
    public class PerfilPermiso
    {
        public byte PerfilId { get; set; }
        public byte MenuId { get; set; }
        public byte SubMenuId { get; set; }
        public byte PermisoId { get; set; }
        public bool Permiso { get; set; }

        //________ Propiedades de Navegacion
        public virtual OpcionesPermiso OpcionesPermiso { get; set; }
        public virtual PerfilSubMenu PerfilSubMenu { get; set; }       
    }
}
