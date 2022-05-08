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
        public Home()
        {
            InitializeComponent();

            //var docente = DocenteUser;

            // llamando a frame Mi Cuenta
            miCuentaGUI.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    miCuenta();
                })
            });


            // llamando a frame matePumacahu
            matePumacahuGUI.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    PaginaWebMatePumacahua();
                })
            });


            // llamando a frame tomar Asistencia
            tomarAsistenciaGUI.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    tomarAsistencia();
                })
            });

            // llamando a frame Mi Horario
            horarioGUI.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    horarios();
                })
            });

        }



        // imagen de mujer "cambiante" link =>
        // https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDehK2CpShuXJEieOi_qvXpfrj2s-m9c3cGA&usqp=CAU 



        // campo Mi cuenta
        private async void miCuenta()
        {
            //  navegando a ventana de inicio del MicuentaDocente
            await Navigation.PushAsync(new MiPerfil());
        }


        // campo Mateo Pumacahua
        private async void PaginaWebMatePumacahua()
        {
            //  navegando a ventana de inicio del MateoPumacahua
            //await Navigation.PushAsync(new MateoPumacahua());
        }


        // campo Mi horario
        private async void horarios()
        {
            //  navegando a ventana de inicio del HorariosAlumnoPage
            //await Navigation.PushAsync(new HorarioDocente());
        }


        // campo TomarAsistencia Docente
        private async void tomarAsistencia()
        {
            //  navegando a ventana de inicio del MiSalonAlumnoPage
            //await Navigation.PushAsync(new TomarAsistenciaDocente());
        }

    }
}