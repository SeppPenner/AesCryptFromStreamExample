// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IXmlService.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   A service for XML serialization / deserialization.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AesCryptFromStreamExample.Services;

/// <inheritdoc cref="IDisposable"/>
/// <summary>
/// A service for XML serialization / deserialization.
/// </summary>
/// <seealso cref="IDisposable"/>
public interface IXmlService : IDisposable
{
    /// <summary>
    /// Serializes an object to a XML string.
    /// </summary>
    /// <param name="myObject">The <see cref="object"/> to be serialized.</param>
    /// <param name="root">The <see cref="XmlRootAttribute"/> to be set.</param>
    /// <returns>A serialized string of the <see cref="object"/></returns>
    string SerializeToString(object myObject, XmlRootAttribute root);

    /// <summary>
    /// Deserializes a XML string to an <see cref="DbConnection"/> <see cref="List{T}"/>.
    /// </summary>
    /// <param name="xmlString">The XML string to be deserialized.</param>
    /// <returns>A deserialized <see cref="List{T}"></see> of <see cref="DbConnections"/></returns>
    List<DbConnection> ImportDbConnectionsFromString(string xmlString);
}
