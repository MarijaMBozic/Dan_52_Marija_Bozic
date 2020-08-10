using PastryShop.Commands;
using PastryShop.Service;
using PastryShop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PastryShop.ViewModels
{
    public class RegistrationViewModel:ViewModelBase
    {
        RegistrationView registrationView;
        ServiceCode service = new ServiceCode();
        #region Constructor
        public RegistrationViewModel(RegistrationView registrationViewOpen)
        {
            customer = new Customer();
            registrationView = registrationViewOpen;
        }
        #endregion

        #region Properties

        private Customer customer;
        public Customer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
                OnPropertyChanged("Doctor");
            }
        }
        #endregion

        #region Commands

        private ICommand save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(param));
                }
                return save;
            }
        }

        private void SaveExecute(object parametar)
        {
            var passwordBox = parametar as PasswordBox;
            var password = passwordBox.Password;
            Customer.Password = password;
            try
            {
                if (service.AddCustomer(Customer) != null)
                {                  
                   CustomerView window = new CustomerView(Customer);
                   window.Show();
                   registrationView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}
