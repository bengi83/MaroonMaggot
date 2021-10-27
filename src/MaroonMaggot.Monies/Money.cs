using System;

namespace MaroonMaggot.Monies
{
    public struct Money : IComparable<Money>, IEquatable<Money>
    {
        #region Properties

        public decimal Amount { get; init; }

        #endregion

        #region Constructor

        public Money(decimal amount)
        {
            Amount = amount;
        }

        #endregion

        #region Methods

        public int CompareTo(Money other)
        {
            if (Amount < other.Amount)
                return -1;
            if (Amount > other.Amount)
                return 1;
            return 0;
        }

        public bool Equals(Money other)
        {
            return Amount == other.Amount;  
        }

        public static bool operator ==(Money lefthand, Money righthand) => lefthand.Amount == righthand.Amount;

        public static bool operator !=(Money lefthand, Money righthand) => lefthand.Amount != righthand.Amount;

        public static bool operator >(Money lefthand, Money righthand) => lefthand.Amount > righthand.Amount;

        public static bool operator <(Money lefthand, Money righthand) => lefthand.Amount < righthand.Amount;

        public static bool operator <=(Money lefthand, Money righthand) => lefthand.Amount <= righthand.Amount;

        public static bool operator >=(Money lefthand, Money righthand) => lefthand.Amount >= righthand.Amount;

        public static Money operator *(Money lefthand, Money righthand) => new(lefthand.Amount * righthand.Amount);

        public static Money operator /(Money lefthand, Money righthand) => new(lefthand.Amount / righthand.Amount);

        public static Money operator %(Money lefthand, Money righthand) => new(lefthand.Amount % righthand.Amount);

        public override bool Equals(object obj) => obj is Money other && this.Equals(other);

        public override int GetHashCode()
        {
            return Amount.GetHashCode();
        }

        #endregion
    }
}
