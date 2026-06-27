using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CUTDataScienceClub.Models;

public class Event
{
	[Key]
	public int Id { get; set; }

	[Required]
	[DisplayName("Title")]
	[StringLength(150)]
	public string? Title { get; set; }

	[DisplayName("Description")]
	[DataType(DataType.MultilineText)]
	public string? Description { get; set; }

	[DisplayName("Location")]
	[StringLength(200)]
	public string? Location { get; set; }

	[DisplayName("Start Date")]
	[DataType(DataType.DateTime)]
	public DateTime StartDate { get; set; }

	[DisplayName("End Date")]
	[DataType(DataType.DateTime)]
	public DateTime? EndDate { get; set; }

	[DisplayName("Organizer")]
	[StringLength(100)]
	public string? Organizer { get; set; }

	[DisplayName("Published")]
	public bool IsPublished { get; set; }
}

