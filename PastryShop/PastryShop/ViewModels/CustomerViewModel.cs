using PastryShop.Service;
using PastryShop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastryShop.ViewModels
{
    public class CustomerViewModel:ViewModelBase
    {
        ServiceCode service = new ServiceCode();
        CustomerView customerView;
        #region Constructore
        public CustomerViewModel(Customer customer, CustomerView customerViewOpen)
        {
            this.customer = customer;
            customerView = customerViewOpen;
            CakeList = new ObservableCollection<vwCake>(service.GetAllCake());
        }
        #endregion

        #region Property
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
                OnPropertyChanged("Customer");
            }
        }

        private ObservableCollection<vwCake> cakeList;
        public ObservableCollection<vwCake> CakeList
        {
            get
            {
                return cakeList;
            }
            set
            {
                cakeList = value;
                OnPropertyChanged("CakeList");
            }
        }

        private ObservableCollection<vwCake> cakeListByType;
        public ObservableCollection<vwCake> CakeListByType
        {
            get
            {
                return cakeList;
            }
            set
            {
                cakeList = value;
                OnPropertyChanged("CakeList");
            }
        }

        private bool isSuccess;
        public bool IsSuccess
        {
            get
            {
                return isSuccess;
            }
            set
            {
                isSuccess = value;
                OnPropertyChanged("IsSuccess");
            }
        }
        #endregion
    }
}
