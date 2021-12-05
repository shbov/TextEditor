using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Notepad.Properties;

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
            SetLightTheme(null, null);
            SetTimerEvery30Sec(null, null);
        }

        public Notepad(bool isNew) : this()
        {
            AddNewFile_Click(null, null);
        }

        private void AddNewFile_Click(object? sender, EventArgs? e)
        {
            var tabClass = new TabClass(contextMenuStrip, s_theme);
            _tabs.Add(tabClass);
        }

        private void OpenFile(object? sender, EventArgs? e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var tabClass = new TabClass(contextMenuStrip, dialog.FileName, File.ReadAllText(dialog.FileName),
                    s_theme);
                _tabs.Add(tabClass);
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format(Resources.OpenError, exception.Message), "Error");
            }
        }

        private void SaveFile(object? sender, EventArgs? e)
        {
            _tabs.GetCurrent()?.Save();
        }

        private void SaveFileAs(object? sender, EventArgs? e)
        {
            _tabs.GetCurrent()?.SaveFileAs();
        }

        private void CloseTab(object? sender, EventArgs? e)
        {
            _tabs.CloseCurrent();
        }

        private void SaveAllFiles(object? sender, EventArgs? e)
        {
            _tabs.SaveAll();
        }

        private void CloseForm(object? sender, FormClosingEventArgs e)
        {
            var unsavedTabs = _tabs.GetUnsaved();

            if (unsavedTabs.Count == 0)
            {
                e.Cancel = false;
                return;
            }

            var saveOrExit = MessageBox.Show(Resources.SaveBeforeExit, "Информация",
                MessageBoxButtons.YesNo);
            if (saveOrExit == DialogResult.Yes)
            {
                e.Cancel = false;
                return;
            }

            e.Cancel = true;
        }
        
        private void UndoAction(object? sender, EventArgs? e)
        {
            _tabs.GetCurrent()?.Undo();
        }

        private void RedoAction(object? sender, EventArgs? e)
        {
            _tabs.GetCurrent()?.Redo();
        }

        private void CutAction(object? sender, EventArgs? e)
        {
            _tabs.GetCurrent()?.Cut();
        }

        private void CopyAction(object? sender, EventArgs? e)
        {
            _tabs.GetCurrent()?.Copy();
        }

        private void PasteAction(object? sender, EventArgs? e)
        {
            _tabs.GetCurrent()?.Paste();
        }

        private void SelectAllAction(object? sender, EventArgs? e)
        {
            _tabs.GetCurrent()?.SelectAll();
        }

        private void SetDarkTheme(object? sender, EventArgs? e)
        {
            s_theme = Theme.Dark;

            BackColor = Color.DarkGray;
            menuStrip.BackColor = Color.DarkGray;
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

        private void SetTimerEverySec(object? sender, EventArgs? e)
        {
            everySecButton.Checked = !everySecButton.Checked;
            every30SecButton.Checked = false;
            everyMinButton.Checked = false;
            timer.Stop();
            timer.Interval = 1000;
            timer.Start();
        }

        private void SetTimerEvery30Sec(object? sender, EventArgs? e)
        {
            everySecButton.Checked = false;
            every30SecButton.Checked = !every30SecButton.Checked;
            everyMinButton.Checked = false;

            timer.Stop();
            timer.Interval = 1000 * 30;
            timer.Start();
        }

        private void SetTimerEveryMin(object? sender, EventArgs? e)
        {
            everySecButton.Checked = false;
            every30SecButton.Checked = false;
            everyMinButton.Checked = !everyMinButton.Checked;

            timer.Stop();
            timer.Interval = 1000 * 60;
            timer.Start();
        }

        private void TimerTick(object? sender, EventArgs? e)
        {
            _tabs.SaveAllExistedFiles();
        }

        private void NewExternalFile(object sender, EventArgs e)
        {
            var newForm = new Notepad(true);
            newForm.Show();
        }

        private void MakeRegularFont(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.Regular();
        }

        private void MakeItalicFont(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.Italic();
        }

        private void MakeBoldFont(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.Bold();
        }

        private void MakeUnderlineFont(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.Underline();
        }

        private void MakeCrossFont(object sender, EventArgs e)
        {
            _tabs.GetCurrent()?.Cross();
        }

        private void CloseApp(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}