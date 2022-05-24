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
        public Menus(List<User_template> User, string Data)//string IDE,string Data)
        {
            InitializeComponent();

            // seleccionando el menu
            if (Data == "Students")
            {
                this.Master = new MenuDetailAlumno(User,Data);
                this.Detail = new NavigationPage(new Home(User,Data));
                App.MenuDetail = this;
            }
            else if (Data== "Teacher")
            {
                this.Master = new ManuDetailDocente(User,Data);
                this.Detail = new NavigationPage(new Home(User, Data));
                App.MenuDetail = this;
            }
            else if(Data== "Administrator")
            {
                this.Master = new MenuDetail();
                this.Detail = new NavigationPage(new Home(User, Data));
                App.MenuDetail = this;
            }
            
        }

        
    }
}