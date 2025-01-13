/*
 * User: lgermain
 * Date: 07/10/2008 14:18
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LuGe.Common.Forms
{
	/// <summary>
	/// Class that determines the cursor position in a RichTextBox.
	/// </summary>
	internal class CursorPosition
	{
		#region APIs
		
		[System.Runtime.InteropServices.DllImport("user32")]
		public static extern int GetCaretPos(ref Point lpPoint);
		
		#endregion

		#region Fields
		
		#endregion

		#region Constructors
		
		#endregion

		#region Properties

		#endregion

		#region Methods
		
		private static int GetCorrection(RichTextBox e, int index)
		{
			Point pt1 = Point.Empty;
			GetCaretPos(ref pt1);
			Point pt2 = e.GetPositionFromCharIndex(index);

			if (pt1 != pt2) return 1;
			else return 0;
		}

		public static int Line(RichTextBox e, int index)
		{
			int correction = GetCorrection(e, index);
			return e.GetLineFromCharIndex(index) - correction + 1;
		}

		public static int Column(RichTextBox e, int index1)
		{
			int correction = GetCorrection(e, index1);
			Point p = e.GetPositionFromCharIndex(index1 - correction);
			
			if (p.X == 1) return 1;
			
			p.X = 0;
			int index2 = e.GetCharIndexFromPosition(p);
			
			int col = index1 - index2 + 1;
			return col;
		}
		
		#endregion

	}
}
