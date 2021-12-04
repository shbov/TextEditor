using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    internal class TabClass
    {
        public TabPage TabPage { get; }
        private RichTextBox _textBox;
        public bool IsTabEdited { get; set; }
        public bool IsTabSaved { get; set; } 
        public string Name { get; set; }
        public string FileName { get; set; }
        public string SavedPath { get;  set; }
        private ContextMenuStrip ContextMenuStrip { get; set; }

        public TabClass(ContextMenuStrip contextMenuStrip) : this(contextMenuStrip, string.Empty, string.Empty)
        {
        }

        public TabClass(ContextMenuStrip contextMenuStrip, string path, string text)
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
                        ContextMenuStrip = ContextMenuStrip,
                    };
                else
                _textBox = new RichTextBox
                    {
                        Dock = DockStyle.Fill,
                        Text = text,
                        BorderStyle = BorderStyle.None,
                        ContextMenuStrip = ContextMenuStrip,
                    };

            _textBox.TextChanged += new EventHandler(TabPage_TextChanged);
            TabPage.Controls.Add(_textBox);
        }

        private void TabPage_TextChanged(object sender, EventArgs e)
        {
            IsTabEdited = true;
            Name = $"{FileName}*";
            TabPage.Text = Name;
        }

        public bool IfFileIsRtf()
          => Path.GetExtension(SavedPath).Equals(".rtf");

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
                File.WriteAllText(SavedPath, IfFileIsRtf()?_textBox.Rtf:_textBox.Text);
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
    }
}
