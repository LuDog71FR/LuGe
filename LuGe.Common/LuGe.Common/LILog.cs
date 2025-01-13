/*
 * User: Ludovic Germain
 * Date: 12/07/2007
 * Time: 09:44
 */

using System;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;

namespace LuGe.Common
{
	/// <summary>
	/// <para>
	/// Provides a set of methods and properties that help debug
	/// and trace the execution of your code.
	/// </para><para>
	/// This class cannot be inherited.
	/// </para>
	/// </summary>
	/// 
	/// <remarks>
	/// The<see cref="LILog.Switch">Switch</see> property help you to dynamically
	/// control the tracing output.
	/// </remarks>
	/// 
	/// <example>
	/// The following example show how to simply debug your code :
	/// <code>
	/// LuGe.Common.LILog.Debug(TraceLevel.Info, "The message.");
	/// </code>
	/// </example>
	public sealed class LILog
	{
		#region Fields
		
		private static TraceSwitch _switch =
			new TraceSwitch("events", "Log");

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Private constructor for the LILog class, 
		/// because the type only declares static members.
		/// </summary>
		private LILog() {}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// <para>
		/// Gets or sets the switch for controlling tracing and debugging
		/// output at runtime by using the configuration file of your
		/// application.
		/// </para>
		/// </summary>
		public static TraceSwitch Switch {
			get { return _switch; }
			set { _switch = value; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Append to a message, the current date and time.
		/// </summary>
		/// <param name="message">Message to trace.</param>
		/// <returns>Return the complete message.</returns>
		private static string BuildMsg(string message) {
			StringBuilder msgb = new StringBuilder();

			msgb.Append(DateTime.Now.ToString("s", CultureInfo.InvariantCulture));
			msgb.Append(" - ");
			msgb.Append(message);

			return msgb.ToString();
		}

        /// <summary>
        /// Writes information about the debug to the trace
        /// listeners in the Listeners collection.
        /// </summary>
        /// <param name="level">Message level based on their importance.</param>
        /// <param name="messages">Array of message to trace. 
        /// Each array item is concat with each other to form one message.</param>
        public static void Debug(TraceLevel level,
                                 params string[] messages)
        {
        	if (messages == null) return;
        	
            StringBuilder message = new StringBuilder();

            foreach (string subMessage in messages) message.Append(subMessage);

            Debug(level, message.ToString());
        }

		/// <summary>
		/// Writes information about the debug to the trace
		/// listeners in the Listeners collection.
		/// </summary>
		/// <param name="level">Message level based on their importance.</param>
		/// <param name="message">Message to trace.</param>
		public static void Debug(TraceLevel level, 
		                         string message) {
			message = BuildMsg(message);

			switch (level) {
				case TraceLevel.Error:
					System.Diagnostics.Debug.WriteLineIf(_switch.TraceError, message);
					break;

				case TraceLevel.Warning:
					System.Diagnostics.Debug.WriteLineIf(_switch.TraceWarning, message);
					break;

				case TraceLevel.Info:
					System.Diagnostics.Debug.WriteLineIf(_switch.TraceInfo, message);
					break;

				case TraceLevel.Verbose:
					System.Diagnostics.Debug.WriteLineIf(_switch.TraceVerbose, message);
					break;
			}
		}

        /// <summary>
        /// Writes information about the debug to the trace
        /// listeners in the Listeners collection.
        /// </summary>
        /// <param name="level">Message level based on their importance.</param>
        /// <param name="messages">Array of message to trace. 
        /// Each array item is concat with each other to form one message.</param>
        public static void Trace(TraceLevel level,
                                 params string[] messages)
        {
        	if (messages == null) return;
        	
            StringBuilder message = new StringBuilder();

            foreach (string subMessage in messages) message.Append(subMessage);

            Trace(level, message.ToString());
        }

		/// <summary>
		/// Writes information about the debug to the trace
		/// listeners in the Listeners collection.
		/// </summary>
		/// <param name="level">Message level based on their importance.</param>
		/// <param name="message">Message to trace.</param>
		public static void Trace(TraceLevel level, 
		                         string message) {
			message = BuildMsg(message);

			switch (level) {
				case TraceLevel.Error:
					System.Diagnostics.Trace.WriteLineIf(_switch.TraceError, message);
					break;

				case TraceLevel.Warning:
					System.Diagnostics.Trace.WriteLineIf(_switch.TraceWarning, message);
					break;

				case TraceLevel.Info:
					System.Diagnostics.Trace.WriteLineIf(_switch.TraceInfo, message);
					break;

				case TraceLevel.Verbose:
					System.Diagnostics.Trace.WriteLineIf(_switch.TraceVerbose, message);
					break;
			}
		}
		
		/// <summary>
		/// Convert the array specified in a string containing all values 
		/// separated by a comma.
		/// </summary>
		/// <param name="values">Array of object to convert.</param>
		/// <returns>A string containing all values of the array specified in parameter
		/// separated by a comma.</returns>
		public static string ConvertToString<T>(IEnumerable<T> values)
		{
			StringBuilder message = new StringBuilder();
			
			foreach(T value in values)
			{
				if (message.Length > 0) message.Append(" , ");
				message.Append(value.ToString());
			}
			
			return message.ToString();
		}
		
		#endregion
	}
}
