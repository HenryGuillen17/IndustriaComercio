using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using IndustriaComercio.Entidades.UsuarioPermisos;

namespace IndustriaComercio.Context.mapping.UsuarioPermiso
{
    public class OpcionesPermisoMapping : EntityTypeConfiguration<OpcionesPermiso>
    {
        public OpcionesPermisoMapping()
        {
            // llave primaria.
            HasKey(t => new {  t.MenuId, t.SubMenuId, t.PermisoId });

            // Tabla y esquema de la base de datos.
            ToTable("OpcionesPermiso", "dbo");

            Property(a => a.MenuId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 

            Property(a => a.SubMenuId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 

            Property(a => a.PermisoId)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental


            Property(a => a.Descripcion)
                .IsRequired() // NOT NULL.
                .HasMaxLength(80);

            //------------------- llave foranea a OpcionesSubMenu y OpcionesMenu ------------

            // Sera obligatorio que SubMenu y Menus tengan una permisos,
            // en pocas palabras defino la entidad padre.
            HasRequired(p => p.OpcionesSubMenu)
            // Indico que un SubMenu y Menu tendras muchos permisos.
            .WithMany(p => p.OpcionesPermisos)
            // Quiero que la relacion se cree con la columna SubMenuId y MenuId.
            .HasForeignKey(p => new { p.MenuId, p.SubMenuId })
            .WillCascadeOnDelete(false);
            //-------------------------------------------------------------------------------

        }
    }
}
