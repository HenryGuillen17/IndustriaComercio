using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Model;
using System.Data.Entity;
using System.Linq;

namespace IndustriaComercio.Models.Servicios
{
    public class ClienteService
    {
        private readonly ModelServidor _db;

        public ClienteService(
            ModelServidor db
            )
        {
            _db = db;
        }
        

        public ClienteModel FindClienteByNoDocumento(
            int tipoDocumento,
            string noDocumento
        )
        {
            var model = _db.Persona
                .Include(x => x.Cliente)
                .Include(x => x.TipoDocumento)
                .Include(x => x.ClasificacionContribuyente)
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
                    Municipio = x.Municipio,
                    Departamento = x.Departamento,
                    Nota = x.Cliente.Nota,
                    NumeroEstablecimientos = x.Cliente.NumeroEstablecimientos,
                    ClasificacionContribuyenteId = x.ClasificacionContribuyenteId,
                    ClasificacionContribuyenteNombre = x.ClasificacionContribuyente.Descripcion,
                    Telefono = x.Telefono,
                    Estado = x.Cliente.Estado
                })
                .FirstOrDefault();

            return model;
        }
    }
}