using System;
using System.Drawing;

namespace CACore.Menu
{

    public abstract class BaseItem : IItem
    {
        protected BaseItem()
        {
            Enabled = true;
            Visible = true;
        }

        public string Key { get; set; }
        public string DisplayName { get; set; }

        public string Hint { get; set; }

        public Icon Icon { get; set; }
        public Icon LargeIcon { get; set; }
        private bool _enabled;

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                OnEnableChanged();
            }
        }

        public IGroup Group { get; set; }
        public abstract void Execute();

        public event EventHandler EnableChanged;

        protected virtual void OnEnableChanged()
        {
            var handler = EnableChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private bool _visible;

        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                OnVisibleChanged();
            }
        }
        public event EventHandler VisibleChanged;
        protected virtual void OnVisibleChanged()
        {
            var handler = VisibleChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}