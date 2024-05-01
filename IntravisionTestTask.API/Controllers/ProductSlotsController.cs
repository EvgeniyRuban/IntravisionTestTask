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
        public async Task<ActionResult<ProductSlotCreateResponse>> Add(
            [FromBody] ProductSlotCreateRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _service.Add(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSlotGetResponse>> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var request = new ProductSlotGetRequest
            {
                Id = id
            };
            var result = await _service.Get(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductSlotGetResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(
            [FromBody] ProductSlotUpdateRequest request,
            CancellationToken cancellationToken)
        {
            await _service.Update(request, cancellationToken);
            return Ok();
        }

        [HttpPut("{id}/add/{productId}")]
        public async Task<ActionResult> AddProductById(
            [FromRoute] Guid id,
            [FromRoute] Guid productId, 
            CancellationToken cancellationToken)
        {
            await _service.AddProductById(id, productId, cancellationToken);
            return Ok();
        }

        [HttpPut("{id}/clear")]
        public async Task<ActionResult> Clear(
            [FromRoute] Guid id, 
            CancellationToken cancellationToken)
        {
            await _service.Clear(id, cancellationToken);
            return Ok();
        }
    }
}
