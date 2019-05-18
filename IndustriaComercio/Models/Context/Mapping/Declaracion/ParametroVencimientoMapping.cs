using IndustriaComercio.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.Mapping.Declaracion
{
    public class ParametroVencimientoMapping : EntityTypeConfiguration<ParametroVencimiento>
    {
        public ParametroVencimientoMapping()

        {
            // llave primaria.
            HasKey(t => t.ParametroVencimientoId);

            Property(a => a.ParametroVencimientoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 

            HasIndex(u => new { u.Mes, u.Dia}).IsUnique();

            // Tabla y esquema de la base de datos.
            ToTable("ParametrosVencimientos", "dbo");
        }
    }
}