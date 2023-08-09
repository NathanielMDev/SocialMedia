namespace SocialMedia.Models.Likes
{
    public class LikeDetail
    {
        public int Id { get; set; }   
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}