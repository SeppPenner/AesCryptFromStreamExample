using System.Collections.Generic;
using AesCryptFromStreamExample;
using AesCryptFromStreamExample.Datatypes;

namespace AesCryptFromStreamExampleUsage
{
    internal static class Program
    {
        private static void Main()
        {
            var dbConnections = new List<DbConnection>
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
            using (var aesCryptor = new AesCryptor())
            {
                aesCryptor.EncryptDbConnectionsToFile("Test.txt", dbConnections, "TestPW");
                //File Test.txt.aes created with the encrypted data types
                // ReSharper disable once UnusedVariable
                var dbConnectionsLoaded = aesCryptor.DecryptFileToDbConnection("Test.txt", "TestPW");
                //dbConnectionsLoaded contains the stored data types in the file
            }
        }
    }
}
