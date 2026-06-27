using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace CUTDataScienceClub.Models;

public class Blog
{
	[Key]
	public int Id { get; set; }

	[Required]
	[StringLength(150)]
	[DisplayName("Title")]
	public string? Title { get; set; }

	[StringLength(150)]
	[DisplayName("Slug")]
	public string? Slug { get; set; }

	[StringLength(500)]
	[DisplayName("Excerpt")]
	[DataType(DataType.MultilineText)]
	public string? Excerpt { get; set; }

	[DisplayName("Content")]
	[DataType(DataType.MultilineText)]
	public string? Content { get; set; }

	[StringLength(100)]
	[DisplayName("Author")]
	public string? Author { get; set; }

	[DisplayName("Published Date")]
	[DataType(DataType.DateTime)]
	public DateTime? PublishedDate { get; set; }

	[DisplayName("Published")]
	public bool IsPublished { get; set; }

	[StringLength(250)]
	[Url]
	[DisplayName("Image URL")]
	public string? ImageUrl { get; set; }

	[StringLength(250)]
	[DisplayName("Tags")]
	public string? Tags { get; set; }

	// Video: persisted URL and filename
	[StringLength(250)]
	[Url]
	[DisplayName("Video URL")]
	public string? VideoUrl { get; set; }

	[StringLength(200)]
	[DisplayName("Video File Name")]
	public string? VideoFileName { get; set; }

	// For form binding only; not mapped to the database
	[NotMapped]
	[DisplayName("Upload Video")]
	public IFormFile? VideoUpload { get; set; }

	// For image upload binding (not persisted directly)
	[NotMapped]
	[DisplayName("Upload Image")]
	public IFormFile? ImageUpload { get; set; }
}

