// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AesCryptor.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   A service to encrypt <see cref="object" />s and serialize them to a file and vice versa.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AesCryptFromStreamExample;

/// <inheritdoc cref="IAesCryptor"/>
/// <summary>
/// A service to encrypt <see cref="object"/>s and serialize them to a file and vice versa.
/// </summary>
/// <seealso cref="IAesCryptor"/>
public class AesCryptor : IAesCryptor
{
    /// <summary>
    /// The XML service.
    /// </summary>
    private readonly IXmlService xmlService = new XmlService();

    /// <inheritdoc cref="IDisposable"/>
    /// <summary>
    /// Disposes the object.
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc cref="IAesCryptor"/>
    /// <summary>
    /// Serializes and encrypts a data <see cref="object"/> to a file.
    /// </summary>
    /// <param name="fileName">The file to be written to.</param>
    /// <param name="databaseConnections">The <see cref="List{T}"/> of <see cref="DbConnection"/>s to be serialized.</param>
    /// <param name="password">The password to encrypt the file with AES.</param>
    /// <seealso cref="IAesCryptor"/>
    public void EncryptDbConnectionsToFile(string fileName, List<DbConnection> databaseConnections, string password)
    {
        var encryptedFile = GetEncryptedFileName(fileName);
        DeleteFileIfExists(encryptedFile);
        var xmlString = this.xmlService.SerializeToString(databaseConnections, new XmlRootAttribute("DbConnections"));
        var encryptedData = EncryptData(xmlString, password);
        File.WriteAllBytes(encryptedFile, encryptedData);
    }

    /// <inheritdoc cref="IAesCryptor"/>
    /// <summary>
    /// Decrypts the file and loads a <see cref="List{T}"/> of <see cref="DbConnection"/>s.
    /// </summary>
    /// <param name="fileName">The file to be loaded.</param>
    /// <param name="password">The password to decrypt the data.</param>
    /// <returns>A <see cref="IEnumerable{T}"/> of <see cref="DbConnection"/>s.</returns>
    /// <seealso cref="IAesCryptor"/>
    public IEnumerable<DbConnection> DecryptFileToDatabaseConnections(string fileName, string password)
    {
        var encryptedFile = GetEncryptedFileName(fileName);
        var encryptedData = File.ReadAllBytes(encryptedFile);
        var xmlString = DecryptData(encryptedData, password);
        return this.xmlService.ImportDbConnectionsFromString(xmlString);
    }

    /// <summary>
    /// Encrypts the data.
    /// </summary>
    /// <param name="normalText">The normal text.</param>
    /// <param name="password">The password.</param>
    /// <returns>The encrypted data as <see cref="T:byte[]"/>.</returns>
    private static byte[] EncryptData(string normalText, string password)
    {
        var normalTextBytes = Encoding.UTF32.GetBytes(normalText);
        using var normalStream = new MemoryStream(normalTextBytes);
        using var encryptedStream = new MemoryStream();
        Crypt.Encrypt(password, normalStream, encryptedStream);
        var encryptedBytes = encryptedStream.ToArray();
        return encryptedBytes;
    }

    /// <summary>
    /// Decrypts the data.
    /// </summary>
    /// <param name="encryptedData">The encrypted data as <see cref="T:byte[]"/>.</param>
    /// <param name="password">The password.</param>
    /// <returns>The decrypted data as <see cref="string"/>.</returns>
    private static string DecryptData(byte[] encryptedData, string password)
    {
        using var encryptedStream = new MemoryStream(encryptedData);
        using var normalStream = new MemoryStream();
        Crypt.Decrypt(password, encryptedStream, normalStream);
        var normalBytes = normalStream.ToArray();
        var normalText = Encoding.UTF32.GetString(normalBytes);
        return normalText;
    }

    /// <summary>
    /// Deletes the file if it exists.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    private static void DeleteFileIfExists(string fileName)
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
    }

    /// <summary>
    /// Gets the encrypted file name from the file name.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The encrypted file name as <see cref="string"/>.</returns>
    private static string GetEncryptedFileName(string fileName)
    {
        return fileName + ".aes";
    }
}
