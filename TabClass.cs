using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Notepad.Properties;

namespace Notepad
{
    /// <summary>
    ///     Класс, отвечающий за работу вкладки.
    /// </summary>
    internal class TabClass
    {
        private readonly RichTextBox _textBox;

        /// <summary>
        ///     Конструктор класса (новый файл).
        /// </summary>
        /// <param name="contextMenuStrip">Элемент меню.</param>
        /// <param name="theme">Тема.</param>
        public TabClass(ContextMenuStrip contextMenuStrip, Theme theme) : this(contextMenuStrip, string.Empty,
            string.Empty, theme)
        {
        }

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        /// <param name="contextMenuStrip">Элемент меню.</param>
        /// <param name="path">Путь к файлу.</param>
        /// <param name="text">Содержимое файла.</param>
        /// <param name="theme">Тема.</param>
        public TabClass(ContextMenuStrip contextMenuStrip, string path, string text, Theme theme)
        {
            ContextMenuStrip = contextMenuStrip;
            if (!path.Equals(string.Empty))
            {
                IsTabSaved = true;
                IsTabEdited = false;
                SavedPath = path;
                Name = Path.GetFileName(path);
                FileName = Name;
            }
            else
            {
                Name = "Untitled*";
                FileName = "Untitled";
                SavedPath = string.Empty;
                IsTabEdited = true;
                IsTabSaved = false;
            }

            TabPage = new TabPage
            {
                Text = Name
            };

            if (IfFileIsRtf())
                _textBox = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    Rtf = text,
                    BorderStyle = BorderStyle.None,
                    ContextMenuStrip = ContextMenuStrip
                };
            else
                _textBox = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    Text = text,
                    BorderStyle = BorderStyle.None,
                    ContextMenuStrip = ContextMenuStrip
                };

            ChangeTheme(theme);
            _textBox.TextChanged += TabPageTextChanged;
            TabPage.Controls.Add(_textBox);
        }

        /// <summary>
        ///     Экемпляр класса TabPage.
        /// </summary>
        public TabPage TabPage { get; }

        /// <summary>
        ///     Сохранен ли файл?
        /// </summary>
        public bool IsTabSaved { get; private set; }

        /// <summary>
        ///// Есть ли изменения в файле?
        /// </summary>
        public bool IsTabEdited { get; set; }
        private string Name { get; set; }
        private string FileName { get; set; }

        /// <summary>
        ///     Путь к файлу.
        /// </summary>
        public string SavedPath { get; private set; }

        private ContextMenuStrip ContextMenuStrip { get; }

        /// <summary>
        ///     Событие, которое вызывается при изменении текста в текстбоке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabPageTextChanged(object? sender, EventArgs e)
        {
            IsTabEdited = true;
            Name = $"{FileName}*";
            TabPage.Text = Name;
        }

        /// <summary>
        ///     Является ли файл .rtf?
        /// </summary>
        /// <returns>true - если да; иначе - false.</returns>
        private bool IfFileIsRtf()
        {
            return Path.GetExtension(SavedPath).Equals(".rtf");
        }

        /// <summary>
        ///     Скопировать текст.
        /// </summary>
        public void Paste()
        {
            _textBox.Paste();
        }

        /// <summary>
        ///     Вырезать текст.
        /// </summary>
        public void Cut()
        {
            _textBox.Cut();
        }

        /// <summary>
        ///     Выделить весь текст.
        /// </summary>
        public void SelectAll()
        {
            _textBox.SelectAll();
        }

        /// <summary>
        ///     Вернуть как было перед отменой.
        /// </summary>
        public void Redo()
        {
            _textBox.Redo();
        }

        /// <summary>
        ///     Отмена предыдущего действия.
        /// </summary>
        public void Undo()
        {
            _textBox.Undo();
        }

        /// <summary>
        ///     Копирование выделенного текста.
        /// </summary>
        public void Copy()
        {
            _textBox.Copy();
        }

        /// <summary>
        ///     Сохранить файл.
        /// </summary>
        public void Save()
        {
            if (!IsTabEdited) return;

            if (!IsTabSaved)
            {
                SaveFileAs();
                return;
            }

            try
            {
                File.WriteAllText(SavedPath, IfFileIsRtf() ? _textBox.Rtf : _textBox.Text);
                IsTabSaved = true;
                IsTabEdited = false;
                Name = FileName;
                TabPage.Text = Name;
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format(Resources.ErrorSave, exception.Message), "Error");
            }
        }

        /// <summary>
        ///     Сохранить файл как.
        /// </summary>
        public void SaveFileAs()
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                File.WriteAllText(dialog.FileName, IfFileIsRtf() ? _textBox.Rtf : _textBox.Text);
                IsTabSaved = true;
                IsTabEdited = false;
                Name = Path.GetFileName(dialog.FileName);
                FileName = Name;
                SavedPath = dialog.FileName;

                TabPage.Text = Name;
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(Resources.ErrorSave, e.Message), "Error");
            }
        }

        /// <summary>
        ///     Изменить тему.
        /// </summary>
        /// <param name="theme">Тема.</param>
        public void ChangeTheme(Theme theme)
        {
            switch (theme)
            {
                case Theme.Dark:
                    _textBox.ForeColor = Color.White;
                    _textBox.BackColor = Color.DarkGray;
                    return;
                case Theme.Light:
                    _textBox.ForeColor = Color.Black;
                    _textBox.BackColor = Color.White;
                    return;
            }
        }

        /// <summary>
        ///     Сделать текст жирным.
        /// </summary>
        public void Bold()
        {
            if (!AllowRtfOnly()) return;

            _textBox.SelectionFont = new Font(
                _textBox.SelectionFont,
                FontStyle.Bold | _textBox.SelectionFont.Style);
        }

        /// <summary>
        ///     Сделать текст курсивным.
        /// </summary>
        public void Italic()
        {
            if (!AllowRtfOnly()) return;

            _textBox.SelectionFont = new Font(
                _textBox.SelectionFont,
                FontStyle.Italic | _textBox.SelectionFont.Style);
        }

        /// <summary>
        ///     Сделать текст зачеркнутым.
        /// </summary>
        public void Cross()
        {
            if (!AllowRtfOnly()) return;

            _textBox.SelectionFont = new Font(
                _textBox.SelectionFont,
                FontStyle.Strikeout | _textBox.SelectionFont.Style);
        }

        /// <summary>
        ///     Сделать текст обычным.
        /// </summary>
        public void Regular()
        {
            if (!AllowRtfOnly()) return;

            _textBox.SelectionFont = new Font(
                _textBox.SelectionFont,
                FontStyle.Regular);
        }

        /// <summary>
        ///     Сделать текст подчеркнутым.
        /// </summary>
        public void Underline()
        {
            if (!AllowRtfOnly()) return;

            _textBox.SelectionFont = new Font(
                _textBox.SelectionFont,
                FontStyle.Underline | _textBox.SelectionFont.Style);
        }

        /// <summary>
        ///     Изменить шрифт выделенного текста.
        /// </summary>
        /// <param name="font">Шрифт</param>
        public void Font(Font font)
        {
            if (!AllowRtfOnly()) return;

            _textBox.SelectionFont = new Font(
                font,
                _textBox.SelectionFont.Style);
        }

        /// <summary>
        ///     Функция, которая разрешает только .rtf файлы.
        /// </summary>
        /// <returns>true - если файл .rtf; иначе - уведомление и false.</returns>
        private bool AllowRtfOnly()
        {
            if (IfFileIsRtf()) return true;

            MessageBox.Show(Resources.OnlyRtf, "Error", MessageBoxButtons.OK);
            return false;
        }
    }
}