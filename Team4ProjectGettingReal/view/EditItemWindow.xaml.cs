using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Team4ProjectGettingReal.Model;

namespace Team4ProjectGettingReal.View
{
    public partial class EditItemWindow : Window
    {
        private Item _selectedItem;

        public EditItemWindow(IEnumerable<Item> items)
        {
            InitializeComponent();
            ItemComboBox.ItemsSource = items;
        }

        private void ItemComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ItemComboBox.SelectedItem is Item selected)
            {
                _selectedItem = selected;
                DescriptionBox.Text = selected.Description;
                PriceBox.Text = selected.Price.ToString();
                AmountBox.Text = selected.Amount.ToString();
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedItem == null)
            {
                MessageBox.Show("Vælg en vare først.");
                return;
            }

            string newDescription = DescriptionBox.Text;

            if (!double.TryParse(PriceBox.Text, out double newPrice) || newPrice < 0)
            {
                MessageBox.Show("Indtast en gyldig pris.");
                return;
            }

            if (!double.TryParse(AmountBox.Text, out double newAmount) || newAmount < 0)
            {
                MessageBox.Show("Indtast en gyldig mængde.");
                return;
            }

            _selectedItem.UpdateItem(newDescription, newPrice, newAmount);

            MessageBox.Show($"Varen '{_selectedItem.Name}' blev opdateret.");

            DialogResult = true;
            Close();
        }
    }
}
