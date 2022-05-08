using MateoPumacahua.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MateoPumacahua.View.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            BindingContext = new LoginVM();


            // llamando a ¿has olvidado tu contraseña?
            olvidadoContraseña.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    olvidoContraseña();
                })
            });

        }

        

        // campo ¿Has Olvidado tu contraseña?
        private async void olvidoContraseña()
        {
            //  navegando a ventana de inicio del olvidadoContraseña
            //await Navigation.PushAsync(new OlvidadoContraseña());
        }
    }
}