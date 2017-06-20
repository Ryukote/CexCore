using System;
using System.Globalization;

namespace CEXIO.Api.MarketEntities
{
    public struct TradeId : IComparable, IComparable<TradeId>, IFormattable, IEquatable<TradeId>
    {
        private readonly uint _id;

        public uint Id
        {
            get { return _id; }
        }

        public TradeId(uint id)
        {
            _id = id;
        }

        public override string ToString()
        {
            return _id.ToString(CultureInfo.InvariantCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return _id.ToString(format, formatProvider);
        }

        #region Equality Crap

        public bool Equals(TradeId other)
        {
            return _id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            return obj is TradeId && Equals((TradeId) obj);
        }

        #endregion

        public override int GetHashCode()
        {
            return (int) _id;
        }


        #region Comparable Crap

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (!(obj is TradeId))
                throw new ArgumentException("Object must be of type TradeId");

            return CompareTo((TradeId) obj);
        }

        public int CompareTo(TradeId other)
        {
            return _id.CompareTo(other._id);
        }

        #endregion


        #region Conversions

        public static implicit operator TradeId(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("value", value, "Value must be >= 0");

            return new TradeId((uint) value);
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
