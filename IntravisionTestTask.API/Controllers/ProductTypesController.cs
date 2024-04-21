using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntravisionTestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeService _service;

        public ProductTypesController(IProductTypeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ProductTypeToGet>> Add(
            [FromBody] ProductTypeToCreate dto,
            CancellationToken cancellationToken)
        {
            var result = await _service.Add(dto, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeToGet>> Get(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _service.Get(id, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductTypeToGet>>> GetAll(CancellationToken cancellationToken)
        {
            var productTypes = await _service.GetAll(cancellationToken);
            return Ok(productTypes);
        }

        [HttpPut]
        public async Task<ActionResult> Update(
            [FromBody] ProductTypeToUpdate dto,
            CancellationToken cancellationToken)
        {
            await _service.Update(dto, cancellationToken);
            return Ok();
        }
    }
}
