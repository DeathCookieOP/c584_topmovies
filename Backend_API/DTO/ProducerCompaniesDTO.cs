using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend_API.DTO
{
    public class ProducerCompaniesDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int? FoundedYear { get; set; }

        public string? CompanyImage { get; set; }
    }
}
