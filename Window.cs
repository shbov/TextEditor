using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Notepad : Form
    {
        private TabManagerClass tabs;
        
        public Notepad()
        {
            InitializeComponent();

            tabs = new(tabControl);
        }

        private void AddNewFile_Click(object sender, EventArgs e)
        {
            var tabClass = new TabClass(contextMenuStrip);
            tabs.Add(tabClass);
        }

        private void выделитьВесьТекстToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenFile(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var tabClass = new TabClass(contextMenuStrip, dialog.FileName, File.ReadAllText(dialog.FileName));
                tabs.Add(tabClass);

                return;
            }
            catch (Exception exeption)
            {
                MessageBox.Show($"Ошибка при открытии файла: {exeption.Message}", "Error");
                return;
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {
            tabs.GetCurrent()?.Save();
        }
        private void SaveFileAs(object sender, EventArgs e)
        {
            tabs.GetCurrent()?.SaveFileAs();
        }

        private void CloseTab(object sender, EventArgs e)
        {
            tabs.CloseCurrent();
        }

        private void SaveAllFiles(object sender, EventArgs e)
        {
            tabs.SaveAll();
        }
    }
}
