using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.EFCore.Extensions;
using MaroonMaggot.Core.ProjectAggregate;
using MaroonMaggot.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaroonMaggot.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;

        //public AppDbContext(DbContextOptions options) : base(options)
        //{
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Core.AccountAggregate.Account> Accounts { get; set; }
        public DbSet<Core.AccountAggregate.JournalEntry> JournalEntries { get; set; }
        public DbSet<Core.AccountAggregate.JournalEntryItem> JournalEntryItems { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

            // alternately this is built-in to EF Core 2.2
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_mediator == null) return result;

            var domainEvents = new List<BaseDomainEvent>();

            domainEvents.AddRange(GetEventsFromBaseEntity<int>());
            domainEvents.AddRange(GetEventsFromBaseEntity<Guid>());

            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }

            return result;
        }

        private BaseDomainEvent[] GetEventsFromBaseEntity<T>() where T : struct
        {
            var events = new List<BaseDomainEvent>();

            var entitiesWithEvents = ChangeTracker
                .Entries<BaseEntity<T>>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                events.AddRange(entity.Events.ToArray());
                entity.Events.Clear();
            }

            return events.ToArray();
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}