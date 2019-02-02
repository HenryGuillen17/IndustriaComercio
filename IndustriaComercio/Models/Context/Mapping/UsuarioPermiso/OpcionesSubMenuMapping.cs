using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using IndustriaComercio.Entidades.UsuarioPermisos;

namespace IndustriaComercio.Context.mapping.UsuarioPermiso
{
    public class OpcionesSubMenuMapping : EntityTypeConfiguration<OpcionesSubMenu>
    {
        public OpcionesSubMenuMapping()
        {
            // llave primaria.
            HasKey(t => new { t.MenuId, t.SubMenuId });

            // Tabla y esquema de la base de datos.
            ToTable("OpcionesSubMenu", "dbo");

            Property(a => a.MenuId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 

            Property(a => a.SubMenuId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 

           

            Property(a => a.Url)
                .IsRequired() // NOT NULL.
                .HasMaxLength(50);

            Property(x => x.Descripcion).IsRequired().HasMaxLength(100);


            //------------------- llave foranea a OpcionesMenu  -----------------------------

            // Sera obligatorio que SubMenu  tenga una Menu,
            // en pocas palabras defino la entidad padre.
            HasRequired(p => p.OpcionesMenu)
            // Indico que un Menu tendra muchos SubMenus.
            .WithMany(p => p.OpcionesSubMenus)
            // Quiero que la relacion se cree con la columna MenuId.
            .HasForeignKey(p => p.MenuId)
            .WillCascadeOnDelete(false);

            //-------------------------------------------------------------------------------
        }
    }
}
