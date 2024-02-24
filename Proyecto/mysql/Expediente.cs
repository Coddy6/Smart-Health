using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.mysql
{
    public class Expediente
    {
        public string Id_Doc { get; set; }
        public string Id_Exp { get; set; }
        public string nombreD { get; set; }
        public string domicilioD { get; set; }
        public string nombreIns { get; set; }
        public string nombreP { get; set; }
        public string apellidoPaternoP { get; set; }
        public string apellidoMaternoP { get; set; }
        public string curpP { get; set; }
        public string domicilioP { get; set; }
        public string fechaNacP { get; set; }
        public string antecHeredoFam { get; set; }
        public string antecPerNoPato { get; set; }
        public string antecPerPato { get; set; }
        public string padecimientoActual { get; set; }
        public string interrogatorioApSis { get; set; }
        public string exploracionFisica { get; set; }
        public string resultados { get; set; }
        public string resultadosObtMedicamentos { get; set; }
        public string diagnostico { get; set; }
        public string comentario { get; set; }

        public Expediente() { }
        public Expediente(string Id_Doc, string Id_Exp, string nombreD, string domicilioD, string nombreIns,
            string nombreP, string apellidoPaternoP, string apellidoMaternoP, string curpP, string domicilioP, 
            string fechaNacP, string antecHeredoFam, string antecPerNoPato, string antecPerPato, string padecimientoActual, 
            string interrogatorioApSis, string exploracionFisica, string resultados, string resultadosObtMedicamentos, 
            string diagnostico, string comentario)
        {
            this.Id_Doc = Id_Doc;
            this.Id_Exp = Id_Exp;
            this.nombreD = nombreD;
            this.domicilioD = domicilioD;
            this.nombreIns = nombreIns;
            this.nombreP = nombreP;
            this.apellidoPaternoP = apellidoPaternoP;
            this.apellidoMaternoP = apellidoMaternoP;
            this.curpP = curpP;
            this.domicilioP = domicilioP;
            this.fechaNacP = fechaNacP;
            this.antecHeredoFam = antecHeredoFam;
            this.antecPerNoPato = antecPerNoPato;
            this.antecPerPato = antecPerPato;
            this.padecimientoActual = padecimientoActual;
            this.interrogatorioApSis = interrogatorioApSis;
            this.exploracionFisica = exploracionFisica;
            this.resultados = resultados;
            this.resultadosObtMedicamentos = resultadosObtMedicamentos;
            this.diagnostico = diagnostico;
            this.comentario = comentario;
        }
    }
}
