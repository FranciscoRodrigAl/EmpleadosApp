using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Clase que permite abrir una conexión a base de datos y ejecutar consultas SQL
    /// </summary>
    internal class DatabaseHelper
    {
        private static DatabaseHelper instance = new DatabaseHelper();

        public static DatabaseHelper Instance
        {
            get { return instance; }
        }

        private static string CONNECTION_STRING = "Data Source=DESKTOP-LVSPAAK\\SQLEXPRESS; Initial Catalog=Empleados; Integrated Security=True";

        /// <summary>
        /// Ejecuta la query dada como parámetro para acciones que
        /// no consideran devolver datos, como update, delete o insert
        /// </summary>
        /// <param name="query">consulta SQL que se ejecutará</param>
        /// <returns>Retorna el número de filas afectadas por la query</returns>
        public int ExecuteNonQuery(string query)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Ejecuta la query como consulta que devolverá datos
        /// </summary>
        /// <param name="query">consulta SQL a ejecutar</param>
        /// <returns>Retorna Datatable con la información consultada por la query</returns>
        public DataTable ExecuteQuery(string query)
        {

            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
