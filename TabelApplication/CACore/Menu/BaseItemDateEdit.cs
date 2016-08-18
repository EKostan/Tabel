using System;
using CACore.View;
using CACore.Visualizers;

namespace CACore.Menu
{
    public abstract class BaseItemDateEdit : BaseItem, IItemDateEdit
    {
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnDateChanged();
            }
        }

        public event EventHandler<DateTime> DateChanged;

        protected virtual void OnDateChanged()
        {
            var handler = DateChanged;
            if (handler != null) handler(this, _date);
        }


        public override void Execute()
        {
            DoExecute();
        }

        protected virtual void DoExecute()
        {

        }
    }

    public abstract class BaseItemDateEdit<TVis> : BaseItemDateEdit
        where TVis: class, IVisualizer
    {
        protected BaseItemDateEdit()
        {
            Workspace.Instance.TabActivated += Instance_TabActivated;
        }

        void Instance_TabActivated(object sender, Core.BaseEventArgs<Tab> e)
        {
            var vis = Workspace.Instance.GetActiveVisualizer<TVis>();

            if (vis == null)
            {
                Visible = false;
                return;
            }

            Visible = true;

            OnVisualizerActivated(vis);
        }

        protected virtual void OnVisualizerActivated(TVis vis)
        {

        }
    }



}