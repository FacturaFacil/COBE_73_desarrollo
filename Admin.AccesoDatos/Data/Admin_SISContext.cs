using System;
using System.Collections.Generic;
using Admin.Models;
using Admin.Models.GEN;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Admin.AccesoDatos.Data
{
    public partial class Admin_SISContext : DbContext
    {
        public Admin_SISContext()
        {
        }

        public Admin_SISContext(DbContextOptions<Admin_SISContext> options)
            : base(options)
        {
        }


        //public  DbSet<TblCntCuentasContables> TblCntCuentasContables { get; set; }
        //public  DbSet<TblCntEdoDeCta> TblCntEdoDeCta { get; set; }
        //public  DbSet<TblCntEdoDeCtaDetalle> TblCntEdoDeCtaDetalle { get; set; }
        //public  DbSet<TblCntGruposCuentasContables> TblCntGruposCuentasContables { get; set; }
        //public  DbSet<TblCntPolizas> TblCntPolizas { get; set; }
        //public  DbSet<TblCntTiposPolizas> TblCntTiposPolizas { get; set; }
        //public  DbSet<TblCxcAbonos> TblCxcAbonos { get; set; }
        //public  DbSet<TblCxcAnticiposClientes> TblCxcAnticiposClientes { get; set; }
        //public  DbSet<TblCxcAplicacionAnticiposClientes> TblCxcAplicacionAnticiposClientes { get; set; }
        //public  DbSet<TblCxcCargos> TblCxcCargos { get; set; }
        //public  DbSet<TblCxcClientes> TblCxcClientes { get; set; }
        //public  DbSet<TblCxcClientesContactos> TblCxcClientesContactos { get; set; }
        //public  DbSet<TblCxcClientesCuentasBancarias> TblCxcClientesCuentasBancarias { get; set; }
        //public  DbSet<TblCxcClientesDirecciones> TblCxcClientesDirecciones { get; set; }
        //public  DbSet<TblCxcClientesResp> TblCxcClientesResp { get; set; }
        //public  DbSet<TblCxcClientesTelefonos> TblCxcClientesTelefonos { get; set; }
        //public  DbSet<TblCxcCobradores> TblCxcCobradores { get; set; }
        //public  DbSet<TblCxcCobros> TblCxcCobros { get; set; }
        //public  DbSet<TblCxcGirosClientes> TblCxcGirosClientes { get; set; }
        //public  DbSet<TblCxcGruposClientes> TblCxcGruposClientes { get; set; }
        //public  DbSet<TblCxcRecibosCaja> TblCxcRecibosCaja { get; set; }
        //public  DbSet<TblCxcRecibosCajaDetalle> TblCxcRecibosCajaDetalle { get; set; }
        //public  DbSet<TblCxcRecibosCajaDetallePagos> TblCxcRecibosCajaDetallePagos { get; set; }
        //public  DbSet<TblCxcTiposContactos> TblCxcTiposContactos { get; set; }
        //public  DbSet<TblCxpDeuda> TblCxpDeuda { get; set; }
        //public  DbSet<TblCxpGirosProveedores> TblCxpGirosProveedores { get; set; }
        //public  DbSet<TblCxpGruposProveedores> TblCxpGruposProveedores { get; set; }
        //public  DbSet<TblCxpPagos> TblCxpPagos { get; set; }
        //public  DbSet<TblCxpProveedores> TblCxpProveedores { get; set; }
        //public  DbSet<TblCxpProveedoresCuentasBancarias> TblCxpProveedoresCuentasBancarias { get; set; }
        //public  DbSet<TblCxpProveedoresDirecciones> TblCxpProveedoresDirecciones { get; set; }
        //public  DbSet<TblCxpRecibosEgresos> TblCxpRecibosEgresos { get; set; }
        //public  DbSet<TblCxpTiposProveedores> TblCxpTiposProveedores { get; set; }
        //public  DbSet<TblFacCotizacion> TblFacCotizacion { get; set; }
        //public  DbSet<TblFacCotizacionDetalle> TblFacCotizacionDetalle { get; set; }
        //public  DbSet<TblFacDevoluciones> TblFacDevoluciones { get; set; }
        //public  DbSet<TblFacDevolucionesDetalle> TblFacDevolucionesDetalle { get; set; }
        //public  DbSet<TblFacFacturas> TblFacFacturas { get; set; }
        //public  DbSet<TblFacFacturasClientes> TblFacFacturasClientes { get; set; }
        //public  DbSet<TblFacFacturasDatosAdicionales> TblFacFacturasDatosAdicionales { get; set; }
        //public  DbSet<TblFacFacturasDetalle> TblFacFacturasDetalle { get; set; }
        //public  DbSet<TblFacFacturasDetallePagos> TblFacFacturasDetallePagos { get; set; }
        //public  DbSet<TblFacFacturasSucursales> TblFacFacturasSucursales { get; set; }
        //public  DbSet<TblFacNotaDevolucionDetalleNoo> TblFacNotaDevolucionDetalleNoo { get; set; }
        //public  DbSet<TblFacNotaDevolucionNoo> TblFacNotaDevolucionNoo { get; set; }
        //public  DbSet<TblFacNotaVenta> TblFacNotaVenta { get; set; }
        //public  DbSet<TblFacNotaVentaDetalle> TblFacNotaVentaDetalle { get; set; }
        //public  DbSet<TblFacNotaVentaDetallePagos> TblFacNotaVentaDetallePagos { get; set; }
        //public  DbSet<TblFacNotasCredito> TblFacNotasCredito { get; set; }
        //public  DbSet<TblFacNotasCreditoDetalle> TblFacNotasCreditoDetalle { get; set; }
        //public  DbSet<TblFacNotasCreditoDetalleBonificaciones> TblFacNotasCreditoDetalleBonificaciones { get; set; }
        //public  DbSet<TblFacNotasCreditoDetalleEntradas> TblFacNotasCreditoDetalleEntradas { get; set; }
        //public  DbSet<TblFacNotasCreditoDetallePagos> TblFacNotasCreditoDetallePagos { get; set; }
        //public  DbSet<TblFacOrdenesVenta> TblFacOrdenesVenta { get; set; }
        //public  DbSet<TblFacPoliza> TblFacPoliza { get; set; }
        //public  DbSet<TblFacPolizaDetalle> TblFacPolizaDetalle { get; set; }
        //public  DbSet<TblFacPolizaServicios> TblFacPolizaServicios { get; set; }
        //public  DbSet<TblFacTecnicos> TblFacTecnicos { get; set; }
        //public  DbSet<TblFacTiposVenta> TblFacTiposVenta { get; set; }
        //public  DbSet<TblFacVendedores> TblFacVendedores { get; set; }
        //public  DbSet<TblFacVendedoresComisiones> TblFacVendedoresComisiones { get; set; }
        //public  DbSet<TblFisComprobantesFiscales> TblFisComprobantesFiscales { get; set; }
        //public  DbSet<TblGenBancos> TblGenBancos { get; set; }
        //public  DbSet<TblGenClasesMovimientos> TblGenClasesMovimientos { get; set; }
        //public  DbSet<TblGenClasesPagos> TblGenClasesPagos { get; set; }
        //public  DbSet<TblGenClavesIeps> TblGenClavesIeps { get; set; }
        //public  DbSet<TblGenClavesIva> TblGenClavesIva { get; set; }
        //public  DbSet<TblGenClavesRetencionesIsr> TblGenClavesRetencionesIsr { get; set; }
        //public  DbSet<TblGenClavesRetencionesIva> TblGenClavesRetencionesIva { get; set; }
        //public  DbSet<TblGenDepartamentos> TblGenDepartamentos { get; set; }
        public DbSet<Tbl_GEN_DISTRIBUIDORES> Tbl_GEN_DISTRIBUIDORES { get; set; }
        //public  DbSet<TblGenDistribuidoresConfiguracion> TblGenDistribuidoresConfiguracion { get; set; }
        //public  DbSet<TblGenDistribuidoresModulos> TblGenDistribuidoresModulos { get; set; }

        //public  DbSet<TblGenEstadosDocumentos> TblGenEstadosDocumentos { get; set; }
        //public  DbSet<TblGenFoliosComprobantes> TblGenFoliosComprobantes { get; set; }
        public DbSet<Tbl_GEN_MODULOS> Tbl_GEN_MODULOS { get; set; }
        public DbSet<Tbl_GEN_MODULOS_OPCIONES> Tbl_GEN_MODULOS_OPCIONES { get; set; }
        public DbSet<Tbl_GEN_ROLES> Tbl_GEN_ROLES { get; set; }
        public DbSet<Tbl_GEN_ROLES_PERMISOS> Tbl_GEN_ROLES_PERMISOS { get; set; }
        //public  DbSet<TblGenListaPrecios> TblGenListaPrecios { get; set; }
        //public  DbSet<TblGenListaPreciosCliente> TblGenListaPreciosCliente { get; set; }
        //public  DbSet<TblGenListaPreciosClienteDetalle> TblGenListaPreciosClienteDetalle { get; set; }
        //public  DbSet<TblGenListaPreciosDetalle> TblGenListaPreciosDetalle { get; set; }
        public DbSet<Tbl_GEN_MENU> Tbl_GEN_MENU { get; set; }

        //public  DbSet<TblGenModulos> TblGenModulos { get; set; }
        //public  DbSet<TblGenModulosOpciones> TblGenModulosOpciones { get; set; }
        //public  DbSet<TblGenModulosOpcionesConfiguracion> TblGenModulosOpcionesConfiguracion { get; set; }
        //public  DbSet<TblGenModulosOpcionesSuperAdministrador> TblGenModulosOpcionesSuperAdministrador { get; set; }
        //public  DbSet<TblGenMonedas> TblGenMonedas { get; set; }
        //public  DbSet<TblGenMovimientos> TblGenMovimientos { get; set; }
        //public  DbSet<TblGenPaises> TblGenPaises { get; set; }
        //public  DbSet<TblGenParidadesVenta> TblGenParidadesVenta { get; set; }
        //public  DbSet<TblGenPoliza> TblGenPoliza { get; set; }
        //public  DbSet<TblGenSatAduanas> TblGenSatAduanas { get; set; }
        //public  DbSet<TblGenSatBancos> TblGenSatBancos { get; set; }
        //public  DbSet<TblGenSatCategoriasIeps> TblGenSatCategoriasIeps { get; set; }
        //public  DbSet<TblGenSatCodigosPostales> TblGenSatCodigosPostales { get; set; }
        //public  DbSet<TblGenSatCvesProdSer> TblGenSatCvesProdSer { get; set; }
        //public  DbSet<TblGenSatCvesUnidad> TblGenSatCvesUnidad { get; set; }
        //public  DbSet<TblGenSatFormasDePago> TblGenSatFormasDePago { get; set; }
        //public  DbSet<TblGenSatImpuestos> TblGenSatImpuestos { get; set; }
        //public  DbSet<TblGenSatMetodosPagos> TblGenSatMetodosPagos { get; set; }
        //public  DbSet<TblGenSatMonedas> TblGenSatMonedas { get; set; }
        //public  DbSet<TblGenSatNumPedimentoAduana> TblGenSatNumPedimentoAduana { get; set; }
        //public  DbSet<TblGenSatPaises> TblGenSatPaises { get; set; }
        //public  DbSet<TblGenSatPatenteAduanal> TblGenSatPatenteAduanal { get; set; }
        //public  DbSet<TblGenSatRegimenFiscal> TblGenSatRegimenFiscal { get; set; }
        //public  DbSet<TblGenSatTasaCuota> TblGenSatTasaCuota { get; set; }
        //public  DbSet<TblGenSatTipocomprobante> TblGenSatTipocomprobante { get; set; }
        //public  DbSet<TblGenSatTiposRelacion> TblGenSatTiposRelacion { get; set; }
        //public  DbSet<TblGenSatUsocfdi> TblGenSatUsocfdi { get; set; }
        //public  DbSet<TblGenServiciosPoliza> TblGenServiciosPoliza { get; set; }
        //public  DbSet<TblGenServidoresCorreo> TblGenServidoresCorreo { get; set; }
        //public  DbSet<TblGenSolicitudesSat> TblGenSolicitudesSat { get; set; }
        public DbSet<Tbl_GEN_SUCURSALES> tbl_GEN_SUCURSALES { get; set; }
        //public  DbSet<TblGenSucursalesContactos> TblGenSucursalesContactos { get; set; }
        //public  DbSet<TblGenSucursalesTelefonos> TblGenSucursalesTelefonos { get; set; }
        //public  DbSet<TblGenTiposContactos> TblGenTiposContactos { get; set; }
        //public  DbSet<TblGenTiposDocumentos> TblGenTiposDocumentos { get; set; }
        //public  DbSet<TblGenTiposMovimientos> TblGenTiposMovimientos { get; set; }
        //public  DbSet<TblGenTiposPagos> TblGenTiposPagos { get; set; }
        //public  DbSet<TblGenUltimoAcceso> TblGenUltimoAcceso { get; set; }
        public DbSet<Tbl_GEN_USUARIOS> tbl_GEN_USUARIOS { get; set; }
        //public  DbSet<TblGenUsuariosConfiguraciones> TblGenUsuariosConfiguraciones { get; set; }
        //public  DbSet<TblGenUsuariosDerechosEmpresasConfig> TblGenUsuariosDerechosEmpresasConfig { get; set; }
        //public  DbSet<TblGenUsuariosDerechosOpciones> TblGenUsuariosDerechosOpciones { get; set; }
        //public  DbSet<TblGenUsuariosJerarquias> TblGenUsuariosJerarquias { get; set; }
        //public  DbSet<TblGenXmlSat> TblGenXmlSat { get; set; }
        public DbSet<Tbl_INV_ALMACENES> Tbl_INV_ALMACENES { get; set; }
        public  DbSet<Tbl_INV_CLASESGASTOS> Tbl_INV_CLASESGASTOS { get; set; }
        //public  DbSet<TblInvEntradas> TblInvEntradas { get; set; }
        //public  DbSet<TblInvEntradasDetalle> TblInvEntradasDetalle { get; set; }
        //public  DbSet<TblInvEntradasDetalleSeriesProductos> TblInvEntradasDetalleSeriesProductos { get; set; }
        //public  DbSet<TblInvInventariosFisicos> TblInvInventariosFisicos { get; set; }
        //public  DbSet<TblInvInventariosFisicosDetalle> TblInvInventariosFisicosDetalle { get; set; }
        public DbSet<Tbl_INV_LINEAS> Tbl_INV_LINEAS { get; set; }
        public DbSet<Tbl_INV_MARCAS> Tbl_INV_MARCAS { get; set; }

        //public DbSet<Tbl_GEN_ROLES_PERMISOS> Tbl_GEN_ROLES_PERMISOS { get; set; }
        //public  DbSet<TblInvPaquetes> TblInvPaquetes { get; set; }
        //public  DbSet<TblInvProductoUbicacion> TblInvProductoUbicacion { get; set; }
        public  DbSet<Tbl_INV_PRODUCTOS> Tbl_INV_PRODUCTOS { get; set; }
        //public  DbSet<TblInvProductosCvesProveedores> TblInvProductosCvesProveedores { get; set; }
        public  DbSet<Tbl_INV_PRODUCTOS_IMPUESTOS> Tbl_INV_PRODUCTOS_IMPUESTOS { get; set; }
        //public  DbSet<TblInvProductosResp> TblInvProductosResp { get; set; }
        //public  DbSet<TblInvSalidas> TblInvSalidas { get; set; }
        //public  DbSet<TblInvSalidasDetalle> TblInvSalidasDetalle { get; set; }
        //public  DbSet<TblInvSalidasDetalleSeriesProductos> TblInvSalidasDetalleSeriesProductos { get; set; }
        public DbSet<Tbl_INV_SUBLINEAS> Tbl_INV_SUBLINEAS { get; set; }
        //public  DbSet<TblInvTraspasos> TblInvTraspasos { get; set; }
        //public  DbSet<TblInvTraspasosDetalle> TblInvTraspasosDetalle { get; set; }
        //public  DbSet<TblInvTraspasosDetalleEstados> TblInvTraspasosDetalleEstados { get; set; }
        //public  DbSet<TblInvTraspasosDetalleSeriesProductos> TblInvTraspasosDetalleSeriesProductos { get; set; }
        //public  DbSet<TblNomBancos> TblNomBancos { get; set; }
        //public  DbSet<TblNomConceptosxempleado> TblNomConceptosxempleado { get; set; }
        //public  DbSet<TblNomDeducciones> TblNomDeducciones { get; set; }
        //public  DbSet<TblNomDepartamentos> TblNomDepartamentos { get; set; }
        //public  DbSet<TblNomDiasIncapacidades> TblNomDiasIncapacidades { get; set; }
        //public  DbSet<TblNomEmpleados> TblNomEmpleados { get; set; }
        //public  DbSet<TblNomHorasExtras> TblNomHorasExtras { get; set; }
        //public  DbSet<TblNomNomina> TblNomNomina { get; set; }
        //public  DbSet<TblNomPercepciones> TblNomPercepciones { get; set; }
        //public  DbSet<TblNomPeriodicidadPagos> TblNomPeriodicidadPagos { get; set; }
        //public  DbSet<TblNomPuestoEmpleados> TblNomPuestoEmpleados { get; set; }
        //public  DbSet<TblNomRecibosNomina> TblNomRecibosNomina { get; set; }
        //public  DbSet<TblNomRiesgoPuestos> TblNomRiesgoPuestos { get; set; }
        //public  DbSet<TblNomTiposContratos> TblNomTiposContratos { get; set; }
        //public  DbSet<TblNomTiposDeducciones> TblNomTiposDeducciones { get; set; }
        //public  DbSet<TblNomTiposIncapacidades> TblNomTiposIncapacidades { get; set; }
        //public  DbSet<TblNomTiposJornadas> TblNomTiposJornadas { get; set; }
        //public  DbSet<TblNomTiposPercepciones> TblNomTiposPercepciones { get; set; }
        //public  DbSet<TblNomTiposRegimenes> TblNomTiposRegimenes { get; set; }
        //public  DbSet<TblPolPeriodicidad> TblPolPeriodicidad { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tbl_INV_LINEAS>()
                .HasKey(c => new { c.Id, c.Id_Dist });

            modelBuilder.Entity<Tbl_INV_SUBLINEAS>()
                 .HasKey(c => new { c.Id, c.Id_Dist, c.Id_Linea });

            modelBuilder.Entity<Tbl_INV_MARCAS>()
                .HasKey(c => new { c.id, c.id_dist });

            modelBuilder.Entity<Tbl_INV_ALMACENES>()
                .HasKey(c => new { c.Id, c.Id_Dist });

            modelBuilder.Entity<Tbl_INV_CLASESGASTOS>()
                .HasKey(c => new { c.Id, c.Id_Dist });

            modelBuilder.Entity<Tbl_INV_PRODUCTOS>()
                .HasKey(c => new { c.Id, c.Id_Dist });

            modelBuilder.Entity<Tbl_INV_PRODUCTOS_IMPUESTOS>()
                .HasKey(c => new { c.Id, c.Id_Dist });
            


            modelBuilder.Entity<Tbl_GEN_USUARIOS>()
               .HasKey(c => new { c.Id, c.Id_Dist });

            modelBuilder.Entity<Tbl_GEN_SUCURSALES>()
              .HasKey(c => new { c.Id, c.Id_Dist });


            modelBuilder.Entity<Tbl_GEN_MODULOS>()
                .HasKey(c => new { c.Id });

            modelBuilder.Entity<Tbl_GEN_MODULOS_OPCIONES>()
                .HasKey(c => new { c.Id, c.Id_Modulo });


            modelBuilder.Entity<Tbl_GEN_ROLES>()
             .HasKey(c => new { c.Id, c.Id_Dist });

            modelBuilder.Entity<Tbl_GEN_ROLES_PERMISOS>()
               .HasKey(c => new { c.Id_Dist, c.Id_Rol, c.Id_Modulo, c.Id_Opciones });

        }
    }
}
