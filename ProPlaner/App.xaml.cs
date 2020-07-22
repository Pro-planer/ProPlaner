using ProPlaner.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProPlaner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            DependencyService.Register<MockPPTaskStore>();
            DependencyService.Register<MockPPAreaStore>();
            MainPage = new AppShell();
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
