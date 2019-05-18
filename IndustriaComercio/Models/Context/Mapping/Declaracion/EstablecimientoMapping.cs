using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.Mapping.Declaracion
{
    public class EstablecimientoMapping : EntityTypeConfiguration<Establecimiento>
    {
        public EstablecimientoMapping()
        {
            // llave primaria.
            HasKey(t => t.EstablecimientoId);

            Property(a => a.EstablecimientoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 

            // Tabla y esquema de la base de datos.
            ToTable("Establecimientos", "dbo");

            // Cliente
            HasRequired(p => p.Cliente)
                .WithMany(p => p.Establecimientos)
                .HasForeignKey(p => p.ClienteId)
                .WillCascadeOnDelete(false);
        }
    }
}