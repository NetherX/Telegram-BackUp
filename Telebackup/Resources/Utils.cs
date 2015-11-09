using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Telebackup
{
    static class Utils
    {
        static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime FromUnixTime(long unixTime)
        { return epoch.AddSeconds(unixTime); }

        public static long ToUnixTime(DateTime date)
        { return Convert.ToInt64((date - epoch).TotalSeconds); }
        
        public static bool DifferentDay(DateTime dt1, DateTime dt2)
        { return dt1.Day != dt2.Day || dt1.Month != dt2.Month || dt1.Year != dt2.Year; }

        public static bool IsNumeric(Key key)
        {
            if ((key >= Key.D0 && key <= Key.D9) || (key >= Key.NumPad0 && key <= Key.NumPad9)
                || key == Key.Back || key == Key.Enter)
                return true;

            return false;
        }
        
        public static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public static string GetPCModel()
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    FileName = "wmic",
                    Arguments = "computersystem get model",
                    CreateNoWindow = true
                }
            };
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output.Split('\n')[1];
        }

        public static string GetOSName()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey
                    (@"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion");
                if (rk != null)
                    return (string)rk.GetValue("ProductName");
            }
            catch { }

            return "Unknown";
        }
    }
}
