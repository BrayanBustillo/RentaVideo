using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaVideo
{
    public partial class VistaClientes : Form
    {
        private NClientes nVariable;
        public VistaClientes()
        {
            InitializeComponent();
            nVariable = new NClientes();
        }

        private void VistaClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            var grupo = nVariable.obtener().Select(c => new { c.ClienteId, c.Nombres, c.Aepllidos, c.FechaIngreso, c.Estado });

            DGVDatos.DataSource = grupo.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var id = txtID.Text.ToString();

            var nombre = txtNombre.Text.ToString();
            var apellido = txtApellido.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Agregar = true;
            }
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                errorProvider1.SetError(txtNombre, "Debe de ingresar el nombre de la Pelicula");
                return;
            }
            if (string.IsNullOrEmpty(apellido) || string.IsNullOrWhiteSpace(apellido))
            {
                errorProvider1.SetError(txtApellido, "Debe de ingresa el genero de la Pelicula");
                return;
            }

            if (Agregar)
            {
                nVariable.Agregar(new Datos.BaseDatos.Modelos.Clientes()
                {
                    Nombres = txtNombre.Text.ToString(),
                    Aepllidos = txtApellido.Text.ToString(),
                    FechaIngreso = DateTime.Now,
                    Estado = chkEstado.Checked,
                });
            }
            else
            {
                nVariable.Editar(new Datos.BaseDatos.Modelos.Clientes()
                {
                    ClienteId = int.Parse(id),
                    Nombres = nombre,
                    Aepllidos = apellido,
                    Estado = chkEstado.Checked,
                });
            }

            CargarDatos();
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            chkEstado.Checked = false;

            dtpFechaIngreso.Value = DateTime.Now;
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool estado = Convert.ToBoolean(DGVDatos.CurrentRow.Cells["Estado"].Value);

            txtID.Text = DGVDatos.CurrentRow.Cells["ClienteId"].Value.ToString();
            txtNombre.Text = DGVDatos.CurrentRow.Cells["Nombres"].Value.ToString();
            txtApellido.Text = DGVDatos.CurrentRow.Cells["Aepllidos"].Value.ToString();
            dtpFechaIngreso.Text = DGVDatos.CurrentRow.Cells["FechaIngreso"].Value.ToString(); 
            chkEstado.Checked = estado;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var id = txtID.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return;
            }
            nVariable.EliminarRegistro(int.Parse(id));
            CargarDatos();
            LimpiarDatos();
        }
    }
}
