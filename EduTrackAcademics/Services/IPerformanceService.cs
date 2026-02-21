using EduTrackAcademics.Model;

namespace EduTrackAcademics.Services
{
    public interface IPerformanceService
    {
        decimal GetAverageScore(int enrollmentId);
        decimal GetCompletionPercentage(int enrollmentId);
    }
}
