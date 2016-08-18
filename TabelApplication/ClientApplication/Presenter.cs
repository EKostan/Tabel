using System;
using CACore.Menu;
using CACore.Splash;
using CACore.Trees;
using CACore.View;
using Core;
using NLog;

namespace ClientApplication
{
    public class Presenter : IDisposable
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ISplashView _splashView;
        private IMainView _mainView;

        private ModuleActivator _moduleActivator;


        public Presenter(IMainView mainView, ISplashView splashView)
        {
            _mainView = mainView;
            _splashView = splashView;
        }

        public event EventHandler PresenterInicializeFinished;

        protected virtual void OnPresenterInicializeFinished()
        {
            EventHandler handler = PresenterInicializeFinished;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public string UserName { get; set; }

        internal void InitPresenter()
        {
            // 1. Сплеш окно
            // 2. Идет сборка плагинов.
            // 3. Запускается движок модуля


            _moduleActivator = new ModuleActivator() {SplashView = _splashView};
            _moduleActivator.Activate(UserName);
            InitView();

        }


    


        private TemplateTree _tree;
        protected void InitView()
        {
            UnSignViewEvents();
            SignViewEvents();

            _mainView.MainMenuTabs = MainMenu.GetTabs();
            _mainView.MenuCategories = MainMenu.GetCategories();
        }

        protected void SignViewEvents()
        {
            _mainView.MenuItemClick += MainViewMenuItemClick;
            _mainView.CloseTabClick += MainViewCloseTabClick;
            _mainView.NodeChecked += MainViewNodeChecked;
            _mainView.TabSelected += MainViewTabSelected;
            _mainView.MainViewLoad += MainViewLoad;
            _mainView.MainViewClose += _mainView_MainViewClose;

            // подписываемся на события рабочего пространства
            Workspace.Instance.TabAdded += Instance_TabAdded;
            Workspace.Instance.TabDeleted += Instance_TabDeleted;
            Workspace.Instance.MessageToasted += Instance_MessageToasted;
        }

        void _mainView_MainViewClose(object sender, EventArgs e)
        {
            // обновляем все текущие настройки всех плагинов
            Workspace.Instance.SaveUserSettings();
        }

        void Instance_MessageToasted(object sender, IToastMessage e)
        {
            _mainView.ToastMessage(e);
        }

        
        void MainViewLoad(object sender, EventArgs e)
        {
            _mainView.Init();
            Workspace.Instance.OnLoad();
        }



        void MainViewTabSelected(object sender, BaseEventArgs<Tab> e)
        {
            Workspace.Instance.ActivateTab(e.Value);
            _mainView.UpdateView();
        }

        void MainViewNodeChecked(object sender, CheckNodeEventArgs e)
        {
            var tree = TreeManager.GetTree(TemplateRegistry.DefaultTemplateName);
            tree.CheckNode(e.Node, e.Check);
        }

        void Instance_TabDeleted(object sender, BaseEventArgs<Tab> e)
        {
            _mainView.DeleteTab(e.Value);
            _mainView.UpdateView();
        }

        void MainViewCloseTabClick(object sender, BaseEventArgs<Tab> e)
        {
            Workspace.Instance.DeleteTab(e.Value);
        }

        void Instance_TabAdded(object sender, BaseEventArgs<Tab> e)
        {
            _mainView.AddNewTab(e.Value);
            _mainView.ActivateTab(e.Value);
        }

        protected void UnSignViewEvents()
        {
            if (_mainView != null)
            {

                _mainView.MenuItemClick -= MainViewMenuItemClick;
                _mainView.CloseTabClick -= MainViewCloseTabClick;
                _mainView.NodeChecked -= MainViewNodeChecked;
                _mainView.TabSelected -= MainViewTabSelected;
                _mainView.MainViewLoad -= MainViewLoad;
            }

            // подписываемся на события рабочего пространства
            Workspace.Instance.TabAdded -= Instance_TabAdded;
            Workspace.Instance.TabDeleted -= Instance_TabDeleted;
        }


        void MainViewMenuItemClick(object sender, BaseEventArgs<IItem> e)
        {
            e.Value.Execute();
        }

        public void Dispose()
        {
            UnSignViewEvents();
        }

       
    }
}
