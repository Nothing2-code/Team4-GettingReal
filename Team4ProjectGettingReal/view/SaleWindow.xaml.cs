using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.Linq;
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
        public string ItemDescription { get; private set; }
        public double ItemPrice { get; private set; }
        public double ItemAmount { get; private set; }
        public string SelectedItemName { get; private set; }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
                if (NameBox.Text != null)
                {
                    ItemName = NameBox.Text;
                }
                if (DescriptionBox.Text != null)
                {
                    ItemDescription = DescriptionBox.Text;
                }

                if (double.TryParse(PriceBox.Text, out double price))
                {
                    ItemPrice = price;
                }

                if (double.TryParse(AmountBox.Text, out double amount))
                {
                    ItemAmount = amount;
                }

                DialogResult = true;
                Close();
            }
        }



}
