using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Entidad.Administracion;
using Capa_Datos.Administracion;

namespace Capa_Negocio.Administracion
{
    public class Cls_Rule_Contingencia
    {

        private Cls_Dat_Contingencia OData = new Cls_Dat_Contingencia();

        public List<Cls_Ent_Contingencia> Contingencia_Listar(Cls_Ent_Contingencia entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return OData.Contingencia_Listar(entidad, ref auditoria);
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
                return OData.Contingencia_Listar_Uno(entidad, ref auditoria);
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
                OData.Contingencia_Insertar(entidad, ref auditoria);
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
                OData.Contingencia_Actualizar(entidad, ref auditoria);
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
                OData.Contingencia_Estado(entidad, ref auditoria);
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
                OData.Contingencia_Eliminar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

    }
}
