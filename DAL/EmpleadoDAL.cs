using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Clase que disponibiliza las acciones que consideren la consulta o manipulación de la base de datos
    /// </summary>
    public class EmpleadoDAL
    {
        /// <summary>
        /// Guarda un nuevo registro de empleado en la base de datos, dando formato 
        /// a la fecha de nacimiento para ser compatible con el formato compatible 
        /// de la base de datos
        /// </summary>
        /// <param name="empleado">Objeto de clase empleado a registrar</param>
        /// <returns>Retorna un bool para indicar si el proceso es exitoso</returns>
        public bool GuardarEmpleado(Empleado empleado)
        {
            string fechanac = empleado.FechaNacimiento.ToString("yyyy-MM-dd");
            string query = $"INSERT INTO empleados(nombre, apellido, fechanacimiento, departamento, salario) VALUES ('{empleado.Nombre}', '{empleado.Apellido}', '{fechanac}', '{empleado.Departamento}', {empleado.Salario})";
            int rows = DatabaseHelper.Instance.ExecuteNonQuery(query);
            if (rows == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Ejecuta la consulta de todos los empleados registrados en base de datos
        /// </summary>
        /// <returns>Retorna una lista con todos lo registros de empleado obtenidos</returns>
        public List<Empleado> ObtenerEmpleados()
        {
            string query = "SELECT * FROM empleados";
            DataTable dt = DatabaseHelper.Instance.ExecuteQuery(query);
            List<Empleado> empleados = new List<Empleado>();
            foreach (DataRow row in dt.Rows)
            {
                Empleado e = new Empleado();
                e.Nombre = row["nombre"].ToString();
                e.Apellido = row["apellido"].ToString();
                e.FechaNacimiento = DateTime.Parse(row["fechanacimiento"].ToString());
                e.Departamento = row["departamento"].ToString();
                e.Salario = float.Parse(row["salario"].ToString());
                empleados.Add(e);
            }
            return empleados;
        }
    }
}
