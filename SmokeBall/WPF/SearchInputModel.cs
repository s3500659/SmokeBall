using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    public class SearchInputModel : ISearchInputModel
    {
        public string? Keyword { get; set; }
        public string? SearchLimit { get; set; }
        public SearchEngine Engine { get; set; }
    }
}
