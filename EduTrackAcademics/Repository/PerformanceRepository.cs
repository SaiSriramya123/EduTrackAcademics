using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
    public class PerformanceRepository
    {
        public List<Performance> GetDummyData()
        {
            return new List<Performance>
            {
                new Performance{EnrollmentId = 1, AvgScore = 45 },
                new Performance{EnrollmentId = 2, AvgScore = 67 },
                new Performance{EnrollmentId = 3, AvgScore = 89 },

            };
        }
    }
}
