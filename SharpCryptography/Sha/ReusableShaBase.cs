using System;

namespace LambdaTheDev.SharpCryptography.Sha
{
    // Abstract base for all SHA-2 implementations
    public abstract class ReusableShaBase : IHashingAlgorithm
    {
        public abstract int DigestLength { get; }
        public abstract ArraySegment<byte> Hash(ArraySegment<byte> input);
    }
}