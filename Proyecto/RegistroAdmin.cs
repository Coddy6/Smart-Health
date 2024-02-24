using MySql.Data.MySqlClient;
using Proyecto.mysql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Proyecto
{
    public partial class RegistroAdmin : Form
    {
        public RegistroAdmin()
        {
            InitializeComponent();
        }

        private void Registro_Click(object sender, EventArgs e)
        {
            int existenciaUsu = 0;
            MySqlCommand comandos = new MySqlCommand(String.Format("select * from usuarios where id =  '{0}'", texId.Text), conexion.obtenerConexion());
            MySqlDataReader readers = comandos.ExecuteReader();
            Usuarios d = new Usuarios();
            while (readers.Read())
            {
                d.id = readers.GetString(0);
                string idd = d.id;
                if (idd == texId.Text)
                {
                    existenciaUsu = 1;
                }
            }

            if (existenciaUsu == 1)
            {
                MessageBox.Show("Cambie ID");
            }
            else
            {
                string admin = texId.Text;
                int p = Convert.ToInt16(admin);
                if (p > 2000)
                {
                    MessageBox.Show("Seleccione un rango de 0 - 1999");
                }
                else
                {
                    Usuarios agregar = new Usuarios();
                    agregar.id = texId.Text;
                    agregar.password = texContra.Text;
                    int retorno = funciones.agregarUsuario(agregar);
                    if (retorno > 0)
                    {
                        MessageBox.Show("Se agrego correctamente");

                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar");
                    }
                }

            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
