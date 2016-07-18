using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TDiary.Migrations
{
    public class LocalizationDbContext : DbContext
    {
        public DbSet<MyStringData> LocalizedStrings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Localization.db");
        }
    }

    public static class LocalizerExtensions
    {
        public static void EnsureSeedData(this LocalizationDbContext context)
        {
            if (!context.LocalizedStrings.Any())
            {
                AddUkEnglish(context);

                context.SaveChanges();
            }
        }

        private static void AddUkEnglish(LocalizationDbContext context)
        {
            context.LocalizedStrings.AddRange(
                new MyStringData("en-GB", "ApplicationTitle", "Magic Bus"),
                new MyStringData("en-GB", "ApplicationHeading", "Your spiffing new travel diary!"),

                new MyStringData("en-GB", "ExperienceListTitle", "Experiences"),
                new MyStringData("en-GB", "ExperienceListHeading", "Here's all your experiences."),

                new MyStringData("en-GB", "ChowTitle.Add", "Tiffin?"),
                new MyStringData("en-GB", "ChowTitle.Edit", "Wrong lunchbox?"),
                new MyStringData("en-GB", "ChowHeading.Add", "Yum, add it to the list!"),
                new MyStringData("en-GB", "ChowHeading.Edit", "Edit the details then."),

                new MyStringData("en-GB", "NapTitle.Add", "Naptastic!"),
                new MyStringData("en-GB", "NapTitle.Edit", "Woken early?"),
                new MyStringData("en-GB", "NapHeading.Add", "Where did you nod off?"),
                new MyStringData("en-GB", "NapHeading.Edit", "Adjust your sleep details."),

                new MyStringData("en-GB", "SightTitle.Add", "What a sight!"),
                new MyStringData("en-GB", "SightTitle.Edit", "Double Take?"),
                new MyStringData("en-GB", "SightHeading.Add", "Seen something fancy?"),
                new MyStringData("en-GB", "SightHeading.Edit", "Change what you saw."),

                new MyStringData("en-GB", "TripTitle.Add", "Life is a journey!"),
                new MyStringData("en-GB", "TripTitle.Edit", "Lost?"),
                new MyStringData("en-GB", "TripHeading.Add", "Add your travel details."),
                new MyStringData("en-GB", "TripHeading.Edit", "Edit your travel details."),

                new MyStringData("en-GB", "Good", "Good Mushroom"),
                new MyStringData("en-GB", "Bad", "Bad Mushroom"),
                new MyStringData("en-GB", "Indifferent", "Zen Moment")
            );
        }
    }
}