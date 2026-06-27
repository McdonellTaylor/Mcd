using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CUTDataScienceClub.Models;

public class Project
{
	[Key]
	public int Id { get; set; }

	[Required]
	[StringLength(150)]
	[DisplayName("Title")]
	public string? Title { get; set; }

	[DataType(DataType.MultilineText)]
	[DisplayName("Description")]
	public string? Description { get; set; }

	[StringLength(100)]
	[DisplayName("Owner")]
	public string? Owner { get; set; }

	[DisplayName("Start Date")]
	[DataType(DataType.Date)]
	public DateTime? StartDate { get; set; }

	[DisplayName("End Date")]
	[DataType(DataType.Date)]
	public DateTime? EndDate { get; set; }

	[DisplayName("Repository URL")]
	[Url]
	public string? RepositoryUrl { get; set; }

	[DisplayName("Technologies")]
	[StringLength(250)]
	public string? Technologies { get; set; }

	[DisplayName("Active")]
	public bool IsActive { get; set; } = true;
}

