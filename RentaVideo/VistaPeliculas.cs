using Datos.BaseDatos.Modelos;
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
    public partial class VistaPeliculas : Form
    {
        private NPeliculas nVariable;
        public VistaPeliculas()
        {
            InitializeComponent();
            nVariable = new NPeliculas();
        }

        private void VistaPeliculas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            var grupo = nVariable.obtener().Select(c => new { c.PeliculaId, c.Nombre, c.Genero, c.Autores, c.Existencia, c.PrecioRenta, c.Estado });

            DGVDatos.DataSource = grupo.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var id = txtID.Text.ToString();

            var nombre = txtNombre.Text.ToString();
            var genero = txtGenero.Text.ToString();
            var autores = txtAutores.Text.ToString();
            var existencia = txtExistencias.Text.ToString();
            var preciorenta = txtPrecioRenta.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Agregar = true;
            }
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                errorProvider1.SetError(txtNombre, "Debe de ingresar el nombre de la Pelicula");
                return;
            }
            if (string.IsNullOrEmpty(genero) || string.IsNullOrWhiteSpace(genero))
            {
                errorProvider1.SetError(txtGenero, "Debe de ingresa el genero de la Pelicula");
                return;
            }
            if (string.IsNullOrEmpty(autores) || string.IsNullOrWhiteSpace(autores))
            {
                errorProvider1.SetError(txtAutores, "Debe de ingresar el nombre del Autor");
                return;
            }
            if (string.IsNullOrEmpty(existencia) || string.IsNullOrWhiteSpace(existencia))
            {
                errorProvider1.SetError(txtGenero, "Debe de ingresar las existencias de la pelicula");
                return;
            }
            if (string.IsNullOrEmpty(preciorenta) || string.IsNullOrWhiteSpace(preciorenta))
            {
                errorProvider1.SetError(txtPrecioRenta, "Debe de ingresar el precio de renta de la pelicula");
                return;
            }

            if (Agregar)
            {
                nVariable.Agregar(new Datos.BaseDatos.Modelos.Peliculas()
                {
                    Nombre = txtNombre.Text.ToString(),
                    Genero = txtGenero.Text.ToString(),
                    Autores = txtAutores.Text.ToString(),
                    Existencia = int.Parse(txtExistencias.Text),
                    Estado = chkEstado.Checked,
                    PrecioRenta = decimal.Parse(txtPrecioRenta.Text),
                });
            }
            else
            {
                nVariable.Editar(new Datos.BaseDatos.Modelos.Peliculas()
                {
                    PeliculaId = int.Parse(id),
                    Nombre = nombre,
                    Genero = genero,
                    Autores = autores,
                    Existencia = int.Parse(existencia),
                    Estado = chkEstado.Checked,
                    PrecioRenta = decimal.Parse(txtPrecioRenta.Text),
                });
            }

            CargarDatos();
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtGenero.Clear();
            txtAutores.Clear();
            txtExistencias.Clear();
            txtPrecioRenta.Clear();
            chkEstado.Checked = false;
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool estado = Convert.ToBoolean(DGVDatos.CurrentRow.Cells["Estado"].Value);

            txtID.Text = DGVDatos.CurrentRow.Cells["PeliculaId"].Value.ToString();
            txtNombre.Text = DGVDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            txtGenero.Text = DGVDatos.CurrentRow.Cells["Genero"].Value.ToString();
            txtAutores.Text = DGVDatos.CurrentRow.Cells["Autores"].Value.ToString();
            txtExistencias.Text = DGVDatos.CurrentRow.Cells["Existencia"].Value.ToString();
            txtPrecioRenta.Text = DGVDatos.CurrentRow.Cells["PrecioRenta"].Value.ToString();
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
