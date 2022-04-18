using System;
using System.IO;
using System.Security.Cryptography;

namespace LambdaTheDev.SharpCryptography.Aes
{
    public class ReusableAes256 : IEncryptionAlgorithm
    {
        private readonly System.Security.Cryptography.Aes _aes = System.Security.Cryptography.Aes.Create();

        public byte[] Iv
        {
            get => _aes.IV;
            set => _aes.IV = value;
        }
        
        public ArraySegment<byte> Encrypt(ArraySegment<byte> input, byte[] key)
        {
            return new ArraySegment<byte>(Encrypt(input, key, _aes.IV));
        }

        public ArraySegment<byte> Decrypt(ArraySegment<byte> input, byte[] key)
        {
            return new ArraySegment<byte>(Decrypt(input, key, _aes.IV));
        }
        
        // Code from:
        // https://stackoverflow.com/questions/53653510/c-sharp-aes-encryption-byte-array
        public byte[] Encrypt(ArraySegment<byte> data, byte[] key, byte[] iv)
        {
            _aes.KeySize = 128;
            _aes.BlockSize = 128; 
            _aes.Padding = PaddingMode.Zeros;
            
            _aes.Key = key;
            _aes.IV = iv;

            using (var encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV))
            {
                return PerformCryptography(data, encryptor);
            }
        }
        
        public byte[] Decrypt(ArraySegment<byte> data, byte[] key, byte[] iv)
        {
            _aes.KeySize = 128;
            _aes.BlockSize = 128;
            _aes.Padding = PaddingMode.Zeros;

            _aes.Key = key;
            _aes.IV = iv;
            
            using (var decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV))
            {
                return PerformCryptography(data, decryptor);
            }
        }

        private byte[] PerformCryptography(ArraySegment<byte> data, ICryptoTransform cryptoTransform)
        {
            using (var ms = new MemoryStream())
            using (var cryptoStream = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data.Array, data.Offset, data.Count);
                cryptoStream.FlushFinalBlock();

                return ms.ToArray();
            }
        }
    }
}