using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Notepad : Form
    {
        private readonly TabManagerClass _tabs;

        private Theme s_theme = Theme.Light;
        public Notepad()
        {
            InitializeComponent();

            _tabs = new TabManagerClass(tabControl);
            this.SetLightTheme(null,null);
        }

        private void AddNewFile_Click(object sender, EventArgs e)
        {
            var tabClass = new TabClass(contextMenuStrip, s_theme);
            _tabs.Add(tabClass);
        }

        private void OpenFile(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var tabClass = new TabClass(contextMenuStrip, dialog.FileName, File.ReadAllText(dialog.FileName), s_theme);
                _tabs.Add(tabClass);
            }
            catch (Exception exeption)
            {
                MessageBox.Show($"Ошибка при открытии файла: {exeption.Message}", "Error");
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.Save();
        }

        private void SaveFileAs(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.SaveFileAs();
        }

        private void CloseTab(object sender, EventArgs e)
        {
            _tabs.CloseCurrent();
        }

        private void SaveAllFiles(object sender, EventArgs e)
        {
            _tabs.SaveAll();
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            var unsavedTabs = _tabs.GetUnsaved();

            if (unsavedTabs.Count == 0)
            {
                e.Cancel = false;
                return;
            }

            var saveOrExit = MessageBox.Show("Не все файлы сохранены. Вы действительно хотите выйти?", "Информация",
                MessageBoxButtons.OKCancel);
            if (saveOrExit == DialogResult.OK)
            {
                e.Cancel = false;
                return;
            }

            e.Cancel = true;
        }

        private void UndoAction(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.Undo();
        }

        private void RedoAction(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.Redo();
        }

        private void CutAction(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.Cut();
        }

        private void CopyAction(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.Copy();
        }

        private void PasteAction(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.Paste();
        }

        private void SelectAllAction(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.SelectAll();
        }

        private void SetDarkTheme(object? sender, EventArgs? e)
        {
            s_theme = Theme.Dark;

            BackColor = Color.Black;
            menuStrip.BackColor = Color.Black;
            menuStrip.ForeColor = Color.White;

            _tabs.GetCurrent()?.ChangeTheme(s_theme);
        }
        private void SetLightTheme(object? sender, EventArgs? e)
        {
            s_theme = Theme.Light;

            BackColor = Color.White;
            menuStrip.BackColor = Color.White;
            menuStrip.ForeColor = Color.Black;

            _tabs.ChangeTheme(s_theme);
        }
    }
}