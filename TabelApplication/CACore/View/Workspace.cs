using System;
using System.Collections.Generic;
using CACore.Visualizers;
using Core;

namespace CACore.View
{
    public class Workspace
    {
        public static Workspace Instance = new Workspace();

        List<Tab> _tabs = new List<Tab>();

        private Tab _activeTab = null;

        private bool _treeVisible = true;
        
        /// <summary>
        /// Отображать окно с деревом данных
        /// </summary>
        public bool TreeVisible
        {
            get { return _treeVisible; }
            set
            {
                _treeVisible = value;
                OnTreeVisibleChanged(_treeVisible);
            }
        }

        public event EventHandler<bool> TreeVisibleChanged;

        protected virtual void OnTreeVisibleChanged(bool e)
        {
            EventHandler<bool> handler = TreeVisibleChanged;
            if (handler != null) handler(this, e);
        }

        public Tab NewTab(IVisualizer visualizer)
        {
            var tab = new Tab();
            tab.Visualizer = visualizer;
            _tabs.Add(tab);

            _activeTab = tab;

            OnTabAdded(new BaseEventArgs<Tab>(tab));
            return tab;
        }

        public void ActivateTab(Tab tab)
        {
            _activeTab = tab;
            OnTabActivated(new BaseEventArgs<Tab>(tab));
        }

        public Tab GetActiveTab()
        {
            return _activeTab;
        }

        public event EventHandler<BaseEventArgs<Tab>> TabAdded;
        public event EventHandler<BaseEventArgs<Tab>> TabDeleted;
        public event EventHandler<BaseEventArgs<Tab>> TabActivated;

        public event EventHandler<IToastMessage> MessageToasted;

        protected virtual void OnTabActivated(BaseEventArgs<Tab> e)
        {
            EventHandler<BaseEventArgs<Tab>> handler = TabActivated;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnTabDeleted(BaseEventArgs<Tab> e)
        {
            EventHandler<BaseEventArgs<Tab>> handler = TabDeleted;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnTabAdded(BaseEventArgs<Tab> e)
        {
            EventHandler<BaseEventArgs<Tab>> handler = TabAdded;
            if (handler != null) handler(this, e);
        }

        public void DeleteTab(Tab tab)
        {
            if (_tabs.Contains(tab))
                _tabs.Remove(tab);

            _activeTab = _tabs.Count <= 0 ? null : _tabs[_tabs.Count - 1];

            tab.Dispose();

            OnTabDeleted(new BaseEventArgs<Tab>(tab));
            
        }

        public event EventHandler Load;
        public event EventHandler Updated;
        public event EventHandler UserSettingsSaving;


        public virtual void OnLoad()
        {
            EventHandler handler = Load;
            if (handler != null) handler(this, EventArgs.Empty);
        }


        protected virtual void OnUserSettingsSaving()
        {
            var handler = UserSettingsSaving;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// Оповещаем все плагины, что сейчас будет происходить сохранение настроек
        /// </summary>
        public void SaveUserSettings()
        {
            OnUserSettingsSaving();
        }

        public void Update()
        {
            OnUpdated();
        }

        protected virtual void OnUpdated()
        {
            var handler = Updated;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public void ToastMessage(IToastMessage toastMessage)
        {
            OnMessageToasted(toastMessage);
        }

        protected virtual void OnMessageToasted(IToastMessage e)
        {
            var handler = MessageToasted;
            if (handler != null) handler(this, e);
        }

        public IVisualizer GetActiveVisualizer()
        {
            var tab = GetActiveTab();

            if (tab == null)
                return null;

            return tab.Visualizer;
        }

        public TVis GetActiveVisualizer<TVis>()
            where TVis : class, IVisualizer

        {
            var tab = GetActiveTab();

            if (tab == null)
                return null;

            return tab.Visualizer as TVis;
        }
    }
}
