using System;
using System.Collections.Generic;
using System.Text;

namespace ProPlaner.Models
{
    public enum PPTaskType
    {
        None = 0,               // gray
        Urgent_Important,       // orange
        Urgent_Unimportant,     // red
        Nonurgent_Important,    // grren
        NonUrgent_Unimportant   // yellow
    }
}
