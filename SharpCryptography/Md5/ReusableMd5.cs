using System;
using System.Security.Cryptography;

namespace LambdaTheDev.SharpCryptography.Md5
{
    public class ReusableMd5 : IHashingAlgorithm
    {
        private readonly MD5CryptoServiceProvider _md5 = new MD5CryptoServiceProvider();
    
        public int DigestLength => 128;

        public ArraySegment<byte> Hash(ArraySegment<byte> input)
        {
            return new ArraySegment<byte>(_md5.ComputeHash(input.Array, input.Offset, input.Count));
        }
    }
}