namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActividadesGravablesPorDeclaracion",
                c => new
                    {
                        ActividadId = c.Int(nullable: false),
                        DeclaracionPreviaId = c.Int(nullable: false),
                        IngresosGravados = c.Int(nullable: false),
                        Tarifa = c.Int(nullable: false),
                        Impuesto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ActividadId, t.DeclaracionPreviaId })
                .ForeignKey("dbo.ActividadesGravadas", t => t.ActividadId)
                .ForeignKey("dbo.DeclaracionesPrevias", t => t.DeclaracionPreviaId)
                .Index(t => t.ActividadId)
                .Index(t => t.DeclaracionPreviaId);
            
            CreateTable(
                "dbo.ActividadesGravadas",
                c => new
                    {
                        ActividadId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Codigo = c.String(),
                    })
                .PrimaryKey(t => t.ActividadId);
            
            CreateTable(
                "dbo.DeclaracionesPrevias",
                c => new
                    {
                        DeclaracionPreviaId = c.Int(nullable: false),
                        Año = c.Int(nullable: false),
                        TipoDeclaracion = c.Byte(nullable: false),
                        TipoContribuyenteId = c.Int(nullable: false),
                        TienePagoVoluntario = c.Boolean(nullable: false),
                        NombreCompleto = c.String(),
                        TipoDocumentoId = c.Int(nullable: false),
                        NoIdentificacion = c.String(),
                        DigitoChequeo = c.String(),
                        Direccion = c.String(),
                        MunicipioNotificacion = c.String(),
                        DepartamentoNotificacion = c.String(),
                        Telefono = c.String(),
                        Correo = c.String(),
                        NumeroEstablecimientos = c.Int(nullable: false),
                        ClasificacionContribuyente = c.String(),
                        IngresosEnElPais = c.Int(nullable: false),
                        IngresosFueraDelMunicipio = c.Int(nullable: false),
                        TotalIngresosMunicipio = c.Int(nullable: false),
                        IngresosDevoluciones = c.Int(nullable: false),
                        IngresosExportaciones = c.Int(nullable: false),
                        IngresosActivosFijos = c.Int(nullable: false),
                        IngresosNoGravados = c.Int(nullable: false),
                        IngresosActividadesExentas = c.Int(nullable: false),
                        TotalIngresosGravables = c.Int(nullable: false),
                        TotalTarifa = c.Int(nullable: false),
                        CapacidadInstalada = c.Int(nullable: false),
                        TotaImpuestoEnergiaElectrica = c.Int(nullable: false),
                        TotalImpuestoIndustriaComercio = c.Int(nullable: false),
                        ImpuestoAvisosTableros = c.Int(nullable: false),
                        PagoUnidadesComerciales = c.Int(nullable: false),
                        SobretasaBomberil = c.Int(nullable: false),
                        SobretasaSeguridad = c.Int(nullable: false),
                        TotalImpuestoCargo = c.Int(nullable: false),
                        ValorExoneracionImpuesto = c.Int(nullable: false),
                        RetencionesDelMunicipio = c.Int(nullable: false),
                        AutoretencionesDelMunicipio = c.Int(nullable: false),
                        AnticipoAnioAnterior = c.Int(nullable: false),
                        AnticipoAnioSiguiente = c.Int(nullable: false),
                        TipoSancion = c.Byte(nullable: false),
                        OtroTipoSancion = c.String(),
                        ValorSancion = c.Int(nullable: false),
                        SaldoFavorPeriodoAnterior = c.Int(nullable: false),
                        TotalSaldoCargo = c.Int(nullable: false),
                        TotalSaldoFavor = c.Int(nullable: false),
                        ValorPagar = c.Int(nullable: false),
                        DescuentoProntoPago = c.Int(nullable: false),
                        InteresesDeMora = c.Int(nullable: false),
                        TotalPagar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeclaracionPreviaId);
            
            CreateTable(
                "dbo.TipoContribuyente",
                c => new
                    {
                        TipoContribuyenteId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoContribuyenteId);
            
            CreateTable(
                "dbo.TipoDocumento",
                c => new
                    {
                        TipoDocumentoId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoDocumentoId);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        PersonaId = c.Int(nullable: false),
                        TipoDocumentoId = c.Int(nullable: false),
                        NoIdentificacion = c.String(nullable: false),
                        PrimerNombre = c.String(nullable: false),
                        SegundoNombre = c.String(),
                        PrimerApellido = c.String(nullable: false),
                        SegundoApellido = c.String(),
                        NombreCompleto = c.String(),
                        FotoPerfil = c.String(),
                        Correo = c.String(),
                        Celular = c.String(),
                        Direccion = c.String(),
                        IsCliente = c.Boolean(nullable: false),
                        IsUsuario = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.TipoDocumento", t => t.TipoDocumentoId)
                .Index(t => t.TipoDocumentoId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        PersonaId = c.Int(nullable: false),
                        TipoClienteId = c.Int(nullable: false),
                        Nota = c.String(),
                        Estado = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.Persona", t => t.PersonaId)
                .Index(t => t.PersonaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        PersonaId = c.Int(nullable: false),
                        Login = c.String(),
                        Contraseña = c.String(nullable: false, maxLength: 100),
                        Estado = c.Byte(nullable: false),
                        PerfilId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.Perfiles", t => t.PerfilId)
                .ForeignKey("dbo.Persona", t => t.PersonaId)
                .Index(t => t.PersonaId)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.Perfiles",
                c => new
                    {
                        PerfilId = c.Byte(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PerfilId);
            
            CreateTable(
                "dbo.PerfilesMenu",
                c => new
                    {
                        PerfilId = c.Byte(nullable: false),
                        MenuId = c.Byte(nullable: false),
                        Permiso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.PerfilId, t.MenuId })
                .ForeignKey("dbo.OpcionesMenu", t => t.MenuId)
                .ForeignKey("dbo.Perfiles", t => t.PerfilId)
                .Index(t => t.PerfilId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.OpcionesMenu",
                c => new
                    {
                        MenuId = c.Byte(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Imagen = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.OpcionesSubMenu",
                c => new
                    {
                        MenuId = c.Byte(nullable: false),
                        SubMenuId = c.Byte(nullable: false),
                        Url = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => new { t.MenuId, t.SubMenuId })
                .ForeignKey("dbo.OpcionesMenu", t => t.MenuId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.OpcionesPermiso",
                c => new
                    {
                        MenuId = c.Byte(nullable: false),
                        SubMenuId = c.Byte(nullable: false),
                        PermisoId = c.Byte(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => new { t.MenuId, t.SubMenuId, t.PermisoId })
                .ForeignKey("dbo.OpcionesSubMenu", t => new { t.MenuId, t.SubMenuId })
                .Index(t => new { t.MenuId, t.SubMenuId });
            
            CreateTable(
                "dbo.PerfilPermisos",
                c => new
                    {
                        PerfilId = c.Byte(nullable: false),
                        MenuId = c.Byte(nullable: false),
                        SubMenuId = c.Byte(nullable: false),
                        PermisoId = c.Byte(nullable: false),
                        Permiso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.PerfilId, t.MenuId, t.SubMenuId, t.PermisoId })
                .ForeignKey("dbo.OpcionesPermiso", t => new { t.MenuId, t.SubMenuId, t.PermisoId })
                .ForeignKey("dbo.PerfilesSubMenu", t => new { t.PerfilId, t.MenuId, t.SubMenuId })
                .Index(t => new { t.PerfilId, t.MenuId, t.SubMenuId })
                .Index(t => new { t.MenuId, t.SubMenuId, t.PermisoId });
            
            CreateTable(
                "dbo.PerfilesSubMenu",
                c => new
                    {
                        PerfilId = c.Byte(nullable: false),
                        MenuId = c.Byte(nullable: false),
                        SubMenuId = c.Byte(nullable: false),
                        Permiso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.PerfilId, t.MenuId, t.SubMenuId })
                .ForeignKey("dbo.PerfilesMenu", t => new { t.PerfilId, t.MenuId })
                .ForeignKey("dbo.OpcionesSubMenu", t => new { t.MenuId, t.SubMenuId })
                .Index(t => new { t.PerfilId, t.MenuId })
                .Index(t => new { t.MenuId, t.SubMenuId });
            
            CreateTable(
                "dbo.UsuariosPermisos",
                c => new
                    {
                        PersonaId = c.Int(nullable: false),
                        MenuId = c.Byte(nullable: false),
                        SubMenuId = c.Byte(nullable: false),
                        PermisoId = c.Byte(nullable: false),
                        Permiso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonaId, t.MenuId, t.SubMenuId, t.PermisoId })
                .ForeignKey("dbo.OpcionesPermiso", t => new { t.MenuId, t.SubMenuId, t.PermisoId })
                .ForeignKey("dbo.UsuariosSubMenu", t => new { t.PersonaId, t.MenuId, t.SubMenuId })
                .Index(t => new { t.PersonaId, t.MenuId, t.SubMenuId })
                .Index(t => new { t.MenuId, t.SubMenuId, t.PermisoId });
            
            CreateTable(
                "dbo.UsuariosSubMenu",
                c => new
                    {
                        PersonaId = c.Int(nullable: false),
                        MenuId = c.Byte(nullable: false),
                        SubMenuId = c.Byte(nullable: false),
                        Permiso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonaId, t.MenuId, t.SubMenuId })
                .ForeignKey("dbo.OpcionesSubMenu", t => new { t.MenuId, t.SubMenuId })
                .ForeignKey("dbo.UsuariosMenu", t => new { t.PersonaId, t.MenuId })
                .Index(t => new { t.PersonaId, t.MenuId })
                .Index(t => new { t.MenuId, t.SubMenuId });
            
            CreateTable(
                "dbo.UsuariosMenu",
                c => new
                    {
                        PersonaId = c.Int(nullable: false),
                        MenuId = c.Byte(nullable: false),
                        Permiso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonaId, t.MenuId })
                .ForeignKey("dbo.OpcionesMenu", t => t.MenuId)
                .ForeignKey("dbo.Usuarios", t => t.PersonaId)
                .Index(t => t.PersonaId)
                .Index(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "PersonaId", "dbo.Persona");
            DropForeignKey("dbo.Usuarios", "PerfilId", "dbo.Perfiles");
            DropForeignKey("dbo.PerfilesMenu", "PerfilId", "dbo.Perfiles");
            DropForeignKey("dbo.PerfilesMenu", "MenuId", "dbo.OpcionesMenu");
            DropForeignKey("dbo.UsuariosPermisos", new[] { "PersonaId", "MenuId", "SubMenuId" }, "dbo.UsuariosSubMenu");
            DropForeignKey("dbo.UsuariosSubMenu", new[] { "PersonaId", "MenuId" }, "dbo.UsuariosMenu");
            DropForeignKey("dbo.UsuariosMenu", "PersonaId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuariosMenu", "MenuId", "dbo.OpcionesMenu");
            DropForeignKey("dbo.UsuariosSubMenu", new[] { "MenuId", "SubMenuId" }, "dbo.OpcionesSubMenu");
            DropForeignKey("dbo.UsuariosPermisos", new[] { "MenuId", "SubMenuId", "PermisoId" }, "dbo.OpcionesPermiso");
            DropForeignKey("dbo.PerfilPermisos", new[] { "PerfilId", "MenuId", "SubMenuId" }, "dbo.PerfilesSubMenu");
            DropForeignKey("dbo.PerfilesSubMenu", new[] { "MenuId", "SubMenuId" }, "dbo.OpcionesSubMenu");
            DropForeignKey("dbo.PerfilesSubMenu", new[] { "PerfilId", "MenuId" }, "dbo.PerfilesMenu");
            DropForeignKey("dbo.PerfilPermisos", new[] { "MenuId", "SubMenuId", "PermisoId" }, "dbo.OpcionesPermiso");
            DropForeignKey("dbo.OpcionesPermiso", new[] { "MenuId", "SubMenuId" }, "dbo.OpcionesSubMenu");
            DropForeignKey("dbo.OpcionesSubMenu", "MenuId", "dbo.OpcionesMenu");
            DropForeignKey("dbo.Persona", "TipoDocumentoId", "dbo.TipoDocumento");
            DropForeignKey("dbo.Cliente", "PersonaId", "dbo.Persona");
            DropForeignKey("dbo.ActividadesGravablesPorDeclaracion", "DeclaracionPreviaId", "dbo.DeclaracionesPrevias");
            DropForeignKey("dbo.ActividadesGravablesPorDeclaracion", "ActividadId", "dbo.ActividadesGravadas");
            DropIndex("dbo.UsuariosMenu", new[] { "MenuId" });
            DropIndex("dbo.UsuariosMenu", new[] { "PersonaId" });
            DropIndex("dbo.UsuariosSubMenu", new[] { "MenuId", "SubMenuId" });
            DropIndex("dbo.UsuariosSubMenu", new[] { "PersonaId", "MenuId" });
            DropIndex("dbo.UsuariosPermisos", new[] { "MenuId", "SubMenuId", "PermisoId" });
            DropIndex("dbo.UsuariosPermisos", new[] { "PersonaId", "MenuId", "SubMenuId" });
            DropIndex("dbo.PerfilesSubMenu", new[] { "MenuId", "SubMenuId" });
            DropIndex("dbo.PerfilesSubMenu", new[] { "PerfilId", "MenuId" });
            DropIndex("dbo.PerfilPermisos", new[] { "MenuId", "SubMenuId", "PermisoId" });
            DropIndex("dbo.PerfilPermisos", new[] { "PerfilId", "MenuId", "SubMenuId" });
            DropIndex("dbo.OpcionesPermiso", new[] { "MenuId", "SubMenuId" });
            DropIndex("dbo.OpcionesSubMenu", new[] { "MenuId" });
            DropIndex("dbo.PerfilesMenu", new[] { "MenuId" });
            DropIndex("dbo.PerfilesMenu", new[] { "PerfilId" });
            DropIndex("dbo.Usuarios", new[] { "PerfilId" });
            DropIndex("dbo.Usuarios", new[] { "PersonaId" });
            DropIndex("dbo.Cliente", new[] { "PersonaId" });
            DropIndex("dbo.Persona", new[] { "TipoDocumentoId" });
            DropIndex("dbo.ActividadesGravablesPorDeclaracion", new[] { "DeclaracionPreviaId" });
            DropIndex("dbo.ActividadesGravablesPorDeclaracion", new[] { "ActividadId" });
            DropTable("dbo.UsuariosMenu");
            DropTable("dbo.UsuariosSubMenu");
            DropTable("dbo.UsuariosPermisos");
            DropTable("dbo.PerfilesSubMenu");
            DropTable("dbo.PerfilPermisos");
            DropTable("dbo.OpcionesPermiso");
            DropTable("dbo.OpcionesSubMenu");
            DropTable("dbo.OpcionesMenu");
            DropTable("dbo.PerfilesMenu");
            DropTable("dbo.Perfiles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Cliente");
            DropTable("dbo.Persona");
            DropTable("dbo.TipoDocumento");
            DropTable("dbo.TipoContribuyente");
            DropTable("dbo.DeclaracionesPrevias");
            DropTable("dbo.ActividadesGravadas");
            DropTable("dbo.ActividadesGravablesPorDeclaracion");
        }
    }
}
