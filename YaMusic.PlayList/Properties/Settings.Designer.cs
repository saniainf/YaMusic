﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YaMusic.PlayListView.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.5.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=(localdb)\\MSSQLLocalDB;Database=YaMusic;Trusted_Connection=True;")]
        public string ConnectionStrings {
            get {
                return ((string)(this["ConnectionStrings"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://music.yandex.ru/handlers/album.jsx?album=")]
        public string AlbumConnectionString {
            get {
                return ((string)(this["AlbumConnectionString"]));
            }
            set {
                this["AlbumConnectionString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://music.yandex.ru/handlers/artist.jsx?artist=")]
        public string ArtistConnectionString {
            get {
                return ((string)(this["ArtistConnectionString"]));
            }
            set {
                this["ArtistConnectionString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://music.yandex.ru/handlers/track.jsx?track=")]
        public string TrackConnectionString {
            get {
                return ((string)(this["TrackConnectionString"]));
            }
            set {
                this["TrackConnectionString"] = value;
            }
        }
    }
}
