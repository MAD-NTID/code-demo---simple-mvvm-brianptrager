using SimpleUserDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleUserDatabase.ViewModels
{
    public class AddUserViewModel : INotifyPropertyChanged
    {
        public Person Person { get; } = new Person();
        public ICommand AddUserCommand { get; }
        public AddUserViewModel()
        {
            AddUserCommand = new Command(AddUser);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public void AddUser()
        {
            //Add user to database!
            Person.ClearFields();
            Application.Current.MainPage.DisplayAlert("Status", "New User Added!", "OK");
        }
    }
}
