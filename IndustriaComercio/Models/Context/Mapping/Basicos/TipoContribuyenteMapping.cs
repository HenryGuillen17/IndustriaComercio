using IndustriaComercio.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.mapping.TablasBasicas
{
    public class TipoContribuyenteMapping : EntityTypeConfiguration<TipoContribuyente>
    {
        public TipoContribuyenteMapping()
        {
            // llave primaria.
            HasKey(t => t.TipoContribuyenteId);

            Property(a => a.TipoContribuyenteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 
            // Tabla y esquema de la base de datos.
            ToTable("TipoContribuyente", "dbo");
        }
    }
}