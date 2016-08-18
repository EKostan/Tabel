using System;
using CACore.Menu;
using DevExpress.XtraBars.Ribbon;

namespace UserInterface.Ribbon
{
    class BarGroupCreator : IGroupCreator
    {
        public RibbonPageGroup Create(IGroup group)
        {
            var pageGroup = new RibbonPageGroup(group.Key)
            {
                Name = group.Key, 
                Text = group.DisplayName, 
                Tag = group,
                Visible = group.Visible,
                AllowMinimize = group.AllowMinimize
            };

            var controller = new BarGroupController(group, pageGroup);

            return pageGroup;
        }
    }

    internal class BarGroupController : IDisposable
    {
        private IGroup _group;
        private RibbonPageGroup _ribbonPageGroup;

        public BarGroupController(IGroup group, RibbonPageGroup ribbonPageGroup)
        {
            _group = group;
            _ribbonPageGroup = ribbonPageGroup;

            SignEvents();
        }

        private void SignEvents()
        {
            _group.VisibleChanged += GroupVisibleChanged;
            _ribbonPageGroup.Disposed += RibbonPageGroupDisposed;
        }

        void GroupVisibleChanged(object sender, EventArgs e)
        {
            _ribbonPageGroup.Visible = _group.Visible;
        }

        void RibbonPageGroupDisposed(object sender, EventArgs e)
        {
            Dispose();
        }


        public void Dispose()
        {
            _group.VisibleChanged -= GroupVisibleChanged;
            _ribbonPageGroup.Disposed -= RibbonPageGroupDisposed;

        }
    }
}
