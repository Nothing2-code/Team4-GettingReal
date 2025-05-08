using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Team4ProjectGettingReal.Model;
using Team4ProjectGettingReal.MVVM;
using Team4ProjectGettingReal.Repository;

namespace Team4ProjectGettingReal.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> items { get; set; }
        public ICommand GenerateSaleCommand { get; }

        public MainWindowViewModel()
        {
            items = new ObservableCollection<Item>();
            items.Add(new Item("Banan", "fra Ecuador", 5, 74));
            items.Add(new Item("Hvedemel", "1kg", 12, 56));
            items.Add(new Item("Dadler", "fra Algeriet", 50, 10));
            items.Add(new Item("Hummus", "200g", 22, 7));
            items.Add(new Item("Gazoz", "fra Tyrkiet", 12, 20));
            items.Add(new Item("Snickers", "50", 28, 15));

            GenerateSaleCommand = new RelayCommand(
            param => GenerateSale(), param => true);
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

        private void GenerateSale()
        {
            var saleWindow = new SaleWindow(items);
            if (saleWindow.ShowDialog() == true)
            {
                string selectedName = saleWindow.SelectedItemName;
                Item item = items.FirstOrDefault(i => i.Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));
                double amountSold = saleWindow.AmountSold;

                try
                {
                    item.ReduceStock(amountSold);
                    MessageBox.Show($"Sale recorded: {amountSold} units of {item.Name}.");
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
