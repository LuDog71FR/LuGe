/*
 * User: lgermain
 * Date: 08/10/2008 08:58
 */

using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace LuGe.AutoUpdateTool
{
	internal sealed class Program
	{
		
		[STAThread]
		public static void Main(string[] args)
		{
			if (args.Length < 4) return;
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			WaitForm form = new WaitForm();
			form.Show();
			
			UpdateModule updater = new UpdateModule(form);
			updater.ExeFile = args[0];
			updater.RemoteUri = args[1];
			updater.Key = args[2];
			updater.ProcessId = int.Parse(args[3]);
			
			Thread updaterThread = new Thread(updater.Start);
			updaterThread.Start();
			
			while (!updaterThread.IsAlive);
			
			do
			{
				Application.DoEvents();
				System.Threading.Thread.Sleep(100);
			} while (updaterThread.ThreadState != System.Threading.ThreadState.Stopped);
		}
		
	}
}
