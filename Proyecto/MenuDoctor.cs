using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.mysql;
using MySql.Data.MySqlClient;
using iText.IO.Image;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using System.IO;

namespace Proyecto
{
    public partial class MenuDoctor : Form
    {
        private Timer ti;
        public MenuDoctor()
        {
            ti = new Timer();
            ti.Tick += new EventHandler(eventoTimer);
            InitializeComponent();
            ti.Enabled = true;
        }
        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BusquedaExpediente NuevaVentana = new BusquedaExpediente();
            NuevaVentana.txtIddoc.Text = textBox2.Text;
            NuevaVentana.nombre.Text = textBox1.Text;
            NuevaVentana.direct.Text = textBox3.Text;
            NuevaVentana.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InicioSesion NuevaVentana = new InicioSesion();
            NuevaVentana.Show();
            this.Hide();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgreagrExedienteAltas NuevaVentana = new AgreagrExedienteAltas();
            NuevaVentana.txtDoctor.Text = textBox1.Text;
            NuevaVentana.Id_doc.Text = textBox2.Text;
            NuevaVentana.textDireccion.Text = textBox3.Text ;
            NuevaVentana.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CrearPDF(string id,string user)
        {
            string rutaArchivo = string.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = saveFileDialog.FileName;
                txtRutaArchivo.Text = rutaArchivo;
                PdfWriter pdfWriter = new PdfWriter("Citas.pdf");
                PdfDocument pdf = new PdfDocument(pdfWriter);
                Document documento = new Document(pdf, PageSize.LETTER);

                string[] columnas = { "Paciente", "Dia", "Hora" };

                documento.SetMargins(60, 20, 55, 20);

                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                float[] tamanios = { 5, 5, 5 };
                Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));


                foreach (String columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
                }

                string sql = "Select dia, hora, nombrePaciente FROM cita Where id_Doc = '" + id + "'";
                MySqlConnection conexionBD = conexion.obtenerConexion();

                string seleccionHorario = domainUpDown1.Text;
                string fechaEleccion = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                string mes = fechaEleccion.Remove(0, 3);
                string meses = mes.Remove(2, 5);
                string año = fechaEleccion.Remove(0, 6);
                DateTime fechael = DateTime.ParseExact(fechaEleccion, "dd/MM/yyyy", null);


                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    int semanaActual = System.Globalization.CultureInfo.InstalledUICulture.Calendar.GetWeekOfYear(fechael, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);

                    string dia = reader["dia"].ToString();
                    string Dia = dia.Remove(10, 15);
                    string Hora = reader["hora"].ToString();
                    string Paciente = reader["nombrePaciente"].ToString();

                    DateTime dateValue = DateTime.ParseExact(Dia, "dd/MM/yyyy", null);
                    string fechaode = dateValue.ToString("dd/MM/yyyy");
                    string mesF = fechaode.Remove(0, 3);
                    string mesesF = mesF.Remove(2, 5);
                    string añoF = fechaode.Remove(0, 6);

                    int semanaPedida = System.Globalization.CultureInfo.InstalledUICulture.Calendar.GetWeekOfYear(dateValue, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);

                    if (seleccionHorario == "Semana")
                    {
                        if (año == añoF)
                        {
                            if (semanaActual == semanaPedida)
                            {
                                tabla.AddCell(new Cell().Add(new Paragraph(Paciente).SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(Dia).SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(Hora).SetFont(fontContenido)));
                            }
                        }
                    }
                    else if (seleccionHorario == "Mes")
                    {
                        if (año == añoF)
                        {
                            if (meses == mesesF)
                            {
                                tabla.AddCell(new Cell().Add(new Paragraph(Paciente).SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(Dia).SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(Hora).SetFont(fontContenido)));
                            }
                        }

                    }
                    else if (seleccionHorario == "Año")
                    {
                        if (año == añoF)
                        {
                            tabla.AddCell(new Cell().Add(new Paragraph(Paciente).SetFont(fontContenido)));
                            tabla.AddCell(new Cell().Add(new Paragraph(Dia).SetFont(fontContenido)));
                            tabla.AddCell(new Cell().Add(new Paragraph(Hora).SetFont(fontContenido)));
                        }
                    }
                }

                documento.Add(tabla);
                documento.Close();
                conexionBD.Close();

                var titulo = new Paragraph("Citas del doctor/a - " + user + ".");
                titulo.SetTextAlignment(TextAlignment.CENTER);
                titulo.SetFontSize(12);

                var dfecha = DateTime.Now.ToString("dd-MM-yyyy");
                var dhora = DateTime.Now.ToString("hh:mm:ss");
                var fecha = new Paragraph("Fecha: " + dfecha + "\nHora: " + dhora);

                string rutaNueva = rutaArchivo;
                PdfDocument pdfDoc = new PdfDocument(new PdfReader("Citas.pdf"), new PdfWriter(rutaNueva));
                Document doc = new Document(pdfDoc);

                int numeros = pdfDoc.GetNumberOfPages();
                for (int i = 1; i <= numeros; i++)
                {
                    PdfPage pagina = pdfDoc.GetPage(i);

                    float y = (pdfDoc.GetPage(i).GetPageSize().GetTop() - 15);
                    //doc.ShowTextAligned(plogo, 40, y,i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                    doc.ShowTextAligned(titulo, 150, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                    doc.ShowTextAligned(fecha, 520, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                    doc.ShowTextAligned(new Paragraph(string.Format("Pagina {0} de {1}", i, numeros)), pdfDoc.GetPage(i).GetPageSize().GetWidth() / 2, pdfDoc.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                }
                doc.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            string user = textBox1.Text;
            CrearPDF(id,user);
        }

        private void eventoTimer(object ob, EventArgs evt)
        {
            DateTime hoy = DateTime.Now;
            Hora.Text = hoy.ToString("HH:mm:ss tt");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Lunes_9.Clear();
            Lunes_10.Clear();
            Lunes_11.Clear();
            Lunes_12.Clear();
            Lunes_1.Clear();
            Lunes_2.Clear();
            Lunes_3.Clear();
            Lunes_4.Clear();
            Lunes_5.Clear();
            Martes_9.Clear();
            Martes_10.Clear();
            Martes_11.Clear();
            Martes_12.Clear();
            Martes_1.Clear();
            Martes_2.Clear();
            Martes_3.Clear();
            Martes_4.Clear();
            Martes_5.Clear();
            Miercoles_9.Clear();
            Miercoles_10.Clear();
            Miercoles_11.Clear();
            Miercoles_12.Clear();
            Miercoles_1.Clear();
            Miercoles_2.Clear();
            Miercoles_3.Clear();
            Miercoles_4.Clear();
            Miercoles_5.Clear();
            Jueves_9.Clear();
            Jueves_10.Clear();
            Jueves_11.Clear();
            Jueves_12.Clear();
            Jueves_1.Clear();
            Jueves_2.Clear();
            Jueves_3.Clear();
            Jueves_4.Clear();
            Jueves_5.Clear();
            Viernes_9.Clear();
            Viernes_10.Clear();
            Viernes_11.Clear();
            Viernes_12.Clear();
            Viernes_1.Clear();
            Viernes_2.Clear();
            Viernes_3.Clear();
            Viernes_4.Clear();
            Viernes_5.Clear();
            string iddoc = textBox2.Text;
            MySqlCommand cono = new MySqlCommand(String.Format("select * from cita where id_Doc = '{0}' order by hora", iddoc), conexion.obtenerConexion());
            MySqlDataReader lea = cono.ExecuteReader();


            string seleccionHorario = domainUpDown1.Text;
            string fechaEleccion = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string mes = fechaEleccion.Remove(0, 3);
            string meses = mes.Remove(2, 5);
            string año = fechaEleccion.Remove(0, 6);

            DateTime fechael = DateTime.ParseExact(fechaEleccion, "dd/MM/yyyy", null);

            while (lea.Read())
            {
                int semanaActual = System.Globalization.CultureInfo.InstalledUICulture.Calendar.GetWeekOfYear(fechael, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                string sems = Convert.ToString(semanaActual);



                Cita c = new Cita();
                c.hora = lea.GetString(2);
                c.nombrePaciente = lea.GetString(4);
                c.dia = lea.GetString(1);
                string dia = c.dia;
                string horas = c.hora;
                DateTime dateValues = DateTime.ParseExact(horas, "HH:mm:ss", null);
                string nomP = c.nombrePaciente;
                string Tiempo = " " + dateValues;
                string horario = Tiempo.Remove(1, 10);
               



                string HoraG = horas.Remove(2, 6);
                string DiaG = dia.Remove(10, 15);



                DateTime dateValue = DateTime.ParseExact(DiaG, "dd/MM/yyyy", null);
                string fechaode = dateValue.ToString("dd/MM/yyyy");
                string CitaP =" " + fechaode + ", " + horario + " con " + nomP + ".";
                string mesF = fechaode.Remove(0, 3);
                string mesesF = mesF.Remove(2, 5);
                string añoF = fechaode.Remove(0, 6);
                int ValorDiaDeLaSemana = (int)dateValue.DayOfWeek;
                int h = Convert.ToInt16(HoraG);


                int semanaPedida = System.Globalization.CultureInfo.InstalledUICulture.Calendar.GetWeekOfYear(dateValue, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                string SemanaP = Convert.ToString(semanaPedida);

                if (seleccionHorario == "Semana")
                {
                    if(año == añoF)
                    {
                        if (semanaActual == semanaPedida)
                        {
                            horarios(CitaP, ValorDiaDeLaSemana, h);
                        }
                    }
                }
                else if (seleccionHorario == "Mes")
                {
                    if(año == añoF)
                    {
                        if (meses == mesesF)
                        {
                            horarios(CitaP, ValorDiaDeLaSemana, h);
                        }
                    }

                }else if(seleccionHorario == "Año")
                {
                    if(año == añoF)
                    {
                        horarios(CitaP, ValorDiaDeLaSemana, h);
                    }
                }

            }
        }
        public void horarios(string CitaP, int ValorDiaDeLaSemana, int h)
        {
            if (ValorDiaDeLaSemana == 1)
            {
                if (h >= 9 && h < 10)
                {
                    if (String.IsNullOrEmpty(Lunes_9.Text))
                    {
                        Lunes_9.Text = CitaP;
                    }
                    else
                    {
                        Lunes_9.Text = Lunes_9.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 10 && h < 11)
                {
                    if (String.IsNullOrEmpty(Lunes_10.Text))
                    {
                        Lunes_10.Text = CitaP;
                    }
                    else
                    {
                        Lunes_10.Text = Lunes_10.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 11 && h < 12)
                {
                    if (String.IsNullOrEmpty(Lunes_11.Text))
                    {
                        Lunes_11.Text = CitaP;
                    }
                    else
                    {
                        Lunes_11.Text = Lunes_11.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 12 && h < 13)
                {
                    if (String.IsNullOrEmpty(Lunes_12.Text))
                    {
                        Lunes_12.Text = CitaP;
                    }
                    else
                    {
                        Lunes_12.Text = Lunes_12.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 13 && h < 14)
                {
                    if (String.IsNullOrEmpty(Lunes_1.Text))
                    {
                        Lunes_1.Text = CitaP;
                    }
                    else
                    {
                        Lunes_1.Text = Lunes_1.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 14 && h < 15)
                {
                    if (String.IsNullOrEmpty(Lunes_2.Text))
                    {
                        Lunes_2.Text = CitaP;
                    }
                    else
                    {
                        Lunes_2.Text = Lunes_2.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 15 && h < 16)
                {
                    if (String.IsNullOrEmpty(Lunes_3.Text))
                    {
                        Lunes_3.Text = CitaP;
                    }
                    else
                    {
                        Lunes_3.Text = Lunes_3.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 16 && h < 17)
                {
                    if (String.IsNullOrEmpty(Lunes_4.Text))
                    {
                        Lunes_4.Text = CitaP;
                    }
                    else
                    {
                        Lunes_4.Text = Lunes_4.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 17 && h < 18)
                {
                    if (String.IsNullOrEmpty(Lunes_5.Text))
                    {
                        Lunes_5.Text = CitaP;
                    }
                    else
                    {
                        Lunes_5.Text = Lunes_5.Text + Environment.NewLine + CitaP;
                    }
                }
            }
            else if (ValorDiaDeLaSemana == 2)
            {
                if (h >= 9 && h < 10)
                {
                    if (String.IsNullOrEmpty(Martes_9.Text))
                    {
                        Martes_9.Text = CitaP;
                    }
                    else
                    {
                        Martes_9.Text = Martes_9.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 10 && h < 11)
                {
                    if (String.IsNullOrEmpty(Martes_10.Text))
                    {
                        Martes_10.Text = CitaP;
                    }
                    else
                    {
                        Martes_10.Text = Martes_10.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 11 && h < 12)
                {
                    if (String.IsNullOrEmpty(Martes_11.Text))
                    {
                        Martes_11.Text = CitaP;
                    }
                    else
                    {
                        Martes_11.Text = Martes_11.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 12 && h < 13)
                {
                    if (String.IsNullOrEmpty(Martes_12.Text))
                    {
                        Martes_12.Text = CitaP;
                    }
                    else
                    {
                        Martes_12.Text = Martes_12.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 13 && h < 14)
                {
                    if (String.IsNullOrEmpty(Martes_1.Text))
                    {
                        Martes_1.Text = CitaP;
                    }
                    else
                    {
                        Martes_1.Text = Martes_1.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 14 && h < 15)
                {
                    if (String.IsNullOrEmpty(Martes_2.Text))
                    {
                        Martes_2.Text = CitaP;
                    }
                    else
                    {
                        Martes_2.Text = Martes_2.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 15 && h < 16)
                {
                    if (String.IsNullOrEmpty(Martes_3.Text))
                    {
                        Martes_3.Text = CitaP;
                    }
                    else
                    {
                        Martes_3.Text = Martes_3.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 16 && h < 17)
                {
                    if (String.IsNullOrEmpty(Martes_4.Text))
                    {
                        Martes_4.Text = CitaP;
                    }
                    else
                    {
                        Martes_4.Text = Martes_4.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 17 && h < 18)
                {
                    if (String.IsNullOrEmpty(Martes_5.Text))
                    {
                        Martes_5.Text = CitaP;
                    }
                    else
                    {
                        Martes_5.Text = Martes_5.Text + Environment.NewLine + CitaP;
                    }
                }
            }
            else if (ValorDiaDeLaSemana == 3)
            {
                if (h >= 9 && h < 10)
                {
                    if (String.IsNullOrEmpty(Miercoles_9.Text))
                    {
                        Miercoles_9.Text = CitaP;
                    }
                    else
                    {
                        Miercoles_9.Text = Miercoles_9.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 10 && h < 11)
                {
                    if (String.IsNullOrEmpty(Miercoles_10.Text))
                    {
                        Miercoles_10.Text = CitaP;
                    }
                    else
                    {
                        Miercoles_10.Text = Miercoles_10.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 11 && h < 12)
                {
                    if (String.IsNullOrEmpty(Miercoles_11.Text))
                    {
                        Miercoles_11.Text = CitaP;
                    }
                    else
                    {
                        Miercoles_11.Text = Miercoles_11.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 12 && h < 13)
                {
                    if (String.IsNullOrEmpty(Miercoles_12.Text))
                    {
                        Miercoles_12.Text = CitaP;
                    }
                    else
                    {
                        Miercoles_12.Text = Miercoles_12.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 13 && h < 14)
                {
                    if (String.IsNullOrEmpty(Miercoles_1.Text))
                    {
                        Miercoles_1.Text = CitaP;
                    }
                    else
                    {
                        Miercoles_1.Text = Miercoles_1.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 14 && h < 15)
                {
                    if (String.IsNullOrEmpty(Miercoles_2.Text))
                    {
                        Miercoles_2.Text = CitaP;
                    }
                    else
                    {
                        Miercoles_2.Text = Miercoles_2.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 15 && h < 16)
                {
                    if (String.IsNullOrEmpty(Miercoles_3.Text))
                    {
                        Miercoles_3.Text = CitaP;
                    }
                    else
                    {
                        Miercoles_3.Text = Miercoles_3.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 16 && h < 17)
                {
                    if (String.IsNullOrEmpty(Miercoles_4.Text))
                    {
                        Miercoles_4.Text = CitaP;
                    }
                    else
                    {
                        Miercoles_4.Text = Miercoles_4.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 17 && h < 18)
                {
                    if (String.IsNullOrEmpty(Miercoles_5.Text))
                    {
                        Miercoles_5.Text = CitaP;
                    }
                    else
                    {
                        Miercoles_5.Text = Miercoles_5.Text + Environment.NewLine + CitaP;
                    }
                }
            }
            else if (ValorDiaDeLaSemana == 4)
            {
                if (h >= 9 && h < 10)
                {
                    if (String.IsNullOrEmpty(Jueves_9.Text))
                    {
                        Jueves_9.Text = CitaP;
                    }
                    else
                    {
                        Jueves_9.Text = Jueves_9.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 10 && h < 11)
                {
                    if (String.IsNullOrEmpty(Jueves_10.Text))
                    {
                        Jueves_10.Text = CitaP;
                    }
                    else
                    {
                        Jueves_10.Text = Jueves_10.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 11 && h < 12)
                {
                    if (String.IsNullOrEmpty(Jueves_11.Text))
                    {
                        Jueves_11.Text = CitaP;
                    }
                    else
                    {
                        Jueves_11.Text = Jueves_11.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 12 && h < 13)
                {
                    if (String.IsNullOrEmpty(Jueves_12.Text))
                    {
                        Jueves_12.Text = CitaP;
                    }
                    else
                    {
                        Jueves_12.Text = Jueves_12.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 13 && h < 14)
                {
                    if (String.IsNullOrEmpty(Jueves_1.Text))
                    {
                        Jueves_1.Text = CitaP;
                    }
                    else
                    {
                        Jueves_1.Text = Jueves_1.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 14 && h < 15)
                {
                    if (String.IsNullOrEmpty(Jueves_2.Text))
                    {
                        Jueves_2.Text = CitaP;
                    }
                    else
                    {
                        Jueves_2.Text = Jueves_2.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 15 && h < 16)
                {
                    if (String.IsNullOrEmpty(Jueves_3.Text))
                    {
                        Jueves_3.Text = CitaP;
                    }
                    else
                    {
                        Jueves_3.Text = Jueves_3.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 16 && h < 17)
                {
                    if (String.IsNullOrEmpty(Jueves_4.Text))
                    {
                        Jueves_4.Text = CitaP;
                    }
                    else
                    {
                        Jueves_4.Text = Jueves_4.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 17 && h < 18)
                {
                    if (String.IsNullOrEmpty(Jueves_5.Text))
                    {
                        Jueves_5.Text = CitaP;
                    }
                    else
                    {
                        Jueves_5.Text = Jueves_5.Text + Environment.NewLine + CitaP;
                    }
                }
            }
            else if (ValorDiaDeLaSemana == 5)
            {
                if (h >= 9 && h < 10)
                {
                    if (String.IsNullOrEmpty(Viernes_9.Text))
                    {
                        Viernes_9.Text = CitaP;
                    }
                    else
                    {
                        Viernes_9.Text = Viernes_9.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 10 && h < 11)
                {
                    if (String.IsNullOrEmpty(Viernes_10.Text))
                    {
                        Viernes_10.Text = CitaP;
                    }
                    else
                    {
                        Viernes_10.Text = Viernes_10.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 11 && h < 12)
                {
                    if (String.IsNullOrEmpty(Viernes_11.Text))
                    {
                        Viernes_11.Text = CitaP;
                    }
                    else
                    {
                        Viernes_11.Text = Viernes_11.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 12 && h < 13)
                {
                    if (String.IsNullOrEmpty(Viernes_12.Text))
                    {
                        Viernes_12.Text = CitaP;
                    }
                    else
                    {
                        Viernes_12.Text = Viernes_12.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 13 && h < 14)
                {
                    if (String.IsNullOrEmpty(Viernes_1.Text))
                    {
                        Viernes_1.Text = CitaP;
                    }
                    else
                    {
                        Viernes_1.Text = Viernes_1.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 14 && h < 15)
                {
                    if (String.IsNullOrEmpty(Viernes_2.Text))
                    {
                        Viernes_2.Text = CitaP;
                    }
                    else
                    {
                        Viernes_2.Text = Viernes_2.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 15 && h < 16)
                {
                    if (String.IsNullOrEmpty(Viernes_3.Text))
                    {
                        Viernes_3.Text = CitaP;
                    }
                    else
                    {
                        Viernes_3.Text = Viernes_3.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 16 && h < 17)
                {
                    if (String.IsNullOrEmpty(Viernes_4.Text))
                    {
                        Viernes_4.Text = CitaP;
                    }
                    else
                    {
                        Viernes_4.Text = Viernes_4.Text + Environment.NewLine + CitaP;
                    }
                }
                else if (h >= 17 && h < 18)
                {
                    if (String.IsNullOrEmpty(Viernes_5.Text))
                    {
                        Viernes_5.Text = CitaP;
                    }
                    else
                    {
                        Viernes_5.Text = Viernes_5.Text + Environment.NewLine + CitaP;
                    }
                }
            }
        }

    }
}
