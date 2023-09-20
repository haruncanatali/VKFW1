using Microsoft.AspNetCore.Mvc;
using VKFW1.Api.Attributes;
using VKFW1.Api.DataAccess.Abstract;
using VKFW1.Api.Entities;
using VKFW1.Api.Models;

namespace VKFW1.Api.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<bool>> Login([FromBody] LoginRequestModel model)
    {
        if (ModelState.IsValid)
        {
            return Ok(_userService.Login(model));
        }

        return BadRequest();
    }

    [HttpGet]
    // IsLogged custom attributesi sistemde giriş yapan kullanıcı bulursa servise müsade ediyor. Authorize gibi davranıyor.
    // bulamassa Unauthorized 401 dönecek
    [IsLogged]
    public async Task<ActionResult<User>> GetLoggedUser()
    {
        return Ok(_userService.LoggedUser());
    }

}