using IntravisionTestTask.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Domain.Dto
{
    public class ProductMachineUpdateRequest : IUpdateRequest<ProductMachine, Guid>
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}