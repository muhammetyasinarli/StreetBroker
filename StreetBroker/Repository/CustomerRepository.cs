using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StreetBroker.Common;
using StreetBroker.Models;

namespace StreetBroker.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool DeleteCustomer(long id)
        {
            Customer customer = GetCustomer(id);
            _context.Remove(customer);
            return _context.SaveChanges() > 0;
        }

        public Customer GetCustomer(long id)
        {
            return _context.Customers.
                    Where(r => r.Id == id).SingleOrDefault<Customer>();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.
                    Where(r => r.RecordStatus == RecordStatus.Active).ToList<Customer>();
        }

        public bool InsertCustomer(Customer customer)
        {
            _context.Add(customer);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Customers.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
