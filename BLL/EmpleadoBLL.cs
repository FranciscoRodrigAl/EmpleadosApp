using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpleadoBLL
    {
        private EmpleadoDAL empleadoDAL;

        public EmpleadoBLL()
        {
            empleadoDAL = new EmpleadoDAL();
        }

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

        public List<Empleado> ObtenerEmpleados()
        {
            return empleadoDAL.ObtenerEmpleados();
        }

        
    }
}
