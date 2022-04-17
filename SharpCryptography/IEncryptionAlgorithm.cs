using System;

namespace LambdaTheDev.SharpCryptography
{
    // Base interface for all encryption algorithms implemented in this library
    public interface IEncryptionAlgorithm
    {
        ArraySegment<byte> Encrypt(ArraySegment<byte> input, byte[] key);
        ArraySegment<byte> Decrypt(ArraySegment<byte> input, byte[] key);
    }
}