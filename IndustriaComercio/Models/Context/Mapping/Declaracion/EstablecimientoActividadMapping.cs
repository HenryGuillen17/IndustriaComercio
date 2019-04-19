using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.Mapping.Declaracion
{
    public class EstablecimientoActividadMapping : EntityTypeConfiguration<EstablecimientoActividad>
    {
        public EstablecimientoActividadMapping()
        {
            // llave primaria.
            HasKey(t => new { t.EstablecimientoId , t.ActividadId});

            // Tabla y esquema de la base de datos.
            ToTable("EstablecimientoActividades", "dbo");

            // Establecimiento
            HasRequired(p => p.Establecimiento)
                .WithMany(p => p.EstablecimientoActividades)
                .HasForeignKey(p => p.EstablecimientoId)
                .WillCascadeOnDelete(false);

            // Actividad
            HasRequired(p => p.Actividad)
                .WithMany(p => p.EstablecimientoActividades)
                .HasForeignKey(p => p.ActividadId)
                .WillCascadeOnDelete(false);
        }
    }
}