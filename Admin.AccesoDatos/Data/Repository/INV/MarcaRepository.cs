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
    public class MarcaRepository : Repository<Tbl_INV_MARCAS>, IMarcaRepository
    {
        private readonly Admin_SISContext  _db;

        public MarcaRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaMarcas(decimal id_dist)
        {
           
            return _db.Tbl_INV_MARCAS.Where(x => x.id_dist == id_dist).Select(i => new SelectListItem()
            {
                Text = i.descripcion ,
                Value = i.id.ToString()
            });
        }

        public void Update(Tbl_INV_MARCAS marca)
        {
            var objDesdeDb = _db.Tbl_INV_MARCAS.FirstOrDefault(s => s.id_dist == marca.id_dist && s.id == marca.id);
            objDesdeDb.descripcion = marca.descripcion;
            objDesdeDb.activo = marca.activo;
            _db.SaveChanges();
        }
    }
}
