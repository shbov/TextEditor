using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class TextEditor : Form
    {
        private TabManagerClass tabs;
        
        public TextEditor()
        {
            InitializeComponent();

            tabs = new(tabControl);
        }

        private void AddNewFile_Click(object sender, EventArgs e)
        {
            var tabClass = new TabClass(contextMenuStrip);
            tabs.Add(tabClass);
        }
    }
}
