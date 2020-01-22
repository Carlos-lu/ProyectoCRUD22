using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico
{
    public static class UsuariosDAO
    {

        private static string cadenaConexion = @"server=L-PCT-116\SQLEXPRESS2016; database= TI2019; user id=sa; password=Lab123456";

        public static bool validaUsuario(string usuario, string clave)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "select idLogin,nombreCompleto " +
                 " from usuarios " +
                 "where login=@login and clave=@clave";

            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            ad.SelectCommand.Parameters.AddWithValue("@idLogin", usuario);
            ad.SelectCommand.Parameters.AddWithValue("@clave", clave);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
       /* public static int guardar(Usuarios usuarios)
        {

            //definimos un objeo conexion 
            SqlConnection conn = new SqlConnection(cadenaConexion);

            string sql = "insert into usuarios(idLogin,nombreCompleto,login,clave," +
                "fechaCreacion) values(@idLogin,@nombreCompleto,@login,@clave,@fechaCreacion)";
            //definimos un comando 
            SqlCommand comando = new SqlCommand(sql, conn);
            //vonfiguramos los parametros

            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@idLogin", usuarios.idLogin);
            comando.Parameters.AddWithValue("@nombreCompleto", usuarios.nombreCompleto);
            comando.Parameters.AddWithValue("@login", usuarios.Login);
            comando.Parameters.AddWithValue("@clave", usuarios.clave);

            
            conn.Open();
            int x = comando.ExecuteNonQuery(); //ejecutamos el comando
            conn.Close();
            return x;
        }*/
    }
}
