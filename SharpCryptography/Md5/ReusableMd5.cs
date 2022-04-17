using System;

namespace LambdaTheDev.SharpCryptography.Md5
{
    public class ReusableMd5 : IHashingAlgorithm
    {
        public int DigestLength => 128;

        public ArraySegment<byte> Hash(ArraySegment<byte> input)
        {
            return new ArraySegment<byte>();
        }
    }
}