/*
 * User: lgermain
 * Date: 24/10/2008 13:23
 */

using System;
using System.Runtime.InteropServices;

namespace LuGe.Common.Forms.Highlight
{
	/// <summary>
	/// Win32Point
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Win32Point
	{
		/// <summary>
		/// x
		/// </summary>
		public int x;
		/// <summary>
		/// y
		/// </summary>
		public int y;
	}
}
