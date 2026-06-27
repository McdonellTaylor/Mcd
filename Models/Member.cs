using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CUTDataScienceClub.Models;

public class Member
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DisplayName("Full Name")]
    public string? FullName { get; set; }

    [Required]
    [DisplayName("Registration Number")]
    public string? RegNumber { get; set; }

    [Required]
    public string? Program { get; set; }

    [Required]
    [DisplayName("Current Level")]
    public string? CurrentLevel { get; set; }
}