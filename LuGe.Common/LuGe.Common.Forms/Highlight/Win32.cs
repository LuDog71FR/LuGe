/*
 * User: lgermain
 * Date: 24/10/2008 13:21
 */

using System;
using System.Runtime.InteropServices;
using HWND = System.IntPtr;

namespace LuGe.Common.Forms.Highlight
{
	/// <summary>
	/// Win32 APIs.
	/// </summary>
	public sealed class Win32
	{
		#region Fields
		
		/// <summary>
		/// WM_USER
		/// </summary>
		public const int WM_USER = 0x400;
		/// <summary>
		/// WM_PAINT
		/// </summary>
		public const int WM_PAINT = 0xF;
		/// <summary>
		/// WM_KEYDOWN
		/// </summary>
		public const int WM_KEYDOWN = 0x100;
		/// <summary>
		/// WM_KEYUP
		/// </summary>
		public const int WM_KEYUP = 0x101;
		/// <summary>
		/// WM_CHAR
		/// </summary>
		public const int WM_CHAR = 0x102;

		/// <summary>
		/// EM_GETSCROLLPOS
		/// </summary>
		public const int EM_GETSCROLLPOS  =       (WM_USER + 221);
		/// <summary>
		/// EM_SETSCROLLPOS
		/// </summary>
		public const int EM_SETSCROLLPOS  =       (WM_USER + 222);

		/// <summary>
		/// VK_CONTROL
		/// </summary>
		public const int VK_CONTROL = 0x11;
		/// <summary>
		/// VK_UP
		/// </summary>
		public const int VK_UP = 0x26;
		/// <summary>
		/// VK_DOWN
		/// </summary>
		public const int VK_DOWN = 0x28;
		/// <summary>
		/// VK_NUMLOCK
		/// </summary>
		public const int VK_NUMLOCK = 0x90;

		/// <summary>
		/// KS_ON
		/// </summary>
		public const short KS_ON = 0x01;
		/// <summary>
		/// KS_KEYDOWN
		/// </summary>
		public const short KS_KEYDOWN = 0x80;
		
		#endregion

		#region Constructors
		
		/// <summary>
		/// Private constructor of the class. Only static methods.
		/// </summary>
		private Win32()
		{
		}
		
		#endregion

		#region Properties

		#endregion

		#region Methods
		
		/// <summary>
		/// SendMessage
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="wMsg"></param>
		/// <param name="wParam"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		[DllImport("user32")] public static extern int SendMessage(HWND hwnd, int wMsg, int wParam, IntPtr lParam);
		
		/// <summary>
		/// PostMessage
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="wMsg"></param>
		/// <param name="wParam"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		[DllImport("user32")] public static extern int PostMessage(HWND hwnd, int wMsg, int wParam, int lParam);
		
		/// <summary>
		/// GetKeyState
		/// </summary>
		/// <param name="nVirtKey"></param>
		/// <returns></returns>
		[DllImport("user32")] public static extern short GetKeyState(int nVirtKey);
		
		/// <summary>
		/// LockWindowUpdate
		/// </summary>
		/// <param name="hwnd"></param>
		/// <returns></returns>
		[DllImport("user32")] public static extern int LockWindowUpdate(HWND hwnd);
		
		#endregion

	}
}
