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
using Team4ProjectGettingReal.View;

namespace Team4ProjectGettingReal.ViewModel
{
    public class InventoryViewModel : ViewModelBase
    {
        public ObservableCollection<Item> items { get; set; }
        public ICommand GenerateSaleCommand { get; }
        public ICommand AddItemCommand { get; }
        public ICommand EditItemCommand { get; }
        public ICommand RemoveItemCommand { get; }

        public InventoryViewModel()
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
            AddItemCommand = new RelayCommand(
            param => AddItem(), param => true);
            EditItemCommand = new RelayCommand(
            param => EditItem(), param => true);
            RemoveItemCommand = new RelayCommand(
            param => RemoveItem(), param => true);
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
            var addItemWindow = new View.AddItemWindow();
            if (addItemWindow.ShowDialog() == true)
            {
                string name = addItemWindow.ItemName;
                string description = addItemWindow.ItemDescription;
                double price = addItemWindow.ItemPrice;
                double amount = addItemWindow.ItemAmount;

                var newItem = new Item(name, description, price, amount);
                items.Add(newItem);

                MessageBox.Show($"Vare tilføjet: {name}, {amount} stk. til {price} kr.");
            }
        }

        private void EditItem()
        {
            var editWindow = new EditItemWindow(items);
            if (editWindow.ShowDialog() == true)
            {
            }
        }


        private void RemoveItem()
        {
            var removeWindow = new View.RemoveItemWindow(items);
            if (removeWindow.ShowDialog() == true)
            {
                var selectedItem = removeWindow.SelectedItem;
                if (removeWindow.DeleteCompletely)
                {
                    items.Remove(selectedItem);
                    MessageBox.Show($"Varen '{selectedItem.Name}' blev slettet helt.");
                }
                else
                {
                    try
                    {
                        selectedItem.ReduceStock(removeWindow.ReduceAmount);
                        MessageBox.Show($"Lageret for '{selectedItem.Name}' blev reduceret med {removeWindow.ReduceAmount} enheder.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
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