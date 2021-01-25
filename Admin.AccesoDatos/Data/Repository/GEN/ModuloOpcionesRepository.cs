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
    public class ModuloOpcionesRepository : Repository<Tbl_GEN_MODULOS_OPCIONES>, IModuloOpcionesRepository
    {
        private readonly Admin_SISContext  _db;

        public ModuloOpcionesRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaModulosOpciones()
        {
            return _db.Tbl_GEN_MODULOS_OPCIONES.Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public void Update(Tbl_GEN_MODULOS_OPCIONES moduloOpciones)
        {
            var objDesdeDb = _db.Tbl_GEN_MODULOS_OPCIONES.FirstOrDefault(s => s.Id == moduloOpciones.Id && s.Id_Modulo == moduloOpciones.Id_Modulo);
            objDesdeDb.Descripcion = moduloOpciones.Descripcion;
            objDesdeDb.Activo = moduloOpciones.Activo;
            objDesdeDb.Tipo = moduloOpciones.Tipo;
            //objDesdeDb.Activo = rol.Activo;
            //objDesdeDb.Numero_Exterior = sucursal.Numero_Exterior;

            _db.SaveChanges();
        }
    }
}
