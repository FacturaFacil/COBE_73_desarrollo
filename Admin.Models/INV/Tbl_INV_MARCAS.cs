using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public class Tbl_INV_MARCAS
    {
        //public TblInvMarcas()
        //{
        //    TblInvProductos = new HashSet<TblInvProductos>();
        //    TblInvProductosResp = new HashSet<TblInvProductosResp>();
        //}

        [Key]
        [Column(Order = 1)]
        public decimal id_dist { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "El campo clave es requerido.")]
        [Display(Name = "Clave")]
        public int id { get; set; }

        [Required(ErrorMessage = "El campo descripción es requerido.")]
        [Display(Name = "Descripción de la marca")]
        public string descripcion { get; set; }
        public bool activo { get; set; }

        //public virtual TblGenDistribuidores IdDistNavigation { get; set; }
        //public virtual ICollection<TblInvProductos> TblInvProductos { get; set; }
        //public virtual ICollection<TblInvProductosResp> TblInvProductosResp { get; set; }
    }
}
