using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleUIBindings
{
    public class Typology
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class TypeL : ObservableCollection<Typology>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
    }
}
