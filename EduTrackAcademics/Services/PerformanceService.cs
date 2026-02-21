using EduTrackAcademics.Repository;

namespace EduTrackAcademics.Services
{
    public class PerformanceService:IPerformanceService
    {
        private readonly IPerformanceRepository _repo;
        public PerformanceService(IPerformanceRepository repo)
        {
            _repo = repo;
        }
        public decimal GetAverageScore(int enrollmentId)
        {
            return _repo.GetAverageScore(enrollmentId);
        }
       
        public decimal GetCompletionPercentage(int enrollmentId)
        {
            return _repo.GetCompletionPercentage(enrollmentId);

        }
    }
}


    


