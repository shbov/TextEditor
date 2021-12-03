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
    }
}
