using MaroonMaggot.Core.ProjectAggregate;
using MaroonMaggot.SharedKernel;

namespace MaroonMaggot.Core.ProjectAggregate.Events
{
    public class ToDoItemCompletedEvent : BaseDomainEvent
    {
        public ToDoItem CompletedItem { get; set; }

        public ToDoItemCompletedEvent(ToDoItem completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}