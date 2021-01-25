using Admin.AccesoDatos.Data.Repository.IGEN;
using Admin.AccesoDatos.Data.Repository.IINV;
using Admin.AccesoDatos.Data.Repository.INV;
using Admin.Models;
using Admin.Models.GEN;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.GEN
{
    public class AlmacenRepository : Repository<Tbl_INV_ALMACENES>, IAlmacenRepository
    {
        private readonly Admin_SISContext  _db;

        public AlmacenRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaAlmacenes(decimal id_dist)
        {
            return _db.Tbl_INV_ALMACENES.Where(x=> x.Id_Dist == id_dist).Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public void Update(Tbl_INV_ALMACENES almacen)
        {
            var objDesdeDb = _db.Tbl_INV_ALMACENES.FirstOrDefault(s => s.Id == almacen.Id && s.Id_Dist == almacen.Id_Dist);
            objDesdeDb.Descripcion = almacen.Descripcion;
            objDesdeDb.Id_Sucursal = almacen.Id_Sucursal;
            objDesdeDb.Predeterminado = almacen.Predeterminado;
            objDesdeDb.Activo = almacen.Activo;
            
            _db.SaveChanges();
        }
    }
}
