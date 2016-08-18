using CACore.View;
using CACore.Visualizers;

namespace CACore.Menu
{
    public abstract class BaseItemButton : BaseItem, IItemButton
    {
        public override void Execute()
        {
            DoExecute();
        }

        protected virtual void DoExecute()
        {

        }
    }

    public abstract class BaseItemButton<TVis> : BaseItemButton
        where TVis : class, IVisualizer
    {
        protected BaseItemButton()
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