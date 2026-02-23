namespace EduTrackAcademics.Model
{
	public class AccountSettingsRequest
	{
		public string? NewEmail { get; set; }
		public string? CurrentPassword { get; set; }
		public string? NewPassword { get; set; }
	}
}
