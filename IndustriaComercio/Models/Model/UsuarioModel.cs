using System.Collections.Generic;
using IndustriaComercio.Entidades.UsuarioPermisos;
using IndustriaComercio.Models.Enum;


namespace IndustriaComercio.Models.Model
{
    public class UsuarioModel : PersonaModel
    {
        public byte? PerfilId { get; set; }
        public string Login { get; set; }
        public string Contrasenia { get; set; }
        public Estado Estado { get; set; }
        public string Perfil { get; internal set; }
        public List<UsuarioMenuModel> UsuarioMenus { get; internal set; }

        internal Usuario UsuarioFactory()
        {
            return new Usuario
            {
                PersonaId = PersonaId,
                Login = Login,
                Contrasenia = Contrasenia,
                Estado = Estado,
                PerfilId = PerfilId
            };

        }
    }
}