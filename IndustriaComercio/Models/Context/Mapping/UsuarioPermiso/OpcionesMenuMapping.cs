using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using IndustriaComercio.Entidades.UsuarioPermisos;

namespace IndustriaComercio.Context.mapping.UsuarioPermiso
{
    public class OpcionesMenuMapping : EntityTypeConfiguration<OpcionesMenu>
    {
        public OpcionesMenuMapping()
        {
            // llave primaria.
            HasKey(t => t.MenuId);

            // Tabla y esquema de la base de datos.
            ToTable("OpcionesMenu", "dbo");

            Property(a => a.MenuId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental 

            Property(x => x.Imagen).IsRequired().HasMaxLength(50); // Ruta del Icono



            Property(x => x.Descripcion).IsRequired().HasMaxLength(100); 
        }
    }
}
