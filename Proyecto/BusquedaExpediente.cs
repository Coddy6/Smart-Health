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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto
{
    public partial class BusquedaExpediente : Form
    {
        public BusquedaExpediente()
        {
            InitializeComponent();

            txtIddoc.Visible = false;
            label1.Visible = false;
            curpPaciente.Visible = false;
            label6.Visible = false;
            comboBox_id_expediente.Visible = false;
            label4.Visible = false;
            txtNombrePaciente.Visible = false;
            label3.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Opción 1")
            {
                dataGridView1.DataSource = funciones.BuscarExpediente1(comboBox_id_expediente.Text);
            }
            else if(comboBox1.Text == "Opción 2")
            {
                dataGridView1.DataSource = funciones.BuscarExpediente2(txtIddoc.Text, curpPaciente.Text);
            }
            else if(comboBox1.Text == "Opción 3")
            {
                dataGridView1.DataSource = funciones.BuscarExpediente3(txtIddoc.Text, txtNombrePaciente.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuDoctor NuevaVentana = new MenuDoctor();
            NuevaVentana.textBox2.Text = txtIddoc.Text;
            NuevaVentana.textBox1.Text = nombre.Text;
            NuevaVentana.textBox3.Text = direct.Text;
            NuevaVentana.Show();
        }

        private void txtnumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
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

        private void txtCurp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras y numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void cargarCategorias()
        {
            comboBox_id_expediente.DataSource = null;
            comboBox_id_expediente.Items.Clear();
            MySqlCommand comandos = new MySqlCommand(String.Format("Select Id_Exp from expediente where Id_Doc = '{0}' order by Id_Exp", txtIddoc.Text), conexion.obtenerConexion());

            try
            {
                MySqlDataAdapter data = new MySqlDataAdapter(comandos);
                DataTable dt = new DataTable();
                data.Fill(dt);

                comboBox_id_expediente.ValueMember = "Id_Exp";
                comboBox_id_expediente.DisplayMember = "Id_Exp";
                comboBox_id_expediente.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar categorias" + ex.Message);
            }
            finally
            {

            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtIddoc.Visible = false;
            label1.Visible = false;
            curpPaciente.Visible = false;
            label6.Visible = false;
            comboBox_id_expediente.Visible = false;
            label4.Visible = false;
            txtNombrePaciente.Visible = false;
            label3.Visible = false;

            if (comboBox1.Text == "Opción 1")
            {
                cargarCategorias();
                comboBox_id_expediente.Visible = true;
                label4.Visible = true;
            }
            else if (comboBox1.Text == "Opción 2")
            {
                txtIddoc.Visible = true;
                curpPaciente.Visible = true;
                label1.Visible = true;
                label6.Visible = true;
            }
            else if (comboBox1.Text == "Opción 3")
            {
                txtIddoc.Visible = true;
                txtNombrePaciente.Visible = true;
                label3.Visible = true;
                label1.Visible = true;
            }
        }
    }
}
