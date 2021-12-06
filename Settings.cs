using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notepad
{
    internal class Settings
    {
        [DataMember] public List<string> Tabs { get; set; }
        [DataMember] public int Timer { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Theme Theme { get; set; }

        public static Settings Load()
        {
            try
            {
                var file = File.ReadAllText("settings.json");
                if (!string.IsNullOrEmpty(file))
                    return JsonConvert.DeserializeObject<Settings>(file) ?? LoadEmptySettings();
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
                var file = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText("settings.json", file);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка при сохранении настроек!");
            }
        }
    }
}