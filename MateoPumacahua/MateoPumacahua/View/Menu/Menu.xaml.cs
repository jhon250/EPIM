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
    public partial class Menu : MasterDetailPage
    {
        public Menu( object Data)
        {
            InitializeComponent();

            this.Master = new MenuDetail();
            this.Detail = new NavigationPage(new Home(Data));
            App.MenuDetail = this;
        }
    }
}