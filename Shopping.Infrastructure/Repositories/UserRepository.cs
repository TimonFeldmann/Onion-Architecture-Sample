using Shopping.Domain;
using Shopping.Service.Interfaces;
using Shopping.Service.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IShoppingListContext _shoppingListContext { get; set; }
        public UserRepository(IShoppingListContext shoppingListContext)
        {
            _shoppingListContext = shoppingListContext;
        }

        public User CreateUser(string name)
        {
            var user = new User(name);

            _shoppingListContext.User.Add(user);

            return user;
        }
    }
}
