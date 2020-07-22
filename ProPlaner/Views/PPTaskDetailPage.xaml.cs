using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ProPlaner.Models;
using ProPlaner.ViewModels;

namespace ProPlaner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PPTaskDetailPage : ContentPage
    {
        PPTaskDetailViewModel viewModel;

        public PPTaskDetailPage(PPTaskDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }


        public PPTaskDetailPage()
        {
            InitializeComponent();

            var task = new PPTask
            {
                DateTime = DateTime.Now.ToString(),
                Name = "New Task",
                Description = "This is a task description."
            };

            viewModel = new PPTaskDetailViewModel(task);
            BindingContext = viewModel;

        }
    }
}