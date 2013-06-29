using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HunterCV.AddIn
{
    public class DownloadResult
    {
        public int Index { get; set; }
        public byte[] Bytes { get; set; }
    }

    public enum FavoritesIcons
    {
        Silver = 0,
        Gold = 1,
        Blue,
        Red
    }

    public static class CrossThreadUtility
    {
        public static void InvokeControlAction<t>(t cont, Action<t> action) where t : Control
        {
            try
            {
                if (cont.InvokeRequired)
                {
                    cont.Invoke(new Action<t, Action<t>>(InvokeControlAction),
                              new object[] { cont, action });
                }
                else
                { action(cont); }
            }
            catch
            {

            }
        }
    }
}
