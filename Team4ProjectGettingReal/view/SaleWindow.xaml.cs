using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Team4ProjectGettingReal.Model;

namespace Team4ProjectGettingReal
{
    /// <summary>
    /// Interaction logic for SaleWindow.xaml
    /// </summary>
    public partial class SaleWindow : Window
    {
        public string ItemName { get; private set; }
        public double AmountSold { get; private set; }
        public string SelectedItemName { get; private set; }


        internal SaleWindow(IEnumerable<Item> items)
        {
            InitializeComponent();
            ItemComboBox.ItemsSource = items;
        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (ItemComboBox.SelectedItem is not Item selected)
            {
                MessageBox.Show("Please select an item.");
                return;
            }

            if (double.TryParse(AmountBox.Text, out double amount))
            {
                SelectedItemName = selected.Name;
                AmountSold = amount;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }


    }


}
