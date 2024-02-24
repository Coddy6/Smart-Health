using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Proyecto
{
    public partial class MenuAdministrador : Form
    {
        private RegistroAdmin forma;

        public MenuAdministrador()
        {
            InitializeComponent();

        }


        private void altasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltasDoctores NuevaVentana = new AltasDoctores();
            NuevaVentana.Show();
        }

        private void individualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BusquedaDoctor NuevaVentana = new BusquedaDoctor();
            NuevaVentana.Show();
        }

        private void generalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsultasGenDoctores NuevaVentana = new ConsultasGenDoctores();
            NuevaVentana.Show();
        }

        private void altasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltasRecepcionista NuevaVentana = new AltasRecepcionista();
            NuevaVentana.Show();
        }

        private void consultasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void individualesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BusquedaRecepcionista NuevaVentana = new BusquedaRecepcionista();
            NuevaVentana.Show();
        }

        private void generalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsultaGenRecepcionista NuevaVentana = new ConsultaGenRecepcionista();
            NuevaVentana.Show();
        }

        private void CierreDeSesion_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\Media\notify.wav");
            simpleSound.Play();
            this.Hide();
            InicioSesion NuevaVentana = new InicioSesion();
            NuevaVentana.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void altasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if(forma == null)
            {
                forma = new RegistroAdmin();
                forma.MdiParent = this;
                forma.FormClosed += new FormClosedEventHandler(cerrarforma);
                forma.Show();
            }else
            {
                forma.Activate();
            }
        }

        void cerrarforma(object sender, FormClosedEventArgs e)
        {
            forma = null;
        }
    }
}
