using CommunityToolkit.Mvvm.Input;
using MateoPumacahua.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MateoPumacahua.ViewModel
{
    public class LoginVM
    {

        // Comandos del boton entrar
        public ICommand IniciarSesionGUI
        {
            get
            {
                // llamamos al metodo Inicio Sesion cuando
                // presione el boton
                return new RelayCommand(InicioSecion);
            }
        }

        private async void InicioSecion()
        {
            await Application.Current.MainPage.Navigation.PushAsync
                (new Home());
        }
    }
}
