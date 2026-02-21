using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
    public class PerformanceRepository : IPerformanceRepository
    {
        public List<Performance> GetDummyData()
        {
            return new List<Performance> {
                new Performance { EnrollmentId = 1, AvgScore = 45 },
                new Performance { EnrollmentId = 2, AvgScore = 67 },
            new Performance { EnrollmentId = 3, AvgScore = 89 },
            };
        }
        public decimal GetAverageScore(int enrollmentId)
        {
            var data =GetDummyData();
            return data
                .Where(p => p.EnrollmentId == enrollmentId)
                .Select(p => p.AvgScore)
                .FirstOrDefault();
        }
        public List<Performance> DummyData()
        {
            return new List<Performance>
            {
                new Performance { EnrollmentId = 1, CompletionPercentage = 78.9m },
                new Performance { EnrollmentId = 2, CompletionPercentage = 90.1m },
                new Performance { EnrollmentId = 3, CompletionPercentage = 99.0m },
            };
        }
        public decimal GetCompletionPercentage(int enrollmentId)
        {
            var data=DummyData();
            return data
                .Where(p => p.EnrollmentId == enrollmentId)
                .Select(p => p.CompletionPercentage)
                .FirstOrDefault();
        }
    }
}
