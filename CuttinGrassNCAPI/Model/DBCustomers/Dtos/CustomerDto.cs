using System.ComponentModel.DataAnnotations;

namespace CuttinGrassNCAPI.Model.DBCustomers.Dtos
{
    public class CustomerDto
    {
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? phoneNumber { get; set; }
		public string? Email { get; set; }
		public string? BusinessName { get; set; }
		public bool IsPayingCustomer { get; set; }
	}
}
