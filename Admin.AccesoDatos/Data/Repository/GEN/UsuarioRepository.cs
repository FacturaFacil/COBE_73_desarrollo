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
    public class UsuarioRepository : Repository<Tbl_GEN_USUARIOS>, IUsuarioRepository
    {
        private readonly Admin_SISContext  _db;

        public UsuarioRepository(Admin_SISContext db) :base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaUsuarios(decimal id_dist)
        {
            return _db.tbl_GEN_USUARIOS.Select(i => new SelectListItem()
            {
                Text = i.Username,
                Value = i.Id.ToString()
            });
        }

        public void Update(Tbl_GEN_USUARIOS usuario)
        {
            var objDesdeDb = _db.tbl_GEN_USUARIOS.FirstOrDefault(s => s.Id == usuario.Id && s.Id_Dist == usuario.Id_Dist);
            objDesdeDb.Username =    usuario.Username;
            if (usuario.Password != "12342343")
            {
                objDesdeDb.Password = usuario.Password;
                objDesdeDb.Confirm_Password = usuario.Confirm_Password;
            }           
            objDesdeDb.Foto_Url = usuario.Foto_Url;
            objDesdeDb.Nombre = usuario.Nombre;
            objDesdeDb.Ap_Paterno = usuario.Ap_Paterno;
            objDesdeDb.Ap_Materno = usuario.Ap_Materno;
            objDesdeDb.Tel_Casa = usuario.Tel_Casa;
            objDesdeDb.Tel_Cel = usuario.Tel_Cel;


            objDesdeDb.Curp = usuario.Curp;
            objDesdeDb.Rfc = usuario.Rfc;
            objDesdeDb.email = usuario.email;
            objDesdeDb.Calle = usuario.Calle;
            objDesdeDb.Num_Ext = usuario.Num_Ext;
            objDesdeDb.Num_Int = usuario.Num_Int;

            objDesdeDb.Colonia = usuario.Colonia;
            objDesdeDb.Ciudad = usuario.Ciudad;
            objDesdeDb.Municipio = usuario.Municipio;
            objDesdeDb.Estado = usuario.Estado;
            objDesdeDb.Activo = usuario.Activo;
            objDesdeDb.Pais = usuario.Pais;
            //objDesdeDb.descripcion = marca.descripcion;
            //objDesdeDb.activo = marca.activo;
            _db.SaveChanges();
        }
    }
}
