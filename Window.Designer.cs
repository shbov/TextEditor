namespace TextEditor
{
    partial class TextEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВсеФайлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.вырезатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.выделитьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обычныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.курсивныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.жирныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подчеркнутыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зачеркнутыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.автосохранениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каждуюСекундуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каждые30СекундToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каждуюМинутуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.темыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.светлаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.темнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.редактированиеToolStripMenuItem,
            this.форматированиеToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1486, 44);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewFile,
            this.открытьФайлToolStripMenuItem,
            this.toolStripSeparator1,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.сохранитьВсеФайлыToolStripMenuItem,
            this.toolStripSeparator2,
            this.выйтиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(90, 36);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // AddNewFile
            // 
            this.AddNewFile.Name = "AddNewFile";
            this.AddNewFile.Size = new System.Drawing.Size(386, 44);
            this.AddNewFile.Text = "Новый файл";
            this.AddNewFile.Click += new System.EventHandler(this.AddNewFile_Click);
            // 
            // открытьФайлToolStripMenuItem
            // 
            this.открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
            this.открытьФайлToolStripMenuItem.Size = new System.Drawing.Size(386, 44);
            this.открытьФайлToolStripMenuItem.Text = "Открыть файл";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(383, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(386, 44);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(386, 44);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            // 
            // сохранитьВсеФайлыToolStripMenuItem
            // 
            this.сохранитьВсеФайлыToolStripMenuItem.Name = "сохранитьВсеФайлыToolStripMenuItem";
            this.сохранитьВсеФайлыToolStripMenuItem.Size = new System.Drawing.Size(386, 44);
            this.сохранитьВсеФайлыToolStripMenuItem.Text = "Сохранить все файлы";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(383, 6);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(386, 44);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            // 
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отменитьToolStripMenuItem,
            this.вернутьToolStripMenuItem,
            this.toolStripSeparator3,
            this.вырезатьToolStripMenuItem,
            this.вставитьToolStripMenuItem,
            this.копироватьToolStripMenuItem,
            this.toolStripSeparator4,
            this.выделитьВсеToolStripMenuItem});
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(114, 36);
            this.редактированиеToolStripMenuItem.Text = "Правка";
            // 
            // отменитьToolStripMenuItem
            // 
            this.отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            this.отменитьToolStripMenuItem.Size = new System.Drawing.Size(297, 44);
            this.отменитьToolStripMenuItem.Text = "Отменить";
            // 
            // вернутьToolStripMenuItem
            // 
            this.вернутьToolStripMenuItem.Name = "вернутьToolStripMenuItem";
            this.вернутьToolStripMenuItem.Size = new System.Drawing.Size(297, 44);
            this.вернутьToolStripMenuItem.Text = "Повтор";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(294, 6);
            // 
            // вырезатьToolStripMenuItem
            // 
            this.вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            this.вырезатьToolStripMenuItem.Size = new System.Drawing.Size(297, 44);
            this.вырезатьToolStripMenuItem.Text = "Вырезать";
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(297, 44);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(297, 44);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(294, 6);
            // 
            // выделитьВсеToolStripMenuItem
            // 
            this.выделитьВсеToolStripMenuItem.Name = "выделитьВсеToolStripMenuItem";
            this.выделитьВсеToolStripMenuItem.Size = new System.Drawing.Size(297, 44);
            this.выделитьВсеToolStripMenuItem.Text = "Выделить все";
            // 
            // форматированиеToolStripMenuItem
            // 
            this.форматированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обычныйToolStripMenuItem,
            this.курсивныйToolStripMenuItem,
            this.жирныйToolStripMenuItem,
            this.подчеркнутыйToolStripMenuItem,
            this.зачеркнутыйToolStripMenuItem});
            this.форматированиеToolStripMenuItem.Name = "форматированиеToolStripMenuItem";
            this.форматированиеToolStripMenuItem.Size = new System.Drawing.Size(226, 36);
            this.форматированиеToolStripMenuItem.Text = "Форматирование";
            // 
            // обычныйToolStripMenuItem
            // 
            this.обычныйToolStripMenuItem.Name = "обычныйToolStripMenuItem";
            this.обычныйToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.обычныйToolStripMenuItem.Text = "Обычный";
            // 
            // курсивныйToolStripMenuItem
            // 
            this.курсивныйToolStripMenuItem.Name = "курсивныйToolStripMenuItem";
            this.курсивныйToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.курсивныйToolStripMenuItem.Text = "Курсивный";
            // 
            // жирныйToolStripMenuItem
            // 
            this.жирныйToolStripMenuItem.Name = "жирныйToolStripMenuItem";
            this.жирныйToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.жирныйToolStripMenuItem.Text = "Жирный";
            // 
            // подчеркнутыйToolStripMenuItem
            // 
            this.подчеркнутыйToolStripMenuItem.Name = "подчеркнутыйToolStripMenuItem";
            this.подчеркнутыйToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.подчеркнутыйToolStripMenuItem.Text = "Подчеркнутый";
            // 
            // зачеркнутыйToolStripMenuItem
            // 
            this.зачеркнутыйToolStripMenuItem.Name = "зачеркнутыйToolStripMenuItem";
            this.зачеркнутыйToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.зачеркнутыйToolStripMenuItem.Text = "Зачеркнутый";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.автосохранениеToolStripMenuItem,
            this.темыToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(152, 36);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // автосохранениеToolStripMenuItem
            // 
            this.автосохранениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каждуюСекундуToolStripMenuItem,
            this.каждые30СекундToolStripMenuItem,
            this.каждуюМинутуToolStripMenuItem});
            this.автосохранениеToolStripMenuItem.Name = "автосохранениеToolStripMenuItem";
            this.автосохранениеToolStripMenuItem.Size = new System.Drawing.Size(329, 44);
            this.автосохранениеToolStripMenuItem.Text = "Автосохранение";
            // 
            // каждуюСекундуToolStripMenuItem
            // 
            this.каждуюСекундуToolStripMenuItem.Name = "каждуюСекундуToolStripMenuItem";
            this.каждуюСекундуToolStripMenuItem.Size = new System.Drawing.Size(349, 44);
            this.каждуюСекундуToolStripMenuItem.Text = "Каждую секунду";
            // 
            // каждые30СекундToolStripMenuItem
            // 
            this.каждые30СекундToolStripMenuItem.Name = "каждые30СекундToolStripMenuItem";
            this.каждые30СекундToolStripMenuItem.Size = new System.Drawing.Size(349, 44);
            this.каждые30СекундToolStripMenuItem.Text = "Каждые 30 секунд";
            // 
            // каждуюМинутуToolStripMenuItem
            // 
            this.каждуюМинутуToolStripMenuItem.Name = "каждуюМинутуToolStripMenuItem";
            this.каждуюМинутуToolStripMenuItem.Size = new System.Drawing.Size(349, 44);
            this.каждуюМинутуToolStripMenuItem.Text = "Каждую минуту";
            // 
            // темыToolStripMenuItem
            // 
            this.темыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.светлаяToolStripMenuItem,
            this.темнаяToolStripMenuItem});
            this.темыToolStripMenuItem.Name = "темыToolStripMenuItem";
            this.темыToolStripMenuItem.Size = new System.Drawing.Size(329, 44);
            this.темыToolStripMenuItem.Text = "Темы";
            // 
            // светлаяToolStripMenuItem
            // 
            this.светлаяToolStripMenuItem.Name = "светлаяToolStripMenuItem";
            this.светлаяToolStripMenuItem.Size = new System.Drawing.Size(235, 44);
            this.светлаяToolStripMenuItem.Text = "Светлая";
            // 
            // темнаяToolStripMenuItem
            // 
            this.темнаяToolStripMenuItem.Name = "темнаяToolStripMenuItem";
            this.темнаяToolStripMenuItem.Size = new System.Drawing.Size(235, 44);
            this.темнаяToolStripMenuItem.Text = "Темная";
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 44);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1486, 916);
            this.tabControl.TabIndex = 2;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(301, 86);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 960);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TextEditor";
            this.Text = "TextEditor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddNewFile;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВсеФайлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem автосохранениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каждуюСекундуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каждые30СекундToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каждуюМинутуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem темыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem светлаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem темнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вернутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem вырезатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem выделитьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обычныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem курсивныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem жирныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подчеркнутыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зачеркнутыйToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}
