using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataModel;

public partial class Movie
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(255)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [Column("movie_image")]
    [StringLength(512)] 
    [Unicode(false)]
    public string MovieImage { get; set; } = null!;

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("rating", TypeName = "decimal(2, 1)")]
    public decimal Rating { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("release_date")]
    public DateOnly? ReleaseDate { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Movies")]
    public virtual ProducerCompany Company { get; set; } = null!;
}
