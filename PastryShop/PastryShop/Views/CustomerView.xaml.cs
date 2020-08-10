using PastryShop.ViewModels;
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

namespace PastryShop.Views
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        CustomerViewModel customerViewModel;
        public CustomerView(Customer customer)
        {
            InitializeComponent();
            CustomerViewModel customerViewModel = new CustomerViewModel(customer, this);
            this.DataContext = customerViewModel;
            this.customerViewModel = customerViewModel;
        }
    }
}
