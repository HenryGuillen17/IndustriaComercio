namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActividadesGravablesPorDeclaracion",
                c => new
                    {
                        ActividadId = c.Int(nullable: false),
                        DeclaracionPreviaId = c.Int(nullable: false),
                        IngresosGravados = c.Double(nullable: false),
                        Impuesto = c.Double(nullable: false),
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
                        Tarifa = c.Double(nullable: false),
                        Valor = c.Double(nullable: false),
                        TipoActividadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActividadId)
                .ForeignKey("dbo.TipoActividad", t => t.TipoActividadId)
                .Index(t => t.TipoActividadId);
            
            CreateTable(
                "dbo.EstablecimientoActividades",
                c => new
                    {
                        EstablecimientoId = c.Int(nullable: false),
                        ActividadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EstablecimientoId, t.ActividadId })
                .ForeignKey("dbo.ActividadesGravadas", t => t.ActividadId)
                .ForeignKey("dbo.Establecimientos", t => t.EstablecimientoId)
                .Index(t => t.EstablecimientoId)
                .Index(t => t.ActividadId);
            
            CreateTable(
                "dbo.Establecimientos",
                c => new
                    {
                        EstablecimientoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.EstablecimientoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        PersonaId = c.Int(nullable: false),
                        NoPlaca = c.String(),
                        ClasificacionContribuyenteId = c.Int(nullable: false),
                        Nota = c.String(),
                        NumeroEstablecimientos = c.Int(nullable: false),
                        Estado = c.Byte(nullable: false),
                        RetieneImpIndustriaComercio = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.ClasificacionesContribuyente", t => t.ClasificacionContribuyenteId)
                .ForeignKey("dbo.Personas", t => t.PersonaId)
                .Index(t => t.PersonaId)
                .Index(t => t.ClasificacionContribuyenteId);
            
            CreateTable(
                "dbo.ClasificacionesContribuyente",
                c => new
                    {
                        ClasificacionContribuyenteId = c.Int(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ClasificacionContribuyenteId);
            
            CreateTable(
                "dbo.DeclaracionesPrevias",
                c => new
                    {
                        DeclaracionPreviaId = c.Int(nullable: false),
                        Año = c.Int(nullable: false),
                        TipoDeclaracion = c.Byte(nullable: false),
                        TipoContribuyenteId = c.Int(nullable: false),
                        TienePagoVoluntario = c.Boolean(nullable: false),
                        PagaAvisoTablero = c.Boolean(nullable: false),
                        FechaDeclaracion = c.DateTime(nullable: false),
                        PersonaId = c.Int(nullable: false),
                        IngresosEnElPais = c.Double(nullable: false),
                        IngresosFueraDelMunicipio = c.Double(nullable: false),
                        TotalIngresosMunicipio = c.Double(nullable: false),
                        IngresosDevoluciones = c.Double(nullable: false),
                        IngresosExportaciones = c.Double(nullable: false),
                        IngresosActivosFijos = c.Double(nullable: false),
                        IngresosNoGravados = c.Double(nullable: false),
                        IngresosActividadesExentas = c.Double(nullable: false),
                        TotalIngresosGravables = c.Double(nullable: false),
                        TotalTarifa = c.Double(nullable: false),
                        CapacidadInstalada = c.Double(nullable: false),
                        TotaImpuestoEnergiaElectrica = c.Double(nullable: false),
                        TotalImpuestoIndustriaComercio = c.Double(nullable: false),
                        ImpuestoAvisosTableros = c.Double(nullable: false),
                        PagoUnidadesComerciales = c.Double(nullable: false),
                        SobretasaBomberil = c.Double(nullable: false),
                        SobretasaSeguridad = c.Double(nullable: false),
                        TotalImpuestoCargo = c.Double(nullable: false),
                        ValorExoneracionImpuesto = c.Double(nullable: false),
                        RetencionesDelMunicipio = c.Double(nullable: false),
                        AutoretencionesDelMunicipio = c.Double(nullable: false),
                        DocumentoRetencion = c.String(),
                        AnticipoAnioAnterior = c.Double(nullable: false),
                        AnticipoAnioSiguiente = c.Double(nullable: false),
                        TipoSancionId = c.Int(nullable: false),
                        ValorSancion = c.Double(nullable: false),
                        SaldoFavorPeriodoAnterior = c.Double(nullable: false),
                        TotalSaldoCargo = c.Double(nullable: false),
                        TotalSaldoFavor = c.Double(nullable: false),
                        ValorPagar = c.Double(nullable: false),
                        PorcentajeDescuento = c.Double(nullable: false),
                        Descuento = c.Double(nullable: false),
                        PorcentajeIntereses = c.Double(nullable: false),
                        Interes = c.Double(nullable: false),
                        TotalPagar = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DeclaracionPreviaId)
                .ForeignKey("dbo.Clientes", t => t.PersonaId)
                .ForeignKey("dbo.TiposSanciones", t => t.TipoSancionId)
                .Index(t => t.PersonaId)
                .Index(t => t.TipoSancionId);
            
            CreateTable(
                "dbo.TiposSanciones",
                c => new
                    {
                        TipoSancionId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Porcentaje = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TipoSancionId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaId = c.Int(nullable: false),
                        TipoDocumentoId = c.Int(nullable: false),
                        NoIdentificacion = c.String(),
                        DigitoChequeo = c.String(),
                        PrimerNombre = c.String(),
                        SegundoNombre = c.String(),
                        PrimerApellido = c.String(),
                        SegundoApellido = c.String(),
                        NombreCompleto = c.String(),
                        FotoPerfil = c.String(),
                        Correo = c.String(),
                        Celular = c.String(),
                        Direccion = c.String(),
                        MunicipioId = c.Int(nullable: false),
                        Telefono = c.String(),
                        IsCliente = c.Boolean(nullable: false),
                        IsUsuario = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.Municipios", t => t.MunicipioId)
                .ForeignKey("dbo.TipoDocumento", t => t.TipoDocumentoId)
                .Index(t => t.TipoDocumentoId)
                .Index(t => t.MunicipioId);
            
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        MunicipioId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        DepartamentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MunicipioId)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DepartamentoId);
            
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
                .ForeignKey("dbo.Personas", t => t.PersonaId)
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
            
            CreateTable(
                "dbo.TipoActividad",
                c => new
                    {
                        TipoActividadId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoActividadId);
            
            CreateTable(
                "dbo.ListaCorreos",
                c => new
                    {
                        ListaCorreoId = c.Int(nullable: false, identity: true),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.ListaCorreoId);
            
            CreateTable(
                "dbo.DescuentosPago",
                c => new
                    {
                        Anio = c.Short(nullable: false),
                        Mes = c.Byte(nullable: false),
                        Porcentaje = c.Double(nullable: false),
                        ConceptoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Anio, t.Mes });
            
            CreateTable(
                "dbo.InteresesMora",
                c => new
                    {
                        Anio = c.Short(nullable: false),
                        Mes = c.Byte(nullable: false),
                        Porcentaje = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Anio, t.Mes });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActividadesGravablesPorDeclaracion", "DeclaracionPreviaId", "dbo.DeclaracionesPrevias");
            DropForeignKey("dbo.ActividadesGravablesPorDeclaracion", "ActividadId", "dbo.ActividadesGravadas");
            DropForeignKey("dbo.ActividadesGravadas", "TipoActividadId", "dbo.TipoActividad");
            DropForeignKey("dbo.EstablecimientoActividades", "EstablecimientoId", "dbo.Establecimientos");
            DropForeignKey("dbo.Establecimientos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "PersonaId", "dbo.Personas");
            DropForeignKey("dbo.Usuarios", "PersonaId", "dbo.Personas");
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
            DropForeignKey("dbo.Personas", "TipoDocumentoId", "dbo.TipoDocumento");
            DropForeignKey("dbo.Personas", "MunicipioId", "dbo.Municipios");
            DropForeignKey("dbo.Municipios", "DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.DeclaracionesPrevias", "TipoSancionId", "dbo.TiposSanciones");
            DropForeignKey("dbo.DeclaracionesPrevias", "PersonaId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "ClasificacionContribuyenteId", "dbo.ClasificacionesContribuyente");
            DropForeignKey("dbo.EstablecimientoActividades", "ActividadId", "dbo.ActividadesGravadas");
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
            DropIndex("dbo.Municipios", new[] { "DepartamentoId" });
            DropIndex("dbo.Personas", new[] { "MunicipioId" });
            DropIndex("dbo.Personas", new[] { "TipoDocumentoId" });
            DropIndex("dbo.DeclaracionesPrevias", new[] { "TipoSancionId" });
            DropIndex("dbo.DeclaracionesPrevias", new[] { "PersonaId" });
            DropIndex("dbo.Clientes", new[] { "ClasificacionContribuyenteId" });
            DropIndex("dbo.Clientes", new[] { "PersonaId" });
            DropIndex("dbo.Establecimientos", new[] { "ClienteId" });
            DropIndex("dbo.EstablecimientoActividades", new[] { "ActividadId" });
            DropIndex("dbo.EstablecimientoActividades", new[] { "EstablecimientoId" });
            DropIndex("dbo.ActividadesGravadas", new[] { "TipoActividadId" });
            DropIndex("dbo.ActividadesGravablesPorDeclaracion", new[] { "DeclaracionPreviaId" });
            DropIndex("dbo.ActividadesGravablesPorDeclaracion", new[] { "ActividadId" });
            DropTable("dbo.InteresesMora");
            DropTable("dbo.DescuentosPago");
            DropTable("dbo.ListaCorreos");
            DropTable("dbo.TipoActividad");
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
            DropTable("dbo.TipoDocumento");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Municipios");
            DropTable("dbo.Personas");
            DropTable("dbo.TiposSanciones");
            DropTable("dbo.DeclaracionesPrevias");
            DropTable("dbo.ClasificacionesContribuyente");
            DropTable("dbo.Clientes");
            DropTable("dbo.Establecimientos");
            DropTable("dbo.EstablecimientoActividades");
            DropTable("dbo.ActividadesGravadas");
            DropTable("dbo.ActividadesGravablesPorDeclaracion");
        }
    }
}
