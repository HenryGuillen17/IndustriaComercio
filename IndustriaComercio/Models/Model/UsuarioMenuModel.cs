using System.Collections.Generic;

namespace IndustriaComercio.Models.Model
{
    public class UsuarioMenuModel
    {
        public int PersonaId { get; set; }
        public byte MenuId { get; set; }
        public string Imagen { get; set; } 
        public string Descripcion { get; set; } 
        public bool Permiso { get; set; }

        // _______ Propiedades de Navegacion
        public virtual ICollection<UsuarioSubMenuModel> UsuarioSubMenus { get; set; }

    }
}
