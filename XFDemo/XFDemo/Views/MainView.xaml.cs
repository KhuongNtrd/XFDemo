using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFDemo.Models;

namespace XFDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        List<Doctor> Doctors { get; set; }

        public MainView()
        {
            InitializeComponent();

            //NavigationPage.SetHasNavigationBar(this, false);

            if (Doctors == null)
            {
                Doctors = new List<Doctor>()
                {
                     new Doctor(){
                        Name ="Nguyen Van A",
                        Title = "Y Ta",
                        Address = "Tp Can Tho",
                        Phonenumber = "0123456789",
                        Image = "https://image.freepik.com/free-vector/doctor-clinic-illustration_1270-69.jpg"
                    },
                     new Doctor(){
                        Name ="Nguyen Van B",
                        Title = "Bac si da khoa",
                        Address = "Tp Can Tho",
                        Phonenumber = "0123456789",
                        Image = "https://image.freepik.com/free-vector/doctor-clinic-illustration_1270-69.jpg"
                    },
                     new Doctor(){
                        Name ="Nguyen Thi C",
                        Title = "Cap cuu",
                        Address = "Tp Can Tho",
                        Phonenumber = "0123456789",
                        Image = "https://image.freepik.com/free-vector/doctor-clinic-illustration_1270-69.jpg"
                     },
                     new Doctor(){
                        Name ="Tran Thi D",
                        Title = "Tai xe",
                        Address = "Tp Can Tho",
                        Phonenumber = "0123456789",
                        Image = "https://image.freepik.com/free-vector/doctor-clinic-illustration_1270-69.jpg"
                    }
                };
            }

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

             ListViewDoctor.ItemsSource = Doctors;
            //await Task.Delay(1000);
            //await Navigation.PushAsync(new DoctorView(Doctors[0]));
        }

        private async void ListViewDoctor_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var doctor = (Doctor)e.Item;

            await Navigation.PushAsync(new DoctorView(doctor));
        }
    }
}