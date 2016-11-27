using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperKeyInfo
{

    public abstract class Key
    {
        public static string ExampleKey { get; protected set; }

        #region Dropbox
        public static string Dropbox_AppKey { get; protected set; }
        public static String Dropbox_AppSecret { get; protected set; }
        #endregion

    }
}
