using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatCat.GameOfLife.Logic
{
    public class Coordinate
    {
        public int Row { get; set; }
        public int Column { get; set; }

        private Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public static Coordinate Create(int row, int column)
        {
            return new Coordinate(row, column);
        }

        public override bool Equals(object obj)
        {
            var otherObj = obj as Coordinate;

            if (obj == null && otherObj != null)
            {
                return false;
            }

            return Row == otherObj.Row && Column == otherObj.Column;
        }

        public override int GetHashCode()
        {
            var hash = string.Format("{0}{1}", Row, Column);

            return hash.GetHashCode();
        }

        public static bool operator ==(Coordinate rhs, Coordinate lhs)
        {
            if (IsNull(rhs, lhs))
            {
                if (BothAreNull(rhs, lhs))
                {
                    return true;
                }

                // Only 1 is null the other is not so they do not equal
                return false;
            }

            return rhs.Equals(lhs);
        }

        public static bool operator !=(Coordinate rhs, Coordinate lhs)
        {
            if (IsNull(rhs, lhs))
            {
                if (BothAreNull(rhs, lhs))
                {
                    return false;
                }

                // Only 1 is null the other is not so they do not equal
                return true;
            }

            return !rhs.Equals(lhs);
        }

        private static bool BothAreNull(Coordinate rhs, Coordinate lhs)
        {
            return ReferenceEquals(rhs, null) && ReferenceEquals(lhs, null);
        }

        private static bool IsNull(Coordinate rhs, Coordinate lhs)
        {
            return ReferenceEquals(rhs, null) || ReferenceEquals(lhs, null);
        }
    }
}
