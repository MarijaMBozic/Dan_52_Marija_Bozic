using PastryShop.Commands;
using PastryShop.Helpers;
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

        private int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;                
                OnPropertyChanged("Quantity");
            }
        }

        private string comment;
        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
                OnPropertyChanged("Comment");
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

        #region Command
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
            CakeByOrder cake = new CakeByOrder();
            cake.CakeName = SelectedCake.Name;
            cake.CakePrice = SelectedCake.SellingPrice;            
            cake.TotalPriceByCake = SelectedCake.SellingPrice * Quantity;
            cake.CakeId = SelectedCake.CakeId;
            cake.CakeQuantity = Quantity;
            cake.CakeComment =Comment;
            
            try
            {                
                TemporaryCakeList.Add(cake);
                
                foreach(CakeByOrder c in TemporaryCakeList)
                {
                    TotalPrice = TotalPrice+ c.TotalPriceByCake;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private ICommand saveOrder;

        public ICommand SaveOrder
        {
            get
            {
                if (saveOrder == null)
                {
                    saveOrder = new RelayCommand(param => SaveOrderExecute());
                }
                return saveOrder;
            }
        }

        private void SaveOrderExecute()
        {
            Order newOrder = new Order();

            newOrder.Date = DateTime.Now;
            newOrder.TotalPrice = TotalPrice;
            newOrder.CustomerId = customer.CustomerId;

            foreach(CakeByOrder cake in TemporaryCakeList)
            {
                newOrder.NumberOfCakes = newOrder.NumberOfCakes + cake.CakeQuantity;
                newOrder.Comment = newOrder.Comment +" "+ cake.CakeComment;                
            }
            try
            {
                int orderNumber= service.AddOrder(newOrder);
                
                if(orderNumber != 0)
                {
                    ListOfCakeInOrder listOfCakeInOrders = new ListOfCakeInOrder();
                    listOfCakeInOrders.OrderId = orderNumber;
                    foreach(var cake in TemporaryCakeList)
                    {
                        listOfCakeInOrders.CakeId = cake.CakeId;
                        service.AddCakeInOrderList(listOfCakeInOrders);
                    }

                    CreateOrderFileTxt.CreateOrder(Customer.FullName, orderNumber, newOrder.Comment);
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

