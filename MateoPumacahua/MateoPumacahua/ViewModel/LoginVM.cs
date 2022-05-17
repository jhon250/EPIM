using CommunityToolkit.Mvvm.Input;
using MateoPumacahua.FireBase;
using MateoPumacahua.Model;
using MateoPumacahua.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Menu = MateoPumacahua.View.Menu.Menu;

namespace MateoPumacahua.ViewModel
{
    public class LoginVM : BaseViewModel
    {
        DocenteDataFB LoginDocente = new DocenteDataFB();
        AlumnosDataFB LoginAlumnos = new AlumnosDataFB();

        #region Atributos
        public int _IdGUI;
        public string _ContraseñaGUI;
        #endregion

        #region Propiedades
        public int IdGUI
        {
            get { return this._IdGUI; }
            set { SetValue(ref this._IdGUI, value); }
        }

        public string ContraseñaGUI
        {
            get { return this._ContraseñaGUI; }
            set { SetValue(ref this._ContraseñaGUI, value); }
        }
        #endregion

        // Comandos del boton entrar
        public ICommand IniciarSesionGUI => new Command(InicioSecion);

        public async void InicioSecion()
        {
            //await App.Current.MainPage.Navigation.PushAsync
            //    (new Home());
            if (IdGUI != 0 && ContraseñaGUI != "")
            {

                var Alum = await LoginAlumnos.IniciarSesion(IdGUI, ContraseñaGUI);
                //Console.WriteLine(Alum.Count);
                if (Alum.Count == 1)
                {
                    //Data_login_Alumno();
                    
                    await App.Current.MainPage.Navigation.PushAsync
                (new Menu(Alum));
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(
                    "E R R O R -- LOGIN",
                    "Datos vacios, por favor ingrese datos",
                    "OK");
            }


        }

        public async void Data_login_Alumno()
        {
            var result = await LoginAlumnos.IniciarSesion(IdGUI, ContraseñaGUI);

            Console.WriteLine(result.Count);
            //List<Grado> lists=new List<Grado>();
            // recorremos la lista 
            foreach (var s in result)
            {
                Console.WriteLine(s.IdeAlumno);
                Console.WriteLine(s.Ide);
                Console.WriteLine(s.Password);
                Console.WriteLine(s.Name);
                Console.WriteLine(s.SurName);
                Console.WriteLine(s.SecondName);
                //lists.Add((Grado)s.Grado1);
                Console.WriteLine(s.Grado1.Seccion);
                
                
            }


        }



    }
}
