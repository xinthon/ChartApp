namespace Modules.Auth.Domain.ValueObjects;

public class Email : IEquatable<Email>
{
    public static Email Empty { get; } = new Email();

    public string Value { get; }

    private Email()
    {
        Value = string.Empty;
    }
    protected Email(string email)
    {
        Value = email;
    }

    public static Email Create(string email) => new Email(email);

    public bool Equals(Email? other)
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

        return Equals((Email)obj);
    }

    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode(Value);
    }

    public override string ToString()
    {
        return Value;
    }
}
