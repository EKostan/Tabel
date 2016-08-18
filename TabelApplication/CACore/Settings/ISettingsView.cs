using System;
using System.Collections.Generic;

namespace CACore.Settings
{
    public interface ISettingsView
    {
        event EventHandler OkClick;
        event EventHandler CancelClick;

        List<ISettingsTab> SettingsTabs { get; set; }

    }
}