using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
    public interface IPerformanceRepository
    {
        List<Performance> GetDummyData();
        decimal GetAverageScore(int avgscore);
        List<Performance> DummyData();
        decimal GetCompletionPercentage(int enrollmentId);
    }
}
