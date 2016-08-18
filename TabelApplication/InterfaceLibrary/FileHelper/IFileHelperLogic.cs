using System;

namespace InterfaceLibrary.FileHelper
{
    interface IFileHelperLogic
    {
        event EventHandler<string> StateChanged;
        event EventHandler<string> FileCopying;
        event EventHandler<int> InitMaxSteps;
        event EventHandler Finished;
        event EventHandler Canceled;
        event EventHandler<string> CopyError;

        string Title { get; set; }

        void DirectoryCopy();
        void OnCancelHandler(object o, EventArgs e);
    }
}
