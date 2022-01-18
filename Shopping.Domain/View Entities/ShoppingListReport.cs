using Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.View_Entities
{
    public class ShoppingListReport
    {
        public ShoppingListReport()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public Guid ShoppingListId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; } = "";
        public string ShoppingItemNames { get; private set; } = "";
        public decimal ShoppingListTotalValue { get; set; }

        public void SetShoppingItemNames(List<ShoppingItem> shoppingItems)
        {
            ShoppingItemNames = shoppingItems.Select(x => x.Name).Aggregate("", (aggregate, current) => aggregate == "" ? current : $"{aggregate}, {current}");
        }
    }
}
