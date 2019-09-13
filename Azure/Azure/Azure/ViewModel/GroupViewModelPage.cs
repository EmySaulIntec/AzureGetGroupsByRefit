using Azure.Models;
using Azure.Services;
using Azure.Utils;
using Newtonsoft.Json;
using Refit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Azure.ViewModel
{
    public class GroupViewModelPage : INotifyPropertyChanged
    {
        public ICommand CallApiCommand { get; set; }

        public ObservableCollection<Group> Groups { get; set; }

        public GroupViewModelPage()
        {
            Groups = new ObservableCollection<Group>();

            CallApiCommand = new Command(async () =>
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var nsAPI = RestService.For<IAzureAppService>(Config.HostUri);
                    var response = await nsAPI.GetGroups(Config.ApiKey);

                    string groupJson = await response.Content.ReadAsStringAsync();

                    Groups.Clear();

                    List<Group> groups = JsonConvert.DeserializeObject<List<Group>>(groupJson);

                    groups.ForEach(e =>
                    {
                        Groups.Add(e);
                    });

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Internet connection", "No connection try later", "Ok");
                }

            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
