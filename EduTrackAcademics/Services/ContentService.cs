using EduTrackAcademics.Model;
using EduTrackAcademics.Repository;

namespace EduTrackAcademics.Services
{
	public class ContentService : IContentService
	{
		private readonly IContentRepo _repo;

		public ContentService(IContentRepo repo)
		{
			_repo = repo;
		}

		public List<Content> GetAll() => _repo.GetAll();

		public List<Content> GetByModule(string moduleId)
			=> _repo.GetByModule(moduleId);

		public List<Content> GetPublished()
			=> _repo.GetPublished();

		public Content Get(string id)
			=> _repo.GetById(id);

		public void Create(Content content)
			=> _repo.Add(content);

		public void Update(Content content)
			=> _repo.Update(content);

		public void Delete(string id)
			=> _repo.Delete(id);
	}
}
