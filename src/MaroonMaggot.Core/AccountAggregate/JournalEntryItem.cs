using MaroonMaggot.SharedKernel;
using System;

namespace MaroonMaggot.Core.AccountAggregate
{
    public class JournalEntryItem : BaseEntity<Guid>
    {
        public Account Account { get; set; }
        public decimal Amount { get; set; }

        public JournalEntryItemType Type => Amount == 0m ? JournalEntryItemType.NoValue : (Amount > 0m ? JournalEntryItemType.Credit : JournalEntryItemType.Debit);
    }
}
