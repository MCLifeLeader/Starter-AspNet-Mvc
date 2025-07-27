namespace Startup.Common.Models;

public abstract class EnumerationWithIdEnumValue<T, TId, TEnum> : EnumerationWithId<T, TId>
    where T : EnumerationWithIdEnumValue<T, TId, TEnum>
    where TId : struct
    where TEnum : struct
{
    /// <summary>
    /// Gets the enumeration value.
    /// </summary>
    public TEnum Enum { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EnumerationWithIdEnumValue{T,TId,TEnum}"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="enumValue">The enumeration value.</param>
    /// <param name="code">The code.</param>
    /// <param name="description">The description.</param>
    /// <param name="isObsolete">Specifies whether the item is obsolete.</param>
    protected EnumerationWithIdEnumValue(TId id, TEnum enumValue, string code, string description, bool isObsolete)
        : base(id, code, description, isObsolete)
    {
        Enum = enumValue;
    }

    /// <summary>
    /// Retrieves an enumeration item based on its enumeration value.
    /// </summary>
    /// <param name="enumValue">The enumeration value.</param>
    /// <param name="defaultValue">The default value to return if no matching item is found.</param>
    /// <param name="raiseError">Specifies whether to raise an error if no matching item is found.</param>
    /// <returns>The enumeration item with the specified enumeration value, or the default value if no matching item is found.</returns>
    public static T? FromEnum(TEnum enumValue, T? defaultValue = null, bool raiseError = true)
    {
        return Parse(enumValue.ToString()!, "Enum", item => Equals(item.Enum, enumValue), defaultValue, raiseError);
    }
}