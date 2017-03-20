namespace PhotoShare.Services
{
    using Data;
    using Models;
    using System.Linq;

    public class TownService
    {
        public void AddTown(string townName, string country)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                context.Towns.Add(town);
                context.SaveChanges();
            }

        }

        public bool IsTownExisting(string townName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Towns.Any(t => t.Name.Equals(townName));
            }
        }

        public Town GetTownByName(string townName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Towns.SingleOrDefault(t => t.Name.Equals(townName));
            }
        }
    }
}
