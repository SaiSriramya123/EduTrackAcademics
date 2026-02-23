using EduTrackAcademics.Model;
using EduTrackAcademics.Repository;

namespace EduTrackAcademics.Services
{
	public class ModuleService : IModuleService
	{
		private readonly IModuleRepo _repo;

		public ModuleService(IModuleRepo repo)
		{
			_repo = repo;
		}

		public List<Module> GetAll() => _repo.GetAll();

		public Module Get(string id) => _repo.GetById(id);

		public List<Module> GetByCourse(string courseId)
			=> _repo.GetByCourse(courseId);

		public void Create(Module module)
			=> _repo.Add(module);

		public void Update(Module module)
			=> _repo.Update(module);

		public void Delete(string id)
			=> _repo.Delete(id);
	}
}
