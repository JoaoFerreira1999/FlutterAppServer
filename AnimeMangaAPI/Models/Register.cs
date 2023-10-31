namespace AnimeMangaAPI.Models
{
    public class Register
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Favorites? Favorites { get; set; }
    }
}
