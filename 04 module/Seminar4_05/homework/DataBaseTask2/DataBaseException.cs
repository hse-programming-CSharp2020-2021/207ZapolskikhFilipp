using System;

namespace DataBaseTask2
{
    class DataBaseException : Exception
    {
        public DataBaseException() {}
        public DataBaseException(string message) : base(message) {}
    }
}
