
using PlantProject.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PlantProject.Services;

namespace PlantProject
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            //makes client to httpt request/response


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
