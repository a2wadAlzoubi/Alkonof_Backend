namespace Application.Entities.Users.Dtos
{
    public class UpdatePasswordDto
    {
        public Guid userId { get; set; }
        public string oldPassword { get; set; } = null!;
        public string newPassword { get; set; } = null!;
        public string confirmPassword { get; set; } = null!;
    }
}
