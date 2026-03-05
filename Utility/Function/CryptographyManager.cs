using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class CryptographyManager
{
    private const string initVector = "pemgail9uzpgzl88";

    // This constant is used to determine the keysize of the encryption algorithm
    private const int keysize = 256;


    private static byte[] key = { };
    private static readonly byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };

    public static string GetMd5Hash(string input)
    {
        using (var md5Hash = MD5.Create())
        {
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (var i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }

    // Verify a hash against a string.
    public static bool VerifyMd5Hash(string input, string hash)
    {
        using (var md5Hash = MD5.Create())
        {
            // Hash the input.
            var hashOfInput = GetMd5Hash(input);

            // Create a StringComparer an compare the hashes.
            var comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
                return true;
            return false;
        }
    }

    public static string Encrypt(string clearText)
    {
        var EncryptionKey = "hyddhrii%2moi43Hd5%%";
        var clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (var encryptor = Aes.Create())
        {
            var pdb = new Rfc2898DeriveBytes(EncryptionKey,
                new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }

                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }

        return clearText;
    }


    public static string Decrypt(string cipherText)
    {
        var EncryptionKey = "hyddhrii%2moi43Hd5%%";
        cipherText = cipherText.Replace(" ", "+");
        var cipherBytes = Convert.FromBase64String(cipherText);
        using (var encryptor = Aes.Create())
        {
            var pdb = new Rfc2898DeriveBytes(EncryptionKey,
                new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }

                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }

        return cipherText;
    }

    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }


    public static string EncryptAESString(string key, string plainText)
    {
        var iv = new byte[16];
        byte[] array;

        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }

                    array = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(array);
    }

    public static string DecryptAESString(string key, string cipherText)
    {
        var iv = new byte[16];
        var buffer = Convert.FromBase64String(cipherText);

        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (var memoryStream = new MemoryStream(buffer))
            {
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (var streamReader = new StreamReader(cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }

    //Encrypt
    public static string EncryptString1(string plainText, string passPhrase)
    {
        var initVectorBytes = Encoding.UTF8.GetBytes(initVector);
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        var password = new PasswordDeriveBytes(passPhrase, null);
        var keyBytes = password.GetBytes(keysize / 8);
        var symmetricKey = new RijndaelManaged();
        symmetricKey.Mode = CipherMode.CBC;
        var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
        var memoryStream = new MemoryStream();
        var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
        cryptoStream.FlushFinalBlock();
        var cipherTextBytes = memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();
        return Convert.ToBase64String(cipherTextBytes);
    }

    //Decrypt
    public static string DecryptString1(string cipherText, string passPhrase)
    {
        var initVectorBytes = Encoding.UTF8.GetBytes(initVector);
        var cipherTextBytes = Convert.FromBase64String(cipherText);
        var password = new PasswordDeriveBytes(passPhrase, null);
        var keyBytes = password.GetBytes(keysize / 8);
        var symmetricKey = new RijndaelManaged();
        symmetricKey.Mode = CipherMode.CBC;
        var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
        var memoryStream = new MemoryStream(cipherTextBytes);
        var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        var plainTextBytes = new byte[cipherTextBytes.Length];
        var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        memoryStream.Close();
        cryptoStream.Close();
        return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
    }

    public static string Decrypt(string stringToDecrypt, string sEncryptionKey)
    {
        var inputByteArray = new byte[stringToDecrypt.Length + 1];
        try
        {
            key = Encoding.UTF8.GetBytes(sEncryptionKey);
            var des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(stringToDecrypt);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms,
                des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            var encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public static string Encrypt(string stringToEncrypt, string SEncryptionKey)
    {
        try
        {
            key = Encoding.UTF8.GetBytes(SEncryptionKey);
            var des = new DESCryptoServiceProvider();
            var inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms,
                des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }


    public string EncryptQueryString(string inputText, string key, string salt)
    {
        var plainText = Encoding.UTF8.GetBytes(inputText);

        using (var rijndaelCipher = new RijndaelManaged())
        {
            var secretKey = new PasswordDeriveBytes(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(salt));
            using (var encryptor = rijndaelCipher.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainText, 0, plainText.Length);
                        cryptoStream.FlushFinalBlock();
                        var base64 = Convert.ToBase64String(memoryStream.ToArray());

                        // Generate a string that won't get screwed up when passed as a query string.
                        var urlEncoded = HttpUtility.UrlEncode(base64);
                        return urlEncoded;
                    }
                }
            }
        }
    }

    public string DecryptQueryString(string inputText, string key, string salt)
    {
        var encryptedData = Convert.FromBase64String(inputText);
        var secretKey = new PasswordDeriveBytes(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(salt));

        using (var rijndaelCipher = new RijndaelManaged())
        {
            using (var decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
            {
                using (var memoryStream = new MemoryStream(encryptedData))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        var plainText = new byte[encryptedData.Length];
                        cryptoStream.Read(plainText, 0, plainText.Length);
                        var utf8 = Encoding.UTF8.GetString(plainText);
                        return utf8;
                    }
                }
            }
        }
    }
}