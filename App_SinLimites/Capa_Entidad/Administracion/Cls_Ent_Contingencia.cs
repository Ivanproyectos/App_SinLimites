using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad.Administracion 
{
    public class Cls_Ent_Contingencia : Base.Cls_Ent_Base
    {

        public int ID_CONTINGENCIA { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public int ID_TIPO_DOCUMENTO { get; set; }
        public string CARGO { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string DESC_TIPO_DOCUMENTO { get; set; }
        public string NOMBRES_APE { get; set; }


    }
}
