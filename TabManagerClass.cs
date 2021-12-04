using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    internal class TabManagerClass
    {
        private readonly TabControl _tabControl;
        private readonly Dictionary<TabPage, TabClass> _tabs = new Dictionary<TabPage, TabClass>();

        public TabManagerClass(TabControl tabControl)
        {
            _tabControl = tabControl;
        }

        public void Add(TabClass tab)
        {
            if (tab == null)
                return;

            _tabControl.TabPages.Add(tab.TabPage);
            _tabControl.SelectedTab = tab.TabPage;

            _tabs.Add(tab.TabPage, tab);
        }

        public TabClass? GetCurrent()
        {
            if (_tabControl.SelectedTab == null) return null;
            return _tabs[_tabControl.SelectedTab];
        }

        public void SaveAll()
        {
            var unsavedTabs = _tabs.Where(item => !item.Value.IsTabSaved);
            foreach (var item in unsavedTabs)
                item.Value.Save();
        }

        public void CloseCurrent()
        {
                var tab = _tabControl.SelectedTab;
            if(!_tabs[tab].IsTabSaved)
            {
                var saveOrExit = MessageBox.Show("Сохранить файл перед закрытием?", "Информация", MessageBoxButtons.YesNo);
                if(saveOrExit == DialogResult.Yes)
                    GetCurrent()?.Save();
                else return;
            }

                _tabs.Remove(tab);

                var index = _tabControl.TabPages.IndexOf(tab);
                _tabControl.TabPages.RemoveAt(index);

                if (_tabControl.TabPages.Count != 0)
                    _tabControl.SelectedTab = _tabControl.TabPages[Math.Max(index - 1, 0)];
            }
        }
}
