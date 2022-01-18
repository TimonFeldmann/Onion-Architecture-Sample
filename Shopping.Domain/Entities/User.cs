using Shopping.Domain.DTOs;
using Shopping.Domain.Events;
using Shopping.Domain.Generic;

namespace Shopping.Domain.Entities
{
    public class User : EventEntity
    {
        private User() { }
        public User(CreateUserDto createUserDto)
        {
            Name = createUserDto.Name;
        }

        public string Name { get; private set; } = null!;

        public void UpdateUser(string newName)
        {
            Name = newName;

            AddDomainEvent(new UserUpdatedEvent()
            {
                Id = Id,
                Name = Name
            });
        }
    }
}
