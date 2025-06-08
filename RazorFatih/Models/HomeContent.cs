namespace RazorFatih.Models
{
    public class HomeContent
    {
        public int Id { get; set; }
        public required string Title { get; set; }   // 'required' eklendi
        public required string Content { get; set; } // 'required' eklendi
    }
}