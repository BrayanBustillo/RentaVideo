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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void peliculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaPeliculas vista = new VistaPeliculas();
            vista.MdiParent = this;
            vista.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaClientes vista = new VistaClientes();
            vista.MdiParent = this;
            vista.Show();
        }

        private void rentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaRenta vista = new VistaRenta();
            vista.MdiParent = this;
            vista.Show();
        }
    }
}
