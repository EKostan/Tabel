using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;

namespace InterfaceLibrary
{
    public class EditMenu
    {
        public event EventHandler<EventArgs> AddCommentClick;
        public event EventHandler<EventArgs> RemoveCommentClick;
        public event EventHandler<EventArgs> ChangeCommentClick;
        public event EventHandler<EventArgs> HistoryClick;

        private BarButtonItem _addItem = null;
        private BarButtonItem _removeItem = null;
        private BarButtonItem _changeItem = null;
        private BarButtonItem _historyItem = null;

        private BarManager _barManager;
        private ImageController _imageController;
        private PopupMenu _popupMenu;
        public EditMenu(Control container)
        {
            var imageCollection = new ImageCollection();
            _barManager = new BarManager() { Images = imageCollection, Form = container};
            _imageController = new ImageController(imageCollection);
            _popupMenu = new PopupMenu(_barManager);

            

            Init();
        }

        public void ClickOnRow(bool enabled)
        {
            AddEnabled = true;
            RemoveEnabled = enabled;
            ChangeEnabled = enabled;
        }

        public bool AddVisible
        {
            get { return _addItem.Visibility == BarItemVisibility.Always; }
            set { _addItem.Visibility = value ? BarItemVisibility.Always : BarItemVisibility.Never; }
        }

        public bool AddEnabled
        {
            get { return _addItem.Enabled; }
            set { _addItem.Enabled = value; }
        }

        public bool RemoveVisible
        {
            get { return _removeItem.Visibility == BarItemVisibility.Always; }
            set { _removeItem.Visibility = value ? BarItemVisibility.Always : BarItemVisibility.Never; }
        }

        public bool RemoveEnabled
        {
            get { return _removeItem.Enabled; }
            set { _removeItem.Enabled = value; }
        }

        public bool ChangeVisible
        {
            get { return _changeItem.Visibility == BarItemVisibility.Always; }
            set { _changeItem.Visibility = value ? BarItemVisibility.Always : BarItemVisibility.Never; }
        }

        public bool ChangeEnabled
        {
            get { return _changeItem.Enabled; }
            set { _changeItem.Enabled = value; }
        }

        public bool HistoryVisible
        {
            get { return _historyItem.Visibility == BarItemVisibility.Always; }
            set { _historyItem.Visibility = value ? BarItemVisibility.Always : BarItemVisibility.Never; }
        }

        public bool HistoryEnabled
        {
            get { return _historyItem.Enabled; }
            set { _historyItem.Enabled = value; }
        }

        private void Init()
        {
            _addItem = new BarButtonItem(_barManager, "Добавить")
            {
                ImageIndex = _imageController.Add(ImageGallery.AddImage)
            };
            _addItem.ItemClick += (sender, args) =>
            {
                if (AddCommentClick != null)
                    AddCommentClick(this, new EventArgs());
            };


            _changeItem = new BarButtonItem(_barManager, "Редактировать")
            {
                ImageIndex = _imageController.Add(ImageGallery.EditImage)
            };

            _changeItem.ItemClick += (sender, args) =>
            {
                if (ChangeCommentClick != null)
                    ChangeCommentClick(this, new EventArgs());
            };


            _removeItem = new BarButtonItem(_barManager, "Удалить")
            {
                ImageIndex = _imageController.Add(ImageGallery.RemoveImage)
            };
            
            _removeItem.ItemClick += (sender, args) =>
            {
                if (RemoveCommentClick != null)
                    RemoveCommentClick(this, new EventArgs());
            };


            _historyItem = new BarButtonItem(_barManager, "История")
            {
                ImageIndex = _imageController.Add(ImageGallery.HistoryImage),
                Visibility = BarItemVisibility.Never
            };
            _historyItem.ItemClick += (sender, args) =>
            {
                if (HistoryClick != null)
                    HistoryClick(this, new EventArgs());
            };

            _popupMenu.AddItems(new BarItem[]
            {
                _addItem,
                _changeItem,
                _removeItem,
                _historyItem
            });

           
           
            
        }

        public void ShowPopup()
        {
            ShowPopup(Cursor.Position);
        }

        public void ShowPopup(Point p)
        {
            _popupMenu.ShowPopup(p);
        }
    }
}