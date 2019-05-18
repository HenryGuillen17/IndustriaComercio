using System;
using System.Collections.Generic;
using System.Linq;
using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Entidades.Persona;
using IndustriaComercio.Models.Enum;


namespace IndustriaComercio.Models.Model
{
    public class ClienteModel : PersonaModel
    {

        public string Nota { get; set; }
        public int NumeroEstablecimientos { get; set; }
        public string NoPlaca { get; set; }
        public bool RetieneImpIndustriaComercio { get; set; }
        public Estado Estado { get; set; }
        public int? ClasificacionContribuyenteId { get; set; }
        public string ClasificacionContribuyenteNombre { get; set; }


        public ICollection<EstablecimientoModel> Establecimientos { get; set; }


        internal Cliente ClienteFactory()
        {
            return new Cliente
            {
                PersonaId = PersonaId,
                NoPlaca = NoPlaca,
                ClasificacionContribuyenteId = ClasificacionContribuyenteId ?? 0,
                Nota = Nota,
                NumeroEstablecimientos = NumeroEstablecimientos,
                Estado = Estado.Activo,
                RetieneImpIndustriaComercio = RetieneImpIndustriaComercio,
                //Establecimientos = Establecimientos.Select(x => new Establecimiento
                //{
                //    EstablecimientoId = x.EstablecimientoId,
                //    ClienteId = PersonaId,
                //    Descripcion = x.Descripcion,
                //    Direccion = x.Direccion,
                //    EstablecimientoActividades = x.EstablecimientoActividades.Select(y => new EstablecimientoActividad
                //    {
                //        ActividadId = y.ActividadId,
                //        EstablecimientoId = x.EstablecimientoId,
                //    }).ToList()
                //}).ToList()
            };
        }
    }
}