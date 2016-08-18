using CACore.View;
using CACore.Visualizers;

namespace CACore.Menu
{
    public abstract class BaseItemTextEdit : BaseItem, IItemTextEdit
    {
        private string _text;
        public ButtonEdit ButtonEdit { get; set; }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                DoTextChanged();
            }
        }

        protected virtual void DoTextChanged()
        {
            
        }

        public override void Execute()
        {
            DoExecute();
        }

        protected virtual void DoExecute()
        {
            
        }
    }

    public abstract class BaseItemTextEdit<TVis> : BaseItemTextEdit
        where TVis : class, IVisualizer
    {
        protected BaseItemTextEdit()
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