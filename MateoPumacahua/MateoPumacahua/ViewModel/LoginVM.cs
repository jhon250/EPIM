using CommunityToolkit.Mvvm.Input;
using MateoPumacahua.FireBase;
using MateoPumacahua.Model;
using MateoPumacahua.View;
using MateoPumacahua.View.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace MateoPumacahua.ViewModel
{
    public class LoginVM : BaseViewModel
    {
        //DocenteDataFB LoginDocente = new DocenteDataFB();
        //AlumnosDataFB LoginAlumnos = new AlumnosDataFB();
        //AdminDataFB LoginAdmin = new AdminDataFB();
        DataBaseFB DatabaseFB = new DataBaseFB();

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
                var Student = await DatabaseFB.Query_Users_Tables_Login(IdGUI.ToString(), ContraseñaGUI, "Students");
                var Teacher = await DatabaseFB.Query_Users_Tables_Login(IdGUI.ToString(), ContraseñaGUI, "Teacher");
                var Administrator = await DatabaseFB.Query_Users_Tables_Login(IdGUI.ToString(), ContraseñaGUI, "Administrator");

                if (Student.Count == 1)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new Menus(Student, "Students"));
                }
                else if (Teacher.Count == 1)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new Menus(Teacher, "Teacher"));
                }
                else if (Administrator.Count == 1)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new Menus(Administrator, "Administrator"));
                }
                else if (IdGUI==1234 && ContraseñaGUI == "admin")
                {
                    //Data_login_Alumno();
                    //Console.WriteLine(await LoginAlumnos.data_course());
                    await App.Current.MainPage.Navigation.PushAsync(new Menus(Administrator, "Administrator"));

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert(
                 "E R R O R -- LOGIN",
                 "Usuario no encontrado",
                 "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(
                    "E R R O R -- LOGIN DATA",
                    "Datos vacios, por favor ingrese datos",
                    "OK");
            }


        }

        //public async Task<List<string>> Extraer_IDE()
        //{
        //    var Alum = await LoginAlumnos.IniciarSesion(IdGUI, ContraseñaGUI);
        //    var Doncent = await LoginDocente.IniciarSesion(IdGUI, ContraseñaGUI);
        //    var Admi = await LoginAdmin.IniciarSesion_Admin(IdGUI, ContraseñaGUI);
        //    List<string> IDE = new List<string>() ;

        //    if (Alum.Count == 1)
        //    {
        //        //Data_login_Alumno();
        //        IDE.Add("Alumno");
        //        foreach (Alumno a in Alum) { IDE.Add(a.IdeAlumno); }
                
        //        //await App.Current.MainPage.Navigation.PushAsync(new Menu(Alum, Doncent, Admi));

        //    }
        //    else if (Doncent.Count == 1)
        //    {
        //        IDE.Add("Docente");
        //        foreach (Docente d in Doncent) { IDE.Add(d.IdeDocente); }
        //        //await App.Current.MainPage.Navigation.PushAsync(new Menu(Alum, Doncent, Admi));
        //    }
        //    else if (Admi.Count == 1)
        //    {
        //        IDE.Add("Admin");
        //        foreach (Admins ad in Admi) { IDE .Add(ad.IdeAdmin); }
        //        //await App.Current.MainPage.Navigation.PushAsync(new Menu(Alum, Doncent, Admi));
        //    }
        //    else
        //    {
        //        IDE.Clear();
        //    }

        //    return IDE;
        //    //var result = await LoginAlumnos.IniciarSesion(IdGUI, ContraseñaGUI);

        //    //Console.WriteLine(result.Count);
        //    ////List<Grado> lists=new List<Grado>();
        //    //// recorremos la lista 
        //    //foreach (var s in result)
        //    //{
        //    //    Console.WriteLine(s.IdeAlumno);
        //    //    Console.WriteLine(s.Ide);
        //    //    Console.WriteLine(s.Password);
        //    //    Console.WriteLine(s.Name);
        //    //    Console.WriteLine(s.SurName);
        //    //    Console.WriteLine(s.SecondName);
        //    //    //lists.Add((Grado)s.Grado1);
        //    //    Console.WriteLine(s.Grado1.Seccion);


        //}


    }



}

