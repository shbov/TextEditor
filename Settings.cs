using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Notepad.Properties;

namespace Notepad
{
    /// <summary>
    /// Класс, отвечающий за настройки.
    /// </summary>
    internal class Settings
    {
        /// <summary>
        ///     Список путей всех открытых файлов.
        /// </summary>
        [DataMember]
        public List<string> Tabs { get; set; } = new();

        /// <summary>
        ///     Таймер.
        /// </summary>
        [DataMember]
        public int Timer { get; set; }

        /// <summary>
        ///     Тема.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Theme Theme { get; set; }

        /// <summary>
        ///     Загрузить настройки.
        /// </summary>
        /// <returns>Настройки.</returns>
        public static Settings Load()
        {
            try
            {
                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText("settings.json"))
                       ?? LoadEmptySettings();
            }
            catch (Exception)
            {
                return LoadEmptySettings();
            }
        }

        /// <summary>
        ///     Загрузить дефолтные настройки.
        /// </summary>
        /// <returns>Настройки.</returns>
        private static Settings LoadEmptySettings()
        {
            return new Settings
            {
                Theme = Theme.Light,
                Timer = 30 * 1000,
                Tabs = new List<string>()
            };
        }

        /// <summary>
        ///     Сохранить настройки.
        /// </summary>
        public void Save()
        {
            try
            {
                var file = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText("settings.json", file);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.ErrorWhileSaving);
            }
        }
    }
}