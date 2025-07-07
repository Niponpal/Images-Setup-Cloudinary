using ImagesSetup.Data;
using ImagesSetup.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ImagesSetup.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicatinDbContext _context;

        public CustomerRepository(ApplicatinDbContext context)
        {
            _context = context;
        }
        public string AddData(Customer customer)
        {
           var data = _context.Customers.Add(customer);
            _context.SaveChanges();
            return "Added data success Full";
        }

        public string DeleteData(int id)
        {
           var data = _context.Customers.Find(id);
            if(data == null)
            {
                return "Not Found";
            }
            _context.Customers.Remove(data);
            _context.SaveChanges();
            return "Deleted Data Success";
        }

        public IEnumerable<Customer> GatAllData()
        {
           var data = _context.Customers.ToList();
            return data;
        }

        public Customer GetById(int id)
        {        
           return _context.Customers.Find(id);
        }

        public void UpdateData(Customer customer)
        {
                _context.Customers.Find(customer.Id);
                _context.SaveChanges();
        }
    }
}
