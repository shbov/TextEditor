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
            _textBox.TextChanged += TabPage_TextChanged;
            TabPage.Controls.Add(_textBox);
        }

        public TabPage TabPage { get; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTabSaved { get; private set; }
        private bool IsTabEdited { get; set; }
        private string Name { get; set; }
        private string FileName { get; set; }
        private string SavedPath { get; set; }
        private ContextMenuStrip ContextMenuStrip { get; }

        private void TabPage_TextChanged(object? sender, EventArgs e)
        {
            IsTabEdited = true;
            Name = $"{FileName}*";
            TabPage.Text = Name;
        }

        private bool IfFileIsRtf()
        {
            return Path.GetExtension(SavedPath).Equals(".rtf");
        }

        public void Paste()
        {
            _textBox.Paste();
        }

        public void Cut()
        {
            _textBox.Cut();
        }

        public void SelectAll()
        {
            _textBox.SelectAll();
        }

        public void Redo()
        {
            _textBox.Redo();
        }

        public void Undo()
        {
            _textBox.Undo();
        }

        public void Copy()
        {
            _textBox.Copy();
        }

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

        public void Bold()
        {
            if (!AllowRtfOnly()) return;

            _textBox.SelectionFont = new Font(
                _textBox.SelectionFont,
                FontStyle.Bold | _textBox.SelectionFont.Style);
        }

        public void Italic()
        {
            if (!AllowRtfOnly()) return;

            _textBox.SelectionFont = new Font(
                _textBox.SelectionFont,
                FontStyle.Italic | _textBox.SelectionFont.Style);
        }

        public void Cross()
        {
            if (!AllowRtfOnly()) return;

            _textBox.SelectionFont = new Font(
                _textBox.SelectionFont,
                FontStyle.Strikeout | _textBox.SelectionFont.Style);
        }

        public void Regular()
        {
            if (!AllowRtfOnly()) return;

            _textBox.SelectionFont = new Font(
                _textBox.SelectionFont,
                FontStyle.Regular);
        }

        public void Underline()
        {
            if (!AllowRtfOnly()) return;

            _textBox.SelectionFont = new Font(
                _textBox.SelectionFont,
                FontStyle.Underline | _textBox.SelectionFont.Style);
        }

        public bool AllowRtfOnly()
        {
            if (IfFileIsRtf()) return true;

            MessageBox.Show(Resources.OnlyRtf, "Error", MessageBoxButtons.OK);
            return false;
        }
    }
}