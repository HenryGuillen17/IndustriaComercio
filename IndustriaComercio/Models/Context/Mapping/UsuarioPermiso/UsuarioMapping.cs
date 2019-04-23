using System.Data.Entity.ModelConfiguration;
using IndustriaComercio.Entidades.UsuarioPermisos;

namespace IndustriaComercio.Context.mapping.UsuarioPermiso
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            // Tabla y esquema de la base de datos.
            ToTable("Usuarios", "dbo");

            HasKey(x => x.PersonaId);

            // Propiedades  
            Property(x => x.Contrasenia).IsRequired().HasMaxLength(500);
            Property(x => x.Login).IsRequired().HasMaxLength(100);
            Property(x => x.PerfilId).IsOptional();

            HasOptional(x => x.Perfil)
            .WithMany(x => x.Usuarios)
            .HasForeignKey(x => x.PerfilId)
            .WillCascadeOnDelete(false);

            HasRequired(x => x.Persona).WithOptional(x => x.Usuario);
        }


    }
}
