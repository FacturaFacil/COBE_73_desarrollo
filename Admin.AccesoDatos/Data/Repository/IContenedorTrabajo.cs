using Admin.AccesoDatos.Data.Repository.IGEN;
using Admin.AccesoDatos.Data.Repository.IINV;
using Admin.AccesoDatos.Data.Repository.INV;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository
{
   public interface IContenedorTrabajo : IDisposable 
    {
        IMarcaRepository Marca { get; }
        IMenuRepository Menu { get; }

        IUsuarioRepository Usuario { get; }

        IDistribuidorRepository Distribuidor { get; }

        ISucursalRepository Sucursal { get; }

        IAlmacenRepository Almacen { get; }

        IRolRepository Rol { get; }

        IRolPermisoRepository RolPermiso { get; }

        IModuloRepository Modulo { get; }

        IModuloOpcionesRepository ModuloOpciones { get; }

        ILineaRepository Linea { get; }

        ISubLineaRepository SubLinea { get; }

        IClaseGastoRepository ClaseGasto { get; }

        IProductoRepository Producto { get; }

        IProductoImpuestoRepository Producto_impuesto { get; }

        void Save();
    }
}
