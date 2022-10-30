using CuttinGrassNCAPI.Data;
using CuttinGrassNCAPI.Model.DBCustomers;
using CuttinGrassNCAPI.Repository.IRepository;

namespace CuttinGrassNCAPI.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDBContext _db;
        public ClientRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public bool CreateCustomer(Customers customer)
        {
            _db.Customers.Add(customer);
            return Save();
        }

        public bool CustomerExists(int id)
        {
            return _db.Customers.Any(x => x.Id == id);
        }

        public bool CustomerExistsPost(string name)
        {
            return _db.Customers.Any(a => a.Name == name);
        }

        public bool DeleteCustomer(Customers customer)
        {
            _db.Customers.Remove(customer);
            return Save();
        }

        public ICollection<Customers> GetCustomers()
        {
            return _db.Customers.OrderBy(x => x.Name).ToList();   
        }

        public Customers GetCustomer(int customerId)
        {
           return _db.Customers.FirstOrDefault(x => x.Id == customerId);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateCustomer(Customers customer)
        {
            _db.Customers.Update(customer);
            return Save();
        }
    }
}

//throw new NotImplementedException();

