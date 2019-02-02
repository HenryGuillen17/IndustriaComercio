using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Context.mapping.UsuarioPermiso
{
    public class UsuarioPermisoMapping : EntityTypeConfiguration<Entidades.UsuarioPermisos.UsuarioPermiso>
    {
        public UsuarioPermisoMapping()
        {
            //Tabla y esquema
            ToTable("UsuariosPermisos", "dbo");

            // Llave
            HasKey(x => new {x.PersonaId, x.MenuId, x.SubMenuId, x.PermisoId});

        

            // Llaves foraneas

            HasRequired(x => x.OpcionesPermiso)
           .WithMany(x => x.UsuarioPermisos)
           .HasForeignKey(x => new { x.MenuId, x.SubMenuId, x.PermisoId })
           .WillCascadeOnDelete(false);

            HasRequired(x=> x.UsuarioSubMenu)
            .WithMany(x=> x.UsuarioPermisos)
            .HasForeignKey(x=> new { x.PersonaId, x.MenuId, x.SubMenuId})
            .WillCascadeOnDelete(false);


        }
    }
}
