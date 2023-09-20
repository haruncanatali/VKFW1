using Microsoft.AspNetCore.Mvc;
using VKFW1.Api.DataAccess.Abstract;
using VKFW1.Api.DataAccess.DB;
using VKFW1.Api.Entities;
using VKFW1.Api.Models;

namespace VKFW1.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _customerService;
    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> Get(long id)
    {
        if (ModelState.IsValid)
        {
            _logger.LogInformation($"{id} li musteri getirildi.");
            return Ok(_customerService.GetById(id));
        }

        return BadRequest(ModelState);
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> List([FromQuery] string? name, string order = "ASC")
    {
        if (ModelState.IsValid)
        {
            _logger.LogInformation($"musteriler listelendi.");
            return Ok(_customerService.GetList(name, order));
        }

        return BadRequest(ModelState);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create([FromBody] CustomerCreateRequestModel model)
    {
        if (ModelState.IsValid)
        {
            _customerService.Add(model);
            _logger.LogInformation($"musteri olusturuldu");
            return Ok();
        }

        return BadRequest(ModelState);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update([FromBody] Customer model)
    {
        if (ModelState.IsValid)
        {
            _customerService.Update(model);
            _logger.LogInformation($"{model.Id} li musteri guncellendi.");
            return Ok();
        }

        return BadRequest(ModelState);
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update([FromBody] CustomerUpdateRequestModel model)
    {
        if (ModelState.IsValid)
        {
            _customerService.UpdatePatch(model.Id,model.Name,model.Surname);
            _logger.LogInformation($"{model.Id} li musteri guncellendi.");
            return Ok();
        }

        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(long id)
    {
        if (ModelState.IsValid)
        {
            _customerService.Delete(id);
            _logger.LogInformation($"{id} li musteri silindi.");
            return NoContent();
        }

        return BadRequest(ModelState);
    }
}