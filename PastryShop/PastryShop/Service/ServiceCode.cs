using PastryShop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastryShop.Service
{
    public class ServiceCode
    {
        public Customer AddCustomer(Customer customer)
        {
            bool uniqueUser = CheckUserName(customer.Username);
            try
            {
                using (PastryShopEntities1 context = new PastryShopEntities1())
                {
                    if (customer.CustomerId == 0)
                    {
                        if (uniqueUser)
                        {
                            Customer newCustomer = new Customer();
                            newCustomer.FullName = customer.FullName;
                            newCustomer.Address = customer.Address;
                            newCustomer.PhoneNumber = customer.PhoneNumber;
                            newCustomer.NumberOfOrders = 0;
                            newCustomer.Username = customer.Username;
                            newCustomer.Password = HashPasswordHelper.HashPassword(customer.Password);
                            context.Customers.Add(newCustomer);
                            context.SaveChanges();
                            customer.CustomerId = newCustomer.CustomerId;
                        }
                        return customer;
                    }
                    else
                    {
                        Customer editCustomer = (from c in context.Customers where c.CustomerId == customer.CustomerId select c).First();
                        editCustomer.FullName = customer.FullName;
                        editCustomer.Address = customer.Address;
                        editCustomer.PhoneNumber = customer.PhoneNumber;
                        editCustomer.Username = customer.Username;
                        editCustomer.Password = customer.Password;
                        editCustomer.CustomerId = customer.CustomerId;
                        context.SaveChanges();
                        return customer;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public Customer Login(string username, string password)
        {
            password = HashPasswordHelper.HashPassword(password);
            try
            {
                using (PastryShopEntities1 context = new PastryShopEntities1())
                {
                    Customer customer = (from d in context.Customers
                                         where d.Username.Equals(username)
                                         where d.Password.Equals(password)
                                         select d).First();
                    return customer;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwCake> GetAllCake()
        {
            try
            {
                using (PastryShopEntities1 context = new PastryShopEntities1())
                {
                    List<vwCake> list = new List<vwCake>();
                    list = (from p in context.vwCakes select p).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }
        public string GetAllCakeByOrder(int orderId)
        {
            List<string> result = new List<string>();
            try
            {
                using (PastryShopEntities1 context = new PastryShopEntities1())
                {
                    
                    List<vwOrderDetail> list = new List<vwOrderDetail>();
                    list = (from p in context.vwOrderDetails where p.OrderId==orderId select p).ToList();
                    foreach(vwOrderDetail O in list)
                    {
                        result.Add(O.CakeName);
                    }
                   return string.Join("\n", result);
                }                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return string.Empty;
            }
        }
        public List<vwOrderDetail> GetAllOrders(int custumerId)
        {
            try
            {
                using (PastryShopEntities1 context = new PastryShopEntities1())
                {
                    List<vwOrderDetail> list = new List<vwOrderDetail>();
                    list = (from p in context.vwOrderDetails where p.CustomerId==custumerId select p).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }
        public string GetAllCommentByOrder(int orderId)
        {
            List<string> result = new List<string>();
            try
            {
                using (PastryShopEntities1 context = new PastryShopEntities1())
                {
                    List<Order> list = new List<Order>();
                    list = (from p in context.Orders where p.OrderId == orderId select p).ToList();
                    foreach (Order O in list)
                    {
                        string[] stringComment = O.Comment.Split();
                        foreach (string str in stringComment)
                        {
                            result.Add(O.Comment);
                        }
                    }
                    return string.Join("\n", result);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return string.Empty;
            }
        }

        public bool CheckUserName(string username)
        {
            using (PastryShopEntities1 context = new PastryShopEntities1())
            {
                vwCustomer customer = (from c in context.vwCustomers where c.Username == username select c).FirstOrDefault();

                if (customer != null)
                {
                    return false;
                }
                return true;
            }
        }

        public int AddOrder(Order order)
        {
            try
            {
                using (PastryShopEntities1 context = new PastryShopEntities1())
                {
                    if (order.OrderId == 0)
                    {
                        Order newOrder = new Order();
                        newOrder.Date = order.Date;
                        newOrder.TotalPrice = order.TotalPrice;
                        newOrder.NumberOfCakes = order.NumberOfCakes;
                        newOrder.Comment = order.Comment;
                        newOrder.CustomerId = order.CustomerId;

                        context.Orders.Add(newOrder);
                        context.SaveChanges();
                        order.OrderId = newOrder.OrderId;

                        return newOrder.OrderId;
                    }
                    else
                    {
                        Order editOrder = (from c in context.Orders where c.OrderId == order.OrderId select c).First();
                        editOrder.Date = order.Date;
                        editOrder.TotalPrice = order.TotalPrice;
                        editOrder.NumberOfCakes = order.NumberOfCakes;
                        editOrder.Comment = order.Comment;
                        editOrder.CustomerId = order.CustomerId;
                        editOrder.OrderId = order.OrderId;
                        context.SaveChanges();
                        return editOrder.OrderId;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return 0;
            }
        }

        public void AddCakeInOrderList(ListOfCakeInOrder list)
        {
            try
            {
                using (PastryShopEntities1 context = new PastryShopEntities1())
                {
                    ListOfCakeInOrder newOrder = new ListOfCakeInOrder();
                    newOrder.OrderId = list.OrderId;
                    newOrder.CakeId = list.CakeId;

                    context.ListOfCakeInOrders.Add(newOrder);
                    context.SaveChanges();
                    
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
    }
}
