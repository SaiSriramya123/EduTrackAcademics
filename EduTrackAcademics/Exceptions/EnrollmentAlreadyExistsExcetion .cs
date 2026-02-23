namespace EduTrackAcademics.Exceptions
{
	public class EnrollmentAlreadyExistsException : Exception
	{
		public int StatusCode { get; }

		public EnrollmentAlreadyExistsException(string message, int statusCode = 500) : base(message)
		{
			StatusCode = statusCode;
		}
	}
}
