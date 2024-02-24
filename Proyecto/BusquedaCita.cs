using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class BusquedaCita : Form
    {
        public BusquedaCita()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dvgBuscar.DataSource = funciones.BuscarCita(txtNombrePaciente.Text, txtNombreDoctor.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Recepcionistas NuevaVentana = new Recepcionistas();
            NuevaVentana.Show();
        }
        private void txtletras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
