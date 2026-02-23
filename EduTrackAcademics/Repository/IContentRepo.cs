using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public interface IContentRepo
	{
		List<Content> GetAll();
		Content GetById(string id);
		List<Content> GetByModule(string moduleId);
		List<Content> GetPublished();
		void Add(Content content);
		void Update(Content content);
		void Delete(string id);
	}
}
