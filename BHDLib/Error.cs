using System;

namespace BhdLib
{
    public class HashCollisionException : Exception
    {
        public HashCollisionException() { }
        public HashCollisionException(string message) : base(message) { }
        public HashCollisionException(string message, Exception inner) : base(message, inner) { }
    }
}
