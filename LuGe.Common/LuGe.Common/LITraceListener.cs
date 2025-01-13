/*
 * User: lgermain
 * Date: 19/01/2009 12:13
 */

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LuGe.Common
{
	/// <summary>
	/// A custom Trace Listener that writes the trace to a <c>RichTextBox</c>.
	/// </summary>
	/// <remarks>
	/// The class and it's method are thread safe !
	/// </remarks>
	public class LITraceListener : TraceListener
	{
		
		#region Delegates

		private delegate void StringSendDelegate(string message);
		
		#endregion
		
		#region Fields
		
		private RichTextBox _target;
		private StringSendDelegate _invokeWrite;
		
		#endregion

		#region Constructors
		
		/// <summary>
		/// Creates a new instance of the class.
		/// </summary>
		public LITraceListener(RichTextBox target)
		{
			_target = target;
			_invokeWrite = new StringSendDelegate(SendString);
		}
		
		#endregion

		#region Properties

		#endregion

		#region Methods
		
		/// <summary>
		/// Writes the specified message to the target listener.
		/// </summary>
		/// <param name="message">Message to write.</param>
		public override void Write(string message)
		{
			_target.Invoke(_invokeWrite, new object[] { message });
		}

		/// <summary>
		/// Writes the specified message to the target listener 
		/// followed by a line terminator.
		/// </summary>
		/// <param name="message">Message to write.</param>
		public override void WriteLine(string message)
		{
			_target.Invoke(_invokeWrite, new object[]
			               { message + Environment.NewLine });
		}

		/// <summary>
		/// Sends the message to the target.
		/// </summary>
		/// <param name="message">Message to send.</param>
		private void SendString(string message)
		{
			_target.AppendText(message);
		}
		
		#endregion

	}
}
