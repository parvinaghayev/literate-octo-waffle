using System.Security.Cryptography;
using System.Text;
using Core.Security.Hashing.Models;

namespace Core.Security.Hashing.Helpers;

public static class HashingHelper
{
    public static HashResponse GeneratePasswordHash(string password)
    {
        using HMACSHA512 algoritm = new HMACSHA512();

        HashResponse response = new();
        response.Salt = algoritm.Key;
        response.Hash = algoritm.ComputeHash(Encoding.UTF8.GetBytes(password));

        return response;
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
    {
        using HMACSHA512 algoritm = new HMACSHA512(passwordSalt);
        byte[] computedHash = algoritm.ComputeHash(Encoding.UTF8.GetBytes(password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != passwordHash[i])
                return false;
        }

        return true;
    }
}