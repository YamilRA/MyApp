using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class Datos
    {
        SqlConnection conexion;
        string cadenaConexion = "Server=localhost;Integrated Security=false;" +
            "User=sa;password=.;initial catalog=Agenda";

        private void conexionOpen()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
        }
        private void conexionClose()
        {
            try { conexion.Close(); }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        public bool Insertar(string nombre, string paterno, string materno,
        string telefono, string correo)
        {
            try
            {
                conexionOpen();
                string comando = "Insert Into Datos(nombre,paterno,materno,telefono," +
                    "correo)Values('" + nombre + "','" + paterno +
                    "','" + materno + "','" + telefono + "','" + correo + "')";
                SqlCommand sqlCommand = new SqlCommand(comando, conexion);
                sqlCommand.ExecuteNonQuery();
                conexionClose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return false;
            }
        }

    }
}
