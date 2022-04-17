using System.Runtime.CompilerServices;

namespace LambdaTheDev.SharpCryptography.Helpers
{
    // Helper class with bitwise operations
    public static class BitwiseOpsHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RotateLeft(uint x, int n)
        {
            return (x << n) | (x >> (32 - n));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RotateRight(uint x, int n)
        {
            return (x >> n) | (x << (32 - n));
        }
    }
}