using System.Windows;

namespace Team4ProjectGettingReal.View
{
    public partial class AddItemWindow : Window
    {
        public string ItemName { get; private set; }
        public string ItemDescription { get; private set; }
        public double ItemPrice { get; private set; }
        public double ItemAmount { get; private set; }

        public AddItemWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                MessageBox.Show("Indtast venligst varenavn.");
                return;
            }

            if (!double.TryParse(PriceBox.Text, out double price))
            {
                MessageBox.Show("Ugyldig pris.");
                return;
            }

            if (!double.TryParse(AmountBox.Text, out double amount))
            {
                MessageBox.Show("Ugyldigt antal.");
                return;
            }

            ItemName = NameBox.Text;
            ItemDescription = DescriptionBox.Text;
            ItemPrice = price;
            ItemAmount = amount;

            DialogResult = true;
            Close();
        }
    }
}
