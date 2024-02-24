using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto.mysql
{
    class conexion
    {
        public static MySqlConnection obtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection("server=127.0.0.2;database=smarthhealth;Uid=Gerente;pwd=AdministrationSmarthSecFile");
            conexion.Open();
            return conexion;
        }
    }
}
