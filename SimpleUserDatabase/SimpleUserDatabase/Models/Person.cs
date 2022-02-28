using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimpleUserDatabase.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set 
            { 
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { 
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { 
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { 
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string FullName {
            get
            {
                return String.Format($"{FirstName} {LastName}");
            }          
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public void ClearFields()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
