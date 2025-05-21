using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Team4ProjectGettingReal.Commands;
using Team4ProjectGettingReal.Model;
using Team4ProjectGettingReal.MVVM;
using Team4ProjectGettingReal.Repository;

namespace Team4ProjectGettingReal.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand ExitCommand { get; }
        private ViewModelBase _selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public MainWindowViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            SelectedViewModel = new HomeViewModel();
            ExitCommand = new RelayCommand(
            param => Exit(), param => true);
        }

        private void Exit()
        {
            System.Environment.Exit(0);
        }

    }

}
