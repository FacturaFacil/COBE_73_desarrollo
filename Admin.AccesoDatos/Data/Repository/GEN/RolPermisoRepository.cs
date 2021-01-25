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
    public class RolPermisoRepository : Repository<Tbl_GEN_ROLES_PERMISOS>, IRolPermisoRepository
    {
        private readonly Admin_SISContext  _db;

        public RolPermisoRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaRolesPermisos(decimal id_dist)
        {
          
            return _db.Tbl_GEN_ROLES_PERMISOS.Where(x => x.Id_Dist == id_dist).Select(i => new SelectListItem()
            {
                Text = i.Id_Rol.ToString(),
                Value = i.Id_Opciones.ToString()
            });
        }

        public void Update(Tbl_GEN_ROLES_PERMISOS rolPermiso)
        {
            //var objDesdeDb = _db.Tbl_GEN_ROLES_PERMISOS.FirstOrDefault(s => s.Id == rol.Id && s.Id_Dist == rol.Id_Dist);
            //objDesdeDb.Rol = rol.Rol;
            //objDesdeDb.Descripcion = rol.Descripcion;
            //objDesdeDb.Activo = rol.Activo;
            //objDesdeDb.Numero_Exterior = sucursal.Numero_Exterior;
            
            _db.SaveChanges();
        }
    }
}
