using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleUIBindings.Classes
{
    public class TypeList : ObservableCollection<Typology>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
    }
}