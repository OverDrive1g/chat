using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    public partial class Form1 : Form {
        private UserData data;
        public Form1()
        {
            InitializeComponent();

            data = new UserData();
        }

        private void button1_Click(object sender, EventArgs e) {

            var message = "This is message";

            using (AesCryptoServiceProvider _crypt = new AesCryptoServiceProvider())
            {
                
                byte[] encrypted = EncryptStringToBytes_Aes(message, _crypt.Key, _crypt.IV);//шифрование сообщение

                data.Key = _crypt.Key;
                data.IV = _crypt.IV;
                //запись
                BinaryFormatter binFormat = new BinaryFormatter();
                using (Stream fStream = new FileStream("user.dat", FileMode.OpenOrCreate)) {
                    binFormat.Serialize(fStream, data);

                }
                //считывание
                using (FileStream fs = new FileStream("user.dat", FileMode.OpenOrCreate)) {
                    UserData userData = (UserData) binFormat.Deserialize(fs);


                    Console.WriteLine("Key: {0}", Encoding.Default.GetString(userData.Key));
                    Console.WriteLine("IV: {0}", Encoding.Default.GetString(userData.IV));
                }

                Console.WriteLine("Test: {0}", Encoding.Default.GetString(encrypted));
                
                string roundtrip = DecryptStringFromBytes_Aes(encrypted, _crypt.Key, _crypt.IV);//дешифрование сообщения
                
                Console.WriteLine("\nOriginal:   {0}", message);
                Console.WriteLine("Round Trip: {0}", roundtrip);
            }
        }

        private byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV) {
            // проверка входных данных
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            using (AesCryptoServiceProvider crypt = new AesCryptoServiceProvider())
            {
                crypt.Key = Key;
                crypt.IV = IV;
                
                ICryptoTransform encryptor = crypt.CreateEncryptor(crypt.Key, crypt.IV);
                
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            
            return encrypted;
        }

        private string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV) {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

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
}
