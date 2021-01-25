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
    public class SucursalRepository : Repository<Tbl_GEN_SUCURSALES>, ISucursalRepository
    {
        private readonly Admin_SISContext  _db;

        public SucursalRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaSucursales(decimal id_dist)
        {
            return _db.tbl_GEN_SUCURSALES.Where(x => x.Id_Dist == id_dist).Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public void Update(Tbl_GEN_SUCURSALES sucursal)
        {
            var objDesdeDb = _db.tbl_GEN_SUCURSALES.FirstOrDefault(s => s.Id == sucursal.Id && s.Id_Dist == sucursal.Id_Dist);
            objDesdeDb.Descripcion = sucursal.Descripcion;
            objDesdeDb.Calle = sucursal.Calle;
            objDesdeDb.Numero_Exterior = sucursal.Numero_Exterior;
            objDesdeDb.Numero_Interior = sucursal.Numero_Interior;
            objDesdeDb.Pais = sucursal.Pais;
            objDesdeDb.Estado = sucursal.Estado;
            objDesdeDb.Municipio_Deleg = sucursal.Municipio_Deleg;
            objDesdeDb.Ciudad = sucursal.Ciudad;
            objDesdeDb.Colonia = sucursal.Colonia;
            objDesdeDb.Cp = sucursal.Cp;
            objDesdeDb.Direccion = sucursal.Direccion;
            objDesdeDb.Matriz_Sucursal = sucursal.Matriz_Sucursal;
            objDesdeDb.Responsable = sucursal.Desc_Corta;
            objDesdeDb.Telefonos = sucursal.Telefonos;
            objDesdeDb.Calle_Y_Numero = sucursal.Calle_Y_Numero;
            objDesdeDb.Email = sucursal.Email;
            objDesdeDb.Activo = sucursal.Activo;
            objDesdeDb.Rfc = sucursal.Rfc;
            _db.SaveChanges();
        }
    }
}
