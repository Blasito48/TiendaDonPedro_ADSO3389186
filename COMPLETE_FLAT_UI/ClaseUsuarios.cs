using System;
using System.Collections.Generic;
using System.Data;
//libreria para conexion a SQL Server
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace COMPLETE_FLAT_UI
{
    public class ClaseUsuarios
    {

        public static string cadena = "Server=DESKTOP-IVF5GP5\\SQLEXPRESS;Database=BD_TiendaDonPedro;User Id=ADSO;Password=12345;TrustServerCertificate=True;";
        public static string excepcion = "";
        //funcion TraerTodo
        public static DataTable Func_TraerTodo()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand("PA_USUARIO_TRAERTODOS", conn);
                //el comando funciona como procedimiento almacenado
                //SqlDataAdapter adap = new SqlDataAdapter("PA_USUARIO_TRAERTODOS", conn);
                //adap.Sand.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                //adap.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
        public static DataTable Func_TraerPasswordUsuario(string alias)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand("PA_USUARIO_1USUARIO", conn);
                //el comando funciona como procedimiento almacenado
                //SqlDataAdapter adap = new SqlDataAdapter("PA_USUARIO_TRAERTODOS", conn);
                //adap.Sand.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                //envio el parametro del P.A
                cmd.Parameters.AddWithValue("@Alias", alias);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                //adap.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
        public static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convertir la cadena de entrada a un arreglo de bytes usando UTF-8
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Crear un StringBuilder para recopilar los bytes
                StringBuilder sBuilder = new StringBuilder();

                // Formatear cada byte como una cadena hexadecimal
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
