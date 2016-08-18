using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CACore.View;
using DevExpress.Utils;
using DevExpress.XtraBars;

namespace InterfaceLibrary.Workspace
{
    public class WorkspaceMenuController : IDisposable
    {
        private BarManager _manager;
        private BarSubItem _popupMenu;
        private WorkspaceController _workspaceController;
        private ImageController _imageController;

        public WorkspaceMenuController(WorkspaceController workspaceController, BarManager manager, 
            BarSubItem popupMenu)
        {
            _manager = manager;
            _popupMenu = popupMenu;
            _workspaceController = workspaceController;
            
            _imageController = new ImageController(_manager.Images as ImageCollection);

            _settingsDialog = new Settings();
            _settingsDialog.DeleteEvent += settings_DeleteEvent;
        }

        private BarButtonItem captureWorkspaceButton;
        private BarButtonItem settingsWorkspaceButton;

        public event EventHandler CaptureWorkspace;
        public event EventHandler<string> ApplyWorkspace;

        public string CurrentTemplateName { get; set; }

        void GetCaptureWorkspaceButton()
        {
            if (captureWorkspaceButton != null)
                captureWorkspaceButton.ItemClick -= b_CaptureWorkspaceClick;

            captureWorkspaceButton = AddButton("Захватить рабочее пространство");
            captureWorkspaceButton.ItemClick += b_CaptureWorkspaceClick;
            captureWorkspaceButton.ImageIndex = _imageController.Add(ImageGallery.AddFile);

            settingsWorkspaceButton = AddButton("Рабочие пространства...");
            settingsWorkspaceButton.ItemClick += settingsWorkspaceButton_ItemClick;
            settingsWorkspaceButton.ImageIndex = _imageController.Add(ImageGallery.SettingsIcon);
        }

        private Settings _settingsDialog;

        void settingsWorkspaceButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            _settingsDialog.LayoutSettingsCollection = _workspaceController.LayoutSettingsCollection;
            _settingsDialog.ShowDialog();

            GenerateMenu(_workspaceController.LayoutSettingsCollection);
        }

        void settings_DeleteEvent(object sender, List<LayoutSettings> e)
        {
            _workspaceController.Delete(e);
            _settingsDialog.LayoutSettingsCollection = _workspaceController.LayoutSettingsCollection;
            OnDeleteEvent(e);
        }

        public event EventHandler<List<LayoutSettings>> DeleteEvent;


        BarButtonItem AddButton(string caption)
        {
            var button = new BarButtonItem();
            
            button.Caption = caption;
            _popupMenu.AddItem(button);
            return button;
        }

        void b_CaptureWorkspaceClick(object sender, ItemClickEventArgs e)
        {
            OnCaptureWorkspace();
        }

        void b_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnApplyWorkspace(e.Item.Caption);
        }

        public void GenerateMenu(LayoutSettingsCollection lsc)
        {
            ClearMenu();
            GetCaptureWorkspaceButton();

            bool beginGroup = false;
            foreach (LayoutSettings item in lsc)
            {
                var button = new BarCheckItem();
                button.Appearance.Font = new Font(button.Font, FontStyle.Bold);


                if (item.Name.Equals(CurrentTemplateName))
                    button.Checked = true;

                button.Caption = item.Name;
                button.ItemClick += b_ItemClick;
                
                var link = _popupMenu.AddItem(button);

                if (!beginGroup)
                {
                    link.BeginGroup = true;
                    beginGroup = true;
                }

            }
        }

        private void ClearMenu()
        {
            if (captureWorkspaceButton != null)
                captureWorkspaceButton.ItemClick -= b_CaptureWorkspaceClick;
            
            var list = _popupMenu.ItemLinks.Cast<BarItemLink>().ToList();

            foreach (BarItemLink link in list)
            {
                if (link.Item != null)
                    link.Item.ItemClick -= b_ItemClick;

                _manager.Items.Remove(link.Item);
            }

            _popupMenu.ItemLinks.Clear();
        }


        public void Dispose()
        {
            ClearMenu();
        }

        protected virtual void OnCaptureWorkspace()
        {
            var handler = CaptureWorkspace;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnApplyWorkspace(string e)
        {
            var handler = ApplyWorkspace;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnDeleteEvent(List<LayoutSettings> e)
        {
            var handler = DeleteEvent;
            if (handler != null) handler(this, e);
        }
    }
}