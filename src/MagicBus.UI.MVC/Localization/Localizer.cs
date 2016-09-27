using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MagicBus.Migrations;

namespace MagicBus
{
    public class StringLocalizer : IStringLocalizer
    {
        private readonly List<MyStringData> _stringData = new List<MyStringData>();
        private readonly LocalizationDbContext _db;

        public StringLocalizer(LocalizationDbContext db)
        {
            _db = db;
            InitializeLocalizedStrings();
        }

        public LocalizedString this[string name]
        {
            get
            {
                var culture = CultureInfo.CurrentUICulture;
                var translation = _stringData.FirstOrDefault(x => x.CultureName == culture.Name && x.Name == name)?.Value;
                return new LocalizedString(name, translation ?? name, translation != null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var culture = CultureInfo.CurrentUICulture;
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
            CultureInfo.DefaultThreadCurrentCulture = culture;
            return new StringLocalizer(_db);
        }

        private void InitializeLocalizedStrings()
        {
            _stringData.Clear();
            _stringData.AddRange(_db.LocalizedStrings.Select(c => new MyStringData(c.CultureName, c.Name, c.Value)));
        }
    }

    public class MyStringData
    {
        public MyStringData() { }
        public MyStringData(string cultureName, string name, string value)
        {
            CultureName = cultureName;
            Name = name;
            Value = value;
        }

        public int Id { get; set; }

        public string CultureName { get; private set; }

        public string Name { get; private set; }

        public string Value { get; private set; }
    }
}