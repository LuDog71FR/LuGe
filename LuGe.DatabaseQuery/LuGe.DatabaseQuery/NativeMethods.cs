using System;
using System.Runtime.InteropServices;

namespace LuGe.DatabaseQuery
{
	public static class NativeMethods
	{
        [DllImport("user32")]
        public static extern int SetForegroundWindow(IntPtr hwnd);
	}
}
