using VKFW1.Api.DataAccess.DB;

namespace VKFW1.Api.Attributes;

public class IsLoggedAttribute : Attribute
{
    public bool IsLoggedIn()
    {
        return UserDB.LoginUserControl();
    }
}