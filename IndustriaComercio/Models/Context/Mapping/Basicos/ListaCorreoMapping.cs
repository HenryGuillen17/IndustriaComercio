using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.mapping.TablasBasicas
{
    public class ListaCorreoMapping : EntityTypeConfiguration<ListaCorreo>
    {
        public ListaCorreoMapping()
        {
            // llave primaria.
            HasKey(t => t.ListaCorreoId);

            Property(a => a.ListaCorreoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 
            // Tabla y esquema de la base de datos.
            ToTable("ListasCorreos", "dbo");
        }
    }
}