using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//libreria para conexion a SQL Server
using System.Data.SqlClient;

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
    }
}
