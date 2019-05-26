using System;
using System.Globalization;

namespace CexCore.MarketEntities
{
    public struct TradeId : IComparable, IComparable<TradeId>, IFormattable, IEquatable<TradeId>
    {
        public uint Id { get; }

        public TradeId(uint id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return Id.ToString(CultureInfo.InvariantCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Id.ToString(format, formatProvider);
        }

        #region Equality Crap

        public bool Equals(TradeId other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            return obj is TradeId && Equals((TradeId)obj);
        }

        #endregion

        public override int GetHashCode()
        {
            return (int)Id;
        }


        #region Comparable Crap

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (!(obj is TradeId))
                throw new ArgumentException("Object must be of type TradeId");

            return CompareTo((TradeId)obj);
        }

        public int CompareTo(TradeId other)
        {
            return Id.CompareTo(other.Id);
        }

        #endregion


        #region Conversions

        public static implicit operator TradeId(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("value", value, "Value must be >= 0");

            return new TradeId((uint)value);
        }

        public static implicit operator int(TradeId value)
        {
            return Convert.ToInt32(value.Id);
        }

        public static implicit operator TradeId(long value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("value", value, "Value must be >= 0");

            return new TradeId(Convert.ToUInt32(value));
        }

        public static implicit operator long(TradeId value)
        {
            return Convert.ToInt64(value.Id);
        }

        public static implicit operator TradeId(string value)
        {
            return new TradeId(uint.Parse(value));
        }

        #endregion

    }
}
