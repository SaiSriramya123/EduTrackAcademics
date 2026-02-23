using EduTrackAcademics.Model;

namespace EduTrackAcademics.Services
{
	public interface IContentService
	{
		List<Content> GetAll();
		List<Content> GetByModule(string moduleId);
		List<Content> GetPublished();
		Content Get(string id);
		void Create(Content content);
		void Update(Content content);
		void Delete(string id);
	}
}
