using Shopping.Domain.Entities;

namespace Shopping.Domain.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public UserDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
        }
    }
}
