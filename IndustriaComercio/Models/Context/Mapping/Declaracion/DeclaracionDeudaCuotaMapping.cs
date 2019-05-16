using IndustriaComercio.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.Mapping.Declaracion
{
    public class DeclaracionDeudaCuotaMapping : EntityTypeConfiguration<DeclaracionDeudaCuota>
    {
        public DeclaracionDeudaCuotaMapping()

        {
            // llave primaria.
            HasKey(x => x.DeclaracionDeudaCuotaId);

            Property(a => a.DeclaracionDeudaCuotaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 

            HasIndex(t => new
            {
                t.DeclaracionPreviaId,
                t.FechaVencimiento
            }).IsUnique();
            
            // Tabla y esquema de la base de datos.
            ToTable("DeclaracionDeudasCuotas", "dbo");


            // DeclaracionPrevia
            HasRequired(p => p.DeclaracionPrevia)
                .WithMany(p => p.DeclaracionDeudasCuotas)
                .HasForeignKey(p => p.DeclaracionPreviaId)
                .WillCascadeOnDelete(false);
        }
    }
}