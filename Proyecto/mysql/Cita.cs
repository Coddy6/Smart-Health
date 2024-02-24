using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.mysql
{
    public class Cita
    {
        public string id_Doc { get; set; }
        public string dia { get; set; }
        public string hora { get; set; }
        public string nombreDoctor { get; set; }
        public string nombrePaciente { get; set; }

        public Cita() { }
        public Cita(string id_Doc, string dia, string hora, string nombreDoctor, string nombrePaciente)
        {
            this.id_Doc = id_Doc;
            this.dia = dia;
            this.hora = hora;
            this.nombreDoctor = nombreDoctor;
            this.nombrePaciente = nombrePaciente;

        }
    }
}
