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
        public async Task<ActionResult<ProductTypeCreateResponse>> Add(
            [FromBody] ProductTypeCreateRequest request,
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
        public async Task<ActionResult<ProductTypeGetResponse>> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var request = new ProductTypeGetRequest
            {
                Id = id
            };
            var result = await _service.Get(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductTypeGetResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var productTypes = await _service.GetAll(cancellationToken);
            return Ok(productTypes);
        }

        [HttpPut]
        public async Task<ActionResult> Update(
            [FromBody] ProductTypeUpdateRequest request,
            CancellationToken cancellationToken)
        {
            await _service.Update(request, cancellationToken);
            return Ok();
        }
    }
}
