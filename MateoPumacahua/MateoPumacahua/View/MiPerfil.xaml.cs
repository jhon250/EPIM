using MateoPumacahua.Model;
using MateoPumacahua.ViewModel;
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
    public partial class MiPerfil : ContentPage
    {
        public MiPerfil(List<User_template> User, string Data)
        {
            InitializeComponent();

            BindingContext = new MiPerfilVM(User,Data);
        }
    }
}