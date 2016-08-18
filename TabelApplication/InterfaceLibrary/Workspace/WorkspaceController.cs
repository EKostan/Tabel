using System.Collections.Generic;
using System.IO;
using CACore.View;
using DevExpress.Utils;

namespace InterfaceLibrary.Workspace
{
    public class WorkspaceController
    {
        private WorkspaceManager _manager;
        private string _viewTypeName;

        public WorkspaceController(WorkspaceManager manager, string viewTypeName)
        {
            _manager = manager;
            _viewTypeName = viewTypeName;
        }

        public const string DefaultLayoutName = "По умолчанию";

        
        public LayoutSettingsCollection DefaultLayoutSettingsCollection
        {
            get
            {
                var res = new LayoutSettingsCollection();
                res.Add(DefaultLayoutSettings);
                res.CurrentLayoutSettings = DefaultLayoutSettings;
                return res;
            }
        }


        public LayoutSettingsCollection LayoutSettingsCollection
        {
            get
            {
                return GetLayoutSetingsCollection();
                //return _layoutSettingsCollection;
            }
            set
            {
                //_layoutSettingsCollection = value;
                //ApplyLayoutSettingsCollection(_layoutSettingsCollection);
                ApplyLayoutSettingsCollection(value);
            }
        }




        /// <summary>
        /// При вызове грабит текущий layout и сохраняет его как layout по умолчанию
        /// </summary>
        public void CaptureDefaultLayoutSettings()
        {
            _manager.CaptureWorkspace(DefaultLayoutName);

            var ws = _manager.GetWorkspace(DefaultLayoutName);

            if (ws != null)
            {
                DefaultLayoutSettings = new LayoutSettings()
                {
                    SerializationData = (byte[])ws.SerializationData,
                    Name = DefaultLayoutName
                };

                CurrentLayoutSettingsName = DefaultLayoutName;
            }
        }

        public LayoutSettings DefaultLayoutSettings { get; set; }

        public string CurrentLayoutSettingsName { get; set; }

        public LayoutSettingsCollection GetLayoutSetingsCollection()
        {
            var res = DefaultLayoutSettingsCollection;

            foreach (var workspace in _manager.Workspaces)
            {
                var layoutSettings = new LayoutSettings()
                {
                    SerializationData = (byte[])workspace.SerializationData,
                    Name = workspace.Name
                };
                res.Add(layoutSettings);
                
                if (CurrentLayoutSettingsName == workspace.Name)
                {
                    res.CurrentLayoutSettings = layoutSettings;
                }

            }

            return res;
        }

        public void SetLayoutSettings(string workspaceName)
        {
            var ws = _manager.GetWorkspace(workspaceName);

            if(ws == null)
                return;

            var layoutSetting = new LayoutSettings() { Name = workspaceName , SerializationData = (byte[])ws.SerializationData};

            string fileName = SaveLayoutSerializationDataToFile(layoutSetting);
            _manager.LoadWorkspace(layoutSetting.Name, fileName);
            _manager.ApplyWorkspace(layoutSetting.Name);
        }

        public void ApplyLayoutSettingsCollection(LayoutSettingsCollection layoutSettings)
        {
            _manager.Workspaces.Clear();
            _manager.RecentWorkspaces.Clear();

            foreach (var layoutSetting in layoutSettings)
            {
                // необходимо промежуточное сохранение на диск, так как workspaceManager 
                // умеет грузить layout только с диска
                string fileName = SaveLayoutSerializationDataToFile(layoutSetting);

                _manager.LoadWorkspace(layoutSetting.Name, fileName);
                _manager.RecentWorkspaces.Add(_manager.GetWorkspace(layoutSetting.Name));
            }

            if (layoutSettings.CurrentLayoutSettings != null)
            {
                CurrentLayoutSettingsName = layoutSettings.CurrentLayoutSettings.Name;
                _manager.ApplyWorkspace(layoutSettings.CurrentLayoutSettings.Name);
            }
        }


        string GetTempFilePathToSettings(string name)
        {
            return Path.Combine(System.Windows.Forms.Application.UserAppDataPath, _viewTypeName + "_" + name + ".xml");
        }
        
        private string SaveLayoutSerializationDataToFile(LayoutSettings layoutSettings)
        {
            var path = GetTempFilePathToSettings(layoutSettings.Name);
            File.WriteAllBytes(path, layoutSettings.SerializationData);
            return path;
        }


        public void CaptureWorkspace(string workspaceName)
        {
            _manager.CaptureWorkspace(workspaceName);
        }


        public void Delete(List<LayoutSettings> list)
        {
            var needUpdate = false;
            foreach (var item in list)
            {
                var ws = _manager.GetWorkspace(item.Name);
                _manager.RemoveWorkspace(ws.Name);


                if (item.Name.Equals(CurrentLayoutSettingsName))
                {
                    needUpdate = true;
                }
            }

            ApplyLayoutSettingsCollection(LayoutSettingsCollection);

            if (needUpdate)
            {
                CurrentLayoutSettingsName = DefaultLayoutName;
            }

            

        }
    }
}
