using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Entidad.Administracion;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Capa_Datos.Administracion
{
    public class Cls_Dat_Ubigeo : Protected.DataBaseHelper
    {


        ///*********************************************** ----------------- **************************************************/

        ///*********************************************** Lista usuarios paginado *************************************************/

        public List<Cls_Ent_Ubigeo> Ubigeo_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int START, string @WHERE, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<Cls_Ent_Ubigeo> lista = new List<Cls_Ent_Ubigeo>();
            using (SqlConnection cn = this.GetNewConnection())
            {
                SqlDataReader dr = null;
                SqlCommand cmd = new SqlCommand("USP_PRUEBA_UBIGEO_PAGINACION", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PI_NROREGISTROS", SqlDbType.Int)).Value = FILAS;
                cmd.Parameters.Add(new SqlParameter("@PI_START", SqlDbType.Int)).Value = START;
                cmd.Parameters.Add(new SqlParameter("@PI_ORDEN_COLUMNA", SqlDbType.VarChar, 100)).Value = ORDEN_COLUMNA;
                cmd.Parameters.Add(new SqlParameter("@PI_ORDEN", SqlDbType.VarChar, 100)).Value = ORDEN;
                cmd.Parameters.Add(new SqlParameter("@PI_WHERE", SqlDbType.VarChar, 1000)).Value = @WHERE;
                cmd.Parameters.Add(new SqlParameter("PO_CUENTA", SqlDbType.Int)).Direction = System.Data.ParameterDirection.Output;
                dr = cmd.ExecuteReader();
                int pos_COD_UBIGEO = dr.GetOrdinal("COD_UBIGEO");
                int pos_COD_UBIGEO_PADRE = dr.GetOrdinal("COD_UBIGEO_PADRE");
                int pos_DESC_UBIGEO = dr.GetOrdinal("DESC_UBIGEO");
                int pos_TIP_ZONA_GEO = dr.GetOrdinal("TIP_ZONA_GEO");
                int pos_FLG_ESTADO = dr.GetOrdinal("FLG_ESTADO");
       

                if (dr.HasRows)
                {
                    Cls_Ent_Ubigeo obj = null;
                    int FILA = 0;
                    while (dr.Read())
                    {
                        obj = new Cls_Ent_Ubigeo();
                        obj.FILA = FILA++;

                        if (dr.IsDBNull(pos_COD_UBIGEO)) obj.COD_UBIGEO = "";
                        else obj.COD_UBIGEO = dr.GetString(pos_COD_UBIGEO);

                        if (dr.IsDBNull(pos_COD_UBIGEO_PADRE)) obj.COD_UBIGEO_PADRE = "";
                        else obj.COD_UBIGEO_PADRE = dr.GetString(pos_COD_UBIGEO_PADRE);

                        if (dr.IsDBNull(pos_DESC_UBIGEO)) obj.DESC_UBIGEO = "";
                        else obj.DESC_UBIGEO = dr.GetString(pos_DESC_UBIGEO);

                        if (dr.IsDBNull(pos_TIP_ZONA_GEO)) obj.TIP_ZONA_GEO = "";
                        else obj.TIP_ZONA_GEO = dr.GetString(pos_TIP_ZONA_GEO);


                        lista.Add(obj);
                    }
                }
                dr.Close();
                int CUENTA = int.Parse(cmd.Parameters["PO_CUENTA"].Value.ToString());
                auditoria.OBJETO = CUENTA;
            }


            return lista;
        }


    }
}
