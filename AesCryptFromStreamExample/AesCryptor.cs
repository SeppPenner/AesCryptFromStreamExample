using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using AesCryptFromStreamExample.Datatypes;
using AesCryptFromStreamExample.Services;
using Crypt = SharpAESCrypt.SharpAESCrypt;

namespace AesCryptFromStreamExample
{
    /// <inheritdoc />
    public class AesCryptor : IAesCryptor
    {
        private readonly IXmlService _xmlService = new XmlService();

        /// <inheritdoc />
        public void Dispose()
        {
        }

        /// <inheritdoc />
        public void EncryptDbConnectionsToFile(string fileName, List<DbConnection> dbConnections, string password)
        {
            var encryptedFile = GetEncryptedFileName(fileName);
            DeleteFileIfExists(encryptedFile);
            var xmlString = _xmlService.SerializeToString(dbConnections, new XmlRootAttribute("DbConnections"));
            var encryptedData = EncryptData(xmlString, password);
            File.WriteAllBytes(encryptedFile, encryptedData);
        }

        /// <inheritdoc />
        public IEnumerable<DbConnection> DecryptFileToDbConnection(string fileName, string password)
        {
            var encryptedFile = GetEncryptedFileName(fileName);
            var encryptedData = File.ReadAllBytes(encryptedFile);
            var xmlString = DecryptData(encryptedData, password);
            return _xmlService.ImportDbConnectionsFromString(xmlString);
        }

        private static byte[] EncryptData(string normalText, string password)
        {
            var normalTextBytes = Encoding.UTF32.GetBytes(normalText);
            byte[] encryptedBytes;
            using (var normalStream = new MemoryStream(normalTextBytes))
            {
                using (var encryptedStream = new MemoryStream())
                {
                    Crypt.Encrypt(password, normalStream, encryptedStream);
                    encryptedBytes = encryptedStream.ToArray();
                }
            }
            return encryptedBytes;
        }

        private static string DecryptData(byte[] encryptedData, string password)
        {
            string normalText;
            using (var encryptedStream = new MemoryStream(encryptedData))
            {
                using (var normalStream = new MemoryStream())
                {
                    Crypt.Decrypt(password, encryptedStream, normalStream);
                    var normalBytes = normalStream.ToArray();
                    normalText = Encoding.UTF32.GetString(normalBytes);
                }
            }
            return normalText;
        }

        private void DeleteFileIfExists(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        private static string GetEncryptedFileName(string fileName)
        {
            return fileName + ".aes";
        }
    }
}