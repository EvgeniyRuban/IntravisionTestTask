using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntravisionTestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSlotsController : ControllerBase
    {
        private readonly IProductSlotService _service;

        public ProductSlotsController(IProductSlotService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ProductSlotToGet>> Add(
            [FromBody] ProductSlotToCreate dto,
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
        public async Task<ActionResult<ProductSlotToGet>> Get(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _service.Get(id, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductSlotToGet>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(
            [FromBody] ProductSlotToUpdate dto,
            CancellationToken cancellationToken)
        {
            await _service.Update(dto, cancellationToken);
            return Ok();
        }
    }
}
