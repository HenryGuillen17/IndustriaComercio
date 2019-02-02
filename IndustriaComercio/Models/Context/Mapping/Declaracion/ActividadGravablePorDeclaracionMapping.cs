using IndustriaComercio.Models.Entidades.Basicos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.Mapping.Declaracion
{
    public class ActividadGravablePorDeclaracionMapping : EntityTypeConfiguration<ActividadGravablePorDeclaracion>
    {
        public ActividadGravablePorDeclaracionMapping()
        {
            // llave primaria.
            HasKey(t => new
            {
                t.ActividadId, t.DeclaracionPreviaId
            });


            // Tabla y esquema de la base de datos.
            ToTable("ActividadesGravablesPorDeclaracion", "dbo");

            Property(a => a.DeclaracionPreviaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 
            Property(a => a.ActividadId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 



            //------------------- llave foranea  ------------

            HasRequired(p => p.DeclaracionPrevia)
            .WithMany(p => p.ActividadesGravadas)
            .HasForeignKey(p => p.DeclaracionPreviaId)
            .WillCascadeOnDelete(false);

            HasRequired(p => p.Actividad)
            .WithMany(p => p.ActividadesGravadas)
            .HasForeignKey(p => p.ActividadId)
            .WillCascadeOnDelete(false);
            //-------------------------------------------------------------------------------
        }
    }
}