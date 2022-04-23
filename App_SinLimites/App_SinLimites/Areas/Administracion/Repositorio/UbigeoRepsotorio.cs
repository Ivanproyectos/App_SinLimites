using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capa_Entidad;
using Capa_Entidad.Administracion;
using Capa_Negocio.Administracion;

namespace App_SinLimites.Areas.Administracion.Repositorio
{
    public class UbigeoRepsotorio : IDisposable
    {
        private Cls_Rule_Ubigeo _rule = new Cls_Rule_Ubigeo();

        public List<Cls_Ent_Ubigeo> Ubigeo_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int START, string @WHERE, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return _rule.Ubigeo_Paginado(ORDEN_COLUMNA, ORDEN, FILAS, START, @WHERE, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<Cls_Ent_Ubigeo>();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}