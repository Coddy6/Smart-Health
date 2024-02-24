using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Proyecto.mysql;
using System.Configuration;
using System.Runtime.Remoting.Channels;

namespace Proyecto
{
    public partial class InicioSesion : Form
    {
        private Timer ti;
        public InicioSesion()
        {
            ti = new Timer();
            ti.Tick += new EventHandler(eventoTimer);
            InitializeComponent();
            ti.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Id.Text) || String.IsNullOrWhiteSpace(Contraseña.Text))
            {
                MessageBox.Show("Hay uno o mas campos vacios");
            }else
            {
                int band1 = 0, band2 = 0, band3 = 0;

                string contra = "";
                string nom = "";
                string id = "";
                string idR = "";
                string direccion = "";
                Usuarios w = new Usuarios();
                MySqlCommand comandoss = new MySqlCommand(String.Format("select * from usuarios where id =  '{0}' and password = '{1}'", Id.Text, Contraseña.Text), conexion.obtenerConexion());
                MySqlDataReader readerss = comandoss.ExecuteReader();
                while (readerss.Read())
                {
                    w.password = readerss.GetString(1);
                    w.id = readerss.GetString(0);
                    string Id = w.id;
                    string password = w.password;
                    if (password == Contraseña.Text)
                    {
                        contra = w.password;
                        id = w.id;
                    }
                }

                MySqlCommand conectar = new MySqlCommand(String.Format("select * from doctor where Id_Doctor =  '{0}'", Id.Text), conexion.obtenerConexion());
                MySqlDataReader leer = conectar.ExecuteReader();

                if (leer.Read())
                {
                    band1 = 1;
                    Doctor s = new Doctor();
                    MySqlCommand comand = new MySqlCommand(String.Format("select * from doctor where Id_Doctor =  '{0}'", Id.Text), conexion.obtenerConexion());
                    MySqlDataReader read = comand.ExecuteReader();
                    while (read.Read())
                    {
                        s.Id = read.GetString(0);
                        s.nombre = read.GetString(1);
                        s.domicilio = read.GetString(5);
                        direccion = s.domicilio;
                        string Idd = s.Id;

                        nom = s.nombre;
                        if (Idd == Id.Text)
                        {
                            idR = s.Id;
                        }
                    }
                }

                MySqlCommand cono = new MySqlCommand(String.Format("select * from recepcionista where Id_Recepcionista = '{0}'", Id.Text), conexion.obtenerConexion());
                MySqlDataReader lea = cono.ExecuteReader();

                if (lea.Read())
                {
                    band2 = 1;
                    Recepcionista s = new Recepcionista();
                    MySqlCommand comand = new MySqlCommand(String.Format("select * from recepcionista where Id_Recepcionista =  '{0}'", Id.Text), conexion.obtenerConexion());
                    MySqlDataReader read = comand.ExecuteReader();
                    while (read.Read())
                    {
                        s.Id = read.GetString(0);
                        string Idd = s.Id;
                        if (Idd == Id.Text)
                        {
                            idR = s.Id;
                        }
                    }
                }
                MySqlCommand con = new MySqlCommand(String.Format("select * from usuarios where password = '{0}' and id = '{1}'", Contraseña.Text, Id.Text), conexion.obtenerConexion());
                MySqlDataReader l = con.ExecuteReader();

                if (l.Read())
                {
                    band3 = 1;
                }

                if ((band1 == 1) && (Contraseña.Text == contra) && (Id.Text == id) && (Id.Text == idR))
                {
                    this.Hide();
                    MenuDoctor NuevaVentana = new MenuDoctor();
                    NuevaVentana.textBox1.Text = nom;
                    NuevaVentana.textBox2.Text = Id.Text;
                    NuevaVentana.textBox3.Text = direccion;
                    NuevaVentana.Show();
                }
                else if ((band2 == 1) && (Contraseña.Text == contra) && (Id.Text == id) && (Id.Text == idR))
                {
                    this.Hide();
                    Recepcionistas NuevaVentana = new Recepcionistas();
                    NuevaVentana.Show();
                }
                else if (band3 == 1 && (Contraseña.Text == contra) && (Id.Text == id))
                {
                    this.Hide();
                    MenuAdministrador NuevaVentana = new MenuAdministrador();
                    NuevaVentana.Show();

                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void eventoTimer(object ob, EventArgs evt)
        {
            DateTime hoy = DateTime.Now;
            Horario.Text = hoy.ToString("HH:mm:ss tt");
        }

        private void Registrar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Id.Text) || String.IsNullOrWhiteSpace(Contraseña.Text))
            {
                MessageBox.Show("Hay uno o mas campos vacios");
            }
            else
            {
                MySqlCommand comando = new MySqlCommand(String.Format("select * from recepcionista where Id_Recepcionista = '{0}'", Id.Text), conexion.obtenerConexion());
                MySqlDataReader reader = comando.ExecuteReader();
                int existencia = 0;
                int existenciaDoc = 0;


                while (reader.Read())
                {
                    Recepcionista c = new Recepcionista();
                    c.Id = reader.GetString(0);
                    string id = c.Id;

                    if (id == Id.Text)
                    {
                        existencia = 1;
                    }
                    else
                    {
                        MessageBox.Show("Empleado no dado de alta");
                    }

                }
                MySqlCommand comandoDoc = new MySqlCommand(String.Format("select * from doctor where Id_Doctor = '{0}'", Id.Text), conexion.obtenerConexion());
                MySqlDataReader readerDoc = comandoDoc.ExecuteReader();

                while (readerDoc.Read())
                {
                    Doctor r = new Doctor();
                    r.Id = readerDoc.GetString(0);
                    string idDoc = r.Id;
                    string NomDoc = r.nombre;

                    if (idDoc == Id.Text)
                    {
                        existenciaDoc = 1;
                    }
                    else
                    {
                        MessageBox.Show("Empleado no dado de alta");
                    }

                }


                if (existencia == 1 || existenciaDoc == 1)
                {
                    int existenciaUsu = 0;
                    MySqlCommand comandos = new MySqlCommand(String.Format("select * from usuarios where id = '{0}'", Id.Text), conexion.obtenerConexion());
                    MySqlDataReader readers = comandos.ExecuteReader();
                    Usuarios d = new Usuarios();
                    while (readers.Read())
                    {
                        d.id = readers.GetString(0);
                        string id = d.id;
                        if (id == Id.Text)
                        {
                            existenciaUsu = 1;
                        }
                    }

                    if (existenciaUsu == 1)
                    {
                        MessageBox.Show("Usuario registrado, presione el boton Aceptar");
                    }
                    else
                    {
                        Usuarios agregar = new Usuarios();
                        agregar.id = Id.Text;
                        agregar.password = Contraseña.Text;
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
                else
                {
                    MessageBox.Show("Favor de dar de alta al empleado");
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
    }
}
