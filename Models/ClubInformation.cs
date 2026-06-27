using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace CUTDataScienceClub.Models;

public class ClubInformation
{
	[Key]
	public int Id { get; set; }

	[Required]
	[StringLength(100)]
	[DisplayName("Club Name")]
	public string Name { get; set; } = string.Empty;

	[StringLength(250)]
	[DisplayName("Short Description")]
	public string? ShortDescription { get; set; }

	[DisplayName("About")]
	[DataType(DataType.MultilineText)]
	public string? About { get; set; }

	[DisplayName("Mission")]
	[DataType(DataType.MultilineText)]
	public string? Mission { get; set; }

	[DisplayName("Vision")]
	[DataType(DataType.MultilineText)]
	public string? Vision { get; set; }

	[StringLength(100)]
	[DisplayName("Contact Person")]
	public string? ContactPerson { get; set; }

	[EmailAddress]
	[StringLength(150)]
	[DisplayName("Contact Email")]
	public string? Email { get; set; }

	[Phone]
	[StringLength(30)]
	[DisplayName("Contact Phone")]
	public string? Phone { get; set; }

	[StringLength(250)]
	[DisplayName("Address")]
	public string? Address { get; set; }

	[Url]
	[StringLength(250)]
	[DisplayName("Website URL")]
	public string? WebsiteUrl { get; set; }

	[Url]
	[StringLength(250)]
	[DisplayName("Facebook URL")]
	public string? FacebookUrl { get; set; }

	[Url]
	[StringLength(250)]
	[DisplayName("Twitter URL")]
	public string? TwitterUrl { get; set; }

	[Url]
	[StringLength(250)]
	[DisplayName("Instagram URL")]
	public string? InstagramUrl { get; set; }

	[Url]
	[StringLength(250)]
	[DisplayName("LinkedIn URL")]
	public string? LinkedInUrl { get; set; }

	[Url]
	[StringLength(250)]
	[DisplayName("Logo URL")]
	public string? LogoUrl { get; set; }

	// Not persisted file upload for admin UI
	[NotMapped]
	[DisplayName("Upload Logo")]
	public IFormFile? LogoUpload { get; set; }

	[DisplayName("Founded Date")]
	[DataType(DataType.Date)]
	public DateTime? FoundedDate { get; set; }

	[StringLength(20)]
	[DisplayName("Primary Color")]
	public string? PrimaryColor { get; set; }

	[StringLength(20)]
	[DisplayName("Secondary Color")]
	public string? SecondaryColor { get; set; }
}
