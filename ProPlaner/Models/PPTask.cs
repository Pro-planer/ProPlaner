using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProPlaner.Models
{
    public class PPTask
    {
        public string Id { get; set; }
        public string DateTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PPTaskType TaskType { get; set; }
        public string AreaId { get; set; }

        public Xamarin.Forms.Color Color
        {
            get
            {
                Xamarin.Forms.Color color = Xamarin.Forms.Color.Gray;

                switch (TaskType)
                {
                    case PPTaskType.None:
                        color = Xamarin.Forms.Color.Gray;
                        break;
                    case PPTaskType.Urgent_Important:
                        color = Xamarin.Forms.Color.Orange;
                        break;
                    case PPTaskType.Urgent_Unimportant:
                        color = Xamarin.Forms.Color.Red;
                        break;
                    case PPTaskType.Nonurgent_Important:
                        color = Xamarin.Forms.Color.Green;
                        break;
                    case PPTaskType.NonUrgent_Unimportant:
                        color = Xamarin.Forms.Color.Yellow;
                        break;
                    default:
                        break;
                }

                return color;
            }
        }

    }
}
