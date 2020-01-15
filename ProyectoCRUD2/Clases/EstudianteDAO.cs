using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico
{
    public static class EstudianteDAO
    {
        private  static string cadenaConexion = @"server=PC1\SQLEXPRESS2016; database= TI2019; user id=sa; password=Lab123456";
        public static int guardar(Estudiante estudiante)
        {
            
            //definimos un objeo conexion 
            SqlConnection conn = new SqlConnection(cadenaConexion);

            string sql = "insert into Estudiantes(matricula,apellidos,nombres,genero,"+
                "fechaNacimiento, email) values(@matricula,@apellidos,@nombres,@genero,@fechaNacimiento,@email)";
            //definimos un comando 
            SqlCommand comando = new SqlCommand(sql,conn);
            //vonfiguramos los parametros

            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@matricula", estudiante.Matricula);
            comando.Parameters.AddWithValue("@apellidos", estudiante.Apellidos);
            comando.Parameters.AddWithValue("@nombres", estudiante.Nombres);
            comando.Parameters.AddWithValue("@genero", estudiante.Genero);
            comando.Parameters.AddWithValue("@fechaNacimiento", estudiante.FechaNacimiento.Date);
            comando.Parameters.AddWithValue("@email", estudiante.Correo);
            conn.Open();
            int x = comando.ExecuteNonQuery(); //ejecutamos el comando
            conn.Close();
            return x;
        }
        /// <summary>
        /// Devuelve todas las filas de la tabla
        /// </summary>
        /// <returns></returns>
        public static DataTable getDatos()
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "select matricula,apellidos,nombres,genero," +
                 "fechaNacimiento, email from Estudiantes order by apellidos";

            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }
        public static DataTable getNombresCompletos()
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "select matricula,upper(apellidos + ' ' + nombres) as Estudiante " +
                 " from Estudiantes order by apellidos,nombres";

            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }
        /// <summary>
        /// Obtiene un estudiante por su numero de matricula
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public static DataTable getDatos(String matricula)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "select matricula,apellidos,nombres,genero," +
                 "fechaNacimiento, email from Estudiantes " +
                 "where matricula=@matricula " +
                 "order by apellidos, nombres";

            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            ad.SelectCommand.Parameters.AddWithValue("@matricula", matricula);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }
        public static int delete(String matricula)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);

            string sql = "delete from Estudiantes "+
                "where matricula=@matricula";

            //definimos un comando 
            SqlCommand comando = new SqlCommand(sql, conn);
            //vonfiguramos los parametros

            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@matricula",matricula);
            conn.Open();
            int x = comando.ExecuteNonQuery(); //ejecutamos el comando
            conn.Close();
            return x;
        }
        public static int Update(Estudiante estudiante)
        {

            //definimos un objeo conexion 
            SqlConnection conn = new SqlConnection(cadenaConexion);

            string sql = "UPDATE Estudiantes SET apellidos=@apellidos, nombres=@nombres, genero=@genero, " + 
                "fechaNacimiento=@fechaNacimiento, email=@email WHERE matricula=@matricula";
            //definimos un comando 
            SqlCommand comando = new SqlCommand(sql, conn);
            //vonfiguramos los parametros
            conn.Open();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@matricula", estudiante.Matricula);
            comando.Parameters.AddWithValue("@apellidos", estudiante.Apellidos);
            comando.Parameters.AddWithValue("@nombres", estudiante.Nombres);
            comando.Parameters.AddWithValue("@genero", estudiante.Genero);
            comando.Parameters.AddWithValue("@fechaNacimiento", estudiante.FechaNacimiento.Date);
            comando.Parameters.AddWithValue("@email", estudiante.Correo);
            conn.Open();
            int s = comando.ExecuteNonQuery(); //ejecutamos el comando
            conn.Close();
            return s;
        }

    }
}
