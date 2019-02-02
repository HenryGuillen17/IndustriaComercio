using System;
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.UsuarioPermisos
{
    public class Perfil 
    {
        public byte PerfilId { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<PerfilMenu> PerfilMenus { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
