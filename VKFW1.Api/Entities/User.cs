namespace VKFW1.Api.Entities;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsLogged { get; set; }
    public DateTime LoggedDate { get; set; }
}