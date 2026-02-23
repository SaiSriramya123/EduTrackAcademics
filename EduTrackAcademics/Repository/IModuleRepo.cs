using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public interface IModuleRepo
	{
		List<Module> GetAll();
		Module GetById(string id);
		List<Module> GetByCourse(string courseId);
		void Add(Module module);
		void Update(Module module);
		void Delete(string id);
	}
}
