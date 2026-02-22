using System.ComponentModel.DataAnnotations;

namespace EduTrackAcademics.Model
{
	public class Student
	{
		[Key]
		public string StudentId { get; set; }

		[Required(ErrorMessage = "Student name is required.")]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be 2–100 characters.")]
		public string StudentName { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
		[StringLength(254)]
		public string StudentEmail { get; set; }

		[Required(ErrorMessage = "Phone number is required.")]
		[RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter a valid 10-digit mobile number.")]
		[Display(Name = "Mobile (+91)")]
		public long StudentPhone { get; set; }

		[Required(ErrorMessage = "Qualification is required.")]
		[RegularExpression(@"^(B\.Tech\.|MBA)$")]
	//	[RegularExpression(
	//@" ^ (B\.A\.|B\.Sc\.|B\.Com|B\.E\.|B\.Tech|BBA|BCA|MBBS \(Medical\)|BDS \(Dental\)|M\.A\.|
 //       M\.Sc\.|M\.Com|M\.E\.|M\.Tech|MBA|MCA|Ph\.D\.)$")]
		public string StudentQualification { get; set; }

		[Required(ErrorMessage = "Program is required.")]
		[RegularExpression(
	          @"^(Computer Science (?:&|&amp;) Engineering \(CSE\)|Electronics (?:&|&amp;) Communication Engineering \(ECE\)|Accounting 
              (?:&|&amp;) Finance $", ErrorMessage = "Invalid Program Details")]

//VLSI Design|Robotics (?:&|&amp;) Automation|Organic Chemistry|Climate Change (?:&|&amp;) Sustainability)$",
//	ErrorMessage = "Please select a valid program from the list.")]
		public string StudentProgram { get; set; }

		[Required(ErrorMessage = "Academic year is required.")]
		[DataType(DataType.Date)]
		public DateOnly StudentAcademicYear { get; set; }

		[Required(ErrorMessage = "Gender is required.")]
		[RegularExpression(@"^(Male|Female|Non-Binary|Other|Prefer Not To Say)$",
					ErrorMessage = "Gender must be one of: Male, Female, Non-Binary, Other, Prefer Not To Say.")]
		[StringLength(20)]
		public string StudentGender { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[StringLength(200)]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,64}$",
			ErrorMessage = "Password must be 8–64 chars and include uppercase, lowercase, number, and special character.")]
		public string StudentPassword { get; set; }

		
		//Additional fields for student profile
		public decimal? CGPA { get; set; }
		public string? Nationality{ get; set; }
		public string? Citizenship { get; set; }
		public string? dayscholarHosteller { get; set; }
		public decimal? GateScore { get; set; }
		public string? Certifications { get; set; }
		public string? Clubs_Chapters { get; set; }
		public string? Achievements { get; set; }
		public int? EducationGap { get; set; }
		public byte[] StudentResume { get; set; }

		public virtual ICollection<Programs> Pgmdetails { get; set; }
	}
}
