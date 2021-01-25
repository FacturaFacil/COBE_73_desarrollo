using Admin.AccesoDatos.Data.Repository.IINV;
using Admin.AccesoDatos.Data.Repository.INV;
using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository.INV
{
    public class ClaseGastoRepository : Repository<Tbl_INV_CLASESGASTOS>, IClaseGastoRepository
    {
        private readonly Admin_SISContext  _db;

        public ClaseGastoRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaClaseGastos(decimal id_dist)
        {
            return _db.Tbl_INV_CLASESGASTOS.Where(x => x.Id_Dist == id_dist).Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }
        public void Update(Tbl_INV_CLASESGASTOS obj)
        {
            var objDesdeDb = _db.Tbl_INV_CLASESGASTOS.FirstOrDefault(s => s.Id_Dist == obj.Id_Dist && s.Id == obj.Id);
            objDesdeDb.Descripcion = obj.Descripcion;
            objDesdeDb.Predefinido = obj.Predefinido;
            objDesdeDb.Activo = obj.Activo;

            _db.SaveChanges();
        }
        public void UpdatePredeterminado(decimal id_dist , int id_clase_gasto)
        {
            var commandText = "UPDATE Tbl_INV_CLASESGASTOS  SET predefinido=0 where id_dist = @id_dist AND id <>  @id_clase_gasto";            
            var Param = new SqlParameter("@id_dist", id_dist);
            var Param2 = new SqlParameter("@id_clase_gasto", id_clase_gasto);
           
            var objDesdeDb = _db.Database.ExecuteSqlRaw(commandText, parameters: new[] { Param, Param2 });
            ///////Prueba subida

            _db.SaveChanges();
        }
       
    }
}
