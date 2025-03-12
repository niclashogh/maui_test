using maui_test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_test.ViewModels
{
    public class TrendingVM : NotifyPropertyChanged
    {
        // Problem: To find trending acticals we have to load a big collection or the entirety to "rank" which is more trendy.
        // There ofc. are workarounds but needs to be hardcoded with a trending-score minimum validation.
    }
}
