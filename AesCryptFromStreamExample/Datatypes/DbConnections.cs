using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AesCryptFromStreamExample.Datatypes
{
    /// <summary>
    /// A data class to encapsulate lists in XML.
    /// </summary>
    [Serializable]
    [XmlRoot("DbConnections")]
    public class DbConnections
    {
        /// <summary>
        /// Default constructor of <see cref="DbConnections"/>.
        /// </summary>
        public DbConnections()
        {
            Items = new List<DbConnection>();
        }

        /// <summary>
        /// The list of <see cref="DbConnection"/> items.
        /// </summary>
        [XmlElement("DbConnection")]
        public List<DbConnection> Items { get; set; }
    }
}