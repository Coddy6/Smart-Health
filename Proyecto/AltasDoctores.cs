using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Proyecto.mysql;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Proyecto
{
    public partial class AltasDoctores : Form
    {
        public AltasDoctores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuAdministrador NuevaVentana = new MenuAdministrador();
            NuevaVentana.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.txtNombre, "");
            errorProvider1.SetError(this.txtCurp, "");
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCurp.Text))
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    errorProvider1.SetError(this.txtNombre, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtCurp.Text))
                {
                    errorProvider1.SetError(this.txtCurp, "Rellenar espacio en blanco");
                }
            }else
            {
                bool entro = false;
                MySqlCommand conectar = new MySqlCommand(String.Format("select * from doctor where curp =  '{0}'", txtCurp.Text), conexion.obtenerConexion());
                MySqlDataReader leer = conectar.ExecuteReader();

                while (leer.Read())
                {
                    Doctor s = new Doctor();
                    s.curp = leer.GetString(4);
                    string curp = s.curp;

                    if (curp == txtCurp.Text)
                    {
                        entro = true;
                    }
                }
                if (entro == false)
                {
                    bool Aceptado = false;
                    bool Ingresado = false;
                    string fechaActual;
                    DateTime Hoy = DateTime.Now;
                    fechaActual = Hoy.ToString("yyyy/MM/dd");
                    int año = Convert.ToInt32(fechaActual.Remove(4, 6));
                    string mesA = fechaActual.Remove(0, 5);
                    int mes = Convert.ToInt32(mesA.Remove(2, 3));
                    int dia = Convert.ToInt32(fechaActual.Remove(0, 8));


                    string fechaNac = dateTimePicker1.Value.ToString("yyyy/MM/dd");
                    int añoNac = Convert.ToInt32(fechaNac.Remove(4, 6));

                    if ((año - añoNac) >= 26)
                    {
                        Aceptado = true;
                    }
                    else
                    {
                        MessageBox.Show("Fuera del rango de edad - 26");
                    }

                    string fechaIng = dateTimePicker2.Value.ToString("yyyy/MM/dd");
                    int añoIng = Convert.ToInt32(fechaIng.Remove(4, 6));
                    string mesAIng = fechaIng.Remove(0, 5);
                    int mesIng = Convert.ToInt32(mesAIng.Remove(2, 3));
                    int diaIng = Convert.ToInt32(fechaIng.Remove(0, 8));

                    if (Aceptado == true)
                    {
                        if (añoIng == año)
                        {
                            if (mesIng == mes)
                            {
                                if (diaIng == dia)
                                {
                                    Ingresado = true;
                                }
                                else if(diaIng < dia)
                                {
                                    Ingresado = true;
                                }
                                else
                                {
                                    MessageBox.Show("Tomar un dia antes o el de la fecha actual - Fecha de ingreso");
                                }
                            }
                            else if(mesIng < mes)
                            {
                                if(diaIng == dia)
                                {
                                    Ingresado = true;
                                }else if(diaIng < dia)
                                {
                                    Ingresado = true;
                                }
                                else
                                {
                                    MessageBox.Show("Tomar un dia antes o el de la fecha actual - Fecha de ingreso");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Tomar un mes anterior o el de la fecha actual - Fecha de ingreso");
                            }
                        }else if(añoIng < año)
                        {
                            Ingresado = true;
                        }
                        else
                        {
                            MessageBox.Show("Tomar un año anterior o el de la fecha actual - Fecha de ingreso");
                        }
                    }


                    if (Aceptado == true && Ingresado == true)
                    {
                        if (txtCurp.TextLength < 18)
                        {
                            MessageBox.Show("Agrege los 18 caracteres");
                            if (txtTelefono.TextLength >= 1 && txtTelefono.TextLength < 10)
                            {
                                MessageBox.Show("Agrege los 10 caracteres");
                            }
                            else if (txtCurp.TextLength == 18 && (txtTelefono.TextLength == 10 || txtTelefono.TextLength == 0))
                            {
                                Doctor agregar = new Doctor();
                                agregar.nombre = txtNombre.Text;
                                agregar.apellidoPaterno = txtApellidoP.Text;
                                agregar.apellidoMaterno = txtApellidoM.Text;
                                agregar.curp = txtCurp.Text;
                                agregar.domicilio = txtDomicilio.Text;
                                agregar.telefono = txtTelefono.Text;
                                agregar.fechaNac = fechaNac;
                                agregar.fechaIng = fechaIng;
                                agregar.especialidad = especialidadcombo.Text;
                                int retorno = funciones.agregarDoctor(agregar);
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
                            if (txtTelefono.TextLength >= 1 && txtTelefono.TextLength < 10)
                            {
                                MessageBox.Show("Agrege los 10 caracteres");
                            }
                            else if (txtCurp.TextLength == 18 && (txtTelefono.TextLength == 10 || txtTelefono.TextLength == 0))
                            {
                                Doctor agregar = new Doctor();
                                agregar.nombre = txtNombre.Text;
                                agregar.apellidoPaterno = txtApellidoP.Text;
                                agregar.apellidoMaterno = txtApellidoM.Text;
                                agregar.curp = txtCurp.Text;
                                agregar.domicilio = txtDomicilio.Text;
                                agregar.telefono = txtTelefono.Text;
                                agregar.fechaNac = fechaNac;
                                agregar.fechaIng = fechaIng;
                                agregar.especialidad = especialidadcombo.Text;
                                int retorno = funciones.agregarDoctor(agregar);
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
                }
                else
                {
                    MessageBox.Show("CURP ya registrada");
                }
                
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void txtCurp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras y numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
