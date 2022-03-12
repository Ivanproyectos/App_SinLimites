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
    public class Cls_Rule_Banco
    {

        private Cls_Dat_Banco OData = new Cls_Dat_Banco();

        public List<Cls_Ent_Banco> Banco_Listar(Cls_Ent_Banco entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return OData.Banco_Listar(entidad, ref auditoria);
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
                return OData.Banco_Listar_Uno(entidad, ref auditoria);
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
                OData.Banco_Insertar(entidad, ref auditoria);
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
                OData.Banco_Actualizar(entidad, ref auditoria);
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
                OData.Banco_Estado(entidad, ref auditoria);
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
                OData.Banco_Eliminar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

    }
}
