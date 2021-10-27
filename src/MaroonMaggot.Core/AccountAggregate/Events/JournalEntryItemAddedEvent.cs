using MaroonMaggot.SharedKernel;

namespace MaroonMaggot.Core.AccountAggregate.Events
{
    public class JournalEntryItemAddedEvent : BaseDomainEvent
    {
        public JournalEntry JournalEntry { get; set; }
        public JournalEntryItem JournalEntryItem { get; set; }
        
        public JournalEntryItemAddedEvent(JournalEntry journalEntry, JournalEntryItem journalEntryItem)
        {
            JournalEntry = journalEntry;
            JournalEntryItem = journalEntryItem;
        }
    }
}
