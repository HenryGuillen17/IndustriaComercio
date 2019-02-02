using System.Data.Entity.ModelConfiguration;
using IndustriaComercio.Entidades.UsuarioPermisos;

namespace IndustriaComercio.Context.mapping.UsuarioPermiso
{
    public class UsuarioMenuMapping : EntityTypeConfiguration<UsuarioMenu>
    {
        public UsuarioMenuMapping()
        {
            // Tabla y esquema
            ToTable("UsuariosMenu", "dbo");

            //Llave
            HasKey(x => new { x.PersonaId, x.MenuId });

            HasRequired(x => x.Menu)
            .WithMany(x => x.UsuarioMenus)
            .HasForeignKey(x => x.MenuId)
            .WillCascadeOnDelete(false);

            HasRequired(x => x.Usuario)
            .WithMany(x => x.UsuarioMenus)
            .HasForeignKey(x => x.PersonaId)
            .WillCascadeOnDelete(false);


        }
    }
}
