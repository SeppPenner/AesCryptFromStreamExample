// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAesCryptor.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   A service to encrypt <see cref="object" />s and serialize them to a file and vice versa.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AesCryptFromStreamExample
{
    using System;
    using System.Collections.Generic;

    using AesCryptFromStreamExample.Datatypes;

    /// <summary>
    /// A service to encrypt <see cref="object"/>s and serialize them to a file and vice versa.
    /// </summary>
    public interface IAesCryptor : IDisposable
    {
        /// <summary>
        /// Serializes and encrypts a data <see cref="object"/> to a file.
        /// </summary>
        /// <param name="fileName">The file to be written to.</param>
        /// <param name="databaseConnections">The <see cref="List{T}"/> of <see cref="DbConnection"/>s to be serialized.</param>
        /// <param name="password">The password to encrypt the file with AES.</param>
        // ReSharper disable once UnusedMemberInSuper.Global
        void EncryptDbConnectionsToFile(string fileName, List<DbConnection> databaseConnections, string password);

        /// <summary>
        /// Decrypts the file and loads a <see cref="List{T}"/> of <see cref="DbConnection"/>s.
        /// </summary>
        /// <param name="fileName">The file to be loaded.</param>
        /// <param name="password">The password to decrypt the data.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> of <see cref="DbConnection"/>s.</returns>
        // ReSharper disable once UnusedMemberInSuper.Global
        IEnumerable<DbConnection> DecryptFileToDatabaseConnections(string fileName, string password);
    }
}