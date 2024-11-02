using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend_API.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        public required string CompanyName { get; set; }

        public string MovieImage { get; set; } = null!;

        public string Title { get; set; } = null!;

        public decimal Rating { get; set; }

        public string? Description { get; set; }

        public DateOnly? ReleaseDate { get; set; }

    }
}
