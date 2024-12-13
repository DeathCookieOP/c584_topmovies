namespace Backend_API.DTO
{
    public class MovieAddDTO
    {
        public string Title { get; set; } = null!;
        public string MovieImage { get; set; } = null!;
        public int CompanyId { get; set; }
        public decimal Rating { get; set; }
        public string? Description { get; set; }
        public DateOnly? ReleaseDate { get; set; }

    }
}
