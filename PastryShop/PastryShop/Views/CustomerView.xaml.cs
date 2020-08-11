using PastryShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private bool isValidCake;
        private bool isValidQuantity;

        public CustomerView(Customer customer)
        {
            InitializeComponent();
            CustomerViewModel customerViewModel = new CustomerViewModel(customer, this);
            this.DataContext = customerViewModel;
            this.customerViewModel = customerViewModel;
        }
        private void IsRegistationEnabled()
        {
            if (isValidCake &&
                isValidQuantity)
            {
                btnAddToList.IsEnabled = true;
            }
            else
            {
                btnAddToList.IsEnabled = false;
            }
        }
        private void txtComment_TextChanged(object sender, TextChangedEventArgs e)
        {
            string patternUserName = @"^([a-zA-Z ]{1,})$";
            Match match = Regex.Match(txtComment.Text, patternUserName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtComment.BorderBrush = new SolidColorBrush(Colors.Red);
                txtComment.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                txtComment.BorderBrush = new SolidColorBrush(Colors.Black);
                txtComment.Foreground = new SolidColorBrush(Colors.Black);
            }
            IsRegistationEnabled();
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            string patternUserName = @"^([1-9]{1,2})$";
            Match match = Regex.Match(txtQuantity.Text, patternUserName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtQuantity.BorderBrush = new SolidColorBrush(Colors.Red);
                txtQuantity.Foreground = new SolidColorBrush(Colors.Red);
                isValidQuantity = false;
            }
            else
            {
                txtQuantity.BorderBrush = new SolidColorBrush(Colors.Black);
                txtQuantity.Foreground = new SolidColorBrush(Colors.Black);
                isValidQuantity = true;
            }
            IsRegistationEnabled();
        }

        private void cmbLisOfCake_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            if (cmbLisOfCake.SelectedItem.ToString()==string.Empty)
            {
                cmbLisOfCake.BorderBrush = new SolidColorBrush(Colors.Red);
                cmbLisOfCake.Foreground = new SolidColorBrush(Colors.Red);
                isValidCake = false;
            }
            else
            {
                cmbLisOfCake.BorderBrush = new SolidColorBrush(Colors.Black);
                cmbLisOfCake.Foreground = new SolidColorBrush(Colors.Black);
                isValidCake = true;
            }
            IsRegistationEnabled();
        }
    }
}
