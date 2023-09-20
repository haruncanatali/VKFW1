using VKFW1.Api.Entities;
using VKFW1.Api.Models;

namespace VKFW1.Api.DataAccess.DB;

public class UserDB
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public UserDB(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public static List<User> users = new List<User>
    {
        new()
        {
            Username = "haruncan.atali",
            Password = "deneme-sifre"
        }
    };

    public static User? GetUser(LoginRequestModel model)
    {
        return users.FirstOrDefault(c=> c.Username == model.Username && c.Password == model.Password);
    }

    public static void UpdateUser(User model)
    {
        User? user = GetUser(new LoginRequestModel{Username = model.Username,Password = model.Password});

        if (user != null)
        {
            // kullanıcının giriş yaptığını güncelleyelim
            user.IsLogged = model.IsLogged;
            user.LoggedDate = model.LoggedDate;
            
            // sistemde tek bir kullanıcı giriş yapsın birden fazla giriş yapan olmasın
            foreach (var user_ in users)
            {
                if (user_.Username == user.Username && user_.Password == user.Password)
                {
                    continue;
                }
                else
                {
                    user_.IsLogged = false;
                }
            }
        }

        
    }

    public static bool LoginUserControl()
    {
        return users.Any(c => c.IsLogged);
    }

    public static User LoggedUser()
    {
        return users.First(c => c.IsLogged);
    }
}