using System.Collections.Generic;

namespace MaroonMaggot.Web.ApiModels
{
    public class AccountDTO : CreateAccountDTO
    {
        public int Id { get; set; }
        public List<JournalEntryDTO> JournalEntries = new();
    }
}
