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
            Property(x => x.Contraseña).IsRequired().HasMaxLength(100);

            HasRequired(x => x.Perfil)
            .WithMany(x => x.Usuarios)
            .HasForeignKey(x => x.PerfilId)
            .WillCascadeOnDelete(false);

            HasRequired(x => x.Persona).WithOptional(x => x.Usuario);
        }


    }
}
