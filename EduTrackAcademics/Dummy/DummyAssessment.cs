using EduTrackAcademics.Model;

namespace EduTrackAcademics.Dummy
{
	public class DummyAssessment
	{
		public List<Assessment> GetSample()
		{
			return new List<Assessment>
			{
				new Assessment
				{
					AssessmentID="AS001",
					CourseID="C101",
					Type="Assignment",
					MaxMarks=20,
					DueDate=DateTime.Today.AddDays(5),
					Status="Open"
				},
				new Assessment
				{
					AssessmentID="AS002",
					CourseID="C101",
					Type="Quiz",
					MaxMarks=10,
					DueDate=DateTime.Today.AddDays(2),
					Status="Open"
				},
				new Assessment
				{
					AssessmentID="AS003",
					CourseID="C102",
					Type="Exam",
					MaxMarks=100,
					DueDate=DateTime.Today.AddDays(10),
					Status="Closed",
					MarksObtained=85,
					Feedback="Good performance"
				}
			};
		}
	}
}
