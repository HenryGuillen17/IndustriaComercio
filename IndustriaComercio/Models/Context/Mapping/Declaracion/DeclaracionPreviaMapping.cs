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

            Property(a => a.DeclaracionPreviaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 

            // Tabla y esquema de la base de datos.
            ToTable("DeclaracionesPrevias", "dbo");

            Property(a => a.TipoSancionId).IsOptional();


            // Cliente
            HasRequired(p => p.Cliente)
                .WithMany(p => p.DeclaracionesPrevias)
                .HasForeignKey(p => p.PersonaId)
                .WillCascadeOnDelete(false);

            // Tipo Sanción
            HasRequired(p => p.TipoSancion)
                .WithMany(p => p.DeclaracionesPrevias)
                .HasForeignKey(p => p.TipoSancionId)
                .WillCascadeOnDelete(false);

        }
    }
}