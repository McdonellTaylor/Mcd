using System.Collections.Generic;
using System.Linq;
using CUTDataScienceClub.Models;

namespace CUTDataScienceClub.ViewModels
{
	public class HomeViewModel
	{
		// Members
		public IEnumerable<Member> Members { get; set; } = Enumerable.Empty<Member>();
		public Member? Member { get; set; }

		// Events
		public IEnumerable<Event> Events { get; set; } = Enumerable.Empty<Event>();
		public Event? Event { get; set; }

		// Projects
		public IEnumerable<Project> Projects { get; set; } = Enumerable.Empty<Project>();
		public Project? Project { get; set; }

		// Blogs
		public IEnumerable<Blog> Blogs { get; set; } = Enumerable.Empty<Blog>();
		public Blog? Blog { get; set; }

		// Club information (site metadata)
		public IEnumerable<ClubInformation> ClubInformations { get; set; } = Enumerable.Empty<ClubInformation>();
		public ClubInformation? ClubInformation { get; set; }

		// Error / UI helpers
		public ErrorViewModel? Error { get; set; }
	}
}
