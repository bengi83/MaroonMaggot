using System;
using System.Linq;
using MaroonMaggot.Core.AccountAggregate;
using MaroonMaggot.Core.ProjectAggregate;
using MaroonMaggot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MaroonMaggot.Web
{
    public static class SeedData
    {
        public static readonly Project TestProject1 = new Project("Test Project");
        public static readonly Account Account1 = new Account("Liabilities");
        public static readonly Account Account2 = new Account("Assets");

        public static readonly ToDoItem ToDoItem1 = new ToDoItem
        {
            Title = "Get Sample Working",
            Description = "Try to get the sample to build."
        };
        public static readonly ToDoItem ToDoItem2 = new ToDoItem
        {
            Title = "Review Solution",
            Description = "Review the different projects in the solution and how they relate to one another."
        };
        public static readonly ToDoItem ToDoItem3 = new ToDoItem
        {
            Title = "Run and Review Tests",
            Description = "Make sure all the tests run and review what they are doing."
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                // Look for any TODO items.
                if (dbContext.ToDoItems.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);


            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.ToDoItems)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            TestProject1.AddItem(ToDoItem1);
            TestProject1.AddItem(ToDoItem2);
            TestProject1.AddItem(ToDoItem3);
            dbContext.Projects.Add(TestProject1);

            dbContext.Accounts.Add(Account2);
            dbContext.Accounts.Add(Account1);

            var je = new JournalEntry(DateTime.UtcNow, "Example");
            je.AddJournalEntryItem(new JournalEntryItem
            {
                Account = Account1,
                Amount = -30.25m
            });
            je.AddJournalEntryItem(new JournalEntryItem
            {
                Account = Account2,
                Amount = 30.25m
            });

            dbContext.JournalEntries.Add(je);

            dbContext.SaveChanges();
        }
    }
}
