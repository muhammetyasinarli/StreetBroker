using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreetBroker.Models;

namespace StreetBroker.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        bool InsertCustomer(Customer customer);
        Customer GetCustomer(long id);
        bool DeleteCustomer(long id);
        bool UpdateCustomer(Customer customer);
    }
}
