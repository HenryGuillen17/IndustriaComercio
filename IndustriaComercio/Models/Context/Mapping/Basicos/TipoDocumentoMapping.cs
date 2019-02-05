using IndustriaComercio.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.mapping.TablasBasicas
{
    public class TipoDocumentoMapping: EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumentoMapping()
        {
            // llave primaria.
            HasKey(t => t.TipoDocumentoId);

            Property(a => a.TipoDocumentoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 
            // Tabla y esquema de la base de datos.
            ToTable("TipoDocumento", "dbo");
        }
    }
}