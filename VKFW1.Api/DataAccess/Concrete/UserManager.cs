using VKFW1.Api.DataAccess.Abstract;
using VKFW1.Api.DataAccess.DB;
using VKFW1.Api.Entities;
using VKFW1.Api.Models;

namespace VKFW1.Api.DataAccess.Concrete;

public class UserManager : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool Login(LoginRequestModel model)
    {
        User? user = UserDB.GetUser(model);

        if (user != null)
        {
            UserDB.UpdateUser(user);

            return true;
        }

        return false;
    }

    public User LoggedUser()
    {
        return UserDB.LoggedUser();
    }
}