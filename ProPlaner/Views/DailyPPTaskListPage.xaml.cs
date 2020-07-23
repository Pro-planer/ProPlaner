using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ProPlaner.Models;
using ProPlaner.Views;
using ProPlaner.ViewModels;

namespace ProPlaner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyPPTaskListPage : ContentPage
    {
        DailyPPTaskListViewModel viewModel;

        public DailyPPTaskListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DailyPPTaskListViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (PPTask)layout.BindingContext;
            await Navigation.PushAsync(new PPTaskDetailPage(new PPTaskDetailViewModel(item)));
            //await Navigation.PushModalAsync(new NavigationPage(new PPTaskDetailPage(new PPTaskDetailViewModel(item))));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewPPTaskPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}