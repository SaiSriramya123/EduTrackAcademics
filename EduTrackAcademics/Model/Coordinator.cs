using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> 2f863bfb0e55ccdde94f00cc3325f740cbb6ab15

namespace EduTrackAcademics.Model
{
	public class Coordinator
	{
<<<<<<< HEAD
		[Key]
		public string CoordinatorId { get; set; }
		[Required]
		public string CoordinatorName { get; set; }

		[Required, EmailAddress]
		public string CoordinatorEmail { get; set; }

		public long CoordinatorPhone { get; set; }

		public string CoordinatorQualification { get; set; }

		public string CoordinatorExperience { get; set; }

		public string CoordinatorGender { get; set; }
		[Required]
		[NotMapped]
		public IFormFile Resume { get; set; }

		[Required]
		public string ResumePath{ get; set; }

		[Required]
		public string CoordinatorPassword { get; set; }
		[Required]
		public bool IsFirstLogin { get; set; }
		[Required]
		public bool IsActive { get; set; }


=======
		public string CoordinatorId { get; set; }

		[Required(ErrorMessage = "Instructor name is required.")]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be 2–100 characters.")]
		public string CoordinatorName { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
		[StringLength(254)]
		public string CoordinatorEmail { get; set; }
		[Required(ErrorMessage = "Phone number is required.")]
		[RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter a valid 10-digit mobile number.")]
		[Display(Name = "Mobile (+91)")]
		public long CoordinatorPhone { get; set; }

		public string CoordinatorQualification { get; set; }
		
		[Required(ErrorMessage = "Experience (years) is required.")]
		[Range(0, 50, ErrorMessage = "Experience must be between 0 and 40 years.")]
		public string CoordinatorExperience { get; set; }
		[Required(ErrorMessage = "Gender is required.")]
		[RegularExpression(@"^(Male|Female|Non-Binary|Other|Prefer Not To Say)$",
				ErrorMessage = "Gender must be one of: Male, Female, Non-Binary, Other, Prefer Not To Say.")]
		[StringLength(20)]
		public string CoordinatorGender { get; set; }

		[Required(ErrorMessage = "Resume upload is required.")]
		public byte[] CoordinatorResume { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[StringLength(200)]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,64}$",
			ErrorMessage = "Password must be 8–64 chars and include uppercase, lowercase, number, and special character.")]
		public string CoordinatorPassword { get; set; }
>>>>>>> 2f863bfb0e55ccdde94f00cc3325f740cbb6ab15
	}
}
