using Firebase.Database;
using Firebase.Database.Query;
using MateoPumacahua.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateoPumacahua.FireBase
{
    public class AdminDataFB
    {
        private FirebaseClient DataAdmin;

        public AdminDataFB()
        {
            DataAdmin = new FirebaseClient("https://mateopumacahuaoficial-default-rtdb.firebaseio.com/");
        }

        // metodo para iniciar secion con ide y contraseña
        public async Task<List<Admins>> IniciarSesion_Admin(int ideGUI, string ContraseñaGUI)
        {
            // llamamos a mostrar todos los administradores para poder
            var todosAdministrador = await MostrarDatosAdmin();

            // verificamos si existe un administrador mediante (ide y contraseña)
            // si existe retorna una listar con todos los datos del administrador 
            // si no retorna una lista vacia
            return todosAdministrador.Where(Alum =>
            Alum.Ide == ideGUI && Alum.Password == ContraseñaGUI).
            ToList();

        }

        // metodo para obtener datos de inicio sesion mediante ide alumno
        public async Task<List<Admins>> IniciarSesionApp_Admin(string IdAdmin)
        {
            // llamamos a mostrar todos los administradores para poder
            var todosAdministrador = await MostrarDatosAdmin();

            // verificamos si existe un administrador mediante (ide y contraseña)
            // si existe retorna una listar con todos los datos del administrador 
            // si no retorna una lista vacia
            return todosAdministrador.Where(Admin =>
            Admin.IdeAdmin == IdAdmin).ToList();
        }

        // metodo de agragar alumnos
        public async Task AgregarDatosAdmin(Admins _newDataAdmin)
        {
            await DataAdmin
                .Child("Admin")
                .PostAsync(new Admins()
                {
                    Ide = _newDataAdmin.Ide,
                    Password = _newDataAdmin.Password,
                    Name = _newDataAdmin.Name,
                    SurName = _newDataAdmin.SurName,
                    SecondName = _newDataAdmin.SecondName,
                });
        }

        // funcion de mostrar alumnos
        public async Task<List<Admins>> MostrarDatosAdmin()
        {
            return (await DataAdmin
                .Child("Admin")
                .OnceAsync<Admins>())
                .Select(item => new Admins
                {
                    IdeAdmin = item.Key,
                    Ide = item.Object.Ide,
                    Password = item.Object.Password,
                    Name = item.Object.Name,
                    SurName = item.Object.SurName,
                    SecondName = item.Object.SecondName
                    ,
                }).ToList();
        }

    }


}
