using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace App_SinLimites.Areas.Administracion.Models
{
    public class ContingenciasModelView
    {
        public int ID_CONTINGENCIA { get; set; }

        [Display(Name = "Número Documento: ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Número Documento] es obligatorio")]
        public string NUMERO_DOCUMENTO { get; set; }

        [Display(Name = "Nombre: ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Nombre] es obligatorio")]
        public string NOMBRE { get; set; }

        [Display(Name = "Apellido Paterno: ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Apellido Paterno] es obligatorio")]
        public string APELLIDO_PATERNO { get; set; }

        [Display(Name = "Apellido Materno: ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Apellido Materno] es obligatorio")]
        public string APELLIDO_MATERNO { get; set; }


        [Display(Name = "Tipo Documento: ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Tipo Documento] es obligatorio")]
        public int ID_TIPO_DOCUMENTO { get; set; }
        public List<SelectListItem> Lista_Tipo_Documento { get; set; }




        [Display(Name = "Telefono: ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Telefono] es obligatorio")]
        public string TELEFONO { get; set; }

        [Display(Name = "Correo: ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Correo] es obligatorio")]
        public string CORREO { get; set; }



        [Display(Name = "Cargo: ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Cargo] es obligatorio")]
        public string CARGO { get; set; }



     



        public string Accion { get; set; }

    }
}