using System.Collections.Generic;


namespace IndustriaComercio.Models.Model
{
    public class UsuarioSubMenuModel
    {
        public int PersonaId { get; set; }
        public byte MenuId { get; set; }
        public byte SubMenuId { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public bool Permiso { get; set; }

        //_________ Propiedades de navegacion

        public virtual ICollection<UsuarioPermisoModel> UsuarioPermisos { get; set; }

    }
}
