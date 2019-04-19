using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.mapping.Persona
{
    public class PersonaMapping : EntityTypeConfiguration<IndustriaComercio.Entidades.Persona.Persona>
    {
        public PersonaMapping()
        {
            // llave primaria.
            HasKey(t => t.PersonaId);

            // Tabla y esquema de la base de datos.
            ToTable("Personas", "dbo");

            Property(a => a.PersonaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(x => x.TipoDocumento)
                .WithMany(x => x.Personas)
                .HasForeignKey(x => x.TipoDocumentoId)
                .WillCascadeOnDelete(false);

            


        }

    }
}