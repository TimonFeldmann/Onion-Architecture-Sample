using Microsoft.EntityFrameworkCore;
using Shopping.Domain;
using Shopping_Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Interfaces
{
    public interface IShoppingListRepository
    {
        Task<ShoppingList?> GetShoppingListForUser(Guid userId);
        ShoppingList CreateShoppingList(CreateShoppingListDto shoppingListDto);
    }
}
