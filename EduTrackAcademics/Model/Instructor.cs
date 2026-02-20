using System.ComponentModel.DataAnnotations;

namespace EduTrackAcademics.Model
{
	public class Instructor
	{
		[Key]
		public string InstructorID { get; set; }

		[Required(ErrorMessage = "Instructor name is required.")]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be 2–100 characters.")]
		public string InstructorName { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
		[StringLength(254)]
		public string InstructorEmail { get; set; }

		[Required(ErrorMessage = "Phone number is required.")]
		[RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter a valid 10-digit mobile number.")]
		[Display(Name = "Mobile (+91)")]
		public long InstructorPhone { get; set; }

		[Required(ErrorMessage = "Instructor qualification is required.")]
		[RegularExpression(
			@"^(?i)(Ph\.D\.|PhD|M\.Phil\.|MPhil|M\.E\.|ME|M\.Tech|MTech|M\.Sc\.|MSc|M\.A\.|MA|MBA|
            MCA|B\.Ed\.|BEd|M\.Ed\.|MEd|D\.Ed\.|DEd|UGC-NET|CSIR-NET|NET|SET|SLET|GATE)$",
			ErrorMessage = "Enter a valid qualification (e.g., Ph.D., M.Tech, M.Sc., NET, SET).")]
		public string InstructorQualification { get; set; }

		[Required(ErrorMessage = "At least three skill is required.")]
		[RegularExpression(
	          @"^(?i)(Communication|Teamwork|Artificial(?: |-)?Intelligence|Python|Java|C\#|C\+\+|SQL|Git(?:\/)?GitHub|
              postman|Management)$",
	          ErrorMessage = "Please select a valid instructor skill from the list.")]
		public string InstructorSkills { get; set; }

		[Required(ErrorMessage = "Experience (years) is required.")]
		[Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years.")]
		public int InstructorExperience { get; set; }

		[Required(ErrorMessage = "Join date is required.")]
		[DataType(DataType.Date)]
		//[DateNotInFuture(ErrorMessage = "Join date cannot be in the future.")]
		//[DateNotBefore(2000, 1, 1, ErrorMessage = "Join date cannot be before 01-01-2000.")]
		public DateOnly InstructorJoinDate { get; set; }
		[Required(ErrorMessage = "Gender is required.")]
		[RegularExpression(@"^(Male|Female|Non-Binary|Other|Prefer Not To Say)$",
					ErrorMessage = "Gender must be one of: Male, Female, Non-Binary, Other, Prefer Not To Say.")]
		[StringLength(20)]
		public string InstructorGender { get; set; }
		[Required(ErrorMessage = "Password is required.")]
		[StringLength(200)]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,64}$",
			ErrorMessage = "Password must be 8–64 chars and include uppercase, lowercase, number, and special character.")]
		public string InstructorPassword { get; set; }

		[Required(ErrorMessage = "Resume upload is required.")]
		public byte[] InstructorResume { get; set; }

	}
}
