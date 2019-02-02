using IndustriaComercio.Models.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.Mapping.Declaracion
{
    public class ActividadGravadaMapping : EntityTypeConfiguration<ActividadGravada>
    {
        public ActividadGravadaMapping()
        {
            // llave primaria.
            HasKey(t => t.ActividadId);

            Property(a => a.ActividadId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 

            // Tabla y esquema de la base de datos.
            ToTable("ActividadesGravadas", "dbo");

            
        }
    }
}