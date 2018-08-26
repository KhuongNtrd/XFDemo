using System;
using System.ComponentModel;
using System.Text;

namespace XFDemo.Models
{
    public class Doctor : INotifyPropertyChanged
    {
        private string _name;
        private string _title;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged(nameof(Name));
                }
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged(nameof(Title));
                }
            }
        }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public string Image { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
