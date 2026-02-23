using EduTrackAcademics.Dummy;
using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public class ModuleRepo : IModuleRepo
	{
		private static List<Module> modules = DummyModule.Data;

		public List<Module> GetAll() => modules;

		public Module GetById(string id)
			=> modules.FirstOrDefault(m => m.ModuleID == id);

		public List<Module> GetByCourse(string courseId)
			=> modules.Where(m => m.CourseID == courseId).ToList();

		public void Add(Module module)
			=> modules.Add(module);

		public void Update(Module module)
		{
			var existing = GetById(module.ModuleID);
			if (existing == null) return;

			existing.Name = module.Name;
			existing.SequenceOrder = module.SequenceOrder;
			existing.LearningObjectives = module.LearningObjectives;
		}

		public void Delete(string id)
		{
			var module = GetById(id);
			if (module != null)
				modules.Remove(module);
		}
	}
}
