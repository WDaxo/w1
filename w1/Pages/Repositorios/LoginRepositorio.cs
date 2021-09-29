using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace w1.Pages.Repositorios
{
    public class LoginRepositorio
    {
        public bool ExisteUsuario(string NombreUsuario, string Password) 
        {
            bool respuesta = false;
            string connectionString = "server=localhost;database=w1; Integrated Security = true";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_check_usuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NombreUsuario", NombreUsuario)); 
            cmd.Parameters.Add(new SqlParameter("@Password", Password));
            sql.Open();
            int resultadoQuery = (int)cmd.ExecuteScalar();
            if (resultadoQuery > 0) 
            {
                respuesta = true;
            }


            return respuesta;
        }
    }
}
