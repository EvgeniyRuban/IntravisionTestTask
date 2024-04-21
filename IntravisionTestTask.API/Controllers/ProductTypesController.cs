using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Entities;
using IntravisionTestTask.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IntravisionTestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly ICrudRepository<ProductType, Guid> _repository;

        public ProductTypesController(ICrudRepository<ProductType, Guid> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<ProductType>> Add(
            [FromBody] ProductTypeToCreate productTypeDto,
            CancellationToken cancellationToken)
        {
            var productType = new ProductType()
            {
                Title = productTypeDto.Title,
            };

            var result = await _repository.Add(productType, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(
            [FromRoute]Guid id, 
            CancellationToken cancellationToken)
        {
            await _repository.Delete(id, cancellationToken);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> Get(
            [FromRoute] Guid id, 
            CancellationToken cancellationToken)
        {
            var result = await _repository.Get(id, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductType>>> GetAll(CancellationToken cancellationToken)
        {
            var productTypes = await _repository.GetAll(cancellationToken);
            return Ok(productTypes);
        }

        [HttpPut]
        public async Task<ActionResult> Update(
            [FromBody] ProductTypeToUpdate entityToUpdate, 
            CancellationToken cancellationToken)
        {
            var productTypeToUpdate = new ProductType
            {
                Id = entityToUpdate.Id,
                Title = entityToUpdate.Title,
            };

            await _repository.Update(productTypeToUpdate, cancellationToken);
            return Ok();
        }
    }
}
