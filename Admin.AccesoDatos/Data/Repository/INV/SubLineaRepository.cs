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
    public class SubLineaRepository : Repository<Tbl_INV_SUBLINEAS>, ISubLineaRepository
    {
        private readonly Admin_SISContext  _db;

        public SubLineaRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaSubLineas(decimal id_dist, int id_linea)
        {
            return _db.Tbl_INV_SUBLINEAS.Where(x => x.Id_Dist == id_dist && x.Id_Linea == id_linea).Select(i => new SelectListItem()
            {
                Text = i.Descripcion ,
                Value = i.Id.ToString()
            });
        }

        public void Update(Tbl_INV_SUBLINEAS sublinea)
        {
            var objDesdeDb = _db.Tbl_INV_SUBLINEAS.FirstOrDefault(s => s.Id_Dist == sublinea.Id_Dist && s.Id == sublinea.Id && s.Id_Linea == sublinea.Id_Linea);
            objDesdeDb.Descripcion = sublinea.Descripcion;
            objDesdeDb.Activo = sublinea.Activo;
            _db.SaveChanges();
        }
    }
}
