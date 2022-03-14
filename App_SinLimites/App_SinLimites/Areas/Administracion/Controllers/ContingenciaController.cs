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
    public class ContingenciaController : Controller
    {
        //
        // GET: /Administracion/Contingencia/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Contingencia_Listar(Cls_Ent_Contingencia entidad)
        {
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            try
            {
                using (ContingenciaRepositorio repositorio = new ContingenciaRepositorio())
                {
                    auditoria.OBJETO = repositorio.Contingencia_Listar(entidad, ref auditoria);
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
            ContingenciasModelView model = new ContingenciasModelView();
            model.Accion = Accion;
            model.ID_CONTINGENCIA = id;


            using (CombosRepositorio RepositorioUbigeo = new CombosRepositorio())
            {
                model.Lista_Tipo_Documento = RepositorioUbigeo.Tipo_Documento_Listar(ref auditoria).Where(t => t.ID_TIPO_DOCUMENTO != 6).Select(x => new SelectListItem()
                {
                    Text = x.DESC_TIPO_DOCUMENTO,
                    Value = x.ID_TIPO_DOCUMENTO.ToString()
                }).ToList();
                model.Lista_Tipo_Documento.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });
            }

            if (Accion == "M")
            {
                using (ContingenciaRepositorio repositorioContingencia = new ContingenciaRepositorio())
                {
                    Cls_Ent_Contingencia entidad = new Cls_Ent_Contingencia();
                    auditoria = new Capa_Entidad.Cls_Ent_Auditoria();
                    Cls_Ent_Contingencia lista = new Cls_Ent_Contingencia();
                    entidad.ID_CONTINGENCIA = id;
                    lista = repositorioContingencia.Contingencia_Listar_Uno(entidad, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                        auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                    }
                    else
                    {
                        model.ID_CONTINGENCIA = lista.ID_CONTINGENCIA;
                        model.ID_TIPO_DOCUMENTO = lista.ID_TIPO_DOCUMENTO;
                        model.NUMERO_DOCUMENTO = lista.NUMERO_DOCUMENTO;
                        model.NOMBRE = lista.NOMBRE;
                        model.APELLIDO_PATERNO = lista.APELLIDO_PATERNO;
                        model.APELLIDO_MATERNO = lista.APELLIDO_MATERNO;
                        model.CORREO = lista.CORREO;
                        model.TELEFONO = lista.TELEFONO;
                        model.CARGO = lista.CARGO;
     
                    }
                }
            }
            return View(model);
        }

        public ActionResult Contingencia_Insertar(Cls_Ent_Contingencia entidad)
        {
            Capa_Entidad.Cls_Ent_Auditoria auditoria = new Capa_Entidad.Cls_Ent_Auditoria();
            var ip_local = Recursos.Clases.Css_IP.ObtenerIp();
            using (ContingenciaRepositorio Contingenciarepositorio = new ContingenciaRepositorio())
            {
                entidad.IP_CREACION = ip_local;
                Contingenciarepositorio.Contingencia_Insertar(entidad, ref auditoria);

                if (!auditoria.EJECUCION_PROCEDIMIENTO)
                {
                    string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                    auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                }
            }
            return Json(auditoria, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contingencia_Actualizar(Cls_Ent_Contingencia entidad)
        {
            Capa_Entidad.Cls_Ent_Auditoria auditoria = new Capa_Entidad.Cls_Ent_Auditoria();
            var ip_local = Recursos.Clases.Css_IP.ObtenerIp();
            using (ContingenciaRepositorio Contingenciarepositorio = new ContingenciaRepositorio())
            {
                entidad.IP_MODIFICACION = ip_local;
                Contingenciarepositorio.Contingencia_Actualizar(entidad, ref auditoria);

                if (!auditoria.EJECUCION_PROCEDIMIENTO)
                {
                    string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                    auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                }
            }
            return Json(auditoria, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contingencia_Eliminar(Cls_Ent_Contingencia entidad)
        {
            Capa_Entidad.Cls_Ent_Auditoria auditoria = new Capa_Entidad.Cls_Ent_Auditoria();
            using (ContingenciaRepositorio Contingenciarepositorio = new ContingenciaRepositorio())
            {
                Contingenciarepositorio.Contingencia_Eliminar(entidad, ref auditoria);
                if (!auditoria.EJECUCION_PROCEDIMIENTO)
                {
                    string CodigoLog = Recursos.Clases.Css_Log.Guardar(auditoria.ERROR_LOG);
                    auditoria.MENSAJE_SALIDA = Recursos.Clases.Css_Log.Mensaje(CodigoLog);
                }
            }
            return Json(auditoria, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contingencia_Estado(Cls_Ent_Contingencia entidad)
        {
            Capa_Entidad.Cls_Ent_Auditoria auditoria = new Capa_Entidad.Cls_Ent_Auditoria();
            var ip_local = Recursos.Clases.Css_IP.ObtenerIp();
            using (ContingenciaRepositorio Contingenciarepositorio = new ContingenciaRepositorio())
            {
                entidad.IP_MODIFICACION = ip_local;
                Contingenciarepositorio.Contingencia_Estado(entidad, ref auditoria);

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
