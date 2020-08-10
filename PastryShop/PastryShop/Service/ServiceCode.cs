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
    }
}
