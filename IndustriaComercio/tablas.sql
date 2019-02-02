USE [Hacienda]
GO

/****** Object:  Table [dbo].[DeclaracionesPrevias]    Script Date: 27/01/2019 22:33:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DeclaracionesPrevias](
	[DeclaracionPreviaId] [int] NOT NULL,
	[Año] [int] NOT NULL,
	[TipoDeclaracion] [tinyint] NOT NULL,
	[TipoContribuyenteId] [int] NOT NULL,
	[TienePagoVoluntario] [bit] NOT NULL,
	[NombreCompleto] [nvarchar](max) NULL,
	[TipoDocumentoId] [int] NOT NULL,
	[NoIdentificacion] [nvarchar](max) NULL,
	[DigitoChequeo] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[MunicipioNotificacion] [nvarchar](max) NULL,
	[DepartamentoNotificacion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NULL,
	[Correo] [nvarchar](max) NULL,
	[NumeroEstablecimientos] [int] NOT NULL,
	[ClasificacionContribuyente] [nvarchar](max) NULL,
	[IngresosEnElPais] [int] NOT NULL,
	[IngresosFueraDelMunicipio] [int] NOT NULL,
	[TotalIngresosMunicipio] [int] NOT NULL,
	[IngresosDevoluciones] [int] NOT NULL,
	[IngresosExportaciones] [int] NOT NULL,
	[IngresosActivosFijos] [int] NOT NULL,
	[IngresosNoGravados] [int] NOT NULL,
	[IngresosActividadesExentas] [int] NOT NULL,
	[TotalIngresosGravables] [int] NOT NULL,
	[TotalTarifa] [int] NOT NULL,
	[CapacidadInstalada] [int] NOT NULL,
	[TotaImpuestoEnergiaElectrica] [int] NOT NULL,
	[TotalImpuestoIndustriaComercio] [int] NOT NULL,
	[ImpuestoAvisosTableros] [int] NOT NULL,
	[PagoUnidadesComerciales] [int] NOT NULL,
	[SobretasaBomberil] [int] NOT NULL,
	[SobretasaSeguridad] [int] NOT NULL,
	[TotalImpuestoCargo] [int] NOT NULL,
	[ValorExoneracionImpuesto] [int] NOT NULL,
	[RetencionesDelMunicipio] [int] NOT NULL,
	[AutoretencionesDelMunicipio] [int] NOT NULL,
	[AnticipoAnioAnterior] [int] NOT NULL,
	[AnticipoAnioSiguiente] [int] NOT NULL,
	[TipoSancion] [tinyint] NOT NULL,
	[OtroTipoSancion] [nvarchar](max) NULL,
	[ValorSancion] [int] NOT NULL,
	[SaldoFavorPeriodoAnterior] [int] NOT NULL,
	[TotalSaldoCargo] [int] NOT NULL,
	[TotalSaldoFavor] [int] NOT NULL,
	[ValorPagar] [int] NOT NULL,
	[DescuentoProntoPago] [int] NOT NULL,
	[InteresesDeMora] [int] NOT NULL,
	[TotalPagar] [int] NOT NULL,
 CONSTRAINT [PK_dbo.DeclaracionesPrevias] PRIMARY KEY CLUSTERED 
(
	[DeclaracionPreviaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [Hacienda]
GO

/****** Object:  Table [dbo].[ActividadesGravables]    Script Date: 27/01/2019 22:33:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ActividadesGravables](
	[ActividadId] [int] NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Codigo] [nvarchar](max) NULL,
	[IngresosGravados] [int] NOT NULL,
	[Tarifa] [int] NOT NULL,
	[Impuesto] [int] NOT NULL,
	[DeclaracionPreviaId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ActividadesGravables] PRIMARY KEY CLUSTERED 
(
	[ActividadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ActividadesGravables]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ActividadesGravables_dbo.DeclaracionesPrevias_DeclaracionPrevia_DeclaracionPreviaId] FOREIGN KEY([DeclaracionPreviaId])
REFERENCES [dbo].[DeclaracionesPrevias] ([DeclaracionPreviaId])
GO

ALTER TABLE [dbo].[ActividadesGravables] CHECK CONSTRAINT [FK_dbo.ActividadesGravables_dbo.DeclaracionesPrevias_DeclaracionPrevia_DeclaracionPreviaId]
GO

