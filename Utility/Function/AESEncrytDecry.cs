using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AESEncrytDecry
{
    public static string DecryptStringAES(string cipherText, string partialCode)
    {
        var keybytes = Encoding.UTF8.GetBytes(partialCode);
        var iv = Encoding.UTF8.GetBytes(partialCode);

        var encrypted = Convert.FromBase64String(cipherText);
        var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);


        return decriptedFromJavascript;
    }

    public static string EncryptStringAES(string data, string partialCode)
    {
        var keybytes = Encoding.UTF8.GetBytes(partialCode);
        var iv = Encoding.UTF8.GetBytes(partialCode);


        var decriptedFromJavascript = EncryptStringToBytes(data, keybytes, iv);
        var encrypted = Convert.ToBase64String(decriptedFromJavascript);

        return encrypted;
    }

    public static string DecryptStringAES1(string raw)
    {
        try
        {
            var keybytes = Encoding.UTF8.GetBytes("8080808080808080");
            var iv = Encoding.UTF8.GetBytes("8080808080808080");
            // Create Aes that generates a new key and initialization vector (IV).
            // Same key must be used in encryption and decryption
            using (var aes = new AesManaged())
            {
                // Encrypt string
                //byte[] encrypted = Encrypt1(raw, aes.Key, aes.IV);
                // Print encrypted string

                //decrypt the bytes to a string.
                var data = Encoding.UTF8.GetBytes(raw);
                var decrypted = Decrypt1(data, keybytes, iv);
                // Print decrypted string. It should be same as raw data
                return decrypted;
            }
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp.Message);
            return "";
        }

        Console.ReadKey();
    }


    private static byte[] Encrypt(byte[] plainBytes, byte[] key)
    {
        byte[] encryptedBytes = null;

        // Set up the encryption objects
        using (var aes = Aes.Create())
        {
            aes.Key = key;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;

            // Encrypt the input plaintext using the AES algorithm
            using (var encryptor = aes.CreateEncryptor())
            {
                encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }
        }

        return encryptedBytes;
    }

    private static byte[] Decrypt(byte[] cipherBytes, byte[] key)
    {
        byte[] decryptedBytes = null;

        // Set up the encryption objects
        using (var aes = Aes.Create())
        {
            aes.Key = key;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;

            // Decrypt the input ciphertext using the AES algorithm
            using (var decryptor = aes.CreateDecryptor())
            {
                decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            }
        }

        return decryptedBytes;
    }


    private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0) throw new ArgumentNullException("cipherText");
        if (key == null || key.Length <= 0) throw new ArgumentNullException("key");
        if (iv == null || iv.Length <= 0) throw new ArgumentNullException("key");

        // Declare the string used to hold
        // the decrypted text.
        string plaintext = null;

        // Create an RijndaelManaged object
        // with the specified key and IV.
        using (var rijAlg = new RijndaelManaged())
        {
            //Settings
            rijAlg.Mode = CipherMode.CBC;
            rijAlg.Padding = PaddingMode.PKCS7;
            rijAlg.FeedbackSize = 128;

            rijAlg.Key = key;
            rijAlg.IV = iv;

            // Create a decrytor to perform the stream transform.
            var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
            try
            {
                // Create the streams used for decryption.
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                plaintext = "keyError";
            }
        }

        return plaintext;
    }

    private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
    {
        // Check arguments.
        if (plainText == null || plainText.Length <= 0) throw new ArgumentNullException("plainText");
        if (key == null || key.Length <= 0) throw new ArgumentNullException("key");
        if (iv == null || iv.Length <= 0) throw new ArgumentNullException("key");
        byte[] encrypted;
        // Create a RijndaelManaged object
        // with the specified key and IV.
        using (var rijAlg = new RijndaelManaged())
        {
            rijAlg.Mode = CipherMode.CBC;
            rijAlg.Padding = PaddingMode.PKCS7;
            rijAlg.FeedbackSize = 128;

            rijAlg.Key = key;
            rijAlg.IV = iv;

            // Create a decrytor to perform the stream transform.
            var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

            // Create the streams used for encryption.
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }


    private static byte[] Encrypt1(string plainText, byte[] Key, byte[] IV)
    {
        byte[] encrypted;
        // Create a new AesManaged.
        using (var aes = new AesManaged())
        {
            // Create encryptor
            var encryptor = aes.CreateEncryptor(Key, IV);
            // Create MemoryStream
            using (var ms = new MemoryStream())
            {
                // Create crypto stream using the CryptoStream class. This class is the key to encryption
                // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream
                // to encrypt
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    // Create StreamWriter and write data to a stream
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }

                    encrypted = ms.ToArray();
                }
            }
        }

        // Return encrypted data
        return encrypted;
    }

    private static string Decrypt1(byte[] cipherText, byte[] Key, byte[] IV)
    {
        string plaintext = null;
        // Create AesManaged
        using (var aes = new AesManaged())
        {
            // Create a decryptor
            var decryptor = aes.CreateDecryptor(Key, IV);
            // Create the streams used for decryption.
            using (var ms = new MemoryStream(cipherText))
            {
                // Create crypto stream
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    // Read crypto stream
                    using (var reader = new StreamReader(cs))
                    {
                        plaintext = reader.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }
}