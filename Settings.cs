using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    internal class Settings
    {
        [JsonProperty]
        public List<string>? Tabs { get; set; }

        [JsonProperty]
        public int Timer { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Theme Theme { get; set; }


        public static Settings Load()
        {
            try
            {
                var file = File.ReadAllText("settings.json");
                if (!string.IsNullOrEmpty(file))
                { var settings = JsonConvert.DeserializeObject<Settings>(file);
                    if (settings == null) return LoadEmptySettings();
                    else return settings;
                }
            }
            catch (Exception)
            {
return LoadEmptySettings();
            }
            return LoadEmptySettings();
        }

        private static Settings LoadEmptySettings()
        {
            return new Settings
            {
                Theme = Theme.Light,
                Timer = 30 * 1000,
                Tabs = new List<string>()
            };
        }

        public void Save()
        {
            try
            {
                var file = JsonConvert.SerializeObject(this);
                File.WriteAllText("settings.json", file);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error while saving settings! {exception.Message}");
            }
        }
    }
}
