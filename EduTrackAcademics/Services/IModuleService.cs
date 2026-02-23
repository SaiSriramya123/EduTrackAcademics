using EduTrackAcademics.Model;

namespace EduTrackAcademics.Services
{
	public interface IModuleService
	{
		List<Module> GetAll();
		Module Get(string id);
		List<Module> GetByCourse(string courseId);
		void Create(Module module);
		void Update(Module module);
		void Delete(string id);
	}
}
