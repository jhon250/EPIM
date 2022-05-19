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
    public partial class Menus : MasterDetailPage
    {
        public Menus(string IDE,string Data)
        {
            InitializeComponent();

            // seleccionando el menu
            if (Data == "Alumno")
            {
                this.Master = new MenuDetailAlumno();
                this.Detail = new NavigationPage(new Home(IDE,Data));
                App.MenuDetail = this;
            }
            else if (Data=="Docente")
            {
                this.Master = new ManuDetailDocente();
                this.Detail = new NavigationPage(new Home(IDE, Data));
                App.MenuDetail = this;
            }
            else
            {
                this.Master = new MenuDetail();
                this.Detail = new NavigationPage(new Home(IDE, Data));
                App.MenuDetail = this;
            }
        }

        
    }
}