using Ardalis.GuardClauses;
using MaroonMaggot.Core.AccountAggregate.Events;
using MaroonMaggot.SharedKernel;
using MaroonMaggot.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace MaroonMaggot.Core.AccountAggregate
{
    public class Account : BaseEntity<int>, IAggregateRoot
    {
        #region Class Data

        private List<Account> _subAccounts = new();

        #endregion

        #region Properties

        public string Name { get; private set; }
        public IEnumerable<Account> SubAccounts => _subAccounts.AsReadOnly();

        #endregion

        #region Constructor

        public Account(string name)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
        }

        #endregion

        #region MyRegion

        public void AddSubAccount(Account subAccount)
        {
            Guard.Against.Null(subAccount, nameof(subAccount));
            _subAccounts.Add(subAccount);

            var subAccountAddedEvent = new SubAccountAddedEvent(this, subAccount);
            Events.Add(subAccountAddedEvent);
        }

        public void UpdateName(string newName)
        {
            Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
        } 

        #endregion
    }
}
