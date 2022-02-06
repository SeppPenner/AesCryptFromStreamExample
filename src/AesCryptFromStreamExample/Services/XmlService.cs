// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlService.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   A service for XML serialization / deserialization.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AesCryptFromStreamExample.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using AesCryptFromStreamExample.Datatypes;

    /// <inheritdoc cref="IXmlService"/>
    /// <summary>
    /// A service for XML serialization / deserialization.
    /// </summary>
    /// <seealso cref="IXmlService"/>
    public class XmlService : IXmlService
    {
        /// <inheritdoc cref="IXmlService"/>
        /// <summary>
        /// Serializes an object to a XML string.
        /// </summary>
        /// <param name="myObject">The <see cref="object"/> to be serialized.</param>
        /// <param name="root">The <see cref="XmlRootAttribute"/> to be set.</param>
        /// <returns>A serialized string of the <see cref="object"/></returns>
        /// <seealso cref="IXmlService"/>
        public string SerializeToString(object myObject, XmlRootAttribute root)
        {
            var stringWriter = new StringWriter();
            var serializer = new XmlSerializer(myObject.GetType(), root);
            serializer.Serialize(stringWriter, myObject);
            return stringWriter.ToString();
        }

        /// <inheritdoc cref="IXmlService"/>
        /// <summary>
        /// Deserializes a XML string to an <see cref="DbConnection"/> <see cref="List{T}"/>.
        /// </summary>
        /// <param name="xmlString">The XML string to be deserialized.</param>
        /// <returns>A deserialized <see cref="List{T}"></see> of <see cref="DbConnections"/></returns>
        /// <seealso cref="IXmlService"/>
        public List<DbConnection> ImportDbConnectionsFromString(string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(DbConnections));
            var databaseConnections = (DbConnections?) xmlSerializer.Deserialize(new StringReader(xmlString));
            return databaseConnections?.Items.ToList() ?? new List<DbConnection>();
        }

        /// <inheritdoc cref="IDisposable"/>
        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <seealso cref="IDisposable"/>
        public void Dispose()
        {
        }
    }
}