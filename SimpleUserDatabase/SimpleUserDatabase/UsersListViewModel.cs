using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using SimpleUserDatabase.Models;
using SimpleUserDatabase.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SimpleUserDatabase.ViewModels
{
    public class UsersListViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Person> People { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public UsersListViewModel()
        {
            Title = "List of Users";
            People = new ObservableRangeCollection<Person>();
            
            RefreshCommand = new AsyncCommand(OnRefresh);
            PopulateList();
        }

        public void PopulateList()
        {
            var mainDir = FileSystem.AppDataDirectory;
            var fileName = Path.Combine(mainDir, "users.json");
            if (File.Exists(fileName))  //Load JSON data into list if file exists
            {
                using (var reader = new StreamReader(fileName))
                {
                    var fileContents = reader.ReadToEnd();
                    People.AddRange(JsonConvert.DeserializeObject<List<Person>>(fileContents));
                }
            }
            else
            {
                People.Add(new Person() { FirstName = "John", LastName = "Doe", Email = "jd@gmail.com", Password = "duh" });
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    string userData = JsonConvert.SerializeObject(People);
                    writer.Write(userData);
                }
            }
        }

        async Task OnRefresh()
        {
            IsBusy = true;
            await Task.Delay(1500);
            PopulateList();
            IsBusy = false;
        }
    }
}
