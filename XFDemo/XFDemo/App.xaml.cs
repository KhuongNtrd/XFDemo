using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFDemo.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFDemo
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

#if DEBUG
            LiveReload.Init();
#endif

            MainPage = new NavigationPage(new MainView());
        }
    }
}
