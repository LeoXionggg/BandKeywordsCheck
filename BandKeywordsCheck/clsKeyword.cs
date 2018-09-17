using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandKeywordsCheck
{
    public class clsKeyword
    {
        public clsKeyword(string kw)
        {
            Keyword = kw;
            IsChecked = false;
            IsBrand = false;
        }

        public string Keyword { get; set; }
        public bool IsChecked { get; set; }

        public bool IsBrand { get; set; }
    }
}
