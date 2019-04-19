using IndustriaComercio.Entidades.UsuarioPermisos;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Entidades.Basicos;
using IndustriaComercio.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IndustriaComercio.Models.Servicios
{
    public class UsuarioService : GenericRepository<Usuario>
    {
        private readonly ModelServidor _db;

        public UsuarioService(ModelServidor db) : base(db)
        {
            _db = db;           
        }

        public UsuarioModel Login(string usuario, string contraseña)
        {
            var query = (from q in _db.Usuario
                         where q.Login == usuario && q.Contraseña == contraseña
                         select new UsuarioModel
                         {
                             PersonaId = q.PersonaId,
                             NombreCompleto = q.Persona.NombreCompleto,
                             Perfil = q.Perfil.Descripcion,
                             PerfilId = q.PerfilId,
                             Login = q.Login,
                             Contraseña = q.Contraseña,
                             Estado = q.Estado,
                             UsuarioMenus = (from u in q.Perfil.PerfilMenus
                                             select new UsuarioMenuModel
                                             {
                                                 PersonaId = q.PersonaId,
                                                 MenuId = u.MenuId,
                                                 Descripcion = u.Menu.Descripcion,
                                                 Imagen = u.Menu.Imagen,
                                                 Permiso = u.Permiso,
                                                 UsuarioSubMenus = u.PerfilSubMenus.Select(x => new UsuarioSubMenuModel
                                                 {
                                                     PersonaId = q.PersonaId,
                                                     MenuId = x.MenuId,
                                                     SubMenuId = x.SubMenuId,
                                                     Url = x.SubMenu.Url,
                                                     Descripcion = x.SubMenu.Descripcion,
                                                     Permiso = x.Permiso
                                                 }).ToList()
                                             }).ToList()
                         }).FirstOrDefault();

            return query;
        }
    }
}