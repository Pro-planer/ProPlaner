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

    }
}
