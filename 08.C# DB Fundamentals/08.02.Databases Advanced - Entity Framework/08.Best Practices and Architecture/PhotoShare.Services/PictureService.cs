namespace PhotoShare.Services
{
    using Data;
    using Models;
    using System.Linq;

    public class PictureService
    {
        public bool IsPicExisting(string albumName, string picTitle, string pictureFilePath)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.SingleOrDefault(alb => alb.Name == albumName)
                    .Pictures
                    .Any(p => p.Title == picTitle && p.Path == pictureFilePath);
            }
        }

        public void AddPicture(string albumName,string pictureTitle, string pictureFilePath)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album=context.Albums.SingleOrDefault(alb => alb.Name == albumName);
                Picture pic = new Picture()
                {
                    Title = pictureTitle,
                    Path = pictureFilePath
                };
                bool isExistingInDb = context.Pictures.Any(p => p.Path == pictureFilePath && p.Title == pictureTitle);
                if (!isExistingInDb)
                {
                    context.Pictures.Add(pic);
                }
                album.Pictures.Add(pic);
                context.SaveChanges();
            }
        }
    }
}
