using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Team4ProjectGettingReal.Model;

namespace Team4ProjectGettingReal.View
{
    public partial class RemoveItemWindow : Window
    {
        public Item SelectedItem { get; private set; }
        public bool DeleteCompletely { get; private set; } = true;
        public double ReduceAmount { get; private set; }

        public RemoveItemWindow(IEnumerable<Item> items)
        {
            InitializeComponent();
            ItemComboBox.ItemsSource = items;

            DeleteCompletelyBox.Checked += Checkbox_Changed;
            DeleteCompletelyBox.Unchecked += Checkbox_Changed;

            UpdateAmountPanelVisibility();
        }

        private void UpdateAmountPanelVisibility()
        {
            AmountPanel.Visibility = DeleteCompletelyBox.IsChecked == true
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        private void Checkbox_Changed(object sender, RoutedEventArgs e)
        {
            UpdateAmountPanelVisibility();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (ItemComboBox.SelectedItem is not Item selected)
            {
                MessageBox.Show("Vælg en vare først.");
                return;
            }

            SelectedItem = selected;
            DeleteCompletely = DeleteCompletelyBox.IsChecked == true;

            if (!DeleteCompletely)
            {
                if (!double.TryParse(AmountBox.Text, out double amount) || amount <= 0)
                {
                    MessageBox.Show("Indtast et gyldigt tal for mængde.");
                    return;
                }
                ReduceAmount = amount;
            }

            DialogResult = true;
            Close();
        }
    }
}
