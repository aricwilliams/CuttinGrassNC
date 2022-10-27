using CuttinGrassNCAPI.Model.DBCustomers;
using CuttinGrassNCAPI.Repository.IRepository;

namespace CuttinGrassNCAPI.Repository
{
    public class ClientRepository : IClientRepository
    {
        public bool CreateCustomer(Customers customer)
        {
            throw new NotImplementedException();
        }

        public bool CustomerExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool CustomerExistsPost(string name)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(Customers customer)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customers> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Customers GetCustomers(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customers customer)
        {
            throw new NotImplementedException();
        }
    }
}
