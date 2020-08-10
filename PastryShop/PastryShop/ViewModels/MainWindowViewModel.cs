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
    public class MainWindowViewModel:ViewModelBase
    {
        MainWindow main;
        RegistrationView registrationView;
        #region Constructor

        public MainWindowViewModel(MainWindow mainOpen)
        {
            this.main = mainOpen;
        }
        #endregion

        #region Properties
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        #endregion

        #region Command
        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(param => LoginExecute(param));
                }
                return login;
            }
        }

        private void LoginExecute(object parametar)
        {
            try
            {
                var passwordBox = parametar as PasswordBox;
                var password = passwordBox.Password;
                ServiceCode service = new ServiceCode();

                Customer customer = service.Login(Username, password);
                if (customer == null)
                {
                    MessageBox.Show("Uneti korisnik ne postoji!");
                }
                else
                {
                    CustomerView window = new CustomerView(customer);
                    window.Show();
                    main.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private ICommand registration;
        public ICommand Registration
        {
            get
            {
                if (registration == null)
                {
                    registration = new RelayCommand(param => RegistrationExecute(), param => CanRegistrationDoctorExecute());
                }
                return registration;
            }
        }

        private void RegistrationExecute()
        {
            try
            {
                registrationView = new RegistrationView();
                registrationView.Show();
                main.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanRegistrationDoctorExecute()
        {
            return true;
        }
        #endregion
    }
}
