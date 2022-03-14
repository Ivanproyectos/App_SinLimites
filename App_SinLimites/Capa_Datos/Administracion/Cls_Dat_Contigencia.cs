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
    public class Cls_Dat_Contingencia : Protected.DataBaseHelper
    {

      ///*********************************************** ----------------- **************************************************/

        ///*********************************************** Lista los  cargo *************************************************/

        public List<Cls_Ent_Contingencia> Contingencia_Listar(Cls_Ent_Contingencia entidad_param, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<Cls_Ent_Contingencia> lista = new List<Cls_Ent_Contingencia>();
            try
            {
                using (SqlConnection cn = this.GetNewConnection())
                {
                    SqlDataReader dr = null;
                    SqlCommand cmd = new SqlCommand("USP_ADMIN_CONTIGENCIA_LISTAR", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (entidad_param.NOMBRES_APE == null)
                    { cmd.Parameters.Add(new SqlParameter("@PI_NOMBRES_APE", SqlDbType.VarChar, 200)).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add(new SqlParameter("@PI_NOMBRES_APE", SqlDbType.VarChar, 200)).Value = entidad_param.NOMBRES_APE; }

                    if (entidad_param.NUMERO_DOCUMENTO == null)
                    { cmd.Parameters.Add(new SqlParameter("@PI_NUMERO_DOCUMENTO", SqlDbType.VarChar, 200)).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add(new SqlParameter("@PI_NUMERO_DOCUMENTO", SqlDbType.VarChar, 200)).Value = entidad_param.NUMERO_DOCUMENTO; }

                    if (entidad_param.FLG_ESTADO == 2)
                    { cmd.Parameters.Add(new SqlParameter("@PI_FLG_ESTADO", SqlDbType.Int)).Value = DBNull.Value; }
                    else
                    { cmd.Parameters.Add(new SqlParameter("@PI_FLG_ESTADO", SqlDbType.Int)).Value = entidad_param.FLG_ESTADO; }
                    dr = cmd.ExecuteReader();
                    int pos_ID_CONTINGENCIA = dr.GetOrdinal("ID_CONTINGENCIA");
                    int pos_NOMBRES_APE = dr.GetOrdinal("NOMBRES_APE");
                    int pos_NUMERO_DOCUMENTO = dr.GetOrdinal("NUMERO_DOCUMENTO");
                    int pos_ID_TIPO_DOCUMENTO = dr.GetOrdinal("ID_TIPO_DOCUMENTO");
                    int pos_CARGO = dr.GetOrdinal("CARGO");
                    int pos_TELEFONO = dr.GetOrdinal("TELEFONO");
                    int pos_CORREO = dr.GetOrdinal("CORREO");
                    int pos_DESC_TIPO_DOCUMENTO = dr.GetOrdinal("DESC_TIPO_DOCUMENTO");
                    int pos_FLG_ESTADO = dr.GetOrdinal("FLG_ESTADO");
                    int pos_USU_CREACION = dr.GetOrdinal("USU_CREACION");
                    int pos_FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int pos_USU_MODIFICACION = dr.GetOrdinal("USU_MODIFICACION");
                    int pos_FEC_MODIFICACION = dr.GetOrdinal("FECHA_MODIFICACION");
                    if (dr.HasRows)
                    {
                        Cls_Ent_Contingencia obj = null;
                        while (dr.Read())
                        {
                            obj = new Cls_Ent_Contingencia();
                            if (dr.IsDBNull(pos_ID_CONTINGENCIA)) obj.ID_CONTINGENCIA = 0;
                            else obj.ID_CONTINGENCIA = int.Parse(dr[pos_ID_CONTINGENCIA].ToString());

                            if (dr.IsDBNull(pos_NOMBRES_APE)) obj.NOMBRES_APE = "";
                            else obj.NOMBRES_APE = dr.GetString(pos_NOMBRES_APE);

                            if (dr.IsDBNull(pos_NUMERO_DOCUMENTO)) obj.NUMERO_DOCUMENTO = "";
                            else obj.NUMERO_DOCUMENTO = dr.GetString(pos_NUMERO_DOCUMENTO);

                            if (dr.IsDBNull(pos_ID_TIPO_DOCUMENTO)) obj.ID_TIPO_DOCUMENTO = 0;
                            else obj.ID_TIPO_DOCUMENTO = int.Parse(dr[pos_ID_TIPO_DOCUMENTO].ToString());

                            if (dr.IsDBNull(pos_CORREO)) obj.CORREO = "";
                            else obj.CORREO = dr.GetString(pos_CORREO);

                            if (dr.IsDBNull(pos_CARGO)) obj.CARGO = "";
                            else obj.CARGO = dr.GetString(pos_CARGO);

                            if (dr.IsDBNull(pos_TELEFONO)) obj.TELEFONO = "";
                            else obj.TELEFONO = dr.GetString(pos_TELEFONO);



                            if (dr.IsDBNull(pos_DESC_TIPO_DOCUMENTO)) obj.DESC_TIPO_DOCUMENTO = "";
                            else obj.DESC_TIPO_DOCUMENTO = dr.GetString(pos_DESC_TIPO_DOCUMENTO);

              

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

        ///*********************************************** ----------------- **************************************************/

        ///*********************************************** Lista sucursal por id *************************************************/

        public Cls_Ent_Contingencia Contingencia_Listar_Uno(Cls_Ent_Contingencia entidad_param, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            Cls_Ent_Contingencia obj = new Cls_Ent_Contingencia();
            try
            {
                using (SqlConnection cn = this.GetNewConnection())
                {
                    SqlDataReader dr = null;
                    SqlCommand cmd = new SqlCommand("USP_ADMIN_CONTIGENCIA_LISTAR_UNO", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PI_ID_CONTINGENCIA", SqlDbType.BigInt)).Value = entidad_param.ID_CONTINGENCIA;
                    dr = cmd.ExecuteReader();
                    int pos_ID_CONTINGENCIA = dr.GetOrdinal("ID_CONTINGENCIA");
                    int pos_NOMBRE = dr.GetOrdinal("NOMBRE");
                    int pos_APELLIDO_PATERNO = dr.GetOrdinal("APELLIDO_PATERNO");
                    int pos_APELLIDO_MATERNO = dr.GetOrdinal("APELLIDO_MATERNO");
                    int pos_NUMERO_DOCUMENTO = dr.GetOrdinal("NUMERO_DOCUMENTO");
                    int pos_ID_TIPO_DOCUMENTO = dr.GetOrdinal("ID_TIPO_DOCUMENTO");
                    int pos_CARGO = dr.GetOrdinal("CARGO");
                    int pos_TELEFONO = dr.GetOrdinal("TELEFONO");
                    int pos_CORREO = dr.GetOrdinal("CORREO");
  
                    if (dr.HasRows)
                    {
                        //Cls_Ent_Contingencia obj = null;
                        while (dr.Read())
                        {
                            obj = new Cls_Ent_Contingencia();
                            if (dr.IsDBNull(pos_ID_CONTINGENCIA)) obj.ID_CONTINGENCIA = 0;
                            else obj.ID_CONTINGENCIA = int.Parse(dr[pos_ID_CONTINGENCIA].ToString());

                            if (dr.IsDBNull(pos_CARGO)) obj.CARGO = "";
                            else obj.CARGO = dr.GetString(pos_CARGO);


                            if (dr.IsDBNull(pos_APELLIDO_MATERNO)) obj.APELLIDO_MATERNO = "";
                            else obj.APELLIDO_MATERNO = dr.GetString(pos_APELLIDO_MATERNO);


                            if (dr.IsDBNull(pos_NOMBRE)) obj.NOMBRE = "";
                            else obj.NOMBRE = dr.GetString(pos_NOMBRE);


                            if (dr.IsDBNull(pos_APELLIDO_PATERNO)) obj.APELLIDO_PATERNO = "";
                            else obj.APELLIDO_PATERNO = dr.GetString(pos_APELLIDO_PATERNO);

                            if (dr.IsDBNull(pos_NUMERO_DOCUMENTO)) obj.NUMERO_DOCUMENTO = "";
                            else obj.NUMERO_DOCUMENTO = dr.GetString(pos_NUMERO_DOCUMENTO);

                            if (dr.IsDBNull(pos_ID_TIPO_DOCUMENTO)) obj.ID_TIPO_DOCUMENTO = 0;
                            else obj.ID_TIPO_DOCUMENTO = int.Parse(dr[pos_ID_TIPO_DOCUMENTO].ToString());

                            if (dr.IsDBNull(pos_CORREO)) obj.CORREO = "";
                            else obj.CORREO = dr.GetString(pos_CORREO);

                            if (dr.IsDBNull(pos_TELEFONO)) obj.TELEFONO = "";
                            else obj.TELEFONO = dr.GetString(pos_TELEFONO);

           
                        }
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return obj;
        }

        ///*********************************************** ----------------- **************************************************/

        ///*********************************************** Inserta sucursal  *************************************************/

        public void Contingencia_Insertar(Cls_Ent_Contingencia entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            try
            {
                using (SqlConnection cn = this.GetNewConnection())
                {
                    SqlCommand cmd = new SqlCommand("USP_ADMIN_CONTIGENCIA_INSERTAR", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PI_ID_TIPO_DOCUMENTO", SqlDbType.Int)).Value = entidad.ID_TIPO_DOCUMENTO;
                    cmd.Parameters.Add(new SqlParameter("@PI_NUMERO_DOCUMENTO", SqlDbType.VarChar, 200)).Value = entidad.NUMERO_DOCUMENTO;
                    cmd.Parameters.Add(new SqlParameter("@PI_NOMBRE", SqlDbType.VarChar, 200)).Value = entidad.NOMBRE;
                    cmd.Parameters.Add(new SqlParameter("@PI_APELLIDO_PATERNO", SqlDbType.VarChar, 200)).Value = entidad.APELLIDO_PATERNO;
                    cmd.Parameters.Add(new SqlParameter("@PI_APELLIDO_MATERNO", SqlDbType.VarChar, 200)).Value = entidad.APELLIDO_MATERNO;
                    cmd.Parameters.Add(new SqlParameter("@PI_CORREO", SqlDbType.VarChar, 200)).Value = entidad.CORREO;
                    cmd.Parameters.Add(new SqlParameter("@PI_TELEFONO", SqlDbType.VarChar, 9)).Value = entidad.TELEFONO;
                    cmd.Parameters.Add(new SqlParameter("@PI_CARGO", SqlDbType.VarChar, 200)).Value = entidad.CARGO;
                    cmd.Parameters.Add(new SqlParameter("@PI_USUARIO_CREACION", SqlDbType.VarChar, 200)).Value = entidad.USU_CREACION;
                    cmd.Parameters.Add(new SqlParameter("PO_VALIDO", SqlDbType.Int)).Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("PO_MENSAJE", SqlDbType.VarChar, 200)).Direction = System.Data.ParameterDirection.Output;
                    if (cn.State != System.Data.ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["PO_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["PO_MENSAJE"].Value.ToString();
                    if (PO_VALIDO == "0")
                    {
                        auditoria.Rechazar(PO_MENSAJE);
                    }
                
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

        ///*********************************************** ----------------- **************************************************/

        ///*********************************************** Actualiza  sucursal  *************************************************/

        public void Contingencia_Actualizar(Cls_Ent_Contingencia entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            try
            {
                using (SqlConnection cn = this.GetNewConnection())
                {
                    SqlCommand cmd = new SqlCommand("USP_ADMIN_CONTIGENCIA_ACTUALIZAR", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PI_ID_CONTINGENCIA", SqlDbType.Int)).Value = entidad.ID_CONTINGENCIA;
                    cmd.Parameters.Add(new SqlParameter("@PI_ID_TIPO_DOCUMENTO", SqlDbType.Int)).Value = entidad.ID_TIPO_DOCUMENTO;
                    cmd.Parameters.Add(new SqlParameter("@PI_NUMERO_DOCUMENTO", SqlDbType.VarChar, 200)).Value = entidad.NUMERO_DOCUMENTO;
                    cmd.Parameters.Add(new SqlParameter("@PI_NOMBRE", SqlDbType.VarChar, 200)).Value = entidad.NOMBRE;
                    cmd.Parameters.Add(new SqlParameter("@PI_APELLIDO_PATERNO", SqlDbType.VarChar, 200)).Value = entidad.APELLIDO_PATERNO;
                    cmd.Parameters.Add(new SqlParameter("@PI_APELLIDO_MATERNO", SqlDbType.VarChar, 200)).Value = entidad.APELLIDO_MATERNO;
                    cmd.Parameters.Add(new SqlParameter("@PI_CORREO", SqlDbType.VarChar, 200)).Value = entidad.CORREO;
                    cmd.Parameters.Add(new SqlParameter("@PI_TELEFONO", SqlDbType.VarChar, 9)).Value = entidad.TELEFONO;
                    cmd.Parameters.Add(new SqlParameter("@PI_CARGO", SqlDbType.VarChar, 200)).Value = entidad.CARGO;
                    cmd.Parameters.Add(new SqlParameter("@PI_USUARIO_MODIFICACION", SqlDbType.VarChar, 200)).Value = entidad.USU_MODIFICACION;
                    cmd.Parameters.Add(new SqlParameter("PO_VALIDO", SqlDbType.Int)).Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("PO_MENSAJE", SqlDbType.VarChar, 200)).Direction = System.Data.ParameterDirection.Output;
                    if (cn.State != System.Data.ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["PO_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["PO_MENSAJE"].Value.ToString();
                    if (PO_VALIDO == "0")
                    {
                        auditoria.Rechazar(PO_MENSAJE);
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

        ///*********************************************** ----------------- **************************************************/

        ///*********************************************** Elimina sucursal  *************************************************/

        public void Contingencia_Eliminar(Cls_Ent_Contingencia entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            try
            {
                using (SqlConnection cn = this.GetNewConnection())
                {
                    SqlCommand cmd = new SqlCommand("USP_ADMIN_CONTIGENCIA_ELIMINAR", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PI_ID_CONTINGENCIA", SqlDbType.Int)).Value = entidad.ID_CONTINGENCIA;
                    cmd.Parameters.Add(new SqlParameter("PO_VALIDO", SqlDbType.Int)).Direction = System.Data.ParameterDirection.Output;
                    if (cn.State != System.Data.ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["PO_VALIDO"].Value.ToString();
                    if (PO_VALIDO == "0")
                    {
                        auditoria.Rechazar("Registro no eliminado");
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

        ///*********************************************** ----------------- **************************************************/

        ///*********************************************** Cambia estado de sucursal  *************************************************/

        public void Contingencia_Estado(Cls_Ent_Contingencia entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            try
            {
                using (SqlConnection cn = this.GetNewConnection())
                {
                    SqlCommand cmd = new SqlCommand("USP_ADMIN_CONTIGENCIA_ESTADO", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PI_ID_CONTINGENCIA", SqlDbType.Int)).Value = entidad.ID_CONTINGENCIA;
                    cmd.Parameters.Add(new SqlParameter("@PI_FLG_ESTADO", SqlDbType.VarChar, 200)).Value = entidad.FLG_ESTADO;
                    cmd.Parameters.Add(new SqlParameter("@PI_IP_MODIFICACION", SqlDbType.VarChar, 200)).Value = entidad.IP_MODIFICACION;
                    cmd.Parameters.Add(new SqlParameter("@PI_USUARIO_MODIFICACION", SqlDbType.VarChar, 200)).Value = entidad.USU_MODIFICACION;
                    cmd.Parameters.Add(new SqlParameter("PO_VALIDO", SqlDbType.Int)).Direction = System.Data.ParameterDirection.Output;
                    if (cn.State != System.Data.ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["PO_VALIDO"].Value.ToString();
                    if (PO_VALIDO == "0")
                    {
                        auditoria.Rechazar("Estado no cambiado ");
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

    }
}
