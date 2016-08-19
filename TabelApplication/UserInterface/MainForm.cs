using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CACore.Menu;
using CACore.Trees;
using CACore.View;
using Core;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using InterfaceLibrary;
using UserInterface.Ribbon;
using UserInterface.Trees;
using UserInterface.Trees.Menu;
using CheckNodeEventArgs = CACore.Trees.CheckNodeEventArgs;

namespace UserInterface
{
    public partial class MainForm : RibbonForm, IMainView
    {
        public MainForm()
        {

            InitializeComponent();

            UserLookAndFeel.Default.SetSkinStyle("Office 2013");

            treeList1.ExpandAll();

        }

        ImageController _ribbonImageController;
        ImageController _ribbonImageLargeController;
        ImageController _treeImageController;
        ImageController _tabImageController;
        
        #region Ribbon

        /// <summary>
        /// Инициализирует и отображает все контролы главного окна.
        /// Необходимо вызывать в главном потоке перед отображением.
        /// </summary>
        public void Init()
        {


            _ribbonImageController = new ImageController(imageCollectionRibbon);
            _ribbonImageLargeController = new ImageController(imageCollectionLargeRibbon);
            _tabImageController = new ImageController(imageCollectionTab);

            var ribbonBuilder = new RibbonBuilder();
            ribbonBuilder.RibbonControl = ribbonControl1;
            ribbonBuilder.ImageController = _ribbonImageController;
            ribbonBuilder.ImageLargeController = _ribbonImageLargeController;
            ribbonBuilder.Tabs = _mainMenuTabs;
            ribbonBuilder.Categories = _mainMenuCategories;
            ribbonBuilder.Build();


            var backstageViewImageController = new ImageController(imageCollectionBackstage);
            var backstageViewBuilder = new BackstageViewBuilder();
            backstageViewBuilder.BackstageViewControl = backstageViewControl1;
            backstageViewBuilder.ImageController = backstageViewImageController;
            backstageViewBuilder.Build();



            SignRibbonEvents();

        }

        private void SignRibbonEvents()
        {
            ribbonControl1.ItemClick += ribbonControl1_ItemClick;
        }

        private void UnSignRibbonEvents()
        {
            ribbonControl1.ItemClick -= ribbonControl1_ItemClick;
        }

        void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var menuItem = e.Item.Tag as IItem;

            if (menuItem != null)
                OnMenuItemClick(new BaseEventArgs<IItem>(menuItem));
        }

        #endregion

        #region Tree

        public Tree Tree 
        {
            get { return _tree; }
            set
            {
                if (_tree != null)
                {
                    UnSignTreeEvents();
                }

                _tree = value;
                InicializeTree();
            }
        }




        private List<IMenuTab> _mainMenuTabs;
        public ICollection<IMenuTab> MainMenuTabs
        {
            get { return _mainMenuTabs; }
            set
            {
                if (_mainMenuTabs != null)
                    UnSignRibbonEvents();

                _mainMenuTabs = new List<IMenuTab>(value);
                //InicializeRibbon();
            }
        }

        private List<ICategory> _mainMenuCategories = new List<ICategory>();
        public ICollection<ICategory> MenuCategories
        {
            get { return _mainMenuCategories; }
            set
            {
                if (_mainMenuCategories != null)
                    UnSignRibbonEvents();

                _mainMenuCategories = new List<ICategory>(value);
                //InicializeRibbon();
            }
        }

        private Tree _tree;

        private delegate void inicializeTreeDelegate();
        private void InicializeTree()
        {
            if(_tree == null)
                return;

            if (InvokeRequired)
            {
                Invoke(new inicializeTreeDelegate(InicializeTree));
                return;
            }

            treeList1.BeginUpdate();
            try
            {
                _treeImageController = new ImageController(imageCollectionTree);
                var treeListBuilder = new TreeListBuilder();
                treeListBuilder.ImageController = _treeImageController;
                treeListBuilder.TreeList = treeList1;
                treeListBuilder.Build(_tree);
                treeList1.ExpandAll();
            }
            finally
            {
                treeList1.EndUpdate();
            }

            SignTreeEvents();

        }

        private void SignTreeEvents()
        {
            _tree.NodeAdded += _tree_NodeAdded;
            _tree.NodeDeleted += _tree_NodeDeleted;
            _tree.NodeUpdated += _tree_NodeUpdated;
        }

        void _tree_NodeUpdated(object sender, BaseEventArgs<INode> e)
        {
            var treeListBuilder = new TreeListBuilder()
            {
                ImageController = new ImageController(imageCollectionTree),
                TreeList = treeList1
            };
            treeListBuilder.UpdateTree(_tree);
        }

        

        private void UnSignTreeEvents()
        {
            _tree.NodeAdded -= _tree_NodeAdded;
            _tree.NodeDeleted -= _tree_NodeDeleted;
        }

        void _tree_NodeAdded(object sender, NodesEventArgs e)
        {
            AddNodesToTreeList(e.Nodes, e.ParentNode);
        }

        delegate void addNodesToTreeList(List<INode> nodes, INode parentNode);
        void AddNodesToTreeList(List<INode> nodes, INode parentNode)
        {
            if (InvokeRequired)
            {
                Invoke(new addNodesToTreeList(AddNodesToTreeList), nodes, parentNode);
            }
            else
            {
                var treeListBuilder = new TreeListBuilder()
                {
                    ImageController = new ImageController(imageCollectionTree),
                    TreeList = treeList1
                };


                treeListBuilder.AddNodes(nodes, parentNode);
            }
        }

        void _tree_NodeDeleted(object sender, NodeChangeEventArgs e)
        {
            DeleteNodeFromTreeList(e.Node, e.ParentNode);
        }

        delegate void deleteNodeFromTreeList(INode node, INode parentNode);
        void DeleteNodeFromTreeList(INode node, INode parentNode)
        {
            if (InvokeRequired)
            {
                Invoke(new deleteNodeFromTreeList(DeleteNodeFromTreeList), node, parentNode);
            }
            else
            {
                var treeListBuilder = new TreeListBuilder()
                {
                    ImageController = new ImageController(imageCollectionTree),
                    TreeList = treeList1
                };

                treeListBuilder.DeleteNode(node, parentNode);
            }
        }

        delegate void addNodeToTreeList(INode node, INode parentNode);
        void AddNodeToTreeList(INode node, INode parentNode)
        {
            if (InvokeRequired)
            {
                Invoke(new addNodeToTreeList(AddNodeToTreeList), node, parentNode);
            }
            else
            {
                var treeListBuilder = new TreeListBuilder()
                {
                    ImageController = new ImageController(imageCollectionTree),
                    TreeList = treeList1
                };


                treeListBuilder.AddNode(node, parentNode);
            }
        }

        private TreeListBuilder TreeListBuilder
        {
            get
            {
                var treeListBuilder = new TreeListBuilder()
                {
                    ImageController = new ImageController(imageCollectionTree),
                    TreeList = treeList1
                };
                return treeListBuilder;
            }
        }


        public void CheckNode(INode node, bool check)
        {
            // отключаем событие чтобы презентаер пять не сработал
            treeList1.AfterCheckNode -= treeList1_AfterCheckNode;

            var treeListNode = TreeListBuilder.FindTreeListNode(node);
            treeListNode.Checked = check;

            // включаем событие
            treeList1.AfterCheckNode += treeList1_AfterCheckNode;
        }

        public event EventHandler MainViewLoad;
        public event EventHandler MainViewClose;

        private void CreateNodeMenu(INode node)
        {
            popupMenuNode.ClearLinks();
            var builder = new NodeMenuBuilder();
            builder.PopupMenu = popupMenuNode;
            builder.Node = node;
            builder.Build();
        }


        TreeListNode FindMouseNode(Point p)
        {
            TreeListHitInfo hi = treeList1.CalcHitInfo(p);
            TreeListNode hInfoNode = hi.Node;
            return hInfoNode;
        }

        private void treeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Column.Equals(treeListColumnData))
            {
                var node = e.CellValue as INode;

                if (node == null)
                    return;

                e.CellText = node.DisplayName;
            }
            else if (e.Column.Equals(treeListColumnStatus))
            {
                if (e.Node[2] == null)
                {
                    e.CellText = string.Empty;
                    e.Handled = true;
                }
            }

        }

        private void treeList1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var treeListNode = FindMouseNode(e.Location);

                if (treeListNode == null)
                    return;

                var node = treeListNode.Tag as INode;

                if (node == null)
                    return;

                CreateNodeMenu(node);

                popupMenuNode.ShowPopup(treeList1.PointToScreen(e.Location));
            }
        }



        private void treeList1_AfterCheckNode(object sender, NodeEventArgs e)
        {
            var node = e.Node.Tag as INode;

            if (node == null)
                return;

            OnNodeChecked(new CheckNodeEventArgs(node, e.Node.Checked));

        }



        #endregion

        #region Workspace


        private delegate void emptyDelegate();
        public void CloseView()
        {
            if (InvokeRequired)
            {
                Invoke(new emptyDelegate(CloseView));
            }
            else
                Close();
        }

        public void AddNewTab(Tab tab)
        {
            var tabPage = new XtraTabPage();
            tabPage.Text = tab.Visualizer.Name;
            tab.Visualizer.NameChanged += VisualizerOnNameChanged; 
            tabPage.Tag = tab;

            var imageIndex = _tabImageController.Add(tab.Visualizer.Icon, tab.Visualizer.GetType());
            tabPage.ImageIndex = imageIndex;
            try
            {
                var visualizerControl = (Control)tab.Visualizer.Presentation;
                visualizerControl.Dock = DockStyle.Fill;
                tabPage.Controls.Add(visualizerControl);
                xtraTabControl1.TabPages.Add(tabPage);
            }
            catch (Exception e)
            {
                Dialogs.ErrorMessageBox("Ошибка открытия вкладки: {0}", e);
                // ошибка в визулизаторе представление должно наследоваться от Control 
                // либо у визуализатора отсутствует представление
            }
        }

        public void DeleteTab(Tab tab)
        {
            //foreach (XtraTabPage tabPage in xtraTabControl1.TabPages)
            //{
            //    var currentTab = tabPage.Tag as Tab;

            //    if (currentTab == null)
            //        continue;

            //    if (currentTab.Equals(tab))
            //    {
            //        currentTab.Visualizer.NameChanged -= VisualizerOnNameChanged;
            //        xtraTabControl1.TabPages.Remove(tabPage);
            //        break;
            //    }
            //}

            XtraTabPage prevTabPage = null;
            foreach (XtraTabPage tabPage in xtraTabControl1.TabPages)
            {
                var currentTab = tabPage.Tag as Tab;

                if (currentTab == null)
                    continue;

                if (currentTab.Equals(tab))
                {
                    currentTab.Visualizer.NameChanged -= VisualizerOnNameChanged;

                    //xtraTabControl1.SelectedPageChanged -= xtraTabControl1_SelectedPageChanged;
                    xtraTabControl1.TabPages.Remove(tabPage);
                    //xtraTabControl1.SelectedPageChanged += xtraTabControl1_SelectedPageChanged;

                    if (prevTabPage != null)
                        xtraTabControl1.SelectedTabPage = prevTabPage;

                    break;
                }

                prevTabPage = tabPage;
            }
        }

        public void ActivateTab(Tab tab)
        {
            //xtraTabControl1.SelectedPageChanged -= xtraTabControl1_SelectedPageChanged;

            foreach (XtraTabPage tabPage in xtraTabControl1.TabPages)
            {
                var currentTab = tabPage.Tag as Tab;

                if (currentTab != null && currentTab.Equals(tab))
                {
                    xtraTabControl1.SelectedTabPage = tabPage;
                    break;
                }
            }

            //xtraTabControl1.SelectedPageChanged += xtraTabControl1_SelectedPageChanged;
        }

        private void VisualizerOnNameChanged(object sender, string s)
        {
            foreach (XtraTabPage tabPage in xtraTabControl1.TabPages)
            {
                var currentTab = tabPage.Tag as Tab;

                if (currentTab == null)
                    continue;

                if (currentTab.Visualizer.Equals(sender))
                {
                    tabPage.Text = s;
                }
            }
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            if (SelectedTab == null)
                return;

            OnCloseTabClick(new BaseEventArgs<Tab>(SelectedTab));
        }


        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page == null)
                return;

            var tab = e.Page.Tag as Tab;
            if (tab != null) tab.OnTabActivated();
            OnTabSelected(new BaseEventArgs<Tab>(tab));
        }


        #endregion

        public event EventHandler<BaseEventArgs<IItem>> MenuItemClick;
        public event EventHandler<BaseEventArgs<Tab>> CloseTabClick;
        public event EventHandler<BaseEventArgs<Tab>> TabSelected;
        public event EventHandler<CheckNodeEventArgs> NodeChecked;

        private delegate void showMessageDelegate(string message);
        public void ShowMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new showMessageDelegate(ShowMessage), message);
            }
            else
                XtraMessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string error)
        {
            if (InvokeRequired)
            {
                Invoke(new showMessageDelegate(ShowError), error);
            }
            else
                XtraMessageBox.Show(this, error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected virtual void OnNodeChecked(CheckNodeEventArgs e)
        {
            EventHandler<CheckNodeEventArgs> handler = NodeChecked;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnMenuItemClick(BaseEventArgs<IItem> e)
        {
            EventHandler<BaseEventArgs<IItem>> handler = MenuItemClick;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnCloseTabClick(BaseEventArgs<Tab> e)
        {
            EventHandler<BaseEventArgs<Tab>> handler = CloseTabClick;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnTabSelected(BaseEventArgs<Tab> e)
        {
            EventHandler<BaseEventArgs<Tab>> handler = TabSelected;
            if (handler != null) handler(this, e);
        }

        private delegate void UpdateDelegate();
        void Update(UpdateDelegate funk)
        {
            if (InvokeRequired)
            {
                Invoke(funk);
            }
            else
            {
                funk();
            }
        }

        public void SetIcon(Icon icon)
        {
            Update(() => { Icon = icon; });
        }

        public void UpdateView()
        {
            //UpdateTree();
        }

        public void ToastMessage(IToastMessage message)
        {
            Update(() => { alertControl1.Show(this, new AlertInfo(message.Caption, message.Message) { Tag = message }); });
        }

        private void UpdateTree()
        {
            TreeListBuilder.UpdateTree(_tree);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OnMainViewLoad();
        }

        protected virtual void OnMainViewLoad()
        {
            var handler = MainViewLoad;
            if (handler != null) handler(this, EventArgs.Empty);
        }


        Tab SelectedTab
        {
            get
            {
                if (xtraTabControl1.SelectedTabPage == null)
                    return null;

                return xtraTabControl1.SelectedTabPage.Tag as Tab;
            }
        }

        private void xtraTabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (SelectedTab == null)
                    return;

                OnCloseTabClick(new BaseEventArgs<Tab>(SelectedTab));
            }
        }

        private void alertControl1_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            var tm = e.Info.Tag as IToastMessage;

            if (tm != null)
            {
                tm.Execute();
                e.AlertForm.Close();
            }
        }

        protected virtual void OnMainViewClose()
        {
            var handler = MainViewClose;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
#if !DEBUG
            if (Dialogs.Question("Вы действительно хотите закрыть программу?") != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
#endif
            OnMainViewClose();
        }

        private void backstageViewControl1_ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            var menuItem = e.Item.Tag as IItem;

            if (menuItem != null)
                OnMenuItemClick(new BaseEventArgs<IItem>(menuItem));
        }
    }
}
