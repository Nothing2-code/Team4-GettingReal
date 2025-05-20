using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Team4ProjectGettingReal.Commands;
using Team4ProjectGettingReal.MVVM;

namespace Team4ProjectGettingReal.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }

    }
}
