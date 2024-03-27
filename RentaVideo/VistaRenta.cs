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
    public partial class VistaRenta : Form
    {
        private NRenta nVariable;
        private NClientes nCliente;
        private NPeliculas nPeliculas;
        public VistaRenta()
        {
            InitializeComponent();
            nVariable = new NRenta();
            nCliente = new NClientes();
            nPeliculas = new NPeliculas();
        }

        private void VistaRenta_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarCombobox();
        }
        private void CargarDatos()
        {
            var grupo = nVariable.obtener().Select(c => new { c.RentaId, c.cliente.Nombres, c.cliente.Aepllidos, c.pelicula.Nombre, c.FechaRenta, c.FechaRetorno, c.Cantidad, c.PrecioRenta });

            DGVDatos.DataSource = grupo.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var id = txtID.Text.ToString();

            var cantidad = txtCantidad.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Agregar = true;
            }
            if (string.IsNullOrEmpty(cantidad) || string.IsNullOrWhiteSpace(cantidad))
            {
                errorProvider1.SetError(txtCantidad, "Debe de ingresar una cantidad");
                return;
            }

            if (Agregar)
            {
                nVariable.Agregar(new Datos.BaseDatos.Modelos.Renta()
                {
                    ClienteId = int.Parse(cmbCliente.SelectedValue.ToString()),
                    PeliculaId = int.Parse(cmbPelicula.SelectedValue.ToString()),
                    Cantidad = int.Parse(txtCantidad.Text),
                    FechaRenta = DateTime.Now,
                    FechaRetorno = dtpFechaRetorno.Value,
                    PrecioRenta = decimal.Parse(txtPrecioRenta.Text),
                });
            }
            else
            {
                nVariable.Editar(new Datos.BaseDatos.Modelos.Renta()
                {
                    RentaId = int.Parse(id),
                    ClienteId = int.Parse(cmbCliente.SelectedValue.ToString()),
                    PeliculaId = int.Parse(cmbPelicula.SelectedValue.ToString()),
                    Cantidad = int.Parse(cantidad),
                    PrecioRenta = decimal.Parse(txtPrecioRenta.Text),
                });

            }

            CargarDatos();
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            txtID.Clear();
            txtCantidad.Clear();
            txtPrecioRenta.Clear();

            Random random = new Random();
            int index1 = random.Next(0, cmbCliente.Items.Count);
            int index2 = random.Next(0, cmbPelicula.Items.Count);

            cmbCliente.SelectedIndex = index1;
            cmbPelicula.SelectedIndex = index2;
        }

        private void CargarCombobox()
        {
            cmbCliente.DataSource = nCliente.obtener().Where(c => c.Estado == true)
                                          .Select(c => new { c.ClienteId, c.Nombres }).ToList();

            cmbCliente.ValueMember = "ClienteId";
            cmbCliente.DisplayMember = "Nombres";


            cmbPelicula.DataSource = nPeliculas.obtener().Where(c => c.Estado == true).Where(c => c.Existencia > 0)
                              .Select(c => new { c.PeliculaId, c.Nombre }).ToList();

            cmbPelicula.ValueMember = "PeliculaId";
            cmbPelicula.DisplayMember = "Nombre";
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = DGVDatos.CurrentRow.Cells["RentaId"].Value.ToString();
            cmbCliente.Text = DGVDatos.CurrentRow.Cells["Nombres"].Value.ToString();
            cmbPelicula.Text = DGVDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            dtpFechaIngreso.Text = DGVDatos.CurrentRow.Cells["FechaRenta"].Value.ToString();
            dtpFechaRetorno.Text = DGVDatos.CurrentRow.Cells["FechaRetorno"].Value.ToString();
            txtCantidad.Text = DGVDatos.CurrentRow.Cells["Cantidad"].Value.ToString();
            txtPrecioRenta.Text = DGVDatos.CurrentRow.Cells["PrecioRenta"].Value.ToString();
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

        private void txtPrecioRenta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
