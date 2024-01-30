namespace Modules.Auth.Domain.ValueObjects;

public class Name : IEquatable<Name>
{
    public static Name Empty { get; } = new Name();
    public string Value { get; }

    private Name()
    {
        Value = string.Empty;
    }

    protected Name(string name)
    {
        Value = name;
    }

    public bool Equals(Name? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        return Equals((Name)obj);
    }

    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode(Value);
    }

    public override string ToString()
    {
        return Value;
    }

    public static Name Create(string name) => new Name(name);
}
