using Firebase.Database;
using MateoPumacahua.Model;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace MateoPumacahua.FireBase
{
    public class AlumnosDataFB
    {
        private FirebaseClient DataAlumnos;
        private FirebaseClient Data;

        public AlumnosDataFB()
        {
            DataAlumnos = new FirebaseClient("https://mateopumacahuaoficial-default-rtdb.firebaseio.com/");

        }

        // metodo para iniciar secion con ide y contraseña
        public async Task<List<Alumno>> IniciarSesion(int ideGUI, string ContraseñaGUI)
        {
            // llamamos a mostrar todos los administradores para poder
            var todosAdministrador = await MostrarDatosAlumno();

            // verificamos si existe un administrador mediante (ide y contraseña)
            // si existe retorna una listar con todos los datos del administrador 
            // si no retorna una lista vacia
            return todosAdministrador.Where(Alum =>
            Alum.Ide == ideGUI && Alum.Password == ContraseñaGUI).
            ToList();

        }

        // metodo para obtener datos de inicio sesion mediante ide alumno
        public async Task<List<Alumno>> IniciarSesionApp(string IdAlumno)
        {
            // llamamos a mostrar todos los administradores para poder
            var todosAdministrador = await MostrarDatosAlumno();

            // verificamos si existe un administrador mediante (ide y contraseña)
            // si existe retorna una listar con todos los datos del administrador 
            // si no retorna una lista vacia
            return todosAdministrador.Where(Alum =>
            Alum.IdeAlumno == IdAlumno).ToList();
        }

        public async Task<List<Alumno>> Iniciar(string grado)
        {
            // llamamos a mostrar todos los administradores para poder
            var todosAdministrador = await MostrarDatosAlumno();

            // verificamos si existe un administrador mediante (ide y contraseña)
            // si existe retorna una listar con todos los datos del administrador 
            // si no retorna una lista vacia
            return todosAdministrador.Where(Alum =>
            Alum.Grado.Grados == grado).ToList();
        }

        public async Task<List<Alumno>> Data_ListWiew(string IdeDocente, string Hora_Inicio)
        {
            var AllAlumno = await MostrarDatosAlumno();
            return AllAlumno.Where(Alum =>
            Alum.Grado.Cursoss.IdeDocenteC == IdeDocente && Alum.Grado.Cursoss.Hora_inicio == Hora_Inicio).ToList();
        }

//public async Task<List<Alumno>> ActualizarDocente(string Grado, string Seccion)
        //{
        //    var da = await MostrarDatosAlumno();
        //    return da.Where(Alum =>
        //    Alum.Grado.Grados == Grado && Alum.Grado.Seccion == Seccion).ToList();
        //}

        //public async Task Actualizar_Alumno(Alumno upAlumno)
        //{
        //    await DataAlumnos.
        //        Child("Alumnos").
        //        Child(upAlumno.IdeAlumno).
        //        PutAsync(upAlumno);
        //}

        // metodo de agragar alumnos
        public async Task AgregarDatosAlumno(
            Alumno _newDataAlumno,
            Grado _newGradoAlumno)
        {
            await DataAlumnos
                .Child("Alumnos")
                .PostAsync(new Alumno()
                {
                    IdeAlumno = _newDataAlumno.IdeAlumno,
                    Ide = _newDataAlumno.Ide,
                    Password = _newDataAlumno.Password,
                    Name = _newDataAlumno.Name,
                    SurName = _newDataAlumno.SurName,
                    Correo = _newDataAlumno.Correo,
                    Genero = _newDataAlumno.Genero,
                    SecondName = _newDataAlumno.SecondName,
                    Grado = _newGradoAlumno,
                });
        }

        // funcion de mostrar alumnos
        public async Task<List<Alumno>> MostrarDatosAlumno()
        {
            return (await DataAlumnos
                .Child("Alumnos")
                .OnceAsync<Alumno>())
                .Select(item => new Alumno {
                    IdeAlumno = item.Key,
                    Ide = item.Object.Ide,
                    Password = item.Object.Password,
                    Name = item.Object.Name,
                    SurName = item.Object.SurName,
                    SecondName = item.Object.SecondName,
                    Correo = item.Object.Correo,
                    Genero = item.Object.Genero,
                    Grado = item.Object.Grado,
                }).ToList();
        }
       //public async Task<List<Alumno>> MostrarAlumnos_Asistencia(int Grado,string Seccion,string IdeDocente)
        //{
        //    var Alumn = await MostrarDatosAlumno();
        //    if (Grado == 1)
        //    {
        //        return Alumn.Where(Alum =>
        //        Alum.Grado1.Seccion == Seccion && 
        //        Alum.Grado1.IdeDocenteG == IdeDocente ).ToList();
        //    }
        //    else if (Grado == 2)
        //    {
        //        return Alumn.Where(Alum =>
        //        Alum.Grado2.Seccion == Seccion).ToList();
        //    }
        //    else if (Grado == 3)
        //    {
        //        return Alumn.Where(Alum =>
        //        Alum.Grado3.Seccion == Seccion).ToList();
        //    }
        //    else if (Grado == 4)
        //    {
        //        return Alumn.Where(Alum =>
        //        Alum.Grado4.Seccion == Seccion).ToList();
        //    }
        //    else if (Grado == 5)
        //    {
        //        return Alumn.Where(Alum =>
        //        Alum.Grado5.Seccion == Seccion).ToList();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //    //return Alumn.Where(Alum =>
        //    //Alum.Grado1.Seccion == Seccion).ToList();
        //}
    }

    public class DataBase
    {
        FirebaseClient _client;
        public DataBase(string id)
        {
            _client = new FirebaseClient("https://mateopumacahuaoficial-default-rtdb.firebaseio.com/Alumnos/"+id+"/Grado/");
        }

        public async void Fun(Course curso)
        {
            await _client.Child("Cursos").
               PostAsync(new Course()
               {
                   Curso = curso.Curso,
                   IdeDocenteC = curso.IdeDocenteC,
                   Hora_inicio = curso.Hora_inicio,
                   Hora_fin = curso.Hora_fin,

               });
        }

        public async Task<List<Course>> Course_data()
        {
            return (await _client.Child("Cursos")
                .OnceAsync<Course>())
                .Select(item => new Course
                 {
                     IdeCurso = item.Key,
                     Curso = item.Object.Curso,
                     Hora_inicio = item.Object.Hora_inicio,
                     Hora_fin=item.Object.Hora_fin,

                 }).ToList();
        }
    }

    public class DIA
    {
        FirebaseClient _client;
        public DIA(string idA,string IdC)
        {
            _client = new FirebaseClient("https://mateopumacahuaoficial-default-rtdb.firebaseio.com/Alumnos/" + idA + "/Grado/Cursos/"+IdC+"/");
        }

        public async void Dia(Day dia)
        {
            await _client.Child("Dias").
               PostAsync(new Day()
               {
                   Mes = dia.Mes,
                   Fecha = dia.Fecha,
                   Presente = dia.Presente,
                   Tarde = dia.Tarde,
                   Falta = dia.Falta,

               });
        }
    }

}
