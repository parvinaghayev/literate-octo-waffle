namespace Core.Security.Jwt.Models;

public class UserProfileListClaim()
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserProfileType { get; set; }
    public string Description { get; set; }
}