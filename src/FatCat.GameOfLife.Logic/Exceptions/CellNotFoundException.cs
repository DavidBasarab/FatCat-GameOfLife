using System;
using System.Runtime.Serialization;

namespace FatCat.GameOfLife.Logic.Exceptions
{
    [Serializable]
    public class CellNotFoundException : Exception
    {
        public CellNotFoundException()
        {
        }

        public CellNotFoundException(string message)
            : base(message)
        {
        }

        public CellNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected CellNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}