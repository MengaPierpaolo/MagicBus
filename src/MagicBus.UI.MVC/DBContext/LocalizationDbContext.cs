using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MagicBus.Migrations
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
        public static void SeedData(this LocalizationDbContext context)
        {
            context.Database.Migrate();

            if (context.LocalizedStrings.Any())
                DeleteLocalization(context);

            AddUkEnglish(context);
            AddUsEnglish(context);
            AddChinese(context);

            context.SaveChanges();
        }

        private static void AddChinese(LocalizationDbContext context)
        {
            context.LocalizedStrings.AddRange(
                new MyStringData("zh-CN", "ApplicationTitle", "魔术公共汽车"),
                new MyStringData("zh-CN", "ApplicationHeading", "你最喜欢的旅行日记"),

                new MyStringData("zh-CN", "ExperienceListTitle", "您的经验"),
                new MyStringData("zh-CN", "ExperienceListHeading", "你看，你所有的好经验"),

                new MyStringData("zh-CN", "ChowTitle.Add", "吃了吗?"),
                new MyStringData("zh-CN", "ChowTitle.Edit", "吃错了吗?"),
                new MyStringData("zh-CN", "ChowHeading.Add", "你吃了什么?"),
                new MyStringData("zh-CN", "ChowHeading.Edit", "你吃了什么?"),

                new MyStringData("zh-CN", "NapTitle.Add", "Naptastic!"),
                new MyStringData("zh-CN", "NapTitle.Edit", "Woken early?"),
                new MyStringData("zh-CN", "NapHeading.Add", "Where did you nod off?"),
                new MyStringData("zh-CN", "NapHeading.Edit", "Adjust your sleep details."),

                new MyStringData("zh-CN", "SightTitle.Add", "What a sight!"),
                new MyStringData("zh-CN", "SightTitle.Edit", "Double Take?"),
                new MyStringData("zh-CN", "SightHeading.Add", "Seen something fancy?"),
                new MyStringData("zh-CN", "SightHeading.Edit", "Change what you saw."),

                new MyStringData("zh-CN", "TripTitle.Add", "Life is a journey!"),
                new MyStringData("zh-CN", "TripTitle.Edit", "Lost?"),
                new MyStringData("zh-CN", "TripHeading.Add", "Add your travel details."),
                new MyStringData("zh-CN", "TripHeading.Edit", "Edit your travel details."),

                new MyStringData("zh-CN", "Good", "很好"),
                new MyStringData("zh-CN", "Bad", "不好"),
                new MyStringData("zh-CN", "Indifferent", "馬馬虎虎")
            );
        }

        private static void AddUsEnglish(LocalizationDbContext context)
        {
            context.LocalizedStrings.AddRange(
                new MyStringData("en-US", "ApplicationTitle", "Magic Bus"),
                new MyStringData("en-US", "ApplicationHeading", "Your groovy new travel diary!"),

                new MyStringData("en-US", "ExperienceListTitle", "Experiences"),
                new MyStringData("en-US", "ExperienceListHeading", "Here's all your experiences."),

                new MyStringData("en-US", "ChowTitle.Add", "Had some Chow?"),
                new MyStringData("en-US", "ChowTitle.Edit", "Chow mixed up?"),
                new MyStringData("en-US", "ChowHeading.Add", "Cool, add it to the list!"),
                new MyStringData("en-US", "ChowHeading.Edit", "Edit the details then."),

                new MyStringData("en-US", "NapTitle.Add", "Naptastic!"),
                new MyStringData("en-US", "NapTitle.Edit", "Woken early?"),
                new MyStringData("en-US", "NapHeading.Add", "Where did you nod off?"),
                new MyStringData("en-US", "NapHeading.Edit", "Adjust your sleep details."),

                new MyStringData("en-US", "SightTitle.Add", "What a sight!"),
                new MyStringData("en-US", "SightTitle.Edit", "Double Take?"),
                new MyStringData("en-US", "SightHeading.Add", "Seen something fancy?"),
                new MyStringData("en-US", "SightHeading.Edit", "Change what you saw."),

                new MyStringData("en-US", "TripTitle.Add", "Life is a journey!"),
                new MyStringData("en-US", "TripTitle.Edit", "Lost?"),
                new MyStringData("en-US", "TripHeading.Add", "Add your travel details."),
                new MyStringData("en-US", "TripHeading.Edit", "Edit your travel details."),

                new MyStringData("en-US", "Good", "Good Mushroom"),
                new MyStringData("en-US", "Bad", "Bad Mushroom"),
                new MyStringData("en-US", "Indifferent", "Zen Moment")
            );
        }

        private static void DeleteLocalization(LocalizationDbContext context)
        {
            context.Database.ExecuteSqlCommand("DELETE FROM LocalizedStrings");
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