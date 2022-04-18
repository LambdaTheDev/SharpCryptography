using System;
using System.Security.Cryptography;

namespace LambdaTheDev.SharpCryptography.Sha
{
    public class ReusableSha512 : ReusableShaBase
    {
        private readonly SHA512CryptoServiceProvider _sha = new SHA512CryptoServiceProvider();
        
        public override int DigestLength => 512;
        public override ArraySegment<byte> Hash(ArraySegment<byte> input)
        {
            return new ArraySegment<byte>(_sha.ComputeHash(input.Array, input.Offset, input.Count));
        }
    }
}