using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Layout.Element;
using MySql.Data.MySqlClient;
using Proyecto.mysql;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Proyecto
{
    public partial class AltasCitas : Form
    {
        private Timer ti;
        public AltasCitas()
        {
            ti = new Timer();
            ti.Tick += new EventHandler(eventoTimer);
            InitializeComponent();
            cargarCategorias();
            Horad.Text = "09:00:00";
            ti.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtNombreD, "");
            errorProvider1.SetError(this.txtNombreP, "");
            if (string.IsNullOrWhiteSpace(txtNombreD.Text) || string.IsNullOrWhiteSpace(txtNombreP.Text))
            {
                if (string.IsNullOrWhiteSpace(txtNombreD.Text))
                {
                    errorProvider1.SetError(this.txtNombreD, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtNombreP.Text))
                {
                    errorProvider1.SetError(this.txtNombreP, "Rellenar espacio en blanco");
                }
            }else
            {
                bool banderaDoc = false;
                string nombre = "";
                Doctor dd =  new Doctor();
                MySqlCommand comand = new MySqlCommand(String.Format("select * from doctor where Id_Doctor =  '{0}'", Id_DocCombo.Text), conexion.obtenerConexion());
                MySqlDataReader read = comand.ExecuteReader();
                while (read.Read())
                {
                    dd.nombre = read.GetString(1);
                    nombre = dd.nombre;
                    banderaDoc = true;
                }

                if(banderaDoc == true)
                {
                    txtNombreD.Text = nombre;
                    string fechaNacQ = dateTimePicker1.Value.ToString("yyyy/MM/dd");
                    string fechaNac = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                    string fechaHora = Horad.Text;
                    Cita agregar = new Cita();
                    agregar.id_Doc = Id_DocCombo.Text;
                    agregar.dia = fechaNacQ;
                    agregar.hora = fechaHora;
                    agregar.nombreDoctor = txtNombreD.Text;
                    agregar.nombrePaciente = txtNombreP.Text;
                    string dia = fechaNac;
                    string dias = dia.Remove(2, 8);
                    string mes = dia.Remove(0, 3);
                    string messs = mes.Remove(2, 5);
                    string años = dia.Remove(0, 6);
                    string hora = fechaHora;
                    string horas = hora.Remove(2, 6);
                    int h = Convert.ToInt16(horas);
                    string minutos = hora.Remove(0, 3);
                    string min = minutos.Remove(2, 3);
                    int MinH = Convert.ToInt16(min);
                    string hhh = Hora.Text;
                    String Hooo = hhh.Remove(2, 6);
                    int Horaa = Convert.ToInt16(Hooo);
                    string minutosH = hhh.Remove(0, 3);
                    string minH = minutosH.Remove(2, 3);
                    int Min = Convert.ToInt16(minH);
                    String Dias = Dia.Text;
                    string DD = Dias.Remove(2, 8);
                    string mm = Dias.Remove(0, 3);
                    string MM = mm.Remove(2, 5);
                    string YY = Dias.Remove(0, 6);

                    int DDDD = Convert.ToInt16(DD);
                    int MMMM = Convert.ToInt16(MM);
                    int YYYY = Convert.ToInt16(YY);
                    int d = Convert.ToInt16(dias);
                    int m = Convert.ToInt16(messs);
                    int y = Convert.ToInt16(años);

                    String date = "" + dias + "/" + messs + "/" + años;

                    DateTime dateValue = DateTime.ParseExact(date, "dd/MM/yyyy", null);
                    int ValorDiaDeLaSemana = (int)dateValue.DayOfWeek;
                    if (ValorDiaDeLaSemana >= 1 && ValorDiaDeLaSemana <= 5)
                    {
                        if (h >= 9 && h <= 17)
                        {

                            if (d >= DDDD && m == MMMM && y == YYYY)
                            {
                                if (d == DDDD)
                                {
                                    if (h >= Horaa)
                                    {
                                        if (MinH >= Min)
                                        {
                                            bool funciona = false;
                                            MySqlCommand comandos = new MySqlCommand(String.Format("Select * from cita where id_Doc = '{0}' and dia = '{1}' and hora = '{2}'", Id_DocCombo.Text, fechaNacQ, fechaHora), conexion.obtenerConexion());
                                            MySqlDataReader readesa = comandos.ExecuteReader();
                                            while (readesa.Read())
                                            {
                                                funciona = true;
                                            }

                                            if (funciona == false)
                                            {
                                                int retorno = funciones.agregarCita(agregar);
                                                if (retorno > 0)
                                                {
                                                    MessageBox.Show("Se agrego correctamente");
                                                }
                                                else
                                                {
                                                    MessageBox.Show("No se pudo agregar");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Horario no disponible");
                                            }
                                            readesa.Close();

                                        }
                                        else
                                        {
                                            MessageBox.Show("Agendar al siguiente turno de cita");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Hora pasada");
                                    }
                                }
                                else
                                {
                                    bool funciona = false;
                                    MySqlCommand comandos = new MySqlCommand(String.Format("Select * from cita where id_Doc = '{0}' and dia = '{1}' and hora = '{2}'", Id_DocCombo.Text , fechaNacQ, fechaHora), conexion.obtenerConexion());
                                    MySqlDataReader readesa = comandos.ExecuteReader();
                                    while (readesa.Read())
                                    {
                                        funciona = true;
                                    }

                                    if (funciona == false)
                                    {
                                        int retorno = funciones.agregarCita(agregar);
                                        if (retorno > 0)
                                        {
                                            MessageBox.Show("Se agrego correctamente");
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se pudo agregar");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Horario no disponible");
                                    }
                                    readesa.Close();
                                }
                            }
                            else if(y > YYYY)
                            {
                                bool funciona = false;
                                MySqlCommand comandos = new MySqlCommand(String.Format("Select * from cita where id_Doc = '{0}' and dia = '{1}' and hora = '{2}'", Id_DocCombo.Text, fechaNacQ, fechaHora), conexion.obtenerConexion());
                                MySqlDataReader readesa = comandos.ExecuteReader();
                                while (readesa.Read())
                                {
                                    funciona = true;
                                }

                                if (funciona == false)
                                {
                                    int retorno = funciones.agregarCita(agregar);
                                    if (retorno > 0)
                                    {
                                        MessageBox.Show("Se agrego correctamente");
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo agregar");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Horario no disponible");
                                }
                                readesa.Close();
                            }
                            else
                            {
                                MessageBox.Show("Dia fuera de la semana/Dia pasado");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Hora no valida - Solo de 9am a 6pm - sistema de 24 horas");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dia no valido - Solo de Lunes a Viernes");
                    }
                }
                else
                {
                    MessageBox.Show("Doctor no existente (Cambie ID)", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Recepcionistas NuevaVentana = new Recepcionistas();
            NuevaVentana.Show();
        }
        private void eventoTimer(object ob, EventArgs evt)
        {
            DateTime hoy = DateTime.Now;
            Hora.Text = hoy.ToString("HH:mm:ss");
            DateTime Hoy = DateTime.Now;
            Dia.Text = Hoy.ToString("dd/MM/yyyy");
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

        private void txthora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 59 && e.KeyChar <= 255))
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

        private void cargarCategorias()
        {
            Id_DocCombo.DataSource = null;
            Id_DocCombo.Items.Clear();
            MySqlCommand comandos = new MySqlCommand(String.Format("Select Id_Doctor from doctor order by Id_Doctor"), conexion.obtenerConexion());

            try
            {
                MySqlDataAdapter data = new MySqlDataAdapter(comandos);
                DataTable dt = new DataTable();
                data.Fill(dt);

                Id_DocCombo.ValueMember = "Id_Doctor";
                Id_DocCombo.DisplayMember = "Id_Doctor";
                Id_DocCombo.DataSource = dt;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error al cargar categorias" + ex.Message);
            }
            finally
            {
            
            }
        }
    }

}
