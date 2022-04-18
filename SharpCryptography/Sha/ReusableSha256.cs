using System;
using System.Security.Cryptography;

namespace LambdaTheDev.SharpCryptography.Sha
{
    public class ReusableSha256 : ReusableShaBase
    {
        private readonly SHA256CryptoServiceProvider _sha = new SHA256CryptoServiceProvider();

        public override int DigestLength => 256;
        public override ArraySegment<byte> Hash(ArraySegment<byte> input)
        {
            return new ArraySegment<byte>(_sha.ComputeHash(input.Array, input.Offset, input.Count));
        }
    }
}