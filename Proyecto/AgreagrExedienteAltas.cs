using MySql.Data.MySqlClient;
using Proyecto.mysql;
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
    public partial class AgreagrExedienteAltas : Form
    {
        public AgreagrExedienteAltas()
        {
            InitializeComponent();
        }

        private void BuscarPaciente_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCurpPaciente.Text))
            {
                MessageBox.Show("Hay un campo vacio");
            }
            else
            {
                bool entro = false;
                Paciente w = new Paciente();
                MySqlCommand comandoss = new MySqlCommand(String.Format("select * from paciente where curp =  '{0}'", txtCurpPaciente.Text), conexion.obtenerConexion());
                MySqlDataReader readerss = comandoss.ExecuteReader();
                while (readerss.Read())
                {
                    w.curp = readerss.GetString(3);
                    string curp = w.curp;
                    if (curp == txtCurpPaciente.Text)
                    {
                        entro = true;
                    }
                }
                if(entro == true)
                {
                    this.Hide();
                    AltasExpedientes NuevaVentana = new AltasExpedientes();
                    NuevaVentana.txtNombreDoc.Text = txtDoctor.Text;
                    NuevaVentana.txtCurp.Text = txtCurpPaciente.Text;
                    NuevaVentana.txtIdDoc.Text = Id_doc.Text;
                    NuevaVentana.txtDomicilioD.Text = textDireccion.Text;
                    NuevaVentana.txtNombreP.ReadOnly = true;
                    NuevaVentana.txtApellidoPaternoP.ReadOnly = true;
                    NuevaVentana.txtApellidoMaternoP.ReadOnly = true;
                    NuevaVentana.txtCurp.ReadOnly = true;
                    NuevaVentana.dateTimePicker1.Visible = false;
                    NuevaVentana.txtDomicilioP.ReadOnly = true;
                    NuevaVentana.txtFechaNacP.ReadOnly = true;
                    buscar.Text = "true";
                    NuevaVentana.Show();
                }
                else
                {
                    MessageBox.Show("CURP del paciente no encontrada");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuDoctor NuevaVentana = new MenuDoctor();
            NuevaVentana.textBox1.Text = txtDoctor.Text;
            NuevaVentana.textBox2.Text = Id_doc.Text;
            NuevaVentana.textBox3.Text = textDireccion.Text;
            NuevaVentana.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltasExpedientes NuevaVentana = new AltasExpedientes();
            NuevaVentana.txtNombreDoc.Text = txtDoctor.Text;
            NuevaVentana.txtIdDoc.Text = Id_doc.Text;
            NuevaVentana.txtDomicilioD.Text = textDireccion.Text;
            NuevaVentana.txtFechaNacP.Visible = false;
            buscar.Text = "false";
            NuevaVentana.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.texNombr, "");
            if (string.IsNullOrWhiteSpace(texNombr.Text))
            {
                

                if (string.IsNullOrWhiteSpace(texNombr.Text))
                {
                    errorProvider1.SetError(this.texNombr, "Rellenar espacio en blanco para la busqueda (Puede colocar solo una letra o mas)");
                }
            }
            else
            {
                dataGridView1.DataSource = funciones.BuscarExp(texNombr.Text);
            }
        }
        private void txtCurp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras y numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
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
