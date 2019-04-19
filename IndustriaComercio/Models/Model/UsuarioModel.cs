using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace IndustriaComercio.Models.Model
{
   public class UsuarioModel : PersonaModel
    {
        public string Perfil { get; set; }
        public byte PerfilId { get; set; }
        public string Login { get; set; }
        public string Contraseña { get; set; }
        public Estado Estado { get; set; }

        //_____________Propiedades 
        public virtual ICollection<UsuarioMenuModel> UsuarioMenus { get; set; }
    }
}