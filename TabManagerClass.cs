using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Notepad.Properties;

namespace Notepad
{
    internal class TabManagerClass
    {
        private readonly TabControl _tabControl;
        private readonly Dictionary<TabPage, TabClass> _tabs = new();

        public TabManagerClass(TabControl tabControl)
        {
            _tabControl = tabControl;
        }

        public void Add(TabClass tab)
        {
            _tabControl.TabPages.Add(tab.TabPage);
            _tabControl.SelectedTab = tab.TabPage;

            _tabs.Add(tab.TabPage, tab);
        }

        public TabClass? GetCurrent()
        {
            return _tabControl.SelectedTab == null ? null : _tabs[_tabControl.SelectedTab];
        }

        public List<TabClass> GetUnsaved()
        {
            return _tabs.Where(item => !item.Value.IsTabSaved).Select(item => item.Value).ToList();
        }

        private List<TabClass> GetSavedTabs()
        {
            return _tabs.Where(item => item.Value.IsTabSaved).Select(item => item.Value).ToList();
        }

        public void SaveAll()
        {
            var unsavedTabs = GetUnsaved();
            foreach (var item in unsavedTabs)
                item.Save();
        }

        public void SaveAllExistedFiles()
        {
            var savedTabs = GetSavedTabs();
            foreach (var item in savedTabs)
                item.Save();
        }

        public void CloseCurrent()
        {
            if (_tabs.Count == 0) return;

            var tab = _tabControl.SelectedTab;
            if (!_tabs[tab].IsTabSaved)
            {
                var saveOrExit = MessageBox.Show(Resources.SaveInfo, "Информация",
                    MessageBoxButtons.YesNo);
                if (saveOrExit == DialogResult.Yes)
                    GetCurrent()?.Save();
            }

            _tabs.Remove(tab);

            var index = _tabControl.TabPages.IndexOf(tab);
            _tabControl.TabPages.RemoveAt(index);

            if (_tabControl.TabPages.Count != 0)
                _tabControl.SelectedTab = _tabControl.TabPages[Math.Max(index - 1, 0)];
        }

        public void ChangeTheme(Theme theme)
        {
            foreach (var item in _tabs)
                item.Value.ChangeTheme(theme);
        }
    }
}