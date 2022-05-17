using MateoPumacahua.View.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MateoPumacahua.View.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDetail : ContentPage
    {
        public MenuDetail()
        {
            InitializeComponent();
        }

        private async void Button_Add_Alumno(object sender, EventArgs e)
        {
            App.MenuDetail.IsPresented = false;
            await App.MenuDetail.Detail.Navigation.PushAsync(new InsertStudent());
        }

        private async void Button_Add_Docente(object sender, EventArgs e)
        {
            App.MenuDetail.IsPresented = false;
            await App.MenuDetail.Detail.Navigation.PushAsync(new InsertDocente());
        }
    }
}