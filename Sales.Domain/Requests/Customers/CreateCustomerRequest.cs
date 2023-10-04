using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Requests.Customers
{
    public sealed class CreateCustomerRequest
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; }
    }
}
