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
    public class ModuloRepository : Repository<Tbl_GEN_MODULOS>, IModuloRepository
    {
        private readonly Admin_SISContext  _db;

        public ModuloRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaModulos()
        {
            return _db.Tbl_GEN_MODULOS.Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public void Update(Tbl_GEN_MODULOS modulo)
        {
            var objDesdeDb = _db.Tbl_GEN_MODULOS.FirstOrDefault(s => s.Id == modulo.Id);
            objDesdeDb.Descripcion  = modulo.Descripcion;
            objDesdeDb.Referencia = modulo.Referencia;
            objDesdeDb.Activo = modulo.Activo;
            //objDesdeDb.Numero_Exterior = sucursal.Numero_Exterior;
            
            _db.SaveChanges();
        }
    }
}
