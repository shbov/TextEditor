using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Notepad.Properties;

namespace Notepad
{
    /// <summary>
    /// Класс, отвечающий за работу формы приложения.
    /// </summary>
    public partial class Notepad : Form
    {
        private readonly TabManagerClass _tabs;
        private Settings _settings;

        private Theme _theme = Theme.Light;

        /// <summary>
        // Конструктор класса.
        /// </summary>
        public Notepad()
        {
            InitializeComponent();
            _tabs = new TabManagerClass(tabControl);
            _settings = new Settings();

            LoadSettings();
        }

        private Notepad(bool isNew) : this()
        {
            AddNewFile_Click(null, null);
        }

        private void AddNewFile_Click(object? sender, EventArgs? e)
        {
            var tabClass = new TabClass(contextMenuStrip, _theme);
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
                    _theme);
                _tabs.Add(tabClass);
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format(Resources.OpenError, exception.Message), "Error");
            }
        }

        private TabClass? OpenFileFromPath(string? path)
        {
            if (string.IsNullOrEmpty(path)) return null;

            try
            {
                if (File.Exists(path))
                {
                    var file = File.ReadAllText(path);
                    return new TabClass(contextMenuStrip, path, file, _theme);
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
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
            SaveSettings();

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
            _theme = Theme.Dark;

            BackColor = Color.DarkGray;
            menuStrip.BackColor = Color.DarkGray;
            menuStrip.ForeColor = Color.White;

            _tabs.GetCurrent()?.ChangeTheme(_theme);
            _settings.Theme = _theme;

            SaveSettings();
        }

        private void SetLightTheme(object? sender, EventArgs? e)
        {
            _theme = Theme.Light;

            BackColor = Color.White;
            menuStrip.BackColor = Color.White;
            menuStrip.ForeColor = Color.Black;

            _tabs.ChangeTheme(_theme);
            _settings.Theme = _theme;

            SaveSettings();
        }

        private void SetTimerEverySec(object? sender, EventArgs? e)
        {
            everySecButton.Checked = !everySecButton.Checked;
            every30SecButton.Checked = false;
            everyMinButton.Checked = false;

            timer.Stop();
            if (everySecButton.Checked)
            {
                timer.Interval = 1000 * 1;
                timer.Start();
                _settings.Timer = 1000 * 1;
            }
            else
            {
                _settings.Timer = 0;
            }

            SaveSettings();
        }

        private void SetTimerEvery30Sec(object? sender, EventArgs? e)
        {
            everySecButton.Checked = false;
            every30SecButton.Checked = !every30SecButton.Checked;
            everyMinButton.Checked = false;

            timer.Stop();
            if (every30SecButton.Checked)
            {
                timer.Interval = 1000 * 30;
                timer.Start();
                _settings.Timer = 1000 * 30;
            }
            else
            {
                _settings.Timer = 0;
            }
        }

        private void SetTimerEveryMin(object? sender, EventArgs? e)
        {
            everySecButton.Checked = false;
            every30SecButton.Checked = false;
            everyMinButton.Checked = !everyMinButton.Checked;

            timer.Stop();
            if (everyMinButton.Checked)
            {
                timer.Interval = 1000 * 60;
                timer.Start();
                _settings.Timer = 1000 * 60;
            }
            else
            {
                _settings.Timer = 0;
            }

            SaveSettings();
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
            SaveSettings();
            Close();
        }

        private void LoadSettings()
        {
            var settings = Settings.Load();

            if (settings.Theme == Theme.Dark) SetDarkTheme(null, null);
            else SetLightTheme(null, null);

            foreach (var item in settings.Tabs)
            {
                var file = OpenFileFromPath(item);
                if (file != null) _tabs.Add(file);
            }

            switch (settings.Timer)
            {
                case 0:
                    break;
                case 1 * 1000:
                    SetTimerEverySec(null, null);
                    break;
                case 30 * 1000:
                    SetTimerEvery30Sec(null, null);
                    break;
                case 60 * 1000:
                    SetTimerEveryMin(null, null);
                    break;
            }

            _settings = settings;
        }

        private void SaveSettings()
        {
            _settings.Tabs = _tabs.All();

            _settings.Save();
        }

        private void ChangeFont(object sender, EventArgs e)
        {
            var file = new FontDialog();
            if (file.ShowDialog() == DialogResult.OK) _tabs.GetCurrent()?.Font(file.Font);
        }
    }
}