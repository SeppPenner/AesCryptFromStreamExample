using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AesCryptFromStreamExample.Datatypes;

namespace AesCryptFromStreamExample.Services
{
    /// <inheritdoc />
    public class XmlService : IXmlService
    {
        /// <inheritdoc />
        public string SerializeToString(object myObject, XmlRootAttribute root)
        {
            var stringwriter = new StringWriter();
            var serializer = new XmlSerializer(myObject.GetType(), root);
            serializer.Serialize(stringwriter, myObject);
            return stringwriter.ToString();
        }

        /// <inheritdoc />
        public List<DbConnection> ImportDbConnectionsFromString(string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(DbConnections));
            var dbConnections = (DbConnections) xmlSerializer.Deserialize(new StringReader(xmlString));
            return dbConnections.Items.ToList();
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}