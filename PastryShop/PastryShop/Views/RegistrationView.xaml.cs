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
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Window
    {
        private bool isValidFullName;
        private bool isValidAddress;
        private bool isValidPhoneNumber;
        private bool isValidUsername;
        private bool isValidPassword;

        public RegistrationView()
        {
            InitializeComponent();
            this.DataContext = new RegistrationViewModel(this);
        }

        private void IsRegistationEnabled()
        {
            if (isValidFullName &&
                isValidAddress &&
                isValidPhoneNumber &&
                isValidUsername &&
                isValidPassword)
            {
                btnSave.IsEnabled = true;
            }
            else
            {
                btnSave.IsEnabled = false;
            }
        }

        private void txtFullname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtFullname.Focus())
            {
                lblValidationFullname.Visibility = Visibility.Visible;
                lblValidationFullname.FontSize = 16;
                lblValidationFullname.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationFullname.Content = "The full name must contain at least 10 caracters!";
            }

            string patternFullName = @"^([a-zA-Z ]{10,100})$";
            Match match = Regex.Match(txtFullname.Text, patternFullName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtFullname.BorderBrush = new SolidColorBrush(Colors.Red);
                txtFullname.Foreground = new SolidColorBrush(Colors.Red);
                isValidFullName = false;
            }
            else
            {
                lblValidationFullname.Visibility = Visibility.Hidden;
                txtFullname.BorderBrush = new SolidColorBrush(Colors.Black);
                txtFullname.Foreground = new SolidColorBrush(Colors.Black);
                isValidFullName = true;
            }
            IsRegistationEnabled();
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAddress.Focus())
            {
                lblValidationAddress.Visibility = Visibility.Visible;
                lblValidationAddress.FontSize = 16;
                lblValidationAddress.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationAddress.Content = "Insert full address!";
            }

            string patternAddress = @"^([a-zA-Z0-9_ /-\\,]{10,100})$";
            Match match = Regex.Match(txtAddress.Text, patternAddress, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtAddress.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAddress.Foreground = new SolidColorBrush(Colors.Red);
                isValidAddress = false;
            }
            else
            {
                lblValidationAddress.Visibility = Visibility.Hidden;
                txtAddress.BorderBrush = new SolidColorBrush(Colors.Black);
                txtAddress.Foreground = new SolidColorBrush(Colors.Black);
                isValidAddress = true;
            }
            IsRegistationEnabled();
        }

        private void txtPhonNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPhonNumber.Focus())
            {
                lblValidationPhoneNumber.Visibility = Visibility.Visible;
                lblValidationPhoneNumber.FontSize = 16;
                lblValidationPhoneNumber.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationPhoneNumber.Content = "Insert phone number!";
            }

            string patternPhoneNumber = @"^([0-9 -/\\]{10,})$";
            Match match = Regex.Match(txtPhonNumber.Text, patternPhoneNumber, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtPhonNumber.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPhonNumber.Foreground = new SolidColorBrush(Colors.Red);
                isValidPhoneNumber = false;
            }
            else
            {
                lblValidationPhoneNumber.Visibility = Visibility.Hidden;
                txtPhonNumber.BorderBrush = new SolidColorBrush(Colors.Black);
                txtPhonNumber.Foreground = new SolidColorBrush(Colors.Black);
                isValidPhoneNumber = true;
            }
            IsRegistationEnabled();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUsername.Focus())
            {
                lblValidationUserName.Visibility = Visibility.Visible;
                lblValidationUserName.FontSize = 16;
                lblValidationUserName.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationUserName.Content = "The username can't special characters.\nAt least 5 characters!";
            }

            string patternUserName = @"^([a-zA-Z0-9]{5,100})$";
            Match match = Regex.Match(txtUsername.Text, patternUserName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtUsername.BorderBrush = new SolidColorBrush(Colors.Red);
                txtUsername.Foreground = new SolidColorBrush(Colors.Red);
                isValidUsername = false;
            }
            else
            {
                lblValidationUserName.Visibility = Visibility.Hidden;
                txtUsername.BorderBrush = new SolidColorBrush(Colors.Black);
                txtUsername.Foreground = new SolidColorBrush(Colors.Black);
                isValidUsername = true;
            }
            IsRegistationEnabled();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Focus())
            {
                lblValidationPassword.Visibility = Visibility.Visible;
                lblValidationPassword.FontSize = 16;
                lblValidationPassword.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationPassword.Content = "The password can't contains special characters.\nMust contains least 2 numbers.\nMinimum length 6 characters!";
            }

            string patternPassword = @"^[A-Za-z]{4,}[0-9]{2,}$";
            Match match = Regex.Match(txtPassword.Password, patternPassword, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPassword.Foreground = new SolidColorBrush(Colors.Red);
                isValidPassword = false;
            }
            else
            {
                lblValidationPassword.Visibility = Visibility.Hidden;
                txtPassword.BorderBrush = new SolidColorBrush(Colors.Black);
                txtPassword.Foreground = new SolidColorBrush(Colors.Black);
                isValidPassword = true;
            }
            IsRegistationEnabled();
        }
    }
}
