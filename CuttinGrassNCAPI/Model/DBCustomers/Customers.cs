using System.ComponentModel.DataAnnotations;

namespace CuttinGrassNCAPI.Model.DBCustomers
{
    public class Customers
    {
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? phoneNumber { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public int ZipCode { get; set; }
		public string? Email { get; set; }
		public string? BusinessName { get; set; }
		public bool IsPayingCustomer { get; set; }
	}
}
