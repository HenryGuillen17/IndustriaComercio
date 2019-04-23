using IndustriaComercio.Common.Extensions;
using IndustriaComercio.Common.Utils;
using IndustriaComercio.Entidades.UsuarioPermisos;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Enum;
using IndustriaComercio.Models.Model;
using PagedList;
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
            var query = (from q in _db.Usuario.Include(x => x.Perfil.PerfilMenus)
                         where q.Login == usuario && q.Contrasenia == contraseña
                         select new UsuarioModel
                         {
                             PersonaId = q.PersonaId,
                             NombreCompleto = q.Persona.NombreCompleto,
                             Perfil = q.Perfil.Descripcion,
                             PerfilId = q.PerfilId,
                             Login = q.Login,
                             Contrasenia = q.Contrasenia,
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



        public Paginacion<UsuarioModel> GetListUsuarioPaginado(
            ApiFilter<UsuarioModel> apiFilter
            )
        {
            var filtros = apiFilter.Filtros != null;

            var list =
                from a in _db.Usuario.Include(x => x.Perfil.PerfilMenus)
                join b in _db.Persona
                .Include(x => x.TipoDocumento)
                .Include(x => x.Municipio)
                .Include(x => x.Municipio.Departamento)
                on a.PersonaId equals b.PersonaId
                where
                    filtros &&
                    (
                        apiFilter.Filtros.PersonaId == 0 || b.PersonaId == apiFilter.Filtros.PersonaId
                    )
                select new UsuarioModel
                {
                    PersonaId = b.PersonaId,
                    TipoDocumentoId = b.TipoDocumentoId,
                    TipoDocumentoNombre = b.TipoDocumento.Descripcion,
                    NoIdentificacion = b.NoIdentificacion,
                    PrimerNombre = b.PrimerNombre,
                    SegundoNombre = b.SegundoNombre,
                    PrimerApellido = b.PrimerApellido,
                    SegundoApellido = b.SegundoApellido,
                    NombreCompleto = b.NombreCompleto,
                    FotoPerfil = b.FotoPerfil,
                    Correo = b.Correo,
                    Celular = b.Celular,
                    Direccion = b.Direccion,
                    MunicipioId = b.MunicipioId,
                    Municipio = b.Municipio.Descripcion,
                    DepartamentoId = b.Municipio.DepartamentoId,
                    Departamento = b.Municipio.Departamento.Descripcion,
                    Telefono = b.Telefono,
                    Estado = a.Estado,
                    Login = a.Login
                };

            return list.OrderBy(apiFilter.OrdenarPor, apiFilter.EsAscendente)
                .ToPagedList(apiFilter.PaginaNo, apiFilter.PorPagina).Paginar();
        }

        public IEnumerable<ComboBox> GetListUsuarioAutocomplete(int limit, string value, TipoBusqueda tipoBusqueda)
        {
            return (
                from a in _db.Usuario
                join b in _db.Persona.Include(x => x.TipoDocumento) on a.PersonaId equals b.PersonaId
                where
                       b.NombreCompleto != null && b.NombreCompleto.Trim() != ""
                    && tipoBusqueda == TipoBusqueda.PorNombreCompleto
                        ? b.NombreCompleto.StartsWith(value)
                        : (tipoBusqueda == TipoBusqueda.PorUsuario
                            ? a.Login.StartsWith(value.Trim())
                            : tipoBusqueda == TipoBusqueda.PorCedula && b.NoIdentificacion.Contains(value))
                let noIdentificacionCompleto = b.TipoDocumento.Descripcion + "-" + b.NoIdentificacion
                orderby b.NombreCompleto
                select new ComboBox
                {
                    Key = a.PersonaId,
                    Value = b.NombreCompleto,
                    Label = a.Login
                }).Take(limit).ToList();
        }

        public IEnumerable<ComboBox> GetListPersonaSinUsuarioAutocomplete(int limit, string value, TipoBusqueda tipoBusqueda)
        {
            return (
                from b in _db.Persona
                join a in _db.Usuario on b.PersonaId equals a.PersonaId into ljc
                from a in ljc.DefaultIfEmpty()
                where
                       a == null
                    && b.NombreCompleto != null && b.NombreCompleto.Trim() != ""
                    && tipoBusqueda == TipoBusqueda.PorNombreCompleto
                        ? b.NombreCompleto.StartsWith(value)
                        : (tipoBusqueda == TipoBusqueda.PorCedula && b.NoIdentificacion.Contains(value))
                let noIdentificacionCompleto = b.TipoDocumento.Descripcion + "-" + b.NoIdentificacion
                orderby b.NombreCompleto
                select new ComboBox
                {
                    Key = b.PersonaId,
                    Value = b.NombreCompleto,
                    Label = noIdentificacionCompleto
                }).Take(limit).ToList();
        }

        public UsuarioModel FindUsuarioByNoDocumento(
            int tipoDocumento,
            string noDocumento
        )
        {
            var model = _db.Persona
                .Include(x => x.Usuario)
                .Include(x => x.TipoDocumento)
                .Include(x => x.Municipio)
                .Include(x => x.Municipio.Departamento)
                .Where(
                    x =>
                    x.TipoDocumentoId == tipoDocumento
                    && x.NoIdentificacion == noDocumento
                ).Select(x => new UsuarioModel
                {
                    PersonaId = x.PersonaId,
                    TipoDocumentoId = x.TipoDocumentoId,
                    TipoDocumentoNombre = x.TipoDocumento.Descripcion,
                    NoIdentificacion = x.NoIdentificacion,
                    PrimerNombre = x.PrimerNombre,
                    SegundoNombre = x.SegundoNombre,
                    PrimerApellido = x.PrimerApellido,
                    SegundoApellido = x.SegundoApellido,
                    NombreCompleto = x.NombreCompleto,
                    FotoPerfil = x.FotoPerfil,
                    Correo = x.Correo,
                    Celular = x.Celular,
                    Direccion = x.Direccion,
                    MunicipioId = x.MunicipioId,
                    Municipio = x.Municipio.Descripcion,
                    DepartamentoId = x.Municipio.DepartamentoId,
                    Departamento = x.Municipio.Departamento.Descripcion,
                    Telefono = x.Telefono,
                    Estado = x.Usuario.Estado
                })
                .FirstOrDefault();

            return model;
        }

        public UsuarioModel FindUsuarioByPersonaId(
            int personaId
        )
        {
            var model = _db.Persona
                .Include(x => x.Usuario)
                .Include(x => x.TipoDocumento)
                .Include(x => x.Municipio)
                .Include(x => x.Municipio.Departamento)
                .Where(x => x.PersonaId == personaId)
                .Select(x => new UsuarioModel
                {
                    PersonaId = x.PersonaId,
                    TipoDocumentoId = x.TipoDocumentoId,
                    TipoDocumentoNombre = x.TipoDocumento.Descripcion,
                    NoIdentificacion = x.NoIdentificacion,
                    PrimerNombre = x.PrimerNombre,
                    SegundoNombre = x.SegundoNombre,
                    PrimerApellido = x.PrimerApellido,
                    SegundoApellido = x.SegundoApellido,
                    NombreCompleto = x.NombreCompleto,
                    FotoPerfil = x.FotoPerfil,
                    Correo = x.Correo,
                    Celular = x.Celular,
                    Direccion = x.Direccion,
                    MunicipioId = x.MunicipioId,
                    Municipio = x.Municipio.Descripcion,
                    DepartamentoId = x.Municipio.DepartamentoId,
                    Departamento = x.Municipio.Departamento.Descripcion,
                    Telefono = x.Telefono,
                    Estado = x.Usuario != null ? x.Usuario.Estado : 0,
                    Login = x.Usuario != null ? x.Usuario.Login : ""
                })
                .FirstOrDefault();

            return model;
        }



        public UsuarioModel FindByLogin(
            string login
        )
        {
            var model = (
                from x in _db.Persona
                join b in _db.Usuario on x.PersonaId equals b.PersonaId
                where b.Login == login.Trim()
                select new UsuarioModel
                {
                    PersonaId = x.PersonaId,
                    TipoDocumentoId = x.TipoDocumentoId,
                    TipoDocumentoNombre = x.TipoDocumento.Descripcion,
                    NoIdentificacion = x.NoIdentificacion,
                    PrimerNombre = x.PrimerNombre,
                    SegundoNombre = x.SegundoNombre,
                    PrimerApellido = x.PrimerApellido,
                    SegundoApellido = x.SegundoApellido,
                    NombreCompleto = x.NombreCompleto,
                    FotoPerfil = x.FotoPerfil,
                    Correo = x.Correo,
                    Celular = x.Celular,
                    Direccion = x.Direccion,
                    MunicipioId = x.MunicipioId,
                    Municipio = x.Municipio.Descripcion,
                    DepartamentoId = x.Municipio.DepartamentoId,
                    Departamento = x.Municipio.Departamento.Descripcion,
                    Telefono = x.Telefono,
                    Estado = b.Estado,
                    Login = b.Login
                })
                .FirstOrDefault();

            return model;
        }

        

        public int Save(UsuarioModel model)
        {
            var usuario = _db.Usuario.Find(model.PersonaId);

            if (usuario == null)
                _db.Usuario.Add(model.UsuarioFactory());
            else
                _db.Entry(model.UsuarioFactory()).State = EntityState.Modified;

            _db.SaveChanges();
            return model.PersonaId;
        }


    }
}