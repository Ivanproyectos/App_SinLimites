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


namespace Capa_Datos.Combos
{
    public class Cls_Dat_Combos : Protected.DataBaseHelper
    {

        ///*********************************************** ----------------- **************************************************/

        ///*********************************************** Lista tipo documento *************************************************/
        ///
        public List<Cls_Ent_Tipo_Documento> Tipo_Documento_Listar(ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<Cls_Ent_Tipo_Documento> lista = new List<Cls_Ent_Tipo_Documento>();
            try
            {
                using (SqlConnection cn = this.GetNewConnection())
                {
                    SqlDataReader dr = null;
                    SqlCommand cmd = new SqlCommand("USP_CONS_TIPO_DOCUMENTO_LISTAR", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();
                    int pos_ID_TIPO_DOCUMENTO = dr.GetOrdinal("ID_TIPO_DOCUMENTO");
                    int pos_DESC_TIPO_DOCUMENTO = dr.GetOrdinal("DESC_TIPO_DOCUMENTO");

                    if (dr.HasRows)
                    {
                        Cls_Ent_Tipo_Documento obj = null;
                        while (dr.Read())
                        {
                            obj = new Cls_Ent_Tipo_Documento();
                            if (dr.IsDBNull(pos_ID_TIPO_DOCUMENTO)) obj.ID_TIPO_DOCUMENTO = 0;
                            else obj.ID_TIPO_DOCUMENTO = int.Parse(dr[pos_ID_TIPO_DOCUMENTO].ToString());
                            if (dr.IsDBNull(pos_DESC_TIPO_DOCUMENTO)) obj.DESC_TIPO_DOCUMENTO = "";
                            else obj.DESC_TIPO_DOCUMENTO = dr.GetString(pos_DESC_TIPO_DOCUMENTO);
                            lista.Add(obj);
                        }
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }


        ///*********************************************** ----------------- **************************************************/

        ///*********************************************** Lista los  cargo *************************************************/

        public List<Cls_Ent_Perfil> Perfil_Listar( ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<Cls_Ent_Perfil> lista = new List<Cls_Ent_Perfil>();
            try
            {
                using (SqlConnection cn = this.GetNewConnection())
                {
                    SqlDataReader dr = null;
                    SqlCommand cmd = new SqlCommand("USP_ADMIN_PERFIL_LISTAR", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                    dr = cmd.ExecuteReader();
                    int pos_ID_PERFIL = dr.GetOrdinal("ID_PERFIL");
                    int pos_DESC_PERFIL = dr.GetOrdinal("DESC_PERFIL");
                    int pos_FLG_ESTADO = dr.GetOrdinal("FLG_ESTADO");
                    int pos_USU_CREACION = dr.GetOrdinal("USU_CREACION");
                    int pos_FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int pos_USU_MODIFICACION = dr.GetOrdinal("USU_MODIFICACION");
                    int pos_FEC_MODIFICACION = dr.GetOrdinal("FECHA_MODIFICACION");
                    if (dr.HasRows)
                    {
                        Cls_Ent_Perfil obj = null;
                        while (dr.Read())
                        {
                            obj = new Cls_Ent_Perfil();
                            if (dr.IsDBNull(pos_ID_PERFIL)) obj.ID_PERFIL = 0;
                            else obj.ID_PERFIL = int.Parse(dr[pos_ID_PERFIL].ToString());
                            if (dr.IsDBNull(pos_DESC_PERFIL)) obj.DESC_PERFIL = "";
                            else obj.DESC_PERFIL = dr.GetString(pos_DESC_PERFIL);


                            if (dr.IsDBNull(pos_FLG_ESTADO)) obj.FLG_ESTADO = 0;
                            else obj.FLG_ESTADO = int.Parse(dr[pos_FLG_ESTADO].ToString());
                            if (dr.IsDBNull(pos_USU_CREACION)) obj.USU_CREACION = "";
                            else obj.USU_CREACION = dr.GetString(pos_USU_CREACION);
                            if (dr.IsDBNull(pos_FECHA_CREACION)) obj.FEC_CREACION = "";
                            else obj.FEC_CREACION = dr.GetString(pos_FECHA_CREACION);
                            if (dr.IsDBNull(pos_USU_MODIFICACION)) obj.USU_MODIFICACION = "";
                            else obj.USU_MODIFICACION = dr.GetString(pos_USU_MODIFICACION);
                            if (dr.IsDBNull(pos_FEC_MODIFICACION)) obj.FEC_MODIFICACION = "";
                            else obj.FEC_MODIFICACION = dr.GetString(pos_FEC_MODIFICACION);

                            lista.Add(obj);
                        }
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }




    }
}
