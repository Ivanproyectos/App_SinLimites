using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_SinLimites.Areas.Administracion.Controllers
{
    public class PruebaController : Controller
    {
        //
        // GET: /Administracion/Prueba/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Ventas_Paginado(Recursos.Paginacion.GridTable grid)
        {
             try{


                 var jsonResult = Json(null, JsonRequestBehavior.AllowGet);
                 jsonResult.MaxJsonLength = int.MaxValue;
                 return jsonResult;
            }
            catch (Exception ex)
            {
                // Recursos.Clases.Css_Log.Guardar(ex.ToString());
                //string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                //auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                return null;
            }
        }



    }
}
