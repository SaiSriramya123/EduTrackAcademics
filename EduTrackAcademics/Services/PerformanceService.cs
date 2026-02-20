using EduTrackAcademics.Repository;

namespace EduTrackAcademics.Services
{
    public class PerformanceService
    {
        private readonly PerformanceRepository _repo;
        public PerformanceService()
        {
            _repo = new PerformanceRepository();
        }
        public decimal GetAverageScore(int enrollementId)
        {
            var data = _repo.GetDummyData();
          var avgresult= (from p in data
                          where p.EnrollmentId == enrollementId
                          select p.AvgScore).DefaultIfEmpty(0).Average();
            return avgresult;
                          
        }
        
        
        }
    }

