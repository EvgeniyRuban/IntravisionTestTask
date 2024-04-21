using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntravisionTestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ProductToGet>> Add(
            [FromBody] ProductToCreate dto,
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
        public async Task<ActionResult<ProductToGet>> Get(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _service.Get(id, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductToGet>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(
            [FromBody] ProductToUpdate dto,
            CancellationToken cancellationToken)
        {
            await _service.Update(dto, cancellationToken);
            return Ok();
        }
    }
}
