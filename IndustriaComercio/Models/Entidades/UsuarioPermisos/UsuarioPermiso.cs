using System.ComponentModel.DataAnnotations.Schema;

namespace IndustriaComercio.Entidades.UsuarioPermisos
{
    public class UsuarioPermiso 
    {
        public int PersonaId { get; set; }
        public byte MenuId { get; set; }
        public byte SubMenuId { get; set; }
        public byte PermisoId { get; set; }
        [NotMapped]
        public string Descripcion { get; set; }
        public bool Permiso { get; set; }

        // Propiedades de Navegacion
        public virtual OpcionesPermiso OpcionesPermiso { get; set; } // Nombre
        public virtual UsuarioSubMenu UsuarioSubMenu { get; set; }
    }
}
