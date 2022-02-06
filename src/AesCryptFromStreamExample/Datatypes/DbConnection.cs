// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbConnection.cs"  company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The XML data type of a database connection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AesCryptFromStreamExample.Datatypes
{
    using System;

    /// <summary>
    /// The XML data type of a database connection.
    /// </summary>
    [Serializable]
    public class DbConnection
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string ConnectionString { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the shown name.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Name { get; set; } = string.Empty;
    }
}