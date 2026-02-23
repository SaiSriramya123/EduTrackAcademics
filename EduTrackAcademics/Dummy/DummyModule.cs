using EduTrackAcademics.Model;

namespace EduTrackAcademics.Dummy
{
	public class DummyModule
	{
		public static List<Module> Data = new()
		{
			new Module
			{
				ModuleID = "MOD1",
				CourseID = "C001",
				Name = "Introduction to Programming",
				SequenceOrder = 1,
				LearningObjectives = "Understand programming basics"
			},
			new Module
			{
				ModuleID = "MOD2",
				CourseID = "C001",
				Name = "OOP Concepts",
				SequenceOrder = 2,
				LearningObjectives = "Learn OOP principles"
			}
		};
	}
}
