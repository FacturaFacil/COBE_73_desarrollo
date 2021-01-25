using Admin.AccesoDatos.Data.Repository.IGEN;
using Admin.AccesoDatos.Data.Repository.IINV;
using Admin.AccesoDatos.Data.Repository.INV;
using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.GEN
{
    public class MenuRepository : Repository<Tbl_GEN_MENU>, IMenuRepository
    {
        private readonly Admin_SISContext  _db;

        public MenuRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaMenu()
        {
            return _db.Tbl_INV_MARCAS.Select(i => new SelectListItem()
            {
                Text = i.descripcion ,
                Value = i.id.ToString()
            });
        }

        public void Update(Tbl_GEN_MENU menu)
        {
            var objDesdeDb = _db.Tbl_GEN_MENU.FirstOrDefault(s => s.Id == menu.Id);
            //objDesdeDb.descripcion = marca.descripcion;
            //objDesdeDb.activo = marca.activo;
            _db.SaveChanges();
        }
    }
}
