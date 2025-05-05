using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team4ProjectGettingReal.Model;
using Team4ProjectGettingReal.MVVM;

namespace Team4ProjectGettingReal.ViewModel
{
    internal class MainWindowViewModel :ViewModelBase
    {
        public ObservableCollection<Item> items { get; set; }

        public MainWindowViewModel ()
        {
            items = new ObservableCollection<Item> ();
            items.Add(new Item("a", "dfd", 56));
            items.Add(new Item("sad", "dfgfg", 90));
        }

        private Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        private void AddItem()
        {

        }
        private void RemoveItem()
        {
            items.Remove(selectedItem);
        }
    }
}
