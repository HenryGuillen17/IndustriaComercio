using IndustriaComercio.Models.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.mapping.TablasBasicas
{
    public class ClasificacionContribuyenteMapping : EntityTypeConfiguration<ClasificacionContribuyente>
    {
        public ClasificacionContribuyenteMapping()
        {
            // llave primaria.
            HasKey(t => t.ClasificacionContribuyenteId);

            Property(a => a.ClasificacionContribuyenteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 
            // Tabla y esquema de la base de datos.
            ToTable("ClasificacionesContribuyente", "dbo");
        }
    }
}