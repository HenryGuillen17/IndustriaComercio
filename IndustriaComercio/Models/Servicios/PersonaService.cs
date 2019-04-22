using IndustriaComercio.Common.Extensions;
using IndustriaComercio.Common.Utils;
using IndustriaComercio.Entidades.Persona;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Entidades.Basicos;
using IndustriaComercio.Models.Enum;
using IndustriaComercio.Models.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IndustriaComercio.Models.Servicios
{
    public class PersonaService : GenericRepository<Persona>
    {
        private readonly ModelServidor _db;

        public PersonaService(ModelServidor db) : base(db) { _db = db; }


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
                let noIdentificacionCompleto = b.TipoDocumento.Descripcion + " " + b.NoIdentificacion
                orderby b.NombreCompleto
                select new ComboBox
                {
                    Key = a.PersonaId,
                    Value = b.NombreCompleto,
                    Label = b.NoIdentificacion
                }).Take(limit).ToList();
        }

        public PersonaModel FindById(int id)
        {
            var model = _db.Persona
                .Include(x => x.TipoDocumento)
                .Include(x => x.Municipio)
                .Include(x => x.Municipio.Departamento)
                .Where(x => x.PersonaId == id)
                .Select(x => new PersonaModel
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
                    Telefono = x.Telefono
                })
                .FirstOrDefault();

            return model;
        }

        public int Save(PersonaModel model)
        {
            if (model.PersonaId == 0)
            {
                model.PersonaId = _db.Persona.Consecutivo(x => x.PersonaId);
                _db.Persona.Add(model.PersonaFactory());
                    
            } else
                _db.Entry(model.PersonaFactory()).State = EntityState.Modified;
            
            _db.SaveChanges();

            return model.PersonaId;
        }
    }
}