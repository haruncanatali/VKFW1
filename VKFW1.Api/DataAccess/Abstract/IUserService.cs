using VKFW1.Api.Entities;
using VKFW1.Api.Models;

namespace VKFW1.Api.DataAccess.Abstract;

public interface IUserService
{
    bool Login(LoginRequestModel model);
    User LoggedUser();
}