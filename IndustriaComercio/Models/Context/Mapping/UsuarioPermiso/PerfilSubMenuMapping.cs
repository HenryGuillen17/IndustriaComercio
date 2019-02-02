using System.Data.Entity.ModelConfiguration;
using IndustriaComercio.Entidades.UsuarioPermisos;

namespace IndustriaComercio.Context.mapping.UsuarioPermiso
{
    public class PerfilSubMenuMapping : EntityTypeConfiguration<PerfilSubMenu>
    {
        public PerfilSubMenuMapping()
        {
            // Tabla y Esquema
            ToTable("PerfilesSubMenu", "dbo");

            // Llave
            HasKey(x => new { x.PerfilId, x.MenuId, x.SubMenuId });


            //----- Llaves 
            HasRequired(x => x.SubMenu)
            .WithMany(x => x.PerfilSubMenus)
            .HasForeignKey(x => new { x.MenuId, x.SubMenuId })
            .WillCascadeOnDelete(false);

            HasRequired(x => x.PerfilMenu)
            .WithMany(x => x.PerfilSubMenus)
            .HasForeignKey(x => new { x.PerfilId, x.MenuId })
            .WillCascadeOnDelete(false);


        }
    }
}
