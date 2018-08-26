using Plugin.Messaging;
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
    public partial class DoctorView : ContentPage
    {
        Doctor EditDoctor { get; set; }

        Doctor CurrentDoctor { get; set; }
        public DoctorView(Doctor doctor)
        {
            InitializeComponent();

            Title = "Edit doctor";

            CurrentDoctor = doctor;
            
            EditDoctor = new Doctor()
            {
                Title = doctor.Title,
                Address = doctor.Address,
                Image = doctor.Image,
                Name = doctor.Name,
                Phonenumber = doctor.Phonenumber
            };

            BindingContext = EditDoctor;
        }

        public DoctorView()
        {
            InitializeComponent();

            Title = "New doctor";

            EditDoctor = new Doctor();

            BindingContext = EditDoctor;
        }



        private void Save_Clicked(object sender, EventArgs e)
        {
            if (CurrentDoctor != null)
            {
                CurrentDoctor.Title = EditDoctor.Title;
                CurrentDoctor.Name = EditDoctor.Name;
                CurrentDoctor.Image = EditDoctor.Image;
                CurrentDoctor.Address = EditDoctor.Address;
                CurrentDoctor.Phonenumber = EditDoctor.Phonenumber;
            }
            else
            {
                MainView.Doctors.Add(EditDoctor);
            }
            //CurrentDoctor.RaisePropertyChanged("Address");
            Navigation.PopAsync();

            Acr.UserDialogs.UserDialogs.Instance.Toast("Item saved...");
        }

        //void Button_Clicked()
        //{
        //    var phoneDialer = CrossMessaging.Current.PhoneDialer;
        //    if (phoneDialer.CanMakePhoneCall)
        //        phoneDialer.MakePhoneCall("+27219333000");
        //}
    }
}