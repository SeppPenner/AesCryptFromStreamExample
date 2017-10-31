using System;

namespace AesCryptFromStreamExample.Datatypes
{
    /// <summary>
    /// The XML data type of a database connection.
    /// </summary>
    [Serializable]
    public class DbConnection
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string ConnectionString { get; set; }

        /// <summary>
        /// The shown name.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Name { get; set; }
    }
}