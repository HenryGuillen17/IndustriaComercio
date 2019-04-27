using IndustriaComercio.Common.Extensions;
using IndustriaComercio.Common.Utils;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Entidades.Basicos;
using IndustriaComercio.Models.Enum;
using IndustriaComercio.Models.Model;
using PagedList;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IndustriaComercio.Models.Servicios
{
    public class ClienteService
    {
        private readonly ModelServidor _db;

        public ClienteService(ModelServidor db) { _db = db; }

        public Paginacion<ClienteModel> GetListClientePaginado(
            ApiFilter<ClienteModel> apiFilter
            )
        {
            var filtros = apiFilter.Filtros != null;

            var list =
                from a in _db.Cliente.Include(x => x.ClasificacionContribuyente)
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
                select new ClienteModel
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
                    ClasificacionContribuyenteId = a.ClasificacionContribuyenteId,
                    ClasificacionContribuyenteNombre = a.ClasificacionContribuyente.Descripcion,
                    // Cliente
                    Nota = a.Nota,
                    NumeroEstablecimientos = a.NumeroEstablecimientos,
                    Estado = a.Estado,
                };

            return list.OrderBy(apiFilter.OrdenarPor, apiFilter.EsAscendente)
                .ToPagedList(apiFilter.PaginaNo, apiFilter.PorPagina).Paginar();
        }

        public IEnumerable<ComboBox> GetListClienteAutocomplete(int limit, string value, TipoBusqueda tipoBusqueda)
        {
            return (
                from a in _db.Cliente
                join b in _db.Persona.Include(x => x.TipoDocumento) on a.PersonaId equals b.PersonaId
                where
                       b.NombreCompleto != null && b.NombreCompleto.Trim() != ""
                    && tipoBusqueda == TipoBusqueda.PorNombreCompleto
                        ? b.NombreCompleto.StartsWith(value)
                        : (tipoBusqueda == TipoBusqueda.PorCedula && b.NoIdentificacion.Contains(value))
                let noIdentificacionCompleto = b.TipoDocumento.Descripcion + "-" + b.NoIdentificacion
                orderby b.NombreCompleto
                select new ComboBox
                {
                    Key = a.PersonaId,
                    Value = b.NombreCompleto,
                    Label = noIdentificacionCompleto
                }).Take(limit).ToList();
        }

        public IEnumerable<ComboBox> GetListPersonaSinClienteAutocomplete(int limit, string value, TipoBusqueda tipoBusqueda)
        {
            return (
                from b in _db.Persona
                join a in _db.Cliente on b.PersonaId equals a.PersonaId into ljc
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

        public ClienteModel FindClienteByNoDocumento(
            int tipoDocumento,
            string noDocumento
        )
        {
            var model = _db.Persona
                .Include(x => x.Cliente.ClasificacionContribuyente)
                .Include(x => x.TipoDocumento)
                .Include(x => x.Municipio)
                .Include(x => x.Municipio.Departamento)
                .Where(
                    x =>
                    x.TipoDocumentoId == tipoDocumento
                    && x.NoIdentificacion == noDocumento
                ).Select(x => new ClienteModel
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
                    Nota = x.Cliente.Nota,
                    NumeroEstablecimientos = x.Cliente.NumeroEstablecimientos,
                    ClasificacionContribuyenteId = x.Cliente.ClasificacionContribuyenteId,
                    ClasificacionContribuyenteNombre = x.Cliente.ClasificacionContribuyente.Descripcion,
                    Telefono = x.Telefono,
                    Estado = x.Cliente.Estado
                })
                .FirstOrDefault();

            return model;
        }

        public ClienteModel FindClienteByPersonaId(
            int personaId
        )
        {
            var model = _db.Persona
                .Include(x => x.Cliente.ClasificacionContribuyente)
                .Include(x => x.TipoDocumento)
                .Include(x => x.Municipio)
                .Include(x => x.Municipio.Departamento)
                .Where(x => x.PersonaId == personaId)
                .Select(x => new ClienteModel
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
                    Nota = x.Cliente != null ? x.Cliente.Nota : null,
                    NoPlaca = x.Cliente != null ? x.Cliente.NoPlaca : null,
                    RetieneImpIndustriaComercio = x.Cliente != null ? x.Cliente.RetieneImpIndustriaComercio : false,
                    NumeroEstablecimientos = x.Cliente != null ? x.Cliente.NumeroEstablecimientos : 1,
                    ClasificacionContribuyenteId = x.Cliente != null ? x.Cliente.ClasificacionContribuyenteId : 0,
                    ClasificacionContribuyenteNombre = x.Cliente.ClasificacionContribuyente.Descripcion,
                    Telefono = x.Telefono,
                    Estado = x.Cliente != null ? x.Cliente.Estado : 0
                })
                .FirstOrDefault();

            if (model.ClasificacionContribuyenteId != 0)
            {
                model.Establecimientos = _db.Establecimiento
                    .Where(x => model.PersonaId == x.ClienteId)
                    .Select(a => new EstablecimientoModel
                    {
                        EstablecimientoId = a.EstablecimientoId,
                        ClienteId = a.ClienteId,
                        Descripcion = a.Descripcion,
                        Direccion = a.Direccion,
                        EstablecimientoActividades = a.EstablecimientoActividades
                            .Select(y => new EstablecimientoActividadModel
                            {
                                ActividadId = y.ActividadId,
                                Descripcion = y.Actividad.Descripcion,
                                Codigo = y.Actividad.Codigo,
                                IngresosGravados = 0,
                                Tarifa = y.Actividad.Tarifa,
                                Valor = y.Actividad.Valor,
                                EstablecimientoId = a.EstablecimientoId,
                            }).ToList(),
                    }).ToList();
            }

            return model;
        }

        public ClienteModel Save(ClienteModel model)
        {
            var cliente = _db.Cliente.AsNoTracking().FirstOrDefault(x => x.PersonaId == model.PersonaId) ;

            if (cliente == null)
            {
                _db.Cliente.Add(model.ClienteFactory());
            }
            else
                _db.Entry(model.ClienteFactory()).State = EntityState.Modified;

            _db.SaveChanges();

            return model;
        }

        public IEnumerable<ListaCorreo> GetListaCorreos()
        {
            return _db.ListaCorreo.ToList();
        }
    }
}