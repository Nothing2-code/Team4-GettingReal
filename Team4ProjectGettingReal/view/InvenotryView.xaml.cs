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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Team4ProjectGettingReal.ViewModel;

namespace Team4ProjectGettingReal.View
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
            DataContext = new InventoryViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
