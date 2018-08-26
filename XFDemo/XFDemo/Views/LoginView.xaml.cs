using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }
        public static async Task<bool> CheckPermissions(Permission permission)
        {
            var permissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
            var request = false;
            if (permissionStatus == PermissionStatus.Denied)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    var title = $"{permission} Permission";
                    var question =
                        $"To use this plugin the {permission} permission is required. Please go into Settings and turn on {permission} for the app.";
                    var positive = "Settings";
                    var negative = "Maybe Later";
                    var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);

                    if (task == null) return false;

                    var result = await task;
                    if (result) CrossPermissions.Current.OpenAppSettings();

                    return false;
                }

                request = true;
            }

            if (request || permissionStatus != PermissionStatus.Granted)
            {
                var shouldShowRequestPermission = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(permission);
                if (shouldShowRequestPermission)
                {
                    var newStatus = await CrossPermissions.Current.RequestPermissionsAsync(permission);
                    if (newStatus.ContainsKey(permission) && newStatus[permission] != PermissionStatus.Granted)
                    {
                        var title = $"{permission} Permission";
                        var question = $"To use the plugin the {permission} permission is required.";
                        var positive = "Settings";
                        var negative = "Maybe Later";
                        var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
                        if (task == null) return false;

                        var result = await task;
                        if (result) CrossPermissions.Current.OpenAppSettings();

                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }

            return true;
        }
        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (await CheckPermissions(Permission.Sms))
            {
                ///Do something...
            }

            if (EntryUsername.Text == "abc" && EntryPassword.Text == "123")
            {
                //Navigate to main view
                App.Current.MainPage = new NavigationPage(new MainView());
            }
            else
            {
                DisplayAlert("Error", "Wrong username or password", "OK");
            }
        }
    }
}