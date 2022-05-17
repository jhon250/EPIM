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
    public partial class Horario : ContentPage
    {
        public Horario()
        {
            InitializeComponent();
        }

        private async void CalendarView_DateSelectionChanged(object sender, EventArgs arg)
        {
            await DisplayAlert("Date Changed", calendar.SelectedDates.ToString(), "OK");
        }
    }
}