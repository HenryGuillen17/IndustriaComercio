using IndustriaComercio.Models.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.mapping.TablasBasicas
{
    public class DepartamentoMapping : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoMapping()
        {
            // llave primaria.
            HasKey(t => t.DepartamentoId);

            Property(a => a.DepartamentoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental
            Property(x => x.Descripcion).HasMaxLength(50).IsRequired();
            // Tabla y esquema de la base de datos.
            ToTable("Departamentos", "dbo");
        }
    }
}