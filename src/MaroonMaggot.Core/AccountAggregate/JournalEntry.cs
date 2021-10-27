using Ardalis.GuardClauses;
using MaroonMaggot.Core.AccountAggregate.Events;
using MaroonMaggot.SharedKernel;
using MaroonMaggot.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaroonMaggot.Core.AccountAggregate
{
    public class JournalEntry : BaseEntity<int>, IAggregateRoot
    {
        #region Class Data

        private List<JournalEntryItem> _journalEntryItems = new();

        #endregion

        #region Properties

        public DateTime JournalDate { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<JournalEntryItem> Items => _journalEntryItems.AsReadOnly();

        #endregion

        #region Constructor

        public JournalEntry(DateTime journalDate, string description)
        {
            JournalDate = Guard.Against.OutOfSQLDateRange(journalDate, nameof(journalDate));
            Description = Guard.Against.NullOrEmpty(description, nameof(description));
        }

        #endregion

        #region Methods

        public void UpdateJournalDate(DateTime journalDate)
        {
            JournalDate = Guard.Against.OutOfSQLDateRange(journalDate, nameof(journalDate));
        }

        public void UpdateDescription(string description)
        {
            Description = Guard.Against.NullOrEmpty(description, nameof(description));
        } 

        public void AddJournalEntryItem(JournalEntryItem journalEntryItem)
        {
            Guard.Against.Null(journalEntryItem, nameof(journalEntryItem));
            _journalEntryItems.Add(journalEntryItem);

            var newJournalEntryItem = new JournalEntryItemAddedEvent(this, journalEntryItem);
            Events.Add(newJournalEntryItem);
        }

        public bool IsBalanced() => _journalEntryItems.Sum(jei => jei.Amount) == 0m;

        #endregion
    }
}
