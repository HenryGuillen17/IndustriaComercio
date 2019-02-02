using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.Mapping.Declaracion
{
    public class DeclaracionPreviaMapping : EntityTypeConfiguration<DeclaracionPrevia>
    {
        public DeclaracionPreviaMapping()
        {
            // llave primaria.
            HasKey(t => t.DeclaracionPreviaId);

            Property(a => a.DeclaracionPreviaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 

            // Tabla y esquema de la base de datos.
            ToTable("DeclaracionesPrevias", "dbo");
        }
    }
}