using System.Data.Entity.ModelConfiguration;
using IndustriaComercio.Entidades.UsuarioPermisos;

namespace IndustriaComercio.Context.mapping.UsuarioPermiso
{
    public class UsuarioSubMenuMapping : EntityTypeConfiguration<UsuarioSubMenu>
    {
        public UsuarioSubMenuMapping()
        {
            // Tabla y esquema
            ToTable("UsuariosSubMenu", "dbo");

            // Llave
            HasKey(x => new { x.PersonaId, x.MenuId, x.SubMenuId });


            // Llaves 
            HasRequired(x => x.OpcionesSubMenu)
            .WithMany(x => x.UsuarioSubMenus)
            .HasForeignKey(x => new { x.MenuId, x.SubMenuId })
            .WillCascadeOnDelete(false);


            HasRequired(x => x.UsuarioMenu)
            .WithMany(x => x.UsuarioSubMenus)
            .HasForeignKey(x => new { x.PersonaId, x.MenuId })
            .WillCascadeOnDelete(false);


        }

    }
}
