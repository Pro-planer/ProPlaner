using System;
using System.Collections.Generic;
using System.Text;

using ProPlaner.Models;


namespace ProPlaner.ViewModels
{
    public class PPTaskDetailViewModel : BaseViewModel
    {
        public PPTask PPTask { get; set; }

        public PPTaskDetailViewModel(PPTask task = null)
        {
            Title = task?.Name;
            PPTask = task;
        }

    }
}
