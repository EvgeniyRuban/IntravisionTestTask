using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductMachineGetRequest : IGetRequest<ProductMachine, Guid>
    {
        [Required]
        public Guid Id { get; set; }
        
    }
}