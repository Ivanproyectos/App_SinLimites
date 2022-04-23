using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using Capa_Entidad.Administracion; 
using App_SinLimites.Areas.Administracion.Repositorio; 

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
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
             try{
                   //grid.page = (grid.page == 0) ? 1 : grid.page;
                grid.rows = (grid.rows == 0) ? 100 : grid.rows;

                var @where = (Recursos.Paginacion.Css_Paginacion.GetWhere(grid.filters, grid.rules));
                if (!string.IsNullOrEmpty(@where))
                {
                    //grid._search = true;
                    if (!string.IsNullOrEmpty(grid.searchString))
                    {
                        @where = @where + " and ";
                    }
                }
                else
                {
                    @where = @where + " 1=1 ";
                }

                using (UbigeoRepsotorio repositorio = new UbigeoRepsotorio())
                {
                    IList<Cls_Ent_Ubigeo> lista = repositorio.Ubigeo_Paginado(grid.sidx, grid.sord, grid.rows, grid.start, @where, ref auditoria);
                    if (auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        var generic = Recursos.Paginacion.Css_Paginacion.BuscarPaginador(grid.draw, (int)auditoria.OBJETO, lista);
                        generic.Value.data = generic.List; 
                        var jsonResult = Json(generic.Value, JsonRequestBehavior.AllowGet);
                        jsonResult.MaxJsonLength = int.MaxValue;
                        return jsonResult;
                    }
                    else
                    {
                        string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                        auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                        return null;
                    }

                }
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
