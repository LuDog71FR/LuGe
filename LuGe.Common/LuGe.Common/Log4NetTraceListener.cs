using System;
using System.Diagnostics;
using log4net;

namespace LuGe.Common
{
	/// <summary>
	/// Custom Trace Listener for Log4Net.
	/// </summary>
	public class Log4NetTraceListener : TraceListener
	{
		readonly ILog _log;
		
		/// <summary>
		/// 
		/// </summary>
		public Log4NetTraceListener()
		{
			_log = LogManager.GetLogger("TraceLogger");
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="log"></param>
		public Log4NetTraceListener(log4net.ILog log)
		{
			_log = log;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventCache"></param>
		/// <param name="source"></param>
		/// <param name="eventType"></param>
		/// <param name="id"></param>
		/// <param name="message"></param>
		public override void TraceEvent(TraceEventCache eventCache,
		                                string source,
		                                TraceEventType eventType,
		                                int id,
		                                string message)
		{
			if (_log == null) return;
			
			switch (eventType)
			{
				case TraceEventType.Critical:
					_log.Fatal(message);
					break;
					
				case TraceEventType.Error:
					_log.Error(message);
					break;
					
				case TraceEventType.Warning:
					_log.Warn(message);
					break;
					
				case TraceEventType.Information:
					_log.Info(message);
					break;

				default:
					_log.Debug(message);
					break;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public override void Write(string message)
		{
			if (_log == null) return;
			
			_log.Debug(message);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public override void WriteLine(string message)
		{
			if (_log == null) return;
			
			_log.Debug(message);
		}
	}
}
