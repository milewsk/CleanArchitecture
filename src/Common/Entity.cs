namespace Common;

public  abstract class Entity : IEquatable<Entity>
{
    #region Constructors

    protected Entity(Guid id)
    {
        Id = id;
        InsertionDate = DateTime.Now;
        LastModified = DateTime.Now;
    }

    protected Entity()
    {
    }

    #endregion

    #region Properties

    public Guid Id { get; private init; }
    public DateTime InsertionDate { get; private init; }
    public DateTime LastModified { get; private set; }

    #endregion

    #region Methods

    public void UpdateLastModified()
    {
        LastModified = DateTime.UtcNow;
    }

    #endregion

    #region Operators

    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }
    
    public static bool operator ==(Entity? left, Entity? right)
    {
        return left != null && right != null && Equals(left, right);
    }
    
    public bool Equals(Entity? other)
    {
        if (other == null)
        {
            return false;
        }

        if (GetType() != other.GetType())
        {
            return false;
        }

        return other.Id == Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (GetType() != obj.GetType())
        {
            return false;
        }

        if (obj is not Entity entity)
        {
            return false;
        }

        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * 45;
    }

    #endregion
}
