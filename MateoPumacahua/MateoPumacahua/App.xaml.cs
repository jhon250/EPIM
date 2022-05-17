using MateoPumacahua.View;
using MateoPumacahua.View.Login;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MateoPumacahua
{
    public partial class App : Application
    {
        public static MasterDetailPage MenuDetail { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
