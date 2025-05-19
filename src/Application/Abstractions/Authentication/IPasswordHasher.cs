namespace Application.Abstractions.Authentication;

public interface IPasswordHasher
{
    bool Hash(string password);
    bool Verify(string password, string hashPassword);
}
