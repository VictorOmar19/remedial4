using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{
    public class Acceso_Datos
    {
        private string cableConn;
        public Acceso_Datos(string connection)
        {
            cableConn = connection;
        }
        public SqlConnection ConnectionEstablecida(ref string mensajeC)
        {
            SqlConnection puerto = new SqlConnection();
            puerto.ConnectionString = cableConn;
            try
            {
                puerto.Open();
                mensajeC = "Connexion Establecida";
            }
            catch (Exception e)
            {
                mensajeC = "Error: " + e;
                puerto = null;
            }
            return puerto;
        }
        public Boolean BaseSegura(string Sqlinstruc, SqlConnection prAb, ref string mensaje, SqlParameter[] evaluacion)
        {
            Boolean resp = false;
            SqlCommand carrito = null;

            if (prAb != null)
            {
                mensaje = "";
                using (carrito = new SqlCommand())
                {
                    carrito.CommandText = Sqlinstruc;
                    carrito.Connection = prAb;
                    foreach (SqlParameter x in evaluacion)
                    {
                        carrito.Parameters.Add(x);
                    }
                    try
                    {
                        carrito.ExecuteNonQuery();
                        mensaje = "Se agregaron correctamente";
                        resp = true;
                    }
                    catch (Exception h)
                    {
                        mensaje = "Error : " + h.Message + " !";
                        resp = false;
                    }
                }
                prAb.Close();
                prAb.Dispose();
            }
            else
            {
                mensaje = "Error de Conexión";
            }
            return resp;
        }
        public Boolean BaseSeguraSinParametros(string Sqlinstruc, SqlConnection prAb, ref string mensaje)
        {
            Boolean resp = false;
            SqlCommand carrito = null;

            if (prAb != null)
            {
                mensaje = "";
                using (carrito = new SqlCommand())
                {
                    carrito.CommandText = Sqlinstruc;
                    carrito.Connection = prAb;
                    try
                    {
                        carrito.ExecuteNonQuery();
                        mensaje = "Se agregaron correctamente";
                        resp = true;
                    }
                    catch (Exception h)
                    {
                        mensaje = "Error : " + h.Message + " !";
                        resp = false;
                    }
                }
                prAb.Close();
                prAb.Dispose();
            }
            else
            {
                mensaje = "Error de Conexión";
            }
            return resp;
        }
        public DataSet LecturaSet(string comandoSql, SqlConnection conAbierta, ref string mensaje, string etiqueta)
        {
            SqlCommand comando = null;
            DataSet dataSet = null;
            SqlDataAdapter dataAdapter = null;

            if (conAbierta == null)
            {
                dataSet = null;
            }
            else
            {
                using (comando = new SqlCommand(comandoSql, conAbierta))
                {
                    using (dataAdapter = new SqlDataAdapter())
                    {
                        dataSet = new DataSet();
                        dataAdapter.SelectCommand = comando;
                        try
                        {
                            dataAdapter.Fill(dataSet, etiqueta);
                            mensaje = "Recuperacion Correcta";
                        }
                        catch (Exception e)
                        {
                            mensaje = "Lo siento: " + e.Message;
                            dataSet = null;
                        }
                    }
                }
            }
            return dataSet;
        }
    }
}
