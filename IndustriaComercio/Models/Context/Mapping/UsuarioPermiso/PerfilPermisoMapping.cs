using System.Data.Entity.ModelConfiguration;
using IndustriaComercio.Entidades.UsuarioPermisos;

namespace IndustriaComercio.Context.mapping.UsuarioPermiso
{
    public class PerfilPermisoMapping : EntityTypeConfiguration<PerfilPermiso>
    {
        public PerfilPermisoMapping()
        {
            // Tabla y esquema
            ToTable("PerfilPermisos", "dbo");

            //Llave
            HasKey(x => new { x.PerfilId, x.MenuId, x.SubMenuId, x.PermisoId });


            // Llaves Foraneas

            HasRequired(x => x.OpcionesPermiso)
           .WithMany(x => x.PerfilPermisos)
           .HasForeignKey(x => new { x.MenuId, x.SubMenuId, x.PermisoId })
           .WillCascadeOnDelete(false);

            HasRequired(x => x.PerfilSubMenu)
            .WithMany(x => x.PerfilPermisos)
            .HasForeignKey(x => new { x.PerfilId, x.MenuId, x.SubMenuId })
            .WillCascadeOnDelete(false);


        }
    }
}
