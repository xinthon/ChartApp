using System.Reflection;

namespace Modules.Auth.Domain.Primitives;

public class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>> where TEnum : Enumeration<TEnum>
{
    public Enumeration(int value, string name)
    {
        Name = name;
        Value = value;
    }

    private static Dictionary<int, TEnum> CreateEnumerations()
    {
        var enumerationType = typeof(TEnum);

        var fieldsForType = enumerationType
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => enumerationType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);

        return fieldsForType.ToDictionary(x => x.Value);
    }

    public bool Equals(Enumeration<TEnum>? other)
    {
        if (other is null)
            return false;

        return GetType() == other.GetType() && Value == other.Value;
    }

    public static TEnum? FromValue(int value)
    { return Enumerations.TryGetValue(value, out TEnum? enumeration) ? enumeration : default; }


    public static TEnum? FromName(string name) { return Enumerations.Values.SingleOrDefault(e => e.Name == name); }

    public override string ToString() { return Name; }

    public string Name { get; protected set; }

    public int Value { get; protected set; }

    private readonly static Dictionary<int, TEnum> Enumerations = CreateEnumerations();
}
