using System;
using System.Collections.Generic;
using CACore.View;
using Contract;

namespace ReferenceEditor.Contracts
{
    class ContractsPresenter : IDisposable
    {
        private ContractsControl _view;

        public ContractsPresenter(ContractsControl view)
        {
            _view = view;
            _view.Load += _view_Load;
            _view.SaveButtonClick += _view_SaveButtonClick;

        }

        void _view_SaveButtonClick(object sender, System.EventArgs e)
        {
            Project.Current.Contracts.Set(_view.GetContracts());
            ReloadData();
        }

        void _view_Load(object sender, System.EventArgs e)
        {
            ReloadData();
        }

        public void ReloadData()
        {
            var data = Project.Current.Contracts.Get();
            _view.SetContracts(data);
        }

        public void Dispose()
        {
            _view.Load -= _view_Load;
            _view.SaveButtonClick -= _view_SaveButtonClick;
        }
    }
}