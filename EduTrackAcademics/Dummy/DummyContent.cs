using EduTrackAcademics.Model;

namespace EduTrackAcademics.Dummy
{
	public class DummyContent
	{
		public static List<Content> GetSample()
		{
			return new List<Content>
			{
				new Content {
					ContentID="CNT001",
					ModuleID="MOD1",
					ContentType="Video",
					Title="Intro to C#",
					ContentURI="https://example.com/video1",
					Duration=TimeSpan.FromMinutes(20),
					Status="Published"
				},
				new Content {
					ContentID="CNT002",
					ModuleID="MOD1",
					ContentType="PDF",
					Title="C# Notes",
					ContentURI="https://example.com/notes",
					Status="Published"
				},
				new Content {
					ContentID="CNT003",
					ModuleID="MOD2",
					ContentType="Slide",
					Title="OOP Slides",
					ContentURI="https://example.com/slides",
					Status="Draft"
				}
			};
		}
	}
}
