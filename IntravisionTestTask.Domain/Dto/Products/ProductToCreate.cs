using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;

public class ProductToCreate : ICreateDto<Product, Guid>
{
    public Guid ProductTypeId { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
}