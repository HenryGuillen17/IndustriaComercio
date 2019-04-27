using IndustriaComercio.Entidades.Basicos;
using System.Collections.Generic;
using System.Linq;

namespace IndustriaComercio.Models.Model
{

    public class EstablecimientoModel
    {
        public int EstablecimientoId { get; set; }
        public int ClienteId { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }

        //Propiedades
        public ICollection<EstablecimientoActividadModel> EstablecimientoActividades { get; set; }


        public Establecimiento ModelFactory()
        {
            return new Establecimiento
            {
                EstablecimientoId = EstablecimientoId,
                ClienteId = ClienteId,
                Descripcion = Descripcion,
                Direccion = Direccion,
                EstablecimientoActividades = EstablecimientoActividades
                .Select(x => new EstablecimientoActividad
                {
                    EstablecimientoId = EstablecimientoId,
                    ActividadId = x.ActividadId
                }).ToList(),
            };

        }


        public void ModelFactory(ref Establecimiento model)
        {
            model.EstablecimientoId = EstablecimientoId;
            model.ClienteId = ClienteId;
            model.Descripcion = Descripcion;
            model.Direccion = Direccion;
            model.EstablecimientoActividades = EstablecimientoActividades
            .Select(x => new EstablecimientoActividad
            {
                EstablecimientoId = EstablecimientoId,
                ActividadId = x.ActividadId
            }).ToList();

        }

    }
}