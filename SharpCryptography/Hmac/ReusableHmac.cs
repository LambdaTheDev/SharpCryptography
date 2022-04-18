using System;

namespace LambdaTheDev.SharpCryptography.Hmac
{
    public class ReusableHmac : IHashingAlgorithm
    {
        public virtual int DigestLength { get; }
        public byte[] SecretKey { get; set; }
        
        public virtual ArraySegment<byte> Hash(ArraySegment<byte> input)
        {
            throw new NotImplementedException();
        }
    }
}