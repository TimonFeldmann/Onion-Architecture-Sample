﻿using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Entities;
using Shopping.Repository.Contexts;
using Shopping.Repository.DTOs;
using Shopping.Repository.Repositories;

namespace Shopping.Infrastructure.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private IShoppingListContext _shoppingListContext { get; set; }
        public ShoppingListRepository(IShoppingListContext shoppingListContext )
        {
            _shoppingListContext = shoppingListContext;
        }
        public async Task<ShoppingList?> GetShoppingListForUser(Guid userId)
        {
            return await _shoppingListContext.ShoppingList
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync() ;
        }
        public ShoppingList CreateShoppingList(CreateShoppingListDto createShoppingListDto)
        {
            var shoppingList = MapCreateToShoppingList(createShoppingListDto);

            _shoppingListContext.ShoppingList.Add(shoppingList);

            return shoppingList;
        }
        private ShoppingList MapCreateToShoppingList(CreateShoppingListDto createShoppingListDto)
        {
            return new ShoppingList(createShoppingListDto.userId);
        }
    }
}
