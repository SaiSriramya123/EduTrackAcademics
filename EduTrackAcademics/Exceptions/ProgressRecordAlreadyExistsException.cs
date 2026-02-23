namespace EduTrackAcademics.Exceptions
{
	public class ProgressRecordAlreadyExistsException: Exception
	{
		public int StatusCode { get; }
		public ProgressRecordAlreadyExistsException(string message, int statusCode = 500) : base(message)
		{
			StatusCode = statusCode;
		}
		
	}
}
