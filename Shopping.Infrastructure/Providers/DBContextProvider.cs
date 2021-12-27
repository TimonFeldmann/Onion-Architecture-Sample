﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Shopping.Service.Interfaces;

namespace Shopping.Infrastructure.Providers
{
    public static class DBContextProvider
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection
                .AddDbContext<IShoppingListContext, ShoppingListContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("ShoppingList")));
        }
    }
}
