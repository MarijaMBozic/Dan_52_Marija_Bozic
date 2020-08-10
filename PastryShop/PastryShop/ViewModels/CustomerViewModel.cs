using PastryShop.Commands;
using PastryShop.Models;
using PastryShop.Service;
using PastryShop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
            SetListCakeByType(isForChildren);
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

        private CakeByOrder cakeByOrder = new CakeByOrder();
        public CakeByOrder CakeByOrder
        {
            get
            {
                return cakeByOrder;
            }
            set
            {
                cakeByOrder = value;
                OnPropertyChanged("CakeByOrder");
            }
        }
        private vwCake selectedCake;
        public vwCake SelectedCake
        {
            get
            {
                return selectedCake;
            }
            set
            {
                selectedCake = value;
                OnPropertyChanged("SelectedCake");
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
                return cakeListByType;
            }
            set
            {
                cakeListByType = value;
                OnPropertyChanged("CakeListByType");
            }
        }

        private ObservableCollection<CakeByOrder> temporaryCakeList = new ObservableCollection<CakeByOrder>();
        public ObservableCollection<CakeByOrder> TemporaryCakeList
        {
            get
            {
                return temporaryCakeList;
            }
            set
            {
                temporaryCakeList = value;
                OnPropertyChanged("TemporaryCakeList");
            }
        }

        private bool isForChildren;
        public bool IsForChildren
        {
            get
            {
                return isForChildren;
            }
            set
            {
                isForChildren = value;
                SetListCakeByType(value);
                OnPropertyChanged("IsForChildren");
            }
        }     

        private double totalPrice;
        public double TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }
        #endregion
        #region
        public void SetListCakeByType(bool isForChildren)
        {
            List<vwCake> cakeList = new List<vwCake>();
            foreach (vwCake cake in CakeList)
            {
                if(cake.IsForChildren== isForChildren)
                {
                    cakeList.Add(cake);
                }
            }
            CakeListByType = new ObservableCollection<vwCake>(cakeList);
        }
        
        private ICommand addCakeToOrderList;

        public ICommand AddCakeToOrderList
        {
            get
            {
                if (addCakeToOrderList == null)
                {
                    addCakeToOrderList = new RelayCommand(param => AddCakeToOrderListExecute());
                }
                return addCakeToOrderList;
            }
        }

        private void AddCakeToOrderListExecute()
        {
            CakeByOrder.CakeName = SelectedCake.Name;
            CakeByOrder.CakePrice = SelectedCake.SellingPrice;
            CakeByOrder.TotalPriceByCake = SelectedCake.SellingPrice * CakeByOrder.CakeQuantity;
            try
            {                
                TemporaryCakeList.Add(cakeByOrder);
                
                foreach(CakeByOrder cake in TemporaryCakeList)
                {
                    TotalPrice = TotalPrice+ cake.TotalPriceByCake;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }

    #endregion
}

