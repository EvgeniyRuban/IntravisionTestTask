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
        public async Task<ActionResult<ProductCreateResponse>> Add(
            [FromBody] ProductCreateRequest request,
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
        public async Task<ActionResult<ProductGetResponse>> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var request = new ProductGetRequest
            {
                Id = id,
            };
            var result = await _service.Get(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductGetResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(
            [FromBody] ProductUpdateRequest request,
            CancellationToken cancellationToken)
        {
            await _service.Update(request, cancellationToken);
            return Ok();
        }
    }
}
