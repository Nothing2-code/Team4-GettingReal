using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Team4ProjectGettingReal.ViewModel;

namespace Team4ProjectGettingReal.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel viewModel;

        public UpdateViewCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Home")
            {
                Trace.WriteLine("Home");
                viewModel.SelectedViewModel = new HomeViewModel();
            }
            else if (parameter.ToString() == "Inventory")
            {
                Trace.WriteLine("Inventory");
                viewModel.SelectedViewModel = new InventoryViewModel();
            }
            else if (parameter.ToString() == "Supplier")
            {
                Trace.WriteLine("Supplier");
                viewModel.SelectedViewModel = new SupplierViewModel();
            }
        }
    }
}