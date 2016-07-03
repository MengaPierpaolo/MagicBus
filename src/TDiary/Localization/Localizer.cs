using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TDiary
{
    public class MyStringLocalizerFactory : IStringLocalizerFactory
    {
        public IStringLocalizer Create(Type resourceSource)
        {
            return new MyStringLocalizer();
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new MyStringLocalizer();
        }
    }

    public class MyStringLocalizer : IStringLocalizer
    {
        private readonly CultureInfo _culture;

        private readonly List<MyStringData> _stringData;

        public MyStringLocalizer()
        {
            _stringData = new List<MyStringData>();

            InitializeLocalizedStrings(_stringData);
        }

        public MyStringLocalizer(CultureInfo culture) : this()
        {
            _culture = culture;
        }

        public LocalizedString this[string name]
        {
            get
            {
                var culture = _culture ?? CultureInfo.CurrentUICulture;
                var translation = _stringData.FirstOrDefault(x => x.CultureName == culture.Name && x.Name == name)?.Value;

                return new LocalizedString(name, translation ?? name, translation != null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var culture = _culture ?? CultureInfo.CurrentUICulture;
                var translation = _stringData.FirstOrDefault(x => x.CultureName == culture.Name && x.Name == name)?.Value;

                if (translation != null)
                {
                    translation = string.Format(translation, arguments);
                }

                return new LocalizedString(name, translation ?? name, translation != null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _stringData.Select(x => new LocalizedString(x.Name, x.Value, true)).ToList();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new MyStringLocalizer(culture);
        }

        private void InitializeLocalizedStrings(List<MyStringData> localizedStrings)
        {
            // TODO: Consider a localizationDB.  NOTE: .resx is flaky in RC2! not really an option as it has to be in the MVC project.
            localizedStrings.Clear();
            localizedStrings.Add(new MyStringData("en-GB", "ApplicationTitle", "Magic Bus"));
            localizedStrings.Add(new MyStringData("en-GB", "ApplicationHeading", "Your spiffing new travel diary!"));

            localizedStrings.Add(new MyStringData("en-GB", "ExperienceListTitle", "Experiences"));
            localizedStrings.Add(new MyStringData("en-GB", "ExperienceListHeading", "Here's all your experiences."));

            localizedStrings.Add(new MyStringData("en-GB", "ChowTitle.Add", "Tiffin?"));
            localizedStrings.Add(new MyStringData("en-GB", "ChowTitle.Edit", "Wrong lunchbox?"));
            localizedStrings.Add(new MyStringData("en-GB", "ChowHeading.Add", "Yum, add it to the list!"));
            localizedStrings.Add(new MyStringData("en-GB", "ChowHeading.Edit", "Edit the details then."));

            localizedStrings.Add(new MyStringData("en-GB", "NapTitle.Add", "Naptastic!"));
            localizedStrings.Add(new MyStringData("en-GB", "NapTitle.Edit", "Woken early?"));
            localizedStrings.Add(new MyStringData("en-GB", "NapHeading.Add", "Where did you nod off?"));
            localizedStrings.Add(new MyStringData("en-GB", "NapHeading.Edit", "Adjust your sleep details."));

            localizedStrings.Add(new MyStringData("en-GB", "SightTitle.Add", "What a sight!"));
            localizedStrings.Add(new MyStringData("en-GB", "SightTitle.Edit", "Double Take?"));
            localizedStrings.Add(new MyStringData("en-GB", "SightHeading.Add", "Seen something fancy?"));
            localizedStrings.Add(new MyStringData("en-GB", "SightHeading.Edit", "Change what you saw."));

            localizedStrings.Add(new MyStringData("en-GB", "TripTitle.Add", "Life is a journey!"));
            localizedStrings.Add(new MyStringData("en-GB", "TripTitle.Edit", "Lost?"));
            localizedStrings.Add(new MyStringData("en-GB", "TripHeading.Add", "Add your travel details."));
            localizedStrings.Add(new MyStringData("en-GB", "TripHeading.Edit", "Edit your travel details."));

            localizedStrings.Add(new MyStringData("en-US", "ApplicationTitle", "Magic Bus"));
            localizedStrings.Add(new MyStringData("en-US", "ApplicationHeading", "Your groovy new travel diary!"));

            localizedStrings.Add(new MyStringData("en-US", "ExperienceListTitle", "Experiences"));
            localizedStrings.Add(new MyStringData("en-US", "ExperienceListHeading", "Here's all your experiences."));

            localizedStrings.Add(new MyStringData("en-US", "ChowTitle.Add", "Had some Chow?"));
            localizedStrings.Add(new MyStringData("en-US", "ChowTitle.Edit", "Chow mixed up?"));
            localizedStrings.Add(new MyStringData("en-US", "ChowHeading.Add", "Cool, add it to the list!"));
            localizedStrings.Add(new MyStringData("en-US", "ChowHeading.Edit", "Edit the details then."));

            localizedStrings.Add(new MyStringData("en-US", "NapTitle.Add", "Naptastic!"));
            localizedStrings.Add(new MyStringData("en-US", "NapTitle.Edit", "Woken early?"));
            localizedStrings.Add(new MyStringData("en-US", "NapHeading.Add", "Where did you nod off?"));
            localizedStrings.Add(new MyStringData("en-US", "NapHeading.Edit", "Adjust your sleep details."));

            localizedStrings.Add(new MyStringData("en-US", "SightTitle.Add", "What a sight!"));
            localizedStrings.Add(new MyStringData("en-US", "SightTitle.Edit", "Double Take?"));
            localizedStrings.Add(new MyStringData("en-US", "SightHeading.Add", "Seen something fancy?"));
            localizedStrings.Add(new MyStringData("en-US", "SightHeading.Edit", "Change what you saw."));

            localizedStrings.Add(new MyStringData("en-US", "TripTitle.Add", "Life is a journey!"));
            localizedStrings.Add(new MyStringData("en-US", "TripTitle.Edit", "Lost?"));
            localizedStrings.Add(new MyStringData("en-US", "TripHeading.Add", "Add your travel details."));
            localizedStrings.Add(new MyStringData("en-US", "TripHeading.Edit", "Edit your travel details."));

            /* Chinese */
            localizedStrings.Add(new MyStringData("zh-CN", "ApplicationTitle", "魔术公共汽车"));
            localizedStrings.Add(new MyStringData("zh-CN", "ApplicationHeading", "你最喜欢的旅行日记"));

            localizedStrings.Add(new MyStringData("zh-CN", "ExperienceListTitle", "您的经验"));
            localizedStrings.Add(new MyStringData("zh-CN", "ExperienceListHeading", "你看，你所有的好经验"));

            localizedStrings.Add(new MyStringData("zh-CN", "ChowTitle.Add", "吃了吗?"));
            localizedStrings.Add(new MyStringData("zh-CN", "ChowTitle.Edit", "吃错了吗?"));
            localizedStrings.Add(new MyStringData("zh-CN", "ChowHeading.Add", "你吃了什么?"));
            localizedStrings.Add(new MyStringData("zh-CN", "ChowHeading.Edit", "你吃了什么?"));

            localizedStrings.Add(new MyStringData("zh-CN", "NapTitle.Add", "Naptastic!"));
            localizedStrings.Add(new MyStringData("zh-CN", "NapTitle.Edit", "Woken early?"));
            localizedStrings.Add(new MyStringData("zh-CN", "NapHeading.Add", "Where did you nod off?"));
            localizedStrings.Add(new MyStringData("zh-CN", "NapHeading.Edit", "Adjust your sleep details."));

            localizedStrings.Add(new MyStringData("zh-CN", "SightTitle.Add", "What a sight!"));
            localizedStrings.Add(new MyStringData("zh-CN", "SightTitle.Edit", "Double Take?"));
            localizedStrings.Add(new MyStringData("zh-CN", "SightHeading.Add", "Seen something fancy?"));
            localizedStrings.Add(new MyStringData("zh-CN", "SightHeading.Edit", "Change what you saw."));

            localizedStrings.Add(new MyStringData("zh-CN", "TripTitle.Add", "Life is a journey!"));
            localizedStrings.Add(new MyStringData("zh-CN", "TripTitle.Edit", "Lost?"));
            localizedStrings.Add(new MyStringData("zh-CN", "TripHeading.Add", "Add your travel details."));
            localizedStrings.Add(new MyStringData("zh-CN", "TripHeading.Edit", "Edit your travel details."));
        }

        private class MyStringData
        {
            public MyStringData(string cultureName, string name, string value)
            {
                CultureName = cultureName;
                Name = name;
                Value = value;
            }

            public string CultureName { get; private set; }

            public string Name { get; private set; }

            public string Value { get; private set; }
        }
    }
}