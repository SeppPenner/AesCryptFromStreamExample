// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs"  company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The main program class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AesCryptFromStreamExampleUsage;

/// <summary>
/// The main program class.
/// </summary>
public static class Program
{
    /// <summary>
    /// The main method.
    /// </summary>
    public static void Main()
    {
        var databaseConnections = new List<DbConnection>
            {
                new DbConnection
                {
                    ConnectionString = "cloud.asdf.org:user:password",
                    Name = "ASDF cloud"
                },
                new DbConnection
                {
                    ConnectionString = "cloud.asdf2.org:user:password",
                    Name = "ASDF cloud2"
                }
            };

        using var aesCryptor = new AesCryptor();
        // File Test.txt.aes created with the encrypted data types.
        aesCryptor.EncryptDbConnectionsToFile("Test.txt", databaseConnections, "TestPW");

        var databaseConnectionsLoaded = aesCryptor.DecryptFileToDatabaseConnections("Test.txt", "TestPW");
        // databaseConnectionsLoaded contains the stored data types in the file.
    }
}
