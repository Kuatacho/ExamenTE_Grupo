using System;
using System.Security.Cryptography;
using System.Text;

public class Encript
{
    public byte[] EncryptBytes(byte[] dataToEncrypt, RSAParameters rsaKeyInfo)
    {
        try
        {
            byte[] encryptedData;
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(rsaKeyInfo);
                encryptedData = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA512);
            }
            return encryptedData;
        }
        catch (CryptographicException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public byte[] DecryptBytes(byte[] dataToDecrypt, RSAParameters rsaKeyInfo)
    {
        try
        {
            byte[] decryptedData;
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(rsaKeyInfo);
                decryptedData = rsa.Decrypt(dataToDecrypt, RSAEncryptionPadding.OaepSHA512);
            }
            return decryptedData;
        }
        catch (CryptographicException e)
        {
            Console.WriteLine(e.ToString());
            return null;
        }
    }
}