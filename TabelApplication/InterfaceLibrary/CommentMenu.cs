using System;
using System.Windows.Forms;

namespace InterfaceLibrary
{
    public  class CommentMenu : ContextMenu
    {
        public event EventHandler<EventArgs> AddCommentEvent;
        public event EventHandler<EventArgs> RemoveCommentEvent;
        public event EventHandler<EventArgs> ChangeCommentEvent;
        public event EventHandler<EventArgs> ViewHistoryEvent;

        private MenuItem _addItem = null;
        private MenuItem _removeItem = null;
        private MenuItem _changeItem = null;
        private MenuItem _historyItem = null;

        public CommentMenu()
        {
            Init();
        }

        public void ClickOnRow(bool row)
        {
            _addItem.Enabled = true;
            _removeItem.Enabled = row;
            _changeItem.Enabled = row;
            _historyItem.Enabled = true;
        }

        private void Init()
        {
            _addItem = new MenuItem("Добавить");
            _changeItem = new MenuItem("Редактировать");
            _removeItem = new MenuItem("Удалить");
            _historyItem = new MenuItem("История");
            MenuItems.Add(_addItem);
            MenuItems.Add(_changeItem);
            MenuItems.Add(_removeItem);
            MenuItems.Add(_historyItem);
            _addItem.Click += (sender, args) =>
            {
                if (AddCommentEvent != null) AddCommentEvent(this, new EventArgs());
            };
            _removeItem.Click += (sender, args) =>
            {
                if (RemoveCommentEvent != null) RemoveCommentEvent(this, new EventArgs());
            };
            _changeItem.Click += (sender, args) =>
            {
                if (ChangeCommentEvent != null) ChangeCommentEvent(this, new EventArgs());
            };
            _historyItem.Click += (sender, args) =>
            {
                if (ViewHistoryEvent != null) ViewHistoryEvent(this, new EventArgs());
            };
        }
    }
}
