namespace EduTrackAcademics.Exceptions
{
	public class EnrollmentNotExistsException : Exception
	{
		public int StatusCode { get; }

		public EnrollmentNotExistsException(string message, int statusCode = 500) : base(message)
		{
			StatusCode = statusCode;
		}
	}
}
