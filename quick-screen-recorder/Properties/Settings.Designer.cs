namespace quick_screen_recorder.Properties {
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.4.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get { return defaultInstance; }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int Theme { get { return ((int)(this["Theme"])); } set { this["Theme"] = value; } }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AlwaysOnTop { get { return ((bool)(this["AlwaysOnTop"])); } set { this["AlwaysOnTop"] = value; } }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        public int QualityIndex { get { return ((int)(this["QualityIndex"])); } set { this["QualityIndex"] = value; } }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool CaptureCursor { get { return ((bool)(this["CaptureCursor"])); } set { this["CaptureCursor"] = value; } }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool HideTaskbar { get { return ((bool)(this["HideTaskbar"])); } set { this["HideTaskbar"] = value; } }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Preview { get { return ((bool)(this["Preview"])); } set { this["Preview"] = value; } }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool CheckForUpdates { get { return ((bool)(this["CheckForUpdates"])); } set { this["CheckForUpdates"] = value; } }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Folder { get { return ((string)(this["Folder"])); } set { this["Folder"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int FpsIndex { get { return ((int)(this["FpsIndex"])); } set { this["FpsIndex"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int ResolutionIndex { get { return ((int)(this["ResolutionIndex"])); } set { this["ResolutionIndex"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool HighlightClicks { get { return ((bool)(this["HighlightClicks"])); } set { this["HighlightClicks"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool HapticsEnabled { get { return ((bool)(this["HapticsEnabled"])); } set { this["HapticsEnabled"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool EnableWatermark { get { return ((bool)(this["EnableWatermark"])); } set { this["EnableWatermark"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Lite Screen Recorder")]
        public string WatermarkText { get { return ((string)(this["WatermarkText"])); } set { this["WatermarkText"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowTimestamp { get { return ((bool)(this["ShowTimestamp"])); } set { this["ShowTimestamp"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoTimestampFile { get { return ((bool)(this["AutoTimestampFile"])); } set { this["AutoTimestampFile"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int CountdownIndex { get { return ((int)(this["CountdownIndex"])); } set { this["CountdownIndex"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int AutoStopIndex { get { return ((int)(this["AutoStopIndex"])); } set { this["AutoStopIndex"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool MinimizeToTray { get { return ((bool)(this["MinimizeToTray"])); } set { this["MinimizeToTray"] = value; } }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool OpenFolderAfterRec { get { return ((bool)(this["OpenFolderAfterRec"])); } set { this["OpenFolderAfterRec"] = value; } }
    }
}
