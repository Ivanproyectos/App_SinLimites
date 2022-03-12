using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using App_SinLimites.Areas.Administracion.Models;
using Capa_Entidad.Base;
using Capa_Entidad.Administracion;
using App_SinLimites.Areas.Administracion.Repositorio;
using App_SinLimites.Areas.Combos.Repositorio;
using App_SinLimites.Recursos;
namespace App_SinLimites.Areas.Administracion.Controllers
{
    public class BancoController : Controller
    {
        //
        // GET: /Administracion/Banco/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Banco_Listar(Cls_Ent_Banco entidad)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            try
            {
                using (BancoRepositorio repositorio = new BancoRepositorio())
                {
                    auditoria.OBJETO = repositorio.Banco_Listar(entidad, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                        auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
            }
            return Json(auditoria, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Mantenimiento(int id, string Accion)
        {

            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            BancosModelView model = new BancosModelView();
            model.Accion = Accion;
            model.ID_BANCO = id;



            if (Accion == "M")
            {
                using (BancoRepositorio repositorioBanco = new BancoRepositorio())
                {
                    Cls_Ent_Banco entidad = new Cls_Ent_Banco();
                    auditoria = new Capa_Entidad.Cls_Ent_Auditoria();
                    Cls_Ent_Banco lista = new Cls_Ent_Banco();
                    entidad.ID_BANCO = id;
                    lista = repositorioBanco.Banco_Listar_Uno(entidad, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                        auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                    }
                    else
                    {
                        model.ID_BANCO = lista.ID_BANCO;
                        model.DESC_BANCO = lista.DESC_BANCO;
                  
                    }
                }
            }
            return View(model);
        }

        public ActionResult Banco_Insertar(Cls_Ent_Banco entidad)
        {
            Capa_Entidad.Cls_Ent_Auditoria auditoria = new Capa_Entidad.Cls_Ent_Auditoria();
            var ip_local = Recursos.Clases.Css_IP.ObtenerIp();
            using (BancoRepositorio Bancorepositorio = new BancoRepositorio())
            {
                entidad.IP_CREACION = ip_local;
                Bancorepositorio.Banco_Insertar(entidad, ref auditoria);

                if (!auditoria.EJECUCION_PROCEDIMIENTO)
                {
                    string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                    auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                }
            }
            return Json(auditoria, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Banco_Actualizar(Cls_Ent_Banco entidad)
        {
            Capa_Entidad.Cls_Ent_Auditoria auditoria = new Capa_Entidad.Cls_Ent_Auditoria();
            var ip_local = Recursos.Clases.Css_IP.ObtenerIp();
            using (BancoRepositorio Bancorepositorio = new BancoRepositorio())
            {
                entidad.IP_MODIFICACION = ip_local;
                Bancorepositorio.Banco_Actualizar(entidad, ref auditoria);

                if (!auditoria.EJECUCION_PROCEDIMIENTO)
                {
                    string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                    auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                }
            }
            return Json(auditoria, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Banco_Eliminar(Cls_Ent_Banco entidad)
        {
            Capa_Entidad.Cls_Ent_Auditoria auditoria = new Capa_Entidad.Cls_Ent_Auditoria();
            using (BancoRepositorio Bancorepositorio = new BancoRepositorio())
            {
                Bancorepositorio.Banco_Eliminar(entidad, ref auditoria);
                if (!auditoria.EJECUCION_PROCEDIMIENTO)
                {
                    string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                    auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                }
            }
            return Json(auditoria, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Banco_Estado(Cls_Ent_Banco entidad)
        {
            Capa_Entidad.Cls_Ent_Auditoria auditoria = new Capa_Entidad.Cls_Ent_Auditoria();
            var ip_local = Recursos.Clases.Css_IP.ObtenerIp();
            using (BancoRepositorio Bancorepositorio = new BancoRepositorio())
            {
                entidad.IP_MODIFICACION = ip_local;
                Bancorepositorio.Banco_Estado(entidad, ref auditoria);

                if (!auditoria.EJECUCION_PROCEDIMIENTO)
                {
                    string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                    auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                }
            }
            return Json(auditoria, JsonRequestBehavior.AllowGet);
        }


    }
}
