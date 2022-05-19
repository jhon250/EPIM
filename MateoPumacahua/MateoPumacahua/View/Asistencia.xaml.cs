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
    public partial class Asistencia : ContentPage
    {
        public Asistencia(string IDE, string Data)
        {
            InitializeComponent();
            BindingContext = new AsistenciasVM(IDE,Data);
            
        }

        
    }
}