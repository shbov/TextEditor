using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    internal class TabClass
    {
        private readonly RichTextBox _textBox;

        public TabClass(ContextMenuStrip contextMenuStrip, Theme theme) : this(contextMenuStrip, string.Empty,
            string.Empty, theme)
        {
        }

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
        public bool IsTabEdited { get; set; }
        public bool IsTabSaved { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string SavedPath { get; set; }
        private ContextMenuStrip ContextMenuStrip { get; }

        private void TabPage_TextChanged(object? sender, EventArgs e)
        {
            IsTabEdited = true;
            Name = $"{FileName}*";
            TabPage.Text = Name;
        }

        public bool IfFileIsRtf()
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
                MessageBox.Show($"Не удалось сохранить файл: {exception.Message}", "Error");
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
                MessageBox.Show($"Ошибка при сохранении файла: {e.Message}", "Error");
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

            MessageBox.Show("Ошибка: сохраните или откройте файл .rtf!", "Error", MessageBoxButtons.OK);
            return false;
        }
    }
}