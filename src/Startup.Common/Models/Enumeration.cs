using System.Reflection;

namespace Startup.Common.Models;

/// <summary>
/// Represents an abstract base class for enumerations.
/// </summary>
/// <typeparam name="T">The type of the enumeration.</typeparam>
public abstract class Enumeration<T> : IEquatable<T>
    where T : Enumeration<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Enumeration{T}"/> class.
    /// </summary>
    /// <param name="code">The code of the enumeration.</param>
    /// <param name="description">The description of the enumeration.</param>
    /// <param name="isObsolete">Indicates whether the enumeration is obsolete.</param>
    protected Enumeration(string code, string description, bool isObsolete)
    {
        Code = code;
        Description = description;
        IsObsolete = isObsolete;
    }

    /// <summary>
    /// Gets the code of the enumeration.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the description of the enumeration.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets a value indicating whether the enumeration is obsolete.
    /// </summary>
    public bool IsObsolete { get; }

    /// <summary>
    /// Gets all the values of the enumeration.
    /// </summary>
    /// <returns>An enumerable collection of the enumeration values.</returns>
    public static IEnumerable<T> GetAll()
    {
        var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

        return fields.Select(f => f.GetValue(null)).Cast<T>();
    }

    /// <summary>
    /// Gets the enumeration value based on the specified code.
    /// </summary>
    /// <param name="code">The code of the enumeration value.</param>
    /// <param name="defaultValue">The default value to return if no matching value is found.</param>
    /// <param name="raiseError">Indicates whether to raise an error if no matching value is found.</param>
    /// <returns>The enumeration value with the specified code.</returns>
    public static T? FromCode(string code, T? defaultValue = null, bool raiseError = true)
    {
        var matchingItem = Parse(code, "Code", item => item.Code == code, defaultValue, raiseError);
        return matchingItem;
    }

    /// <summary>
    /// Parses the enumeration value based on the specified value and predicate.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <param name="fieldName">The name of the field being parsed.</param>
    /// <param name="predicate">The predicate used to match the enumeration value.</param>
    /// <param name="defaultValue">The default value to return if no matching value is found.</param>
    /// <param name="raiseError">Indicates whether to raise an error if no matching value is found.</param>
    /// <returns>The parsed enumeration value.</returns>
    protected static T? Parse(string value, string fieldName, Func<T, bool> predicate, T? defaultValue, bool raiseError)
    {
        var matchingItem = GetAll().SingleOrDefault(predicate) ?? defaultValue;

        if (matchingItem is null && raiseError)
        {
            throw new ArgumentException($"'{value}' is not a valid {fieldName} in {typeof(T).Name}");
        }

        return matchingItem;
    }

    /// <summary>
    /// Returns the description of the enumeration.
    /// </summary>
    /// <returns>The description of the enumeration.</returns>
    public override string ToString()
    {
        return Description;
    }

    /// <summary>
    /// Returns the hash code of the enumeration code.
    /// </summary>
    /// <returns>The hash code of the enumeration code.</returns>
    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }

    /// <summary>
    /// Determines whether the current object is equal to another object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>True if the current object is equal to the other object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        return Equals(obj as T);
    }

    /// <summary>
    /// Determines whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns>True if the current object is equal to the other object; otherwise, false.</returns>
    public bool Equals(T? other)
    {
        return this == other;
    }

    /// <summary>
    /// Determines whether two enumeration values are equal.
    /// </summary>
    /// <param name="enum1">The first enumeration value to compare.</param>
    /// <param name="enum2">The second enumeration value to compare.</param>
    /// <returns>True if the two enumeration values are equal; otherwise, false.</returns>
    public static bool operator ==(Enumeration<T>? enum1, Enumeration<T>? enum2)
    {
        if (ReferenceEquals(enum1, enum2))
        {
            return true;
        }

        if (enum1 is null || enum2 is null)
        {
            return false;
        }

        var typeMatches = enum1.GetType() == enum2.GetType();
        var codeMatches = string.Equals(enum1.Code, enum2.Code, StringComparison.InvariantCultureIgnoreCase);

        return typeMatches && codeMatches;
    }

    /// <summary>
    /// Determines whether two enumeration values are not equal.
    /// </summary>
    /// <param name="enum1">The first enumeration value to compare.</param>
    /// <param name="enum2">The second enumeration value to compare.</param>
    /// <returns>True if the two enumeration values are not equal; otherwise, false.</returns>
    public static bool operator !=(Enumeration<T>? enum1, Enumeration<T>? enum2)
    {
        return !(enum1 == enum2);
    }
}