using Common;

namespace Domain.Users;

public class User : AuditableEntity
{
    public string Email { get; init; }
    
    public string Password { get; init; }
    
    public string FirstName { get; init; }
    
    public string LastName { get; init; }

    public User(Guid id, string email, string password, string firstName, string lastName) :base(id)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }
}
