using System;

namespace LambdaTheDev.SharpCryptography
{
    // Base interface for all hashing algorithms implemented in this library
    public interface IHashingAlgorithm
    {
        int DigestLength { get; } // Output digest length, in bits
        ArraySegment<byte> Hash(ArraySegment<byte> input); // Method used to compute hash
    }
}