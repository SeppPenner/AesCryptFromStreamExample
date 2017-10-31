AesCryptFromStreamExample
====================================

AesCryptFromStreamExample is an assembly/ library to serialize and encrypt data structures from C# as XML string to a file using [AESCrypt](https://www.aescrypt.com/).
The assembly was written and tested in .Net 4.6.2.

[![Build status](https://ci.appveyor.com/api/projects/status/qd124sp96fhwkbgk?svg=true)](https://ci.appveyor.com/project/SeppPenner/aescryptfromstreamexample)
[![GitHub issues](https://img.shields.io/github/issues/SeppPenner/AesCryptFromStreamExample.svg)](https://github.com/SeppPenner/AesCryptFromStreamExample/issues)
[![GitHub forks](https://img.shields.io/github/forks/SeppPenner/AesCryptFromStreamExample.svg)](https://github.com/SeppPenner/AesCryptFromStreamExample/network)
[![GitHub stars](https://img.shields.io/github/stars/SeppPenner/AesCryptFromStreamExample.svg)](https://github.com/SeppPenner/AesCryptFromStreamExample/stargazers)
[![GitHub license](https://img.shields.io/badge/license-AGPL-blue.svg)](https://raw.githubusercontent.com/SeppPenner/AesCryptFromStreamExample/master/License.txt)

## Basic usage:
```csharp
private void Test()
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
```

## Additional information:
This example only works with the AESCrypt library from [NuGet](https://www.nuget.org/packages/SharpAESCrypt.dll/).

You can easily customize the services when changing the DbConnection class, the XmlRootAttribute("DbConnections")
in the AESCryptor class and the DbConnections class (Especially the [XmlRoot("DbConnections")]) to anything else
(Maybe even a generic way with T parameter is possible).


Change history
--------------

* **Version 1.0.0.0 (2017-10-31)** : 1.0 release.
