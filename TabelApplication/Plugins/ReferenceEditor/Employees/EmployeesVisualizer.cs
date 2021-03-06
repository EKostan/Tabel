﻿using System.Collections.Generic;
using CACore.View;
using CACore.Visualizers;
using InterfaceLibrary;

namespace ReferenceEditor.Employees
{
    class EmployeesVisualizer : Visualizer
    {
        private EmployeesPresenter _presenter;

        public EmployeesVisualizer()
        {
            Name = "Сотрудники";
            Icon = ImageGallery.ContactIcon;

            var view = new EmployeesControl();
            _presenter = new EmployeesPresenter(view); 
            Presentation = view;
            Workspace.Instance.Updated += Instance_Updated;
        }

        void Instance_Updated(object sender, System.EventArgs e)
        {
            var vis = Workspace.Instance.GetActiveVisualizer<EmployeesVisualizer>();

            if (!Equals(vis, this))
                return;

            _presenter.ReloadData();
        }

        public override void Dispose()
        {
            Workspace.Instance.Updated -= Instance_Updated;

            _presenter.Dispose();
        }
    }
}