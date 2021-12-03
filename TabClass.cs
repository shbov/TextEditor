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
        public string SavedPath { get;  set; } = string.Empty;
        private ContextMenuStrip _contextMenuStrip;

        public TabClass(ContextMenuStrip contextMenuStrip) : this(contextMenuStrip, string.Empty, string.Empty)
        {
        }

        public TabClass(ContextMenuStrip contextMenuStrip, string path, string text)
        {
            _contextMenuStrip = contextMenuStrip;
            Name = "Untitled";
         

            if (!path.Equals(string.Empty))
            {
                IsTabSaved = true;
                SavedPath = path;

                Name = Path.GetFileName(path);
            }

            TabPage = new TabPage();
            TabPage.Text = Name;

      
                if (IfFileIsRtf())
                _textBox = new RichTextBox
                    {
                        Dock = DockStyle.Fill,
                        Rtf = text,
                        BorderStyle = BorderStyle.None,
                        ContextMenuStrip = _contextMenuStrip,
                    };
                else
                _textBox = new RichTextBox
                    {
                        Dock = DockStyle.Fill,
                        Text = text,
                        BorderStyle = BorderStyle.None,
                        ContextMenuStrip = _contextMenuStrip,
                    };

            _textBox.TextChanged += TabPage_TextChanged;
                TabPage.Controls.Add(_textBox);
        }

        public void TabPage_TextChanged(object sender, EventArgs e)
        {
            this.IsTabEdited = true;
        }

        public bool IfFileIsRtf()
          => Path.GetExtension(SavedPath).Equals(".rtf");
    }
}
