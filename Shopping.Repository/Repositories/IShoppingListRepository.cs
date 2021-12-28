﻿using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;

namespace Shopping.Repository.Repositories
{
    public interface IShoppingListRepository
    {
        Task<ShoppingList?> GetShoppingListForUser(Guid userId);
        ShoppingList CreateShoppingList(CreateShoppingListDto shoppingListDto);
        Task<ShoppingItem> CreateShoppingListItem(Guid shoppingListId, CreateShoppingItemDto createShoppingItemDto);
    }
}
 