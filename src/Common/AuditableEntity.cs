namespace Common;

public abstract class AuditableEntity : Entity
{
    public DateTimeOffset InsertionDate { get; private init; }
    public DateTimeOffset LastModifiedDate { get; private set; }
    
    protected AuditableEntity(Guid id)
    {
        Id = id;
        InsertionDate = DateTimeOffset.UtcNow;
        LastModifiedDate = DateTimeOffset.UtcNow;
    }

    public void UpdateLastModifiedDate()
    {
        LastModifiedDate = DateTimeOffset.UtcNow;
     }
}
