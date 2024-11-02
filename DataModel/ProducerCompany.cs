using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataModel;

[Table("Producer_Company")]
public partial class ProducerCompany
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("company_image")]
    [StringLength(512)]
    [Unicode(false)]
    public string? CompanyImage { get; set; }

    [Column("name")]
    [StringLength(120)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("founded_year")]
    public int? FoundedYear { get; set; }

    [InverseProperty("Company")]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
