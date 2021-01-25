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
    public class DistribuidorRepository : Repository<Tbl_GEN_DISTRIBUIDORES>, IDistribuidorRepository
    {
        private readonly Admin_SISContext  _db;

        public DistribuidorRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaDistribuidores()
        {
            return _db.Tbl_GEN_DISTRIBUIDORES.Select(i => new SelectListItem()
            {
                Text = i.Razon_Social,
                Value = i.Id.ToString()
            });
        }

        public void Update(Tbl_GEN_DISTRIBUIDORES distribuidor)
        {
            var objDesdeDb = _db.Tbl_GEN_DISTRIBUIDORES.FirstOrDefault(s => s.Id == distribuidor.Id);
            //objDesdeDb.descripcion = marca.descripcion;
            //objDesdeDb.activo = marca.activo;
            _db.SaveChanges();
        }
    }
}
