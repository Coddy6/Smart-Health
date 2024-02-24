using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Proyecto.mysql;

public class funciones
{
    public static int agregar(Paciente add)
    {
        int retorno = 0;
        MySqlCommand comando = new MySqlCommand(String.Format("insert into paciente(nombre, apellidoPaterno, apellidoMaterno, curp, domicilio, telefono, genero, fechaNac) " +
            "values('{0}','{1}','{2}','{3}','{4}', '{5}', '{6}', '{7}')", 
            add.nombre,add.apellidoPaterno, add.apellidoMaterno, add.curp, add.domicilio, add.telefono, add.genero, add.fechaNac), 
            conexion.obtenerConexion());
        retorno = comando.ExecuteNonQuery();
        return retorno;
    }

    public static int agregarUsuario(Usuarios add)
    {
        int retorno = 0;
        MySqlCommand comando = new MySqlCommand(string.Format("insert into usuarios(id, password) values('{0}','{1}')", add.id, add.password), conexion.obtenerConexion());
        retorno = comando.ExecuteNonQuery();
        return retorno;
    }

    public static List<Paciente> mostrar()
    {
        List<Paciente> lista = new List<Paciente>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from paciente"), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();

        while (reader.Read())
        {
            Paciente p = new Paciente();
            p.nombre = reader.GetString(0);
            p.apellidoPaterno = reader.GetString(1);
            p.apellidoMaterno = reader.GetString(2);
            p.curp = reader.GetString(3);
            p.domicilio = reader.GetString(4);
            p.telefono = reader.GetString(5);
            p.genero = reader.GetString(6);
            p.fechaNac = reader.GetString(7);
            string diaNac = p.fechaNac;
            string DiaN = diaNac.Remove(10, 15);
            p.fechaNac = DiaN;
            lista.Add(p);
        }
        return lista;
    }

    public static List<Paciente> Buscar(string nombre, string curp)
    {
        List<Paciente> listaBuscar = new List<Paciente>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from paciente where nombre like '{0}%' and curp like '{1}%'", nombre, curp), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();
        while (reader.Read())
        {
            Paciente p = new Paciente();
            p.nombre = reader.GetString(0);
            p.apellidoPaterno = reader.GetString(1);
            p.apellidoMaterno = reader.GetString(2);
            p.curp = reader.GetString(3);
            p.domicilio = reader.GetString(4);
            p.telefono = reader.GetString(5);
            p.genero = reader.GetString(6);
            p.fechaNac = reader.GetString(7);
            string diaNac = p.fechaNac;
            string DiaN = diaNac.Remove(10, 15);
            p.fechaNac = DiaN;
            listaBuscar.Add(p);
        }
        return listaBuscar;
    }

    public static List<Paciente> BuscarExp(string nombre)
    {
        List<Paciente> listaBuscar = new List<Paciente>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from paciente where nombre like '{0}%'", nombre), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();
        while (reader.Read())
        {
            Paciente p = new Paciente();
            p.nombre = reader.GetString(0);
            p.apellidoPaterno = reader.GetString(1);
            p.apellidoMaterno = reader.GetString(2);
            p.curp = reader.GetString(3);
            p.domicilio = reader.GetString(4);
            p.telefono = reader.GetString(5);
            p.genero = reader.GetString(6);
            p.fechaNac = reader.GetString(7);
            string diaNac = p.fechaNac;
            string DiaN = diaNac.Remove(10, 15);
            p.fechaNac = DiaN;
            listaBuscar.Add(p);
        }
        return listaBuscar;
    }

    //////////////////////////////////////////////////////////////////////////////////

    public static int agregarCita(Cita add)
    {
        int retorno = 0;
        MySqlCommand comando = new MySqlCommand(String.Format("insert into cita(id_Doc, dia, hora, nombreDoctor, nombrePaciente) values('{0}','{1}','{2}','{3}','{4}')",
            add.id_Doc, add.dia, add.hora, add.nombreDoctor, add.nombrePaciente), conexion.obtenerConexion());
        retorno = comando.ExecuteNonQuery();
        return retorno;
    }


    public static List<Cita> mostrarCita()
    {
        List<Cita> lista = new List<Cita>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from cita"), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();

        while (reader.Read())
        {
            Cita c = new Cita();
            c.id_Doc = reader.GetString(0);
            c.dia = reader.GetString(1);
            string diaC = c.dia;
            string DiaCN = diaC.Remove(10, 15);
            c.hora = reader.GetString(2);
            c.nombreDoctor = reader.GetString(3);
            c.nombrePaciente = reader.GetString(4);
            c.dia = DiaCN;
            lista.Add(c);
        }
        return lista;
    }

    public static List<Cita> BuscarCita(string nombrePaciente, string nombreDoctor)
    {
        List<Cita> listaBuscar = new List<Cita>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from cita where nombrePaciente like '{0}%' and nombreDoctor like '{1}%'", nombrePaciente, nombreDoctor), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();
        while (reader.Read())
        {
            Cita c = new Cita();
            c.id_Doc = reader.GetString(0);
            c.dia = reader.GetString(1);
            string diaC = c.dia;
            string DiaCN = diaC.Remove(10, 15);
            c.hora = reader.GetString(2);
            c.nombreDoctor = reader.GetString(3);
            c.nombrePaciente = reader.GetString(4);
            c.dia = DiaCN;
            listaBuscar.Add(c);
        }
        return listaBuscar;
    }


    //////////////////////////////////////////////////////////////////////////

    public static int agregarRecepcionista(Recepcionista add)
    {
        int retorno = 0;
        MySqlCommand comando = new MySqlCommand(String.Format("insert into recepcionista(nombre, apellidoPaterno, apellidoMaterno, curp, domicilio, telefono, fechaNac, " +
            "fechaIng) values ('{0}','{1}','{2}','{3}','{4}', '{5}', '{6}', '{7}')", 
            add.nombre, add.apellidoPaterno, add.apellidoMaterno, add.curp, add.domicilio, add.telefono, add.fechaNac, add.fechaIng), 
            conexion.obtenerConexion());
        retorno = comando.ExecuteNonQuery();
        return retorno;
    }


    public static List<Recepcionista> mostrarRecepcionista()
    {
        List<Recepcionista> lista = new List<Recepcionista>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from recepcionista"), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();

        while (reader.Read())
        {
            Recepcionista r = new Recepcionista();
            r.Id = reader.GetString(0);
            r.nombre = reader.GetString(1);
            r.apellidoPaterno = reader.GetString(2);
            r.apellidoMaterno = reader.GetString(3);
            r.curp = reader.GetString(4);
            r.domicilio = reader.GetString(5);
            r.telefono = reader.GetString(6);
            r.fechaNac = reader.GetString(7);
            string diaNac = r.fechaNac;
            r.fechaIng = reader.GetString(8);
            string diaIng = r.fechaIng;
            string DiaN = diaNac.Remove(10, 15);
            string DiaI = diaIng.Remove(10, 15);
            r.fechaNac = DiaN;
            r.fechaIng = DiaI;
            lista.Add(r);
        }
        return lista;
    }

    public static List<Recepcionista> BuscarRecepcionista(string Id_Recepcionista, string nombre)
    {
        List<Recepcionista> listaBuscar = new List<Recepcionista>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from recepcionista where Id_Recepcionista like '{0}%' and nombre like '{1}%'", Id_Recepcionista, nombre), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();
        while (reader.Read())
        {
            Recepcionista r = new Recepcionista();
            r.Id = reader.GetString(0);
            r.nombre = reader.GetString(1);
            r.apellidoPaterno = reader.GetString(2);
            r.apellidoMaterno = reader.GetString(3);
            r.curp = reader.GetString(4);
            r.domicilio = reader.GetString(5);
            r.telefono = reader.GetString(6);
            r.fechaNac = reader.GetString(7);
            string diaNac = r.fechaNac;
            r.fechaIng = reader.GetString(8);
            string diaIng = r.fechaIng;
            string DiaN = diaNac.Remove(10, 15);
            string DiaI = diaIng.Remove(10, 15);
            r.fechaNac = DiaN;
            r.fechaIng = DiaI;

            listaBuscar.Add(r);
        }
        return listaBuscar;
    }

    //////////////////////////////////////////////////////////////

    public static int agregarDoctor(Doctor add)
    {
        int retorno = 0;
        MySqlCommand comando = new MySqlCommand(String.Format("insert into doctor(nombre, apellidoPaterno, apellidoMaterno, curp, " +
            "domicilio, telefono, fechaNac, fechaIng,especialidad) values ('{0}','{1}','{2}','{3}','{4}', '{5}', '{6}', '{7}', '{8}')", 
            add.nombre, add.apellidoPaterno, add.apellidoMaterno, add.curp, add.domicilio, add.telefono, add.fechaNac, add.fechaIng, add.especialidad), 
            conexion.obtenerConexion());
        retorno = comando.ExecuteNonQuery();
        return retorno;
    }


    public static List<Doctor> mostrarDoctor()
    {
        List<Doctor> lista = new List<Doctor>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from doctor"), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();

        while (reader.Read())
        {
            Doctor d = new Doctor();
            d.Id = reader.GetString(0);
            d.nombre = reader.GetString(1);
            d.apellidoPaterno = reader.GetString(2);
            d.apellidoMaterno = reader.GetString(3);
            d.curp = reader.GetString(4);
            d.domicilio = reader.GetString(5);
            d.telefono = reader.GetString(6);
            d.fechaNac = reader.GetString(7);
            string diaNac = d.fechaNac;
            d.fechaIng = reader.GetString(8);
            string diaIng = d.fechaIng;
            string DiaN = diaNac.Remove(10, 15);
            string DiaI = diaIng.Remove(10, 15);
            d.fechaNac = DiaN;
            d.fechaIng = DiaI;
            d.especialidad = reader.GetString(9);
            lista.Add(d);
        }
        return lista;
    }

    public static List<Doctor> BuscarDoctor(string nombre, string Id_Doctor)
    {
        List<Doctor> listaBuscar = new List<Doctor>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from doctor where Id_Doctor like '{0}%' and nombre like '{1}%'", Id_Doctor, nombre), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();
        while (reader.Read())
        {
            Doctor d = new Doctor();
            d.Id = reader.GetString(0);
            d.nombre = reader.GetString(1);
            d.apellidoPaterno = reader.GetString(2);
            d.apellidoMaterno = reader.GetString(3);
            d.curp = reader.GetString(4);
            d.domicilio = reader.GetString(5);
            d.telefono = reader.GetString(6);
            d.fechaNac = reader.GetString(7);
            string diaNac = d.fechaNac;
            d.fechaIng = reader.GetString(8);
            string diaIng = d.fechaIng;
            string DiaN = diaNac.Remove(10, 15);
            string DiaI = diaIng.Remove(10, 15);
            d.fechaNac = DiaN;
            d.fechaIng = DiaI;
            d.especialidad = reader.GetString(9);
            listaBuscar.Add(d);
        }
        return listaBuscar;
    }

    ///////////////////////////////////////////////


    public static int agregarExpediente(Expediente add)
    {
        int retorno = 0;
        MySqlCommand comando = new MySqlCommand(String.Format("insert into expediente(Id_Doc, Id_Exp, nombreDoctor, domicilioDoctor, nombreInstitucion, nombrePaciente, " +
            "apellidoPaternoPaciente, apellidoMaternoPaciente, curpPaciente, domicilioPaciente, fechaNacPaciente, antecedentesHeredoFamiliares, antecedentesPersonalesNoPatologicos, " +
            "antcedentesPersonalesPatologicos, padecimientoActual, interrogatorioApSis, exploracionFisica, resultados, resultadosObtenidosMedicamentos, diagnosticos, comentario) " +
            "values ('{0}','{1}','{2}','{3}','{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}','{15}','{16}','{17}','{18}', '{19}', " +
            "'{20}')", 
            add.Id_Doc, add.Id_Exp, add.nombreD, add.domicilioD, add.nombreIns, add.nombreP, add.apellidoPaternoP, add.apellidoMaternoP, add.curpP, 
            add.domicilioP, add.fechaNacP, add.antecHeredoFam, add.antecPerNoPato, add.antecPerPato, add.padecimientoActual, add.interrogatorioApSis, add.exploracionFisica,
            add.resultados, add.resultadosObtMedicamentos, add.diagnostico, add.comentario), conexion.obtenerConexion());
        retorno = comando.ExecuteNonQuery();
        return retorno;
    }


    public static List<Expediente> mostrarExpediente()
    {
        List<Expediente> lista = new List<Expediente>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from expediente"), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();

        while (reader.Read())
        {
            Expediente e = new Expediente();
            e.Id_Doc = reader.GetString(0);
            e.Id_Exp = reader.GetString(1);
            e.nombreD = reader.GetString(2);
            e.domicilioD = reader.GetString(3);
            e.nombreIns = reader.GetString(4);
            e.nombreP = reader.GetString(5);
            e.apellidoPaternoP = reader.GetString(6);
            e.apellidoMaternoP = reader.GetString(7);
            e.curpP = reader.GetString(8);
            e.domicilioP = reader.GetString(9);
            e.fechaNacP = reader.GetString(10);
            string diaNac = e.fechaNacP;
            e.antecHeredoFam = reader.GetString(11);
            e.antecPerNoPato = reader.GetString(12);
            e.antecPerPato = reader.GetString(13);
            e.padecimientoActual = reader.GetString(14);
            e.interrogatorioApSis = reader.GetString(15);
            e.exploracionFisica = reader.GetString(16);
            e.resultados = reader.GetString(17);
            e.resultadosObtMedicamentos = reader.GetString(18);
            e.diagnostico = reader.GetString(19);
            e.comentario = reader.GetString(20);
            string DiaN = diaNac.Remove(10, 15);
            e.fechaNacP = DiaN;
            lista.Add(e);
        }
        return lista;
    }

    public static List<Expediente> BuscarExpediente1(string Id_Exp)
    {
        List<Expediente> listaBuscar = new List<Expediente>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from expediente where Id_Exp = '{0}'", Id_Exp), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();
        while (reader.Read())
        {
            Expediente e = new Expediente();
            e.Id_Doc = reader.GetString(0);
            e.Id_Exp = reader.GetString(1);
            e.nombreD = reader.GetString(2);
            e.domicilioD = reader.GetString(3);
            e.nombreIns = reader.GetString(4);
            e.nombreP = reader.GetString(5);
            e.apellidoPaternoP = reader.GetString(6);
            e.apellidoMaternoP = reader.GetString(7);
            e.curpP = reader.GetString(8);
            e.domicilioP = reader.GetString(9);
            e.fechaNacP = reader.GetString(10);
            string diaNac = e.fechaNacP;
            e.antecHeredoFam = reader.GetString(11);
            e.antecPerNoPato = reader.GetString(12);
            e.antecPerPato = reader.GetString(13);
            e.padecimientoActual = reader.GetString(14);
            e.interrogatorioApSis = reader.GetString(15);
            e.exploracionFisica = reader.GetString(16);
            e.resultados = reader.GetString(17);
            e.resultadosObtMedicamentos = reader.GetString(18);
            e.diagnostico = reader.GetString(19);
            e.comentario = reader.GetString(20);
            string DiaN = diaNac.Remove(10, 15);
            e.fechaNacP = DiaN;
            listaBuscar.Add(e);
        }
        return listaBuscar;
    }

    public static List<Expediente> BuscarExpediente2(string Id_Doc, string curpPaciente)
    {
        List<Expediente> listaBuscar = new List<Expediente>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from expediente where Id_Doc = '{0}' and curpPaciente like '{1}%'", Id_Doc, curpPaciente), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();
        while (reader.Read())
        {
            Expediente e = new Expediente();
            e.Id_Doc = reader.GetString(0);
            e.Id_Exp = reader.GetString(1);
            e.nombreD = reader.GetString(2);
            e.domicilioD = reader.GetString(3);
            e.nombreIns = reader.GetString(4);
            e.nombreP = reader.GetString(5);
            e.apellidoPaternoP = reader.GetString(6);
            e.apellidoMaternoP = reader.GetString(7);
            e.curpP = reader.GetString(8);
            e.domicilioP = reader.GetString(9);
            e.fechaNacP = reader.GetString(10);
            string diaNac = e.fechaNacP;
            e.antecHeredoFam = reader.GetString(11);
            e.antecPerNoPato = reader.GetString(12);
            e.antecPerPato = reader.GetString(13);
            e.padecimientoActual = reader.GetString(14);
            e.interrogatorioApSis = reader.GetString(15);
            e.exploracionFisica = reader.GetString(16);
            e.resultados = reader.GetString(17);
            e.resultadosObtMedicamentos = reader.GetString(18);
            e.diagnostico = reader.GetString(19);
            e.comentario = reader.GetString(20);
            string DiaN = diaNac.Remove(10, 15);
            e.fechaNacP = DiaN;
            listaBuscar.Add(e);
        }
        return listaBuscar;
    }

    public static List<Expediente> BuscarExpediente3(string Id_Doc, string nombrePaciente)
    {
        List<Expediente> listaBuscar = new List<Expediente>();
        MySqlCommand comando = new MySqlCommand(String.Format("select * from expediente where Id_Doc = '{0}' and nombrePaciente like '{1}%' ", Id_Doc, nombrePaciente), conexion.obtenerConexion());
        MySqlDataReader reader = comando.ExecuteReader();
        while (reader.Read())
        {
            Expediente e = new Expediente();
            e.Id_Doc = reader.GetString(0);
            e.Id_Exp = reader.GetString(1);
            e.nombreD = reader.GetString(2);
            e.domicilioD = reader.GetString(3);
            e.nombreIns = reader.GetString(4);
            e.nombreP = reader.GetString(5);
            e.apellidoPaternoP = reader.GetString(6);
            e.apellidoMaternoP = reader.GetString(7);
            e.curpP = reader.GetString(8);
            e.domicilioP = reader.GetString(9);
            e.fechaNacP = reader.GetString(10);
            string diaNac = e.fechaNacP;
            e.antecHeredoFam = reader.GetString(11);    //texto
            e.antecPerNoPato = reader.GetString(12);    //texto
            e.antecPerPato = reader.GetString(13);      //texto
            e.padecimientoActual = reader.GetString(14);    //texto
            e.interrogatorioApSis = reader.GetString(15);   //texto
            e.exploracionFisica = reader.GetString(16);     //texto
            e.resultados = reader.GetString(17);            //texto
            e.resultadosObtMedicamentos = reader.GetString(18); //texto
            e.diagnostico = reader.GetString(19);               //texto
            e.comentario = reader.GetString(20);                //texto
            string DiaN = diaNac.Remove(10, 15);
            e.fechaNacP = DiaN;
            listaBuscar.Add(e);
        }
        return listaBuscar;
    }

}
