using IndustriaComercio.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.mapping.TablasBasicas
{
    public class TipoActividadMapping : EntityTypeConfiguration<TipoActividad>
    {
        public TipoActividadMapping()
        {
            // llave primaria.
            HasKey(t => t.TipoActividadId);

            Property(a => a.TipoActividadId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 
            // Tabla y esquema de la base de datos.
            ToTable("TipoActividad", "dbo");
        }
    }
}