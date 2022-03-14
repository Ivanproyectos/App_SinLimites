using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capa_Entidad;
using Capa_Entidad.Administracion;
using Capa_Negocio.Administracion;
namespace App_SinLimites.Areas.Administracion.Repositorio
{
    public class ContingenciaRepositorio : IDisposable
    {

        private Cls_Rule_Contingencia _rule = new Cls_Rule_Contingencia();

        public List<Cls_Ent_Contingencia> Contingencia_Listar(Cls_Ent_Contingencia entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return _rule.Contingencia_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<Cls_Ent_Contingencia>();
            }
        }

        public Cls_Ent_Contingencia Contingencia_Listar_Uno(Cls_Ent_Contingencia entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return _rule.Contingencia_Listar_Uno(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new Cls_Ent_Contingencia();
            }
        }



        public void Contingencia_Insertar(Cls_Ent_Contingencia entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                _rule.Contingencia_Insertar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

        public void Contingencia_Actualizar(Cls_Ent_Contingencia entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                _rule.Contingencia_Actualizar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

        public void Contingencia_Estado(Cls_Ent_Contingencia entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                _rule.Contingencia_Estado(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }


        public void Contingencia_Eliminar(Cls_Ent_Contingencia entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                _rule.Contingencia_Eliminar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}