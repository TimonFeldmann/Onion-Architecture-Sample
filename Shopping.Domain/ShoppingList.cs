using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain
{
    public class ShoppingList
    {
        public ShoppingList(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<ShoppingItem> ShoppingItems { get; set; } = new List<ShoppingItem>();

    }
}
