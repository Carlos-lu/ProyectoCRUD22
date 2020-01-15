using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRUD2.Clases
{
    class UsuariosDAO
    {
        private static string cadenaConexion = @"server=L-PCT-116\SQLEXPRESS2016; database= TI2019; user id=sa; password=Lab123456";
        public static int guardar(Usuarios usuarios)
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
        }
    }
}
