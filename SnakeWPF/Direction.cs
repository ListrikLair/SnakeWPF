using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWPF
{
    public class Direction : IEquatable<Direction>
    {
        public static readonly Direction Left = new(0, -1);
        public static readonly Direction Right = new(0, 1);
        public static readonly Direction Up = new(-1, 0);
        public static readonly Direction Down = new(1, 0);

        public int RowOffset { get; }
        public int ColumnOffset { get; }

        private Direction(int rowOffset, int columnOffset)
        {
            RowOffset = rowOffset;
            ColumnOffset = columnOffset;
        }

        public Direction Opposite()
        {
            return new Direction(-RowOffset, -ColumnOffset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Direction)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                return (RowOffset * 397) ^ ColumnOffset;
            }
        }
        
        public static bool operator ==(Direction left, Direction right)
        {
            return EqualityComparer<Direction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(Direction left, Direction right)
        {
            return !(left == right);
        }

        public bool Equals(Direction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return RowOffset == other.RowOffset && ColumnOffset == other.ColumnOffset;
        }
    }
}
