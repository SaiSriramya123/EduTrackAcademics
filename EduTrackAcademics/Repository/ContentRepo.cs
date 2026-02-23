using EduTrackAcademics.Dummy;
using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public class ContentRepo : IContentRepo
	{
		private static List<Content> _data = DummyContent.GetSample();

		public List<Content> GetAll()
			=> _data;

		public Content GetById(string id)
			=> _data.FirstOrDefault(c => c.ContentID == id);

		public List<Content> GetByModule(string moduleId)
			=> _data.Where(c => c.ModuleID == moduleId).ToList();

		public List<Content> GetPublished()
			=> _data.Where(c => c.Status == "Published").ToList();

		public void Add(Content content)
			=> _data.Add(content);

		public void Update(Content content)
		{
			var existing = GetById(content.ContentID);
			if (existing == null) return;

			existing.Title = content.Title;
			existing.ContentURI = content.ContentURI;
			existing.ContentType = content.ContentType;
			existing.Duration = content.Duration;
			existing.Status = content.Status;
		}

		public void Delete(string id)
		{
			var item = GetById(id);
			if (item != null)
				_data.Remove(item);
		}
	}
}
