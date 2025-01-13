/*
 * User: lgermain
 * Date: 24/10/2008 14:42
 */

using System;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using LuGe.Common.Forms;

namespace LuGe.Common.Forms.Highlight
{
	/// <summary>
	/// Extends the RicherTextBox with syntax highlighting.
	/// </summary>
	public partial class HighlightTextBox : RicherTextBox
	{
		
		#region Fields
		
		private bool _parsing; // value indicating the text is being parsed.
		private bool _syntaxHighlighting; // value indicating if syntax highlighting is enable.
		
		#endregion
		
		#region Constructors
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets or sets a value indicating if syntax highlighting is enable.
		/// </summary>
		[Category("Appearance"),
		 Browsable(true),
		 Description("A value indicating if syntax highlighting is enable."),
		 DefaultValue(false)]
		public bool SyntaxHighlighting
		{
			get { return _syntaxHighlighting; }
			set { _syntaxHighlighting = value; }
		}

		#endregion

		#region Methods
		
		/// <summary>
		/// Highlight the text.
		/// </summary>
		private void DoHighlight()
		{
			StringBuilder sb = new StringBuilder((int)(Text.Length * 1.5 + 150));
			
			// TODO : Do the highlight.
			
			sb.Append(@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033");
			sb.Append(@"\viewkind4\uc1\pard\cf1\f0\fs20");
			
			sb.Append(@"{\colortbl;\red255\green0\blue0;\red0\green255\blue0;\red0\green0\blue255;}");
			
			string[] lines = Text.Split('\n');
			foreach (string line in lines)
			{
				for (int i = 0; i < line.Length; i++)
				{
					if (line[i] == '<')
					{
						sb.Append("\\cf3 ");
						sb.Append(line[i]);
						sb.Append("\\cf1 ");
					}
					else
					{
						sb.Append(line[i]);
					}
				}
				
				sb.Append("\\par ");
			}
			
			sb.Append(@"\cf0\fs17}");
			
			Rtf = sb.ToString();
		}
		
		/// <summary>
		/// Overrided the OnTextChanged to display highlighted text.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnTextChanged(EventArgs e)
		{
			if (SyntaxHighlighting == false) 
			{
				base.OnTextChanged(e);
				return;
			}
			
			if (_parsing) return;
			
			_parsing = true;
			Win32.LockWindowUpdate(Handle);
			base.OnTextChanged(e);
			
			Win32Point scrollPos = GetScrollPos();
			int cursorLoc = SelectionStart;
			
			DoHighlight();
			
			SelectionStart = cursorLoc;
			SetScrollPos(scrollPos);
			
			Win32.LockWindowUpdate((IntPtr)0);
			Invalidate();
			_parsing = false;
		}
		
		/// <summary>
		/// Taking care of Keyboard events.
		/// </summary>
		/// <param name="m">Windows message.</param>
		/// <remarks>
		/// Since even when overriding the OnKeyDown method and not calling
		/// the base function we don't have full control of the input, we've
		/// decided to catch windows messages to handle them.
		/// </remarks>
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case Win32.WM_PAINT:
					{
						if (_parsing) return;
						break;
					}
			}
			
			base.WndProc (ref m);
		}
		
		/// <summary>
		/// Overrided the OnVScroll to avoid scrolling when parsing the text.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnVScroll(EventArgs e)
		{
			if (_parsing) return;
			
			base.OnVScroll (e);
		}
		
		/// <summary>
		/// Sends a win32 message to get the scrollbars' position.
		/// </summary>
		/// <returns>a Win32Point structore containing horizontal
		/// and vertical scrollbar position.</returns>
		private unsafe Win32Point GetScrollPos()
		{
			Win32Point res = new Win32Point();
			IntPtr ptr = new IntPtr(&res);
			Win32.SendMessage(Handle, Win32.EM_GETSCROLLPOS, 0, ptr);
			return res;

		}
		
		/// <summary>
		/// Sends a win32 message to set scrollbars position.
		/// </summary>
		/// <param name="point">a Win32Point conatining H/Vscrollbar scrollpos.</param>
		private unsafe void SetScrollPos(Win32Point point)
		{
			IntPtr ptr = new IntPtr(&point);
			Win32.SendMessage(Handle, Win32.EM_SETSCROLLPOS, 0, ptr);

		}
		
		#endregion

	}
}
