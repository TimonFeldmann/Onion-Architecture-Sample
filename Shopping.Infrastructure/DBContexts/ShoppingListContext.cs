using Dasync.Collections;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Entities;
using Shopping.Domain.Generic;
using Shopping.Domain.View_Entities;
using Shopping.RepositoryInterface.Contexts;
using System.Reflection;

namespace Shopping.Infrastructure.DBContexts
{
    internal class ShoppingListContext : DbContext, IShoppingListContext
    {
        private IMediator Mediator { get; set; }
        public DbSet<ShoppingList> ShoppingList { get; set; } = null!;
        public DbSet<ShoppingListReport> ShoppingListReport { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;

        public ShoppingListContext(DbContextOptions<ShoppingListContext> dbContextOptions, IMediator mediator) : base(dbContextOptions)
        {
            Mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var eventEntities = ChangeTracker
                .Entries<EventEntity>()
                .Select(x => x.Entity)
                .ToList();
            var domainEvents = eventEntities
                .SelectMany(x => x.DomainEvents)
                .ToList();
            var integrationEvents = eventEntities
                .SelectMany(x => x.IntegrationEvents)
                .ToList();

            await domainEvents.ParallelForEachAsync(async domainEvent => await Mediator.Publish(domainEvent));

            var saveResult = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

            integrationEvents.ForEach(integrationEvent => Mediator.Publish(integrationEvent));

            return saveResult;
        }
    }
}
