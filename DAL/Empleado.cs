using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Representa un registro de Empleado dentro del sistema.
    /// <remarks>
    /// Es la unidad básica de gestión dentro de la aplicación,
    /// estos registros se crean y listan
    /// </remarks>
    /// </summary>
    public class Empleado
    {
        /// <summary>
        /// Constructor vacío para nuevas instancias de la clase
        /// </summary>
        public Empleado() { }

        /// <summary>
        /// Constructor para empleado que considera el Id junto con los demas parámetros restantes
        /// </summary>
        /// <param name="id">Número identificador del registro de empleado</param>
        /// <param name="nombre">Nombre del empleado</param>
        /// <param name="apellido">Apellido del empleado</param>
        /// <param name="fechanacimiento">Fecha de nacimiento del empleado</param>
        /// <param name="departamento">Departamento donde trabaja el empleadp</param>
        /// <param name="salario">Salario que recibe el empleado</param>
        public Empleado(int id, string nombre, string apellido, DateTime fechanacimiento, string departamento, float salario)
        {

            this.ID = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNacimiento = fechanacimiento;
            this.Departamento = departamento;
            this.Salario = salario;


        }

        /// <summary>
        /// Constructor de empleado que considera valores para todas
        /// sus propiedades exceptuando el Id
        /// </summary>
        /// <param name="nombre">Nombre del empleado</param>
        /// <param name="apellido">Apellido del empleado</param>
        /// <param name="fechanacimiento">Fecha de nacimiento del empleado</param>
        /// <param name="departamento">Departamento donde trabaja el empleadp</param>
        /// <param name="salario">Salario que recibe el empleado</param>
        public Empleado(string nombre, string apellido, DateTime fechanacimiento, string departamento, float salario)
        {

            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNacimiento = fechanacimiento;
            this.Departamento = departamento;
            this.Salario = salario;


        }

        /// <summary>
        /// Número identificador del empleado, obtenido al registrase
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nombre del Empleado
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del empleado
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Fecha de nacimiento del empleado
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Departamento donde se desempeña el empleado
        /// </summary>
        public string Departamento { get; set; }

        /// <summary>
        /// Salario actual del empleado
        /// </summary>
        public float Salario { get; set; }
    }
}
