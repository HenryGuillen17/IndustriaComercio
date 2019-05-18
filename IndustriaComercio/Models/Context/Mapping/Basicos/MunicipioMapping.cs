using IndustriaComercio.Models.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.mapping.TablasBasicas
{
    public class MunicipioMapping : EntityTypeConfiguration<Municipio>
    {
        public MunicipioMapping()
        {
            // llave primaria.
            HasKey(t => t.MunicipioId);

            Property(a => a.MunicipioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental
            Property(x => x.Descripcion).HasMaxLength(50).IsRequired();
            // Tabla y esquema de la base de datos.
            ToTable("Municipios", "dbo");

            // -- FK
            // Departamento
            HasRequired(p => p.Departamento)
                .WithMany(p => p.Municipios)
                .HasForeignKey(p => p.DepartamentoId)
                .WillCascadeOnDelete(false);
        }
    }
}