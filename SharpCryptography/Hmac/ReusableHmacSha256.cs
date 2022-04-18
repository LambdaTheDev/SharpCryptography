using System;
using System.Security.Cryptography;

namespace LambdaTheDev.SharpCryptography.Hmac
{
    public class ReusableHmacSha256 : ReusableHmac
    {
        private readonly HMACSHA256 _hmac = new HMACSHA256();
        
        public override int DigestLength => 256;

        public override ArraySegment<byte> Hash(ArraySegment<byte> input)
        {
            _hmac.Key = SecretKey;
            return new ArraySegment<byte>(_hmac.ComputeHash(input.Array, input.Offset, input.Count));
        }
    }
}