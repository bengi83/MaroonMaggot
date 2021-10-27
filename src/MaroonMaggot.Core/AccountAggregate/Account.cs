using Ardalis.GuardClauses;
using MaroonMaggot.SharedKernel;
using MaroonMaggot.SharedKernel.Interfaces;

namespace MaroonMaggot.Core.AccountAggregate
{
    public class Account : BaseEntity<int>, IAggregateRoot
    {
        #region Class Data

        #endregion

        #region Properties

        public string Name { get; private set; }
        public Account? ParentAccount { get; private set; }

        #endregion

        #region Constructor

        public Account(string name, Account? parentAccount = null)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            ParentAccount = parentAccount;
        }

        #endregion

        #region Methods

        public void UpdateName(string newName)
        {
            Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
        }

        public void ClearParentAccount()
        {
            ParentAccount = null;
        }

        public void SetParentAccount(Account parentAccount)
        {
            ParentAccount = parentAccount;
        }

        #endregion
    }
}
