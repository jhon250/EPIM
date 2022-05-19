using MateoPumacahua.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MateoPumacahua.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home(string IDE, string Data)
        {
            InitializeComponent();
            #region Pruevas
            //verificData_Alumno(_Alumno);
            //verificData_Docente(_Docente);
            //var docente = DocenteUser;
            // seleccionando el menu
            //if (Data == "Alumno")
            //{

            //}
            //else if (Data == "Admin")
            //{

            //}
            //else
            //{

            //}
            #endregion

            #region LLamando comandos
            // llamando a frame Mi Cuenta
            miCuentaGUI.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new MiPerfil(IDE,Data));
                })
            });


            // llamando a frame matePumacahu
            matePumacahuGUI.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new Page());
                })
            });


            // llamando a frame tomar Asistencia
            tomarAsistenciaGUI.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    if (Data=="Alumno")
                    {
                        Navigation.PushAsync(new VerAsistencias());
                    }
                    else
                    {
                        Navigation.PushAsync(new Asistencia());
                    }
                    
                })
            });

            // llamando a frame Mi Horario
            horarioGUI.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new Horario());
                })
            });
            #endregion

        }

        #region Selcetor
        public void verificData_Alumno(List<Alumno> _alumno)
        {
            
            Console.WriteLine(_alumno);
            //List<Grado> lists=new List<Grado>();
            // recorremos la lista 
            foreach (Alumno s in _alumno)
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

        public void verificData_Docente(List<Docente> _Docente)
        {
            Console.WriteLine(_Docente);

            foreach (Docente s in _Docente)
            {
                Console.WriteLine(s.IdeDocente);
                Console.WriteLine(s.Ide);
                Console.WriteLine(s.Password);
                Console.WriteLine(s.Name);
                Console.WriteLine(s.SurName);
                Console.WriteLine(s.SecondName);
                Console.WriteLine(s.Materia);
                Console.WriteLine(s.Grado1.Seccion);

            }
        }
        #endregion

        // imagen de mujer "cambiante" link =>
        // https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDehK2CpShuXJEieOi_qvXpfrj2s-m9c3cGA&usqp=CAU 

        #region MyRegion
        // campo Mi cuenta
        //private async void miCuenta(List<Alumno> _alumno,
        //    List<Docente> _docente,
        //    List<Admins> _admin)
        //{
        //    //  navegando a ventana de inicio del MicuentaDocente
        //    await Navigation.PushAsync(new MiPerfil(_alumno, _docente, _admin));
        //}


        //// campo Mateo Pumacahua
        //private async void PaginaWebMatePumacahua()
        //{
        //    //  navegando a ventana de inicio del MateoPumacahua
        //    await Navigation.PushAsync(new Page());
        //}


        //// campo Mi horario
        //private async void horarios()
        //{
        //    //  navegando a ventana de inicio del HorariosAlumnoPage
        //    await Navigation.PushAsync(new Horario());
        //}


        //// campo TomarAsistencia Docente
        //private async void tomarAsistencia()
        //{
        //    //  navegando a ventana de inicio del MiSalonAlumnoPage
        //    await Navigation.PushAsync(new Asistencia());
        //}
        #endregion

    }
}