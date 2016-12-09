using MyFirstCoreApp.Data;
using System;
using System.Linq;

namespace MyFirstCoreApp.Models
{
    public class DbInitializer
    {
        public static void Initialize(RewardingContext context)
        {
            context.Database.EnsureCreated();

            // проверка на данные в таблице пользователей
            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User { FirstName = "Alex", LastName = "Lucas", BirthDate = DateTime.Parse("13.11.1992") },
                new User { FirstName = "Den", LastName = "Manford", BirthDate = DateTime.Parse("9.6.1988") },
                new User { FirstName = "Max", LastName = "Ivanov", BirthDate = DateTime.Parse("10.9.1981") }
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();

            var awards = new Award[]
            {
                new Award { Title = "Nobel", Description = "Most important prize" },
                new Award { Title = "Darvin", Description = "Not good for you" },
                new Award { Title = "Contoso university award", Description = "For best of the best" }
            };

            foreach (Award a in awards)
            {
                context.Awards.Add(a);
            }

            context.SaveChanges();

            var rewardings = new Rewarding[]
            {
                new Rewarding { UserID = 1, AwardID = 1},
                new Rewarding { UserID = 1, AwardID = 2}
            };

            foreach (Rewarding r in rewardings)
            {
                context.Rewardings.Add(r);
            }

            context.SaveChanges();
        }
    }
}
