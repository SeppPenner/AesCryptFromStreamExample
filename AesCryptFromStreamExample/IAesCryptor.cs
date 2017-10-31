using System;
using System.Collections.Generic;
using AesCryptFromStreamExample.Datatypes;

namespace AesCryptFromStreamExample
{
    /// <inheritdoc />
    /// <summary>
    /// A service to encrypt <see cref="object"/>s and serialize them to a file and vice versa.
    /// </summary>
    public interface IAesCryptor : IDisposable
    {
        /// <summary>
        /// Serializes and encrypts a data <see cref="object"/> to a file.
        /// </summary>
        /// <param name="fileName">The file to be written to.</param>
        /// <param name="dbConnections">The <see cref="List{T}"/> of <see cref="DbConnection"/>s to be serialized.</param>
        /// <param name="password">The password to encrypt the file with AES.</param>
        // ReSharper disable once UnusedMemberInSuper.Global
        void EncryptDbConnectionsToFile(string fileName, List<DbConnection> dbConnections, string password);

        /// <summary>
        /// Decrypts the file and loads a <see cref="List{T}"/> of <see cref="DbConnection"/>s.
        /// </summary>
        /// <param name="fileName">The file to be loaded.</param>
        /// <param name="password">The password to decrypt the data.</param>
        /// <returns></returns>
        // ReSharper disable once UnusedMemberInSuper.Global
        IEnumerable<DbConnection> DecryptFileToDbConnection(string fileName, string password);
    }
}