using ImagesSetup.Models;

namespace ImagesSetup.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GatAllData();
        String AddData(Customer customer);
        Customer GetById(int id);

        void UpdateData(Customer customer);
        string DeleteData(int id);
    }
}
