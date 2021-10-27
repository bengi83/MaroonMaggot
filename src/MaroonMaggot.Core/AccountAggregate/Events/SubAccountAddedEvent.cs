using MaroonMaggot.SharedKernel;

namespace MaroonMaggot.Core.AccountAggregate.Events
{
    public class SubAccountAddedEvent : BaseDomainEvent
    {
        public Account Account { get; set; }
        public Account SubAccount { get; set; }

        public SubAccountAddedEvent(Account account, Account subAccount)
        {
            Account = account;
            SubAccount = subAccount;
        }
    }
}
