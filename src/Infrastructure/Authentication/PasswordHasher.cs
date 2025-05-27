using System.Security.Cryptography;
using Application.Abstractions.Authentication;

namespace Infrastructure.Authentication;

public class PasswordHasher : IPasswordHasher
{
    private static readonly HashAlgorithmName Hasher = HashAlgorithmName.SHA3_512; 
    private const int SaltByteSize = 16;
    private const int HashByteSize = 32;
    private const int Iterations = 300000;
    
    public string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltByteSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Hasher, HashByteSize);

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public bool Verify(string password, string hashPassword)
    {
        string[] splitHashPassword = hashPassword.Split("-");
        byte[] hash = Convert.FromHexString(splitHashPassword[0]);
        byte[] salt = Convert.FromHexString(splitHashPassword[1]);
        
        byte[] passwordHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Hasher, HashByteSize); 
        
        return CryptographicOperations.FixedTimeEquals(hash, passwordHash);
    }
}
