using CuttinGrassNCAPI.Model.DBCustomers;

namespace CuttinGrassNCAPI.Repository.IRepository
{
    public interface IClientRepository
    {
        ICollection<Customers> GetCustomers();
        Customers GetCustomers(int customerId);
        bool CustomerExists(int id);
        bool CustomerExistsPost(string name);
        bool CreateCustomer(Customers customer);
        bool UpdateCustomer(Customers customer);
        bool DeleteCustomer(Customers customer);
        bool Save();

    }
}
