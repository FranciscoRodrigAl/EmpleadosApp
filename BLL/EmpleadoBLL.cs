using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Clase que gestiona las funcionalidades de la aplicación.
    /// Utilizada para acceder a las acciones disponibles por la capa de acceso a datos
    /// </summary>
    public class EmpleadoBLL
    {
        private EmpleadoDAL empleadoDAL;

        public EmpleadoBLL()
        {
            empleadoDAL = new EmpleadoDAL();
        }

        /// <summary>
        /// Ingresa un nuevo registro de empleado a la base de datos solo si 
        /// la combinación de nombre y apellido ya no se encuentra registrada 
        /// en la misma base de datos
        /// </summary>
        /// <param name="empleado">Objeto de clase Empleado a registrar</param>
        public void AgregarEmpleado(Empleado empleado)
        {
            empleado.Nombre = empleado.Nombre.Trim();
            empleado.Apellido = empleado.Apellido.Trim();
            Empleado empleadoExiste = ObtenerEmpleados().Where(e => e.Nombre.Equals(empleado.Nombre) && e.Apellido.Equals(empleado.Apellido)).FirstOrDefault();
            if(empleadoExiste !=  null)
            {
                throw new Exception("Ya existe un empleado con el mismo nombre y apellido");
            }
            if (!empleadoDAL.GuardarEmpleado(empleado))
            {
                throw new Exception("No se registró el empleado");
            }
        }

        /// <summary>
        /// Método para consultar la lista completa de registros de empleados
        /// </summary>
        /// <returns>lista de objetos de clase Empleado</returns>
        public List<Empleado> ObtenerEmpleados()
        {
            return empleadoDAL.ObtenerEmpleados();
        }

        
    }
}
