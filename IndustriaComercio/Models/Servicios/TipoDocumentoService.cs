using IndustriaComercio.Entidades.Basicos;
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
    public class TipoDocumentoService : GenericRepository<TipoDocumento>
    {
        private readonly ModelServidor _db;

        public TipoDocumentoService(ModelServidor db) : base(db)
        {
            _db = db;           
        }

        public int GetConsecutivo()
        {
            return Consecutivo(x => x.TipoDocumentoId);
        }
       
    }
}