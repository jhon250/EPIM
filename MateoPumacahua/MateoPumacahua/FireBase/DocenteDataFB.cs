using Firebase.Database;
using MateoPumacahua.Model;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoPumacahua.FireBase
{
    public class DocenteDataFB
    {

        private FirebaseClient DataAlumnos;

        public DocenteDataFB()
        {
            DataAlumnos = new FirebaseClient("https://mateopumacahuaoficial-default-rtdb.firebaseio.com/");
        }

        // metodo para iniciar secion con ide y contraseña
        public async Task<List<Docente>> IniciarSesion(int ideGUI, string ContraseñaGUI)
        {
            // llamamos a mostrar todos los administradores para poder
            var todosAdministrador = await MostrarDatosDocente();

            // verificamos si existe un administrador mediante (ide y contraseña)
            // si existe retorna una listar con todos los datos del administrador 
            // si no retorna una lista vacia
            return todosAdministrador.Where(Alum =>
            Alum.Ide == ideGUI && Alum.Password == ContraseñaGUI).
            ToList();

        }

        // metodo para obtener datos de inicio sesion mediante ide alumno
        public async Task<List<Docente>> IniciarSesionApp(string IdAlumno)
        {
            // llamamos a mostrar todos los administradores para poder
            var todosAdministrador = await MostrarDatosDocente();

            // verificamos si existe un administrador mediante (ide y contraseña)
            // si existe retorna una listar con todos los datos del administrador 
            // si no retorna una lista vacia
            return todosAdministrador.Where(Alum =>
            Alum.IdeDocente == IdAlumno).ToList();
        }

        // metodo de agragar alumnos
        public async Task AgregarDatosDocente(
            Docente _newDataAlumno,
            Grado _newGradoAlumno)
        {
            await DataAlumnos
                .Child("Docentes")
                .PostAsync(new Docente()
                {
                    IdeDocente = _newDataAlumno.IdeDocente,
                    Ide = _newDataAlumno.Ide,
                    Password = _newDataAlumno.Password,
                    Name = _newDataAlumno.Name,
                    SurName = _newDataAlumno.SurName,
                    SecondName = _newDataAlumno.SecondName,
                    Grado1 = _newGradoAlumno,
                });
        }

        // funcion de mostrar alumnos
        public async Task<List<Docente>> MostrarDatosDocente()
        {
            return (await DataAlumnos
                .Child("Docentes")
                .OnceAsync<Docente>())
                .Select(item => new Docente
                {
                    IdeDocente = item.Key,
                    Ide = item.Object.Ide,
                    Password = item.Object.Password,
                    Name = item.Object.Name,
                    SurName = item.Object.SurName,
                    SecondName = item.Object.SecondName,
                    Grado1 = item.Object.Grado1,
                }).ToList();
        }

    }
}
