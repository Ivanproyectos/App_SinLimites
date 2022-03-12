using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capa_Entidad;
using Capa_Entidad.Administracion;
using Capa_Negocio.Combos;
namespace App_SinLimites.Areas.Combos.Repositorio
{
    public class CombosRepositorio : IDisposable
    {
        private Cls_Rule_Combos _rule = new Cls_Rule_Combos();

        public List<Cls_Ent_Tipo_Documento> Tipo_Documento_Listar(ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return _rule.Tipo_Documento_Listar( ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<Cls_Ent_Tipo_Documento>();
            }
        }

        public List<Cls_Ent_Perfil> Perfil_Listar(ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return _rule.Perfil_Listar(ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<Cls_Ent_Perfil>();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}