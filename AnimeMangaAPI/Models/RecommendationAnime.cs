namespace AnimeMangaAPI.Models
{
    public class RecommendationDatum
    {
        public string mal_id { get; set; }
        public List<Entry> entry { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public User user { get; set; }
    }

    public class Entry
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public Images images { get; set; }
        public string title { get; set; }
    }

    public class RecommendationImages
    {
        public Jpg jpg { get; set; }
        public Webp webp { get; set; }
    }

    public class RecommendationJpg
    {
        public string image_url { get; set; }
        public string small_image_url { get; set; }
        public string large_image_url { get; set; }
    }

    public class RecommendationPagination
    {
        public int last_visible_page { get; set; }
        public bool has_next_page { get; set; }
    }

    public class RecommendationRoot
    {
        public Pagination pagination { get; set; }
        public List<RecommendationDatum> data { get; set; }
    }

    public class User
    {
        public string url { get; set; }
        public string username { get; set; }
    }

    public class RecommendationWebp
    {
        public string image_url { get; set; }
        public string small_image_url { get; set; }
        public string large_image_url { get; set; }
    }


}
