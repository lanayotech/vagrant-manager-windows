using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpSparkle
{
    /// <summary>
    /// SharpSparkle - A C# bridge for WinSparkle <http://sourceforge.net/projects/winsparkle> library.
    /// (c) 2014 by bagnz0r <http://github.com/bagnz0r>
    /// </summary>
    public class SharpSparkle
    {

        /// <summary>
        /// Initializes the Sparkle library.
        /// </summary>
        [DllImport("WinSparkle.dll", EntryPoint = "win_sparkle_init", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Init();

        /// <summary>
        /// Cleans up after the Sparkle library.
        /// </summary>
        [DllImport("WinSparkle.dll", EntryPoint = "win_sparkle_cleanup", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Cleanup();

        /// <summary>
        /// Manually forces Sparkle to check for updates.
        /// </summary>
        [DllImport("WinSparkle.dll", EntryPoint = "win_sparkle_check_update_with_ui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CheckUpdateWithUi();

        /// <summary>
        /// Sets URL for the app's appcast. 
        /// Only http and https schemes are supported.
        /// 
        /// If this function isn't called by the app, the URL is obtained from
        /// Windows resource named "FeedURL" of type "APPCAST".
        /// </summary>
        /// <param name="url">Appcast URL</param>
        [DllImport("WinSparkle.dll", EntryPoint = "win_sparkle_set_appcast_url", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAppcastUrl([MarshalAs(UnmanagedType.LPStr)] string url);

        /// <summary>
        /// Although using this in a properly linked C/C++ app would not be required - it is required here
        /// in C# bridge library.
        /// </summary>
        /// <param name="companyName">Your company name</param>
        /// <param name="appName">Application name</param>
        /// <param name="appVersion">Application version</param>
        [DllImport("WinSparkle.dll", EntryPoint = "win_sparkle_set_app_details", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAppDetails([MarshalAs(UnmanagedType.LPWStr)] string companyName,
            [MarshalAs(UnmanagedType.LPWStr)] string appName,
            [MarshalAs(UnmanagedType.LPWStr)] string appVersion);

        /// <summary>
        /// Set the registry path where settings will be stored.
        ///
        /// Normally, these are stored in
        /// "HKCU\Software\<company_name>\<app_name>\WinSparkle"
        /// but if your application needs to store the data elsewhere for
        /// some reason, using this function is an alternative.
        ///
        /// Note that path is relative to HKCU/HKLM root and the root is not part
        /// of it. For example:
        /// @code
        ///     SetRegistryPath("Software\\My App\\Updates");
        /// @endcode
        /// </summary>
        /// <param name="path"></param>
        [DllImport("WinSparkle.dll", EntryPoint = "win_sparkle_set_registry_path", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRegistryPath([MarshalAs(UnmanagedType.LPStr)] string path);

    }
}
