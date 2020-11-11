// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbConnections.cs"  company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   A data class to encapsulate lists in XML.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AesCryptFromStreamExample.Datatypes
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// A data class to encapsulate lists in XML.
    /// </summary>
    [Serializable]
    [XmlRoot("DbConnections")]
    public class DbConnections
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbConnections"/> class.
        /// </summary>
        public DbConnections()
        {
            this.Items = new List<DbConnection>();
        }

        /// <summary>
        /// Gets or sets the list of <see cref="DbConnection"/> items.
        /// </summary>
        [XmlElement("DbConnection")]
        public List<DbConnection> Items { get; set; }
    }
}