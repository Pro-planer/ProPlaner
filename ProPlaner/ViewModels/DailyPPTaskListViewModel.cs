using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ProPlaner.Models;
using ProPlaner.Services;
using ProPlaner.Views;

namespace ProPlaner.ViewModels
{
    public class DailyPPTaskListViewModel : BaseViewModel
    {
        public ObservableCollection<PPTask> Items { get; set; }

        public IDataStore<PPTask> DataStore => DependencyService.Get<IDataStore<PPTask>>();

        public Command LoadItemsCommand { get; set; }

        public DailyPPTaskListViewModel()
        {
            Title = "Daily Tasks (23 July 2020)";
            Items = new ObservableCollection<PPTask>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewPPTaskPage, PPTask>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as PPTask;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

}
