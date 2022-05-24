using MateoPumacahua.Model;
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
    public partial class MenuDetailAlumno : ContentPage
    {
        List<User_template> User;
        string Data;
        public MenuDetailAlumno(List<User_template> User,
        string Data)
        {
            InitializeComponent();
            this.User = User;
            this.Data = Data;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MiPerfil(User, Data));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MiPerfil(User, Data));
        }
    }
}