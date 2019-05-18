using IndustriaComercio.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.mapping.TablasBasicas
{
    public class TipoSancionMapping : EntityTypeConfiguration<TipoSancion>
    {
        public TipoSancionMapping()
        {
            // llave primaria.
            HasKey(t => t.TipoSancionId);

            Property(a => a.TipoSancionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 
            // Tabla y esquema de la base de datos.
            ToTable("TiposSanciones", "dbo");
        }
    }
}