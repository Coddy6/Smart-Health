using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.mysql;
using MySql.Data.MySqlClient;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using Org.BouncyCastle.Utilities;

namespace Proyecto
{
    public partial class AltasExpedientes : Form
    {
        public AltasExpedientes()
        {

            InitializeComponent();
            registrar_Modif.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string longitud = comboId_exp.Text;
            errorProvider1.SetError(this.txtIdDoc, "");
            errorProvider1.SetError(this.txtNombreDoc, "");
            errorProvider1.SetError(this.txtCurp, "");
            errorProvider1.SetError(this.txtNombreP, "");
            errorProvider1.SetError(this.txtDomicilioD, "");
            errorProvider1.SetError(this.txtPadecimientoActual, "");
            if (string.IsNullOrWhiteSpace(txtIdDoc.Text) || string.IsNullOrWhiteSpace(comboId_exp.Text) || string.IsNullOrWhiteSpace(txtNombreDoc.Text)
                || string.IsNullOrWhiteSpace(txtNombreP.Text) || string.IsNullOrWhiteSpace(txtCurp.Text) || string.IsNullOrWhiteSpace(txtDomicilioD.Text)
                || string.IsNullOrWhiteSpace(txtPadecimientoActual.Text))
            {
                if (string.IsNullOrWhiteSpace(txtIdDoc.Text))
                {
                    errorProvider1.SetError(this.txtIdDoc, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(comboId_exp.Text))
                {
                    errorProvider1.SetError(this.comboId_exp, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtNombreDoc.Text))
                {
                    errorProvider1.SetError(this.txtNombreDoc, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtCurp.Text))
                {
                    errorProvider1.SetError(this.txtCurp, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtNombreP.Text))
                {
                    errorProvider1.SetError(this.txtNombreP, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtDomicilioD.Text))
                {
                    errorProvider1.SetError(this.txtDomicilioD, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtPadecimientoActual.Text))
                {
                    errorProvider1.SetError(this.txtPadecimientoActual, "Rellenar espacio en blanco");
                }
            }
            else
            {

                bool entro = false;
                MySqlCommand conectar = new MySqlCommand(String.Format("select * from expediente where Id_Exp =  '{0}'", comboId_exp.Text), conexion.obtenerConexion());
                MySqlDataReader leer = conectar.ExecuteReader();

                while (leer.Read())
                {
                    Expediente s = new Expediente();
                    s.Id_Exp = leer.GetString(1);
                    string idexp = s.Id_Exp;

                    if (idexp == comboId_exp.Text)
                    {
                        entro = true;
                    }
                }

                if(entro == false)
                {
                    if (txtCurp.TextLength < 18)
                    {
                        MessageBox.Show("Agrege los 18 caracteres");
                        if (longitud.Length < 13)
                        {
                            MessageBox.Show("Agrege los 13 caracteres");
                        }
                        else if (txtCurp.TextLength == 18 && longitud.Length == 13)
                        {
                            Expediente agregar = new Expediente();
                            agregar.Id_Doc = txtIdDoc.Text;
                            agregar.Id_Exp = comboId_exp.Text;
                            agregar.nombreD = txtNombreDoc.Text;
                            agregar.domicilioD = txtDomicilioD.Text;
                            agregar.nombreIns = txtNombreIns.Text;
                            agregar.nombreP = txtNombreP.Text;
                            agregar.apellidoPaternoP = txtApellidoPaternoP.Text;
                            agregar.apellidoMaternoP = txtApellidoMaternoP.Text;
                            agregar.curpP = txtCurp.Text;
                            agregar.domicilioP = txtDomicilioP.Text;
                            agregar.fechaNacP = txtFechaNacP.Text;
                            agregar.antecHeredoFam = AntHeredoFam.Text;
                            agregar.antecPerNoPato = AntPerNoPato.Text;
                            agregar.antecPerPato = AntPerPato.Text;
                            agregar.padecimientoActual = txtPadecimientoActual.Text;
                            agregar.interrogatorioApSis = IntApSis.Text;
                            agregar.exploracionFisica = ExploFisi.Text;
                            agregar.resultados = txtResultados.Text;
                            agregar.resultadosObtMedicamentos = ResulObtMedi.Text;
                            agregar.diagnostico = Diagnos.Text;

                            if (bbusc.Text == "true")
                            {
                                agregar.fechaNacP = txtFechaNacP.Text;
                            }
                            else
                            {
                                string fechaNacQ = dateTimePicker1.Value.ToString("yyyy/MM/dd");
                                agregar.fechaNacP = fechaNacQ;
                            }
                            agregar.comentario = txtComentario.Text;

                            int retorno = funciones.agregarExpediente(agregar);
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
                        if (longitud.Length < 13)
                        {
                            MessageBox.Show("Agrege los 13 caracteres");
                        }
                        else if (txtCurp.TextLength == 18 && longitud.Length == 13)
                        {
                            Expediente agregar = new Expediente();
                            agregar.Id_Doc = txtIdDoc.Text;
                            agregar.Id_Exp = comboId_exp.Text;
                            agregar.nombreD = txtNombreDoc.Text;
                            agregar.domicilioD = txtDomicilioD.Text;
                            agregar.nombreIns = txtNombreIns.Text;
                            agregar.nombreP = txtNombreP.Text;
                            agregar.apellidoPaternoP = txtApellidoPaternoP.Text;
                            agregar.apellidoMaternoP = txtApellidoMaternoP.Text;
                            agregar.curpP = txtCurp.Text;
                            agregar.domicilioP = txtDomicilioP.Text;
                            agregar.fechaNacP = txtFechaNacP.Text;
                            agregar.antecHeredoFam = AntHeredoFam.Text;
                            agregar.antecPerNoPato = AntPerNoPato.Text;
                            agregar.antecPerPato = AntPerPato.Text;
                            agregar.padecimientoActual = txtPadecimientoActual.Text;
                            agregar.interrogatorioApSis = IntApSis.Text;
                            agregar.exploracionFisica = ExploFisi.Text;
                            agregar.resultados = txtResultados.Text;
                            agregar.resultadosObtMedicamentos = ResulObtMedi.Text;
                            agregar.diagnostico = Diagnos.Text;

                            if (bbusc.Text == "true")
                            {
                                agregar.fechaNacP = txtFechaNacP.Text;
                            }
                            else
                            {
                                string fechaNacQ = dateTimePicker1.Value.ToString("yyyy/MM/dd");
                                agregar.fechaNacP = fechaNacQ;
                            }
                            agregar.comentario = txtComentario.Text;

                            int retorno = funciones.agregarExpediente(agregar);
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
                else
                {
                    MessageBox.Show("Id del expediente duplicado");
                }

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuDoctor NuevaVentana = new MenuDoctor();
            NuevaVentana.textBox1.Text = txtNombreDoc.Text;
            NuevaVentana.textBox2.Text = txtIdDoc.Text;
            NuevaVentana.textBox3.Text = txtDomicilioD.Text;
            NuevaVentana.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string curp = txtCurp.Text;

            MySqlCommand cono = new MySqlCommand(String.Format("select * from paciente where curp =   '{0}' ", curp), conexion.obtenerConexion());
            MySqlDataReader lea = cono.ExecuteReader();

            while (lea.Read())
            {
                Paciente c = new Paciente();

                c.nombre = lea.GetString(0);
                c.apellidoPaterno = lea.GetString(1);
                c.apellidoMaterno = lea.GetString(2);
                c.curp = lea.GetString(3);
                c.domicilio = lea.GetString(4);
                c.telefono = lea.GetString(5);
                c.genero = lea.GetString(6);
                c.fechaNac = lea.GetString(7);

                string nombre = c.nombre;
                string apellidoPaterno = c.apellidoPaterno;
                string apellidoMaterno = c.apellidoMaterno;
                string curpp = c.curp;
                string domicilio = c.domicilio;
                string fechaNac = c.fechaNac;
                string fechas = fechaNac.Remove(10, 15);
                DateTime dateValues = DateTime.ParseExact(fechas, "dd/MM/yyyy", null);
                string DIASql = dateValues.ToString("yyyy-MM-dd");


                txtNombreP.Text = nombre;
                txtApellidoMaternoP.Text = apellidoPaterno;
                txtApellidoPaternoP.Text = apellidoMaterno;
                txtCurp.Text = curpp;
                txtDomicilioP.Text = domicilio;
                txtFechaNacP.Text = DIASql;
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
            string id = txtIdDoc.Text; 
            comboId_exp.DataSource = null;
            comboId_exp.Items.Clear();
            MySqlCommand comandos = new MySqlCommand(String.Format("Select Id_Exp from expediente where Id_Doc = '{0}'", id), conexion.obtenerConexion());

            try
            {
                MySqlDataAdapter data = new MySqlDataAdapter(comandos);
                DataTable dt = new DataTable();
                data.Fill(dt);

                comboId_exp.ValueMember = "Id_Exp";
                comboId_exp.DisplayMember = "Id_Exp";
                comboId_exp.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar categorias" + ex.Message);
            }
            finally
            {

            }
        }

        private void seleccion(string exp)
        {
            string id_Exp = comboId_exp.Text;

            dateTimePicker1.Visible = false;
            txtFechaNacP.Visible = true;

            MySqlCommand cono = new MySqlCommand(String.Format("select * from expediente where Id_Exp = '{0}'", id_Exp), conexion.obtenerConexion());
            MySqlDataReader lea = cono.ExecuteReader();

            while (lea.Read())
            {
                Expediente es = new Expediente();

                es.Id_Doc = lea.GetString(0);
                es.Id_Exp = lea.GetString(1);
                es.nombreD = lea.GetString(2);
                es.domicilioD = lea.GetString(3);
                es.nombreIns = lea.GetString(4);
                es.nombreP = lea.GetString(5);
                es.apellidoPaternoP = lea.GetString(6);
                es.apellidoMaternoP = lea.GetString(7);
                es.curpP = lea.GetString(8);
                es.domicilioP = lea.GetString(9);
                es.fechaNacP = lea.GetString(10);
                string diaNac = es.fechaNacP;
                es.antecHeredoFam = lea.GetString(11);
                es.antecPerNoPato = lea.GetString(12);
                es.antecPerPato = lea.GetString(13);
                es.padecimientoActual = lea.GetString(14);
                es.interrogatorioApSis = lea.GetString(15);
                es.exploracionFisica = lea.GetString(16);
                es.resultados = lea.GetString(17);
                es.resultadosObtMedicamentos = lea.GetString(18);
                es.diagnostico = lea.GetString(19);
                es.comentario = lea.GetString(20);
                string DiaN = diaNac.Remove(10, 15);
                es.fechaNacP = DiaN;


                string iddoc = es.Id_Doc;
                string idexp = es.Id_Exp;
                string nombred = es.nombreD;
                string domiciliod = es.domicilioD;
                string nombreins = es.nombreIns;
                string nombrep = es.nombreP;
                string apellidoPaP = es.apellidoPaternoP;
                string apellidoMaP = es.apellidoMaternoP;
                string curpp = es.curpP;
                string domicilioP = es.domicilioP;
                string dianac = es.fechaNacP;
                string anteheredofam = es.antecHeredoFam;
                string antepernopat = es.antecPerNoPato;
                string anteperpato = es.antecPerPato;
                string padecimeintoactual = es.padecimientoActual;
                string interrogatorioapsis = es.interrogatorioApSis;
                string exploracionfisica = es.exploracionFisica;
                string resultado = es.resultados;
                string resultadoobtenidosmedicamentos = es.resultadosObtMedicamentos;
                string diagnostico = es.diagnostico;
                string comentario = es.comentario;

                DateTime dateValues = DateTime.ParseExact(dianac, "dd/MM/yyyy", null);
                string DIASql = dateValues.ToString("yyyy-MM-dd");

                txtIdDoc.Text = iddoc;
                comboId_exp.Text = idexp;
                txtNombreDoc.Text = nombred;
                txtDomicilioD.Text = domiciliod;
                txtNombreIns.Text = nombreins;
                txtNombreP.Text = nombrep;
                txtApellidoPaternoP.Text = apellidoPaP;
                txtApellidoMaternoP.Text = apellidoMaP;
                txtCurp.Text = curpp;
                txtDomicilioP.Text = domicilioP;
                txtFechaNacP.Text = DIASql;
                AntHeredoFam.Text = anteheredofam;
                AntPerNoPato.Text = antepernopat;
                AntPerPato.Text = anteperpato;
                txtPadecimientoActual.Text = padecimeintoactual;
                IntApSis.Text = interrogatorioapsis;
                ExploFisi.Text = exploracionfisica;
                txtResultados.Text = resultado;
                ResulObtMedi.Text = resultadoobtenidosmedicamentos;
                Diagnos.Text = diagnostico;
                txtComentario.Text = comentario;

                txtIdDoc.ReadOnly = true;
                txtNombreDoc.ReadOnly = true;
                txtDomicilioD.ReadOnly = true;
                txtNombreIns.ReadOnly = true;
                txtNombreP.ReadOnly = true;
                txtApellidoPaternoP.ReadOnly = true;
                txtApellidoMaternoP.ReadOnly = true;
                txtCurp.ReadOnly = true;
                txtDomicilioP.ReadOnly = true;
                txtFechaNacP.ReadOnly = true;
                AntHeredoFam.ReadOnly = true;
                AntPerNoPato.ReadOnly = true;
                AntPerPato.ReadOnly = true;
                txtPadecimientoActual.ReadOnly = true;
                IntApSis.ReadOnly = true;
                ExploFisi.ReadOnly = true;
                txtResultados.ReadOnly = true;
                ResulObtMedi.ReadOnly = true;
                Diagnos.ReadOnly = true;
                txtComentario.ReadOnly = true;


            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            txtIdDoc.ReadOnly = true;
            txtNombreDoc.ReadOnly = true;
            txtDomicilioD.ReadOnly = false;
            txtNombreIns.ReadOnly = true;
            txtNombreP.ReadOnly = true;
            txtApellidoPaternoP.ReadOnly = false;
            txtApellidoMaternoP.ReadOnly = false;
            txtCurp.ReadOnly = true;
            txtDomicilioP.ReadOnly = false;
            txtFechaNacP.ReadOnly = true;
            AntHeredoFam.ReadOnly = false;
            AntPerNoPato.ReadOnly = false;
            AntPerPato.ReadOnly = false;
            txtPadecimientoActual.ReadOnly = false;
            IntApSis.ReadOnly = false;
            ExploFisi.ReadOnly = false;
            txtResultados.ReadOnly = false;
            ResulObtMedi.ReadOnly = false;
            Diagnos.ReadOnly = false;
            txtComentario.ReadOnly = false;
            button2.Visible = false;
            registrar_Modif.Visible = true;

        }

        private void registrar_Modif_Click(object sender, EventArgs e)
        {

            string longitud = comboId_exp.Text;
            errorProvider1.SetError(this.txtIdDoc, "");
            errorProvider1.SetError(this.txtNombreDoc, "");
            errorProvider1.SetError(this.txtCurp, "");
            errorProvider1.SetError(this.txtNombreP, "");
            errorProvider1.SetError(this.txtDomicilioD, "");
            errorProvider1.SetError(this.txtPadecimientoActual, "");
            if (string.IsNullOrWhiteSpace(txtIdDoc.Text) || string.IsNullOrWhiteSpace(comboId_exp.Text) || string.IsNullOrWhiteSpace(txtNombreDoc.Text)
                || string.IsNullOrWhiteSpace(txtNombreP.Text) || string.IsNullOrWhiteSpace(txtCurp.Text) || string.IsNullOrWhiteSpace(txtDomicilioD.Text)
                || string.IsNullOrWhiteSpace(txtPadecimientoActual.Text))
            {
                if (string.IsNullOrWhiteSpace(txtIdDoc.Text))
                {
                    errorProvider1.SetError(this.txtIdDoc, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(comboId_exp.Text))
                {
                    errorProvider1.SetError(this.comboId_exp, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtNombreDoc.Text))
                {
                    errorProvider1.SetError(this.txtNombreDoc, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtCurp.Text))
                {
                    errorProvider1.SetError(this.txtCurp, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtNombreP.Text))
                {
                    errorProvider1.SetError(this.txtNombreP, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtDomicilioD.Text))
                {
                    errorProvider1.SetError(this.txtDomicilioD, "Rellenar espacio en blanco");
                }
                if (string.IsNullOrWhiteSpace(txtPadecimientoActual.Text))
                {
                    errorProvider1.SetError(this.txtPadecimientoActual, "Rellenar espacio en blanco");
                }
            }
            else
            {
                bool entro = false;
                MySqlCommand conectar = new MySqlCommand(String.Format("select * from expediente where Id_Exp =  '{0}'", comboId_exp.Text), conexion.obtenerConexion());
                MySqlDataReader leer = conectar.ExecuteReader();

                while (leer.Read())
                {
                    Expediente s = new Expediente();
                    s.Id_Exp = leer.GetString(1);
                    string idexp = s.Id_Exp;

                    if (idexp == comboId_exp.Text)
                    {
                        entro = true;
                    }
                }
                if(entro == true)
                {
                    if (txtCurp.TextLength < 18)
                    {
                        MessageBox.Show("Agrege los 18 caracteres");
                        if (longitud.Length < 13)
                        {
                            MessageBox.Show("Agrege los 13 caracteres");
                        }
                        else if (txtCurp.TextLength == 18 && longitud.Length == 13)
                        {
                            MySqlCommand comando = new MySqlCommand(String.Format("UPDATE expediente set domicilioDoctor = @domicilioDoctor, nombrePaciente = @nombrePaciente, " +
                            "apellidoPaternoPaciente = @apellidoPaternoPaciente, apellidoMaternoPaciente = @apellidoMaternoPaciente, domicilioPaciente = @domicilioPaciente, " +
                            "antecedentesHeredoFamiliares = @antecedentesHeredoFamiliares, antecedentesPersonalesNoPatologicos = @antecedentesPersonalesNoPatologicos, " +
                            "antcedentesPersonalesPatologicos = @antcedentesPersonalesPatologicos, padecimientoActual = @padecimientoActual, interrogatorioApSis = @interrogatorioApSis," +
                            " exploracionFisica = @exploracionFisica, resultados = @resultados, resultadosObtenidosMedicamentos = @resultadosObtenidosMedicamentos, " +
                            "diagnosticos = @diagnosticos, comentario = @comentario where Id_Exp = @Id_Exp"), conexion.obtenerConexion());

                            comando.Parameters.AddWithValue("@domicilioDoctor", txtDomicilioD.Text);
                            comando.Parameters.AddWithValue("@nombrePaciente", txtNombreP.Text);
                            comando.Parameters.AddWithValue("@apellidoPaternoPaciente", txtApellidoPaternoP.Text);
                            comando.Parameters.AddWithValue("@apellidoMaternoPaciente", txtApellidoMaternoP.Text);
                            comando.Parameters.AddWithValue("@domicilioPaciente", txtDomicilioP.Text);
                            comando.Parameters.AddWithValue("@antecedentesHeredoFamiliares", AntHeredoFam.Text);
                            comando.Parameters.AddWithValue("@antecedentesPersonalesNoPatologicos", AntPerNoPato.Text);
                            comando.Parameters.AddWithValue("@antcedentesPersonalesPatologicos", AntPerPato.Text);
                            comando.Parameters.AddWithValue("@padecimientoActual", txtPadecimientoActual.Text);
                            comando.Parameters.AddWithValue("@interrogatorioApSis", IntApSis.Text);
                            comando.Parameters.AddWithValue("@exploracionFisica", ExploFisi.Text);
                            comando.Parameters.AddWithValue("@resultados", txtResultados.Text);
                            comando.Parameters.AddWithValue("@resultadosObtenidosMedicamentos", ResulObtMedi.Text);
                            comando.Parameters.AddWithValue("@diagnosticos", Diagnos.Text);
                            comando.Parameters.AddWithValue("@comentario", txtComentario.Text);
                            comando.Parameters.AddWithValue("@Id_Exp", comboId_exp.Text);
                            comando.ExecuteNonQuery();
                            MessageBox.Show("Datos Actualizados");
                        }
                    }
                    else
                    {
                        if (longitud.Length < 13)
                        {
                            MessageBox.Show("Agrege los 13 caracteres");
                        }
                        else if (txtCurp.TextLength == 18 && longitud.Length == 13)
                        {
                            MySqlCommand comando = new MySqlCommand(String.Format("UPDATE expediente set domicilioDoctor = @domicilioDoctor, nombrePaciente = @nombrePaciente, " +
                            "apellidoPaternoPaciente = @apellidoPaternoPaciente, apellidoMaternoPaciente = @apellidoMaternoPaciente, domicilioPaciente = @domicilioPaciente, " +
                            "antecedentesHeredoFamiliares = @antecedentesHeredoFamiliares, antecedentesPersonalesNoPatologicos = @antecedentesPersonalesNoPatologicos, " +
                            "antcedentesPersonalesPatologicos = @antcedentesPersonalesPatologicos, padecimientoActual = @padecimientoActual, interrogatorioApSis = @interrogatorioApSis," +
                            " exploracionFisica = @exploracionFisica, resultados = @resultados, resultadosObtenidosMedicamentos = @resultadosObtenidosMedicamentos, " +
                            "diagnosticos = @diagnosticos, comentario = @comentario where Id_Exp = @Id_Exp"), conexion.obtenerConexion());

                            comando.Parameters.AddWithValue("@domicilioDoctor", txtDomicilioD.Text);
                            comando.Parameters.AddWithValue("@nombrePaciente", txtNombreP.Text);
                            comando.Parameters.AddWithValue("@apellidoPaternoPaciente", txtApellidoPaternoP.Text);
                            comando.Parameters.AddWithValue("@apellidoMaternoPaciente", txtApellidoMaternoP.Text);
                            comando.Parameters.AddWithValue("@domicilioPaciente", txtDomicilioP.Text);
                            comando.Parameters.AddWithValue("@antecedentesHeredoFamiliares", AntHeredoFam.Text);
                            comando.Parameters.AddWithValue("@antecedentesPersonalesNoPatologicos", AntPerNoPato.Text);
                            comando.Parameters.AddWithValue("@antcedentesPersonalesPatologicos", AntPerPato.Text);
                            comando.Parameters.AddWithValue("@padecimientoActual", txtPadecimientoActual.Text);
                            comando.Parameters.AddWithValue("@interrogatorioApSis", IntApSis.Text);
                            comando.Parameters.AddWithValue("@exploracionFisica", ExploFisi.Text);
                            comando.Parameters.AddWithValue("@resultados", txtResultados.Text);
                            comando.Parameters.AddWithValue("@resultadosObtenidosMedicamentos", ResulObtMedi.Text);
                            comando.Parameters.AddWithValue("@diagnosticos", Diagnos.Text);
                            comando.Parameters.AddWithValue("@comentario", txtComentario.Text);
                            comando.Parameters.AddWithValue("@Id_Exp", comboId_exp.Text);
                            comando.ExecuteNonQuery();
                            MessageBox.Show("Datos Actualizados");
                        }
                    }
                }
                else
                {
                    registrar_Modif.Visible = false;
                    button2.Visible = true;
                }
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cargarCategorias();
        }

        private void comboId_exp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string exp = comboId_exp.Text;
            seleccion(exp);
        }
    }
}
