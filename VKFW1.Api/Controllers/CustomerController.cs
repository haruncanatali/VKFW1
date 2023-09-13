using Microsoft.AspNetCore.Mvc;
using VKFW1.Api.DataAccess.DB;
using VKFW1.Api.Entities;
using VKFW1.Api.Models;

namespace VKFW1.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> Get(long id)
    {
        if (ModelState.IsValid)
        {
            return Ok(CustomerDB.GetById(id));
        }

        return BadRequest(ModelState);
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> List([FromQuery] string? name, string order = "ASC")
    {
        if (ModelState.IsValid)
        {
            return Ok(CustomerDB.GetList(name, order));
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
            CustomerDB.Add(model);
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
            CustomerDB.Update(model);
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
            CustomerDB.UpdatePatch(model.Id,model.Name,model.Surname);
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
            CustomerDB.Delete(id);
            return NoContent();
        }

        return BadRequest(ModelState);
    }
}