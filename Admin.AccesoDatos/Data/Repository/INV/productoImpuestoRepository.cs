using Admin.AccesoDatos.Data.Repository.IINV;
using Admin.AccesoDatos.Data.Repository.INV;
using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.INV
{
    public class ProductoImpuestoRepository : Repository<Tbl_INV_PRODUCTOS_IMPUESTOS>, IProductoImpuestoRepository
    {
        private readonly Admin_SISContext  _db;

        public ProductoImpuestoRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaProductoImpuestos(decimal id_dist)
        {
            return _db.Tbl_INV_PRODUCTOS_IMPUESTOS.Where(x => x.Id_Dist == id_dist).Select(i => new SelectListItem()
            {
                Text = i.Descripcion_Impuesto,
                Value = i.Id.ToString()
            });
        }
        public void Update(Tbl_INV_PRODUCTOS_IMPUESTOS producto_impuesto)
        {
            //var objDesdeDb = _db.Tbl_INV_PRODUCTOS_IMPUESTOS.FirstOrDefault(s => s.Id_Dist == linea.Id_Dist && s.Id == linea.Id);
            //objDesdeDb.Descripcion_Impuesto = linea.Descripcion;
            //objDesdeDb.Activo = linea.Activo;

            //_db.SaveChanges();
        }
    }
}
