using Shopping.Domain.DTOs;

namespace Shopping.Domain.Entities
{
    public class User
    {
        private User() { }
        public User(CreateUserDto createUserDto)
        {
            Id = Guid.NewGuid();
            Name = createUserDto.Name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
