using Admin.AccesoDatos.Data.Repository;
using Admin.AccesoDatos.Data.Repository.GEN;
using Admin.AccesoDatos.Data.Repository.IGEN;
using Admin.AccesoDatos.Data.Repository.IINV;
using Admin.AccesoDatos.Data.Repository.INV;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.AccesoDatos.Data
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly Admin_SISContext _db;

        public ContenedorTrabajo(Admin_SISContext db)
        {
            _db = db;
            Marca = new MarcaRepository(_db);
            Menu = new MenuRepository(_db);
            Usuario = new UsuarioRepository(_db);
            Distribuidor = new DistribuidorRepository(_db);
            Sucursal = new SucursalRepository(_db);
            Almacen = new AlmacenRepository(_db);
            Rol = new RolRepository(_db);
            RolPermiso = new RolPermisoRepository(_db);
            Modulo = new ModuloRepository(_db);
            ModuloOpciones = new ModuloOpcionesRepository(_db);
            Linea = new LineaRepository(_db);
            SubLinea = new SubLineaRepository(_db);
            ClaseGasto = new ClaseGastoRepository(_db);
            Producto = new ProductoRepository(_db);
            Producto_impuesto = new ProductoImpuestoRepository(_db);
        }


        public IMarcaRepository Marca { get; private set; }
        public IMenuRepository Menu{ get; private set; }

        public IUsuarioRepository Usuario { get; private set; }

        public IDistribuidorRepository Distribuidor { get; private set; }

        public ISucursalRepository Sucursal { get; private set; }

        public IAlmacenRepository Almacen { get; private set; }

        public IRolRepository Rol { get; private set; }

        public IRolPermisoRepository RolPermiso { get; private set; }

        public IModuloRepository Modulo { get; private set; }

        public IModuloOpcionesRepository ModuloOpciones { get; private set; }

        public ILineaRepository Linea { get; private set; }

        public ISubLineaRepository SubLinea { get; private set; }

        public IClaseGastoRepository ClaseGasto { get; private set; }

        public IProductoRepository Producto { get; private set; }

        public IProductoImpuestoRepository Producto_impuesto { get; private set; }
        
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
