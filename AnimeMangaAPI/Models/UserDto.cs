namespace AnimeMangaAPI.Models
{
    public class UserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Favorites? Favorites { get; set; }
    }
}
