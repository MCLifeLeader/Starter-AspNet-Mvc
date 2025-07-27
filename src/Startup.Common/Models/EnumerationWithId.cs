namespace Startup.Common.Models;

public abstract class EnumerationWithId<T, TId> : Enumeration<T>
    where T : EnumerationWithId<T, TId>
    where TId : struct
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnumerationWithId{T, TId}"/> class.
    /// </summary>
    /// <param name="id">The ID of the enumeration.</param>
    /// <param name="code">The code of the enumeration.</param>
    /// <param name="description">The description of the enumeration.</param>
    /// <param name="isObsolete">Specifies whether the enumeration is obsolete.</param>
    protected EnumerationWithId(TId id, string code, string description, bool isObsolete)
        : base(code, description, isObsolete)
    {
        Id = id;
    }

    /// <summary>
    /// Gets the ID of the enumeration.
    /// </summary>
    public TId Id { get; }

    /// <summary>
    /// Retrieves an enumeration item based on its ID.
    /// </summary>
    /// <param name="id">The ID of the enumeration item.</param>
    /// <param name="defaultValue">The default value to return if no matching item is found.</param>
    /// <param name="raiseError">Specifies whether to raise an error if no matching item is found.</param>
    /// <returns>The enumeration item with the specified ID, or the default value if no matching item is found.</returns>
    public static T? FromId(TId? id, T? defaultValue = null, bool raiseError = true)
    {
        if (!id.HasValue)
        {
            return defaultValue;
        }

        return FromId(id.Value, defaultValue, raiseError);
    }

    /// <summary>
    /// Retrieves an enumeration item based on its ID.
    /// </summary>
    /// <param name="id">The ID of the enumeration item.</param>
    /// <param name="defaultValue">The default value to return if no matching item is found.</param>
    /// <param name="raiseError">Specifies whether to raise an error if no matching item is found.</param>
    /// <returns>The enumeration item with the specified ID, or the default value if no matching item is found.</returns>
    public static T? FromId(TId id, T? defaultValue = null, bool raiseError = true)
    {
        return Parse(id.ToString()!, "Id", item => Equals(item.Id, id), defaultValue, raiseError);
    }
}
