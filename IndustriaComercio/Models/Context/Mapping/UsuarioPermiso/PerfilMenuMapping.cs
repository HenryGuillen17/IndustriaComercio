using System.Data.Entity.ModelConfiguration;
using IndustriaComercio.Entidades.UsuarioPermisos;

namespace IndustriaComercio.Context.mapping.UsuarioPermiso
{
    public class PerfilMenuMapping : EntityTypeConfiguration<PerfilMenu>
    {
        public PerfilMenuMapping()
        {
            // Tabla
            ToTable("PerfilesMenu", "dbo");

            // Llave
            HasKey(x => new { x.PerfilId, x.MenuId });


            HasRequired(x => x.Menu)
            .WithMany(x => x.PerfilMenus)
            .HasForeignKey(x => x.MenuId)
            .WillCascadeOnDelete(false);

            HasRequired(x => x.Perfil)
            .WithMany(x => x.PerfilMenus)
            .HasForeignKey(x => x.PerfilId)
            .WillCascadeOnDelete(false);
        }
    }
}
