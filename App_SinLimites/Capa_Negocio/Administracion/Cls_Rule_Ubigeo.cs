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
   public class Cls_Rule_Ubigeo
    {
       private Cls_Dat_Ubigeo OData = new Cls_Dat_Ubigeo();

       public List<Cls_Ent_Ubigeo> Ubigeo_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int START, string @WHERE, ref Cls_Ent_Auditoria auditoria)
       {
           try
           {
               return OData.Ubigeo_Paginado(ORDEN_COLUMNA, ORDEN, FILAS, START, @WHERE, ref auditoria);
           }
           catch (Exception ex)
           {
               auditoria.Error(ex);
               return new List<Cls_Ent_Ubigeo>();
           }
       }

    }
}
