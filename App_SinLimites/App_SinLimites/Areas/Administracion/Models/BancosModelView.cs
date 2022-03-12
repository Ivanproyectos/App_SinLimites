using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App_SinLimites.Areas.Administracion.Models
{
    public class BancosModelView
    {
        public int ID_BANCO { get; set; }

        [Display(Name = "Banco: ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Banco] es obligatorio")]
        public string DESC_BANCO { get; set; }

        public string Accion { get; set; }

    }
}