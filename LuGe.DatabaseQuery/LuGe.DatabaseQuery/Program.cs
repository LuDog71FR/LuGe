/*
 * User: lgermain
 * Date: 25/06/2008 10:10
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using LuGe.AutoUpdate;
using LuGe.Common.Forms;

namespace LuGe.DatabaseQuery
{	
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		private static MainForm _mainForm;
		private static FileStream FileLog;
	
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			InitLogging();
			SplashForm.ShowSplashScreen();
			
			if (AutoUpdater.Update(args)) return;
			Program._mainForm = new MainForm();
			
			SplashForm.CloseSplashScreen();
			
			Application.Run(_mainForm);
			EndLogging();
		}
		
		public static void InitLogging()
		{
			FileLog = new FileStream( 
				"\\trace_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".log",
				FileMode.OpenOrCreate);
			Trace.Listeners.Add(new TextWriterTraceListener(FileLog));
			Trace.AutoFlush = true;
			
			Trace.WriteLine("Begin !");
			Trace.WriteLine(string.Empty);
		}
		
		public static void EndLogging()
		{
			Trace.WriteLine(string.Empty);
			Trace.WriteLine("The End !");
			
			Trace.Flush();
			FileLog.Close();
		}	
	}
}
