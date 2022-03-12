using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capa_Entidad;
using Capa_Entidad.Administracion;
using Capa_Negocio.Administracion;
namespace App_SinLimites.Areas.Administracion.Repositorio
{
    public class BancoRepositorio : IDisposable
    {

        private Cls_Rule_Banco _rule = new Cls_Rule_Banco();

        public List<Cls_Ent_Banco> Banco_Listar(Cls_Ent_Banco entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return _rule.Banco_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<Cls_Ent_Banco>();
            }
        }

        public Cls_Ent_Banco Banco_Listar_Uno(Cls_Ent_Banco entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return _rule.Banco_Listar_Uno(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new Cls_Ent_Banco();
            }
        }



        public void Banco_Insertar(Cls_Ent_Banco entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                _rule.Banco_Insertar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

        public void Banco_Actualizar(Cls_Ent_Banco entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                _rule.Banco_Actualizar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

        public void Banco_Estado(Cls_Ent_Banco entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                _rule.Banco_Estado(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }


        public void Banco_Eliminar(Cls_Ent_Banco entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                _rule.Banco_Eliminar(entidad, ref auditoria);
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