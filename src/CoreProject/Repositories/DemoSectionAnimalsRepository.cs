using CoreProject.Models;
using CoreProject.Repositories.Interfaces;
using System.Linq;

namespace CoreProject.Repositories
{
    public class DemoSectionAnimalsRepository : IDemoSectionAnimalsRepository
    {
        public DemoSectionAnimal[] GetAll()
        {
            var rabbit = new DemoSectionAnimal
            {
                Id = 1,
                Name = "Umbraco Rabbit",
                Status = "Alive",
                LastSeen = "Bingo Night at Codegarden 2016",
                Twitter = "UmbracoRabbit",
                Image = "https://pbs.twimg.com/profile_images/609085815382257664/UUPv1wXD_400x400.jpg"
            };

            var giraffe = new DemoSectionAnimal
            {
                Id = 2,
                Name = "Umbraco Giraffe",
                Status = "Killed in action (unconfirmed)",
                LastSeen = "Bingo Night at Codegarden 2016",
                Twitter = "UmbracoGiraffe",
                Image = "https://pbs.twimg.com/profile_images/739882256429387776/lKscySOa_400x400.jpg"
            };

            return new[] { rabbit, giraffe };
        }

        public DemoSectionAnimal GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}