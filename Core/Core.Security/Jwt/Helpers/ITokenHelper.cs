using Core.Security.Jwt.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Security.Jwt.Helpers;

public interface ITokenHelper
{
    Token CreateToken(string userName);
    bool ValidateToken(string rawToken);
    string NormalizeRawToken(string rawToken);
    JwtSecurityToken DecodeToken(string token);
    string GetCurrentToken();
    JwtSecurityToken GetCurrentDecodedToken();
    string GetCurrentUserName();
    int GetUserProfileId();
    string GetTin();
    string GetPin();
    bool GetHasStamp();
    public string GetCurrentUserProfileName();
    string GetFileUrl();
    bool IsJwtToken(string token);
}