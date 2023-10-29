using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        private EmpleadoBLL empleadoBLL;
        
        public Form1()
        {
            InitializeComponent();
            empleadoBLL = new EmpleadoBLL();
        }

        /// <summary>
        /// Carga de empleados cuando se presiona el botón btCargarEmpleados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCargarEmpleados_Click(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        /// <summary>
        /// Llama al método para obtener la lista de empleados desde la BLL 
        /// y los agrega como datasource del dataGridView
        /// </summary>
        private void CargarEmpleados()
        {
            List<Empleado> empleados = empleadoBLL.ObtenerEmpleados();
            if(empleados.Count > 0)
            {
                dataGridView1.DataSource = empleados;
            }
            else
            {
                MessageBox.Show("No hay registros de empleados", "Falta de registros", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void LimpiarFormularioCreacion()
        {
            this.tbNombre.Clear();
            this.tbApellido.Clear();
            this.tbDepartamento.Clear();
            this.numSalario.Value = 0;
            this.dtPickerNacimiento.Value = DateTime.Now;
        }

        /// <summary>
        /// Conjunto de validaciones para un objeto de clase Empleado
        /// valida el largo minimo y máximo de las cadenas de texto Nombre, Apellido y Departamento
        /// valida que la fecha de nacimiento sea distinta del dia actual
        /// valida que el salario sea mayor a cero
        /// </summary>
        /// <param name="empleado">Objeto de clase empleado al cual se validan sus propiedades</param>
        /// <returns>Retorna un bool indicando si los valores del Empleado son válidos o no</returns>
        private bool EmpleadoValido(Empleado empleado)
        {
            bool valido = false;
            valido = empleado.Nombre.Trim().Length > 0 && empleado.Nombre.Trim().Length <= 50;
            if (!valido)
            {
                MessageBox.Show("El nombre del empleado debe tener entre 1 a cincuenta carácteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            valido = empleado.Apellido.Trim().Length > 0 && empleado.Apellido.Trim().Length <= 50;
            if (!valido)
            {
                MessageBox.Show("El apellido del empleado debe tener entre 1 a cincuenta carácteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            valido = empleado.Departamento.Trim().Length > 0 && empleado.Departamento.Trim().Length <= 50;
            if (!valido)
            {
                MessageBox.Show("El departamento del empleado debe tener entre 1 a cincuenta carácteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            valido = empleado.FechaNacimiento < DateTime.Today;
            if (!valido)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser igual o mayor al día de hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            valido = empleado.Salario > 0;
            if (!valido)
            {
                MessageBox.Show("El salario del empleado debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return valido;
        }

        /// <summary>
        /// Ejecuta la recolección de datos de los campos para agregar un nuevo empleado
        /// validando los valores obtenidos y llamando al método de creación de empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAgregarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = tbNombre.Text;
                string apellido = tbApellido.Text;
                string departamento = tbDepartamento.Text;
                DateTime fechaNacimiento = dtPickerNacimiento.Value.ToUniversalTime();
                float salario = (float)numSalario.Value;
                Empleado nuevoEmpleado = new Empleado(nombre, apellido, fechaNacimiento, departamento, salario);
                if (!EmpleadoValido(nuevoEmpleado))
                {
                    throw new Exception("Los datos del empleado a ingresar no son válidos");
                }
                empleadoBLL.AgregarEmpleado(nuevoEmpleado);
                LimpiarFormularioCreacion();
                CargarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
