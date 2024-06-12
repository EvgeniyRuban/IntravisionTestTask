using IntravisionTestTask.Domain.Dto;
using IntravisionTestTask.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntravisionTestTask.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductMachinesController : ControllerBase
    {
        private readonly IProductMachineService _service;

        public ProductMachinesController(IProductMachineService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ProductMachineCreateResponse>> Add(
            [FromBody] ProductMachineCreateRequest request,
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
        public async Task<ActionResult<ProductMachineGetResponse>> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var request = new ProductMachineGetRequest
            {
                Id = id
            };
            var result = await _service.Get(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductMachineGetResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(
            [FromBody] ProductMachineUpdateRequest request,
            CancellationToken cancellationToken)
        {
            await _service.Update(request, cancellationToken);
            return Ok();
        }

        [HttpPatch("{id}/add/{productSlotId}")]
        public async Task<ActionResult> AddProductSlotById(
            [FromRoute] Guid id,
            [FromRoute] Guid productSlotId,
            CancellationToken cancellationToken)
        {
            await _service.AddProductSlotById(id, productSlotId, cancellationToken);
            return Ok();
        }

        [HttpPatch("{id}/clear")]
        public async Task<ActionResult> Clear(
            [FromRoute] Guid id, 
            CancellationToken cancellationToken)
        {
            await _service.Clear(id, cancellationToken);
            return Ok();
        }
    }
}
