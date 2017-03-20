namespace PhotoShare.Services
{
    using Data;
    using Models;
    using System.Linq;

    public class TagService
    {
        public void AddTag(string tag)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Tags.Add(new Tag
                {
                    Name = tag
                });

                context.SaveChanges();
            }
        }

        public bool IsTagExisting(string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Tags.Any(t => t.Name == tagName);
            }
        }
    }
}
