using ProPlaner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProPlaner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPPTaskPage : ContentPage
    {
        public PPTask NewTask { get; set; }

        public NewPPTaskPage()
        {
            InitializeComponent();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "AddItem", NewTask);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}