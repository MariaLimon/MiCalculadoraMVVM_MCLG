using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MiCalculadora_MCLG.Vista;
namespace MiCalculadora_MCLG
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new calculadora();
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
