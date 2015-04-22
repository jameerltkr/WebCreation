﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Hash_Pass
/// </summary>
public class Hash_Pass
{
    private static readonly RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
    private static readonly byte[] c_key = new byte[] { 1, 2, 23, 234, 37, 48, 134, 63, 248, 4 };
    private static readonly byte[] c_iv = new byte[] {111,67,09,9,53};
    public static string EncryptText(string openText)
    {
        RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();

        ICryptoTransform encryptor = rc2CSP.CreateEncryptor();
        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                byte[] toEncrypt = Encoding.Unicode.GetBytes(openText);

                csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
                csEncrypt.FlushFinalBlock();

                byte[] encrypted = msEncrypt.ToArray();

                return Convert.ToBase64String(encrypted);
            }
        }
    }
    public static string DecryptText(string encryptedText)
    {
        RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
        ICryptoTransform decryptor = rc2CSP.CreateDecryptor();
        using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText)))
        {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                List<Byte> bytes = new List<byte>();
                int b;
                do
                {
                    b = csDecrypt.ReadByte();
                    if (b != -1)
                    {
                        bytes.Add(Convert.ToByte(b));
                    }

                }
                while (b != -1);

                return Encoding.Unicode.GetString(bytes.ToArray());
            }
        }
    }



    public static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
    {
        // Check arguments.
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("Key");
        byte[] encrypted;
        // Create an RijndaelManaged object
        // with the specified key and IV.
        using (RijndaelManaged rijAlg = new RijndaelManaged())
        {
            rijAlg.Key = Key;
            rijAlg.IV = IV;
            rijAlg.Mode = CipherMode.CBC;
            rijAlg.Padding = PaddingMode.Zeros;

            // Create a decrytor to perform the stream transform.
            ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
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
    public static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("Key");

        // Declare the string used to hold
        // the decrypted text.
        string plaintext = null;

        // Create an RijndaelManaged object
        // with the specified key and IV.
        using (RijndaelManaged rijAlg = new RijndaelManaged())
        {
            rijAlg.Key = Key;
            rijAlg.IV = IV;
            rijAlg.Mode = CipherMode.CBC;
            rijAlg.Padding = PaddingMode.Zeros;

            // Create a decrytor to perform the stream transform.
            ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

        }

        return plaintext;
    }

}