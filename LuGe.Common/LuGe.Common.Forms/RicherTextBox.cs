/*
 * User: lgermain
 * Date: 07/10/2008 14:12
 */

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LuGe.Common.Forms
{
	/// <summary>
	/// Extends the base RichTextBox with cursor positioning.
	/// </summary>
	public class RicherTextBox : RichTextBox
	{
		
		#region Events
		
		/// <summary>
		/// Event handler when the cursor position changed.
		/// </summary>
		public event EventHandler CursorPositionChanged;
		
		#endregion
		
		#region Fields
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the current column position of the cursor.
		/// </summary>
		public int CurrentColumn
		{
			get { return CursorPosition.Column(this, SelectionStart); }
		}
		
		/// <summary>
		/// Gets the current line position of the cursor.
		/// </summary>
		public int CurrentLine
		{
			get { return CursorPosition.Line(this, SelectionStart); }
		}

		/// <summary>
		/// Gets the current position of the cursor.
		/// </summary>
		public int CurrentPosition
		{
			get { return this.SelectionStart; }
		}

		/// <summary>
		/// Gets the cursor position of the selection ending.
		/// </summary>
		public int SelectionEnd
		{
			get { return SelectionStart + SelectionLength; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Raised when the cursor position changed.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected virtual void OnCursorPositionChanged(EventArgs e)
		{
			if (CursorPositionChanged != null) CursorPositionChanged(this, e);
		}
		
		/// <summary>
		/// Raised when the selection changed.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnSelectionChanged(EventArgs e)
		{
			if (SelectionLength == 0) OnCursorPositionChanged(e);
			else base.OnSelectionChanged(e);
		}		
		
		#endregion
		
	}	
}
