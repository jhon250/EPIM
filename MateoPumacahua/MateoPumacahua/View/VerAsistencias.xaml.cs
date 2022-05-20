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
    public partial class VerAsistencias : ContentPage
    {
        public VerAsistencias(string IDE,string Data)
        {
            InitializeComponent();
        }
    }
}