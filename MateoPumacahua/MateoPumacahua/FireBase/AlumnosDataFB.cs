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
            Alum.IdeAlumno == IdAlumno ).ToList();
        }

        // metodo de agragar alumnos
        public async Task AgregarDatosAlumno(
            Alumno _newDataAlumno, 
            Grado _newGradoAlumno)
        {
            await DataAlumnos
                .Child("Alumnos")
                .PostAsync( new Alumno()
                {
                    IdeAlumno = _newDataAlumno.IdeAlumno,
                    Ide = _newDataAlumno.Ide,
                    Password = _newDataAlumno.Password,
                    Name = _newDataAlumno.Name,
                    SurName = _newDataAlumno.SurName,
                    SecondName = _newDataAlumno.SecondName,
                    Grado1 = _newGradoAlumno,
                });
        }

        // funcion de mostrar alumnos
        public async Task<List<Alumno>> MostrarDatosAlumno()
        {
            return (await DataAlumnos
                .Child("Alumnos")
                .OnceAsync<Alumno>())
                .Select(item =>new Alumno{
                    IdeAlumno = item.Key,
                    Ide = item.Object.Ide,
                    Password = item.Object.Password,
                    Name = item.Object.Name,
                    SurName = item.Object.SurName,
                    SecondName= item.Object.SecondName,
                    Grado1 = item.Object.Grado1,
                }).ToList();
        }

        
    }
}
