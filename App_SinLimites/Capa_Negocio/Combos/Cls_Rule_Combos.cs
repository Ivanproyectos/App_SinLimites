using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Entidad.Administracion;
using Capa_Datos.Combos;
namespace Capa_Negocio.Combos
{
   public  class Cls_Rule_Combos
    {
       private Cls_Dat_Combos OData = new Cls_Dat_Combos();

       public List<Cls_Ent_Tipo_Documento> Tipo_Documento_Listar( ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return OData.Tipo_Documento_Listar( ref auditoria);
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
               return OData.Perfil_Listar(ref auditoria);
           }
           catch (Exception ex)
           {
               auditoria.Error(ex);
               return new List<Cls_Ent_Perfil>();
           }
       }



    }
}
