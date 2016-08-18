using CACore.Menu;

namespace CACore.Trees.Actions
{
    public class ItemButtonAction : BaseItemButton
    {
        private IAction _action;
        public ItemButtonAction(IAction action)
        {
            _action = action;
            DisplayName = _action.Name;
            Icon = _action.Icon;
        }

        protected override void DoExecute()
        {
            _action.Execute();
        }
    }
}
