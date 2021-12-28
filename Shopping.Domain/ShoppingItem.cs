using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain
{
    public class ShoppingItem
    {
        public ShoppingItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public ShoppingList ShoppingList { get; set; } = null!;
    }
}
