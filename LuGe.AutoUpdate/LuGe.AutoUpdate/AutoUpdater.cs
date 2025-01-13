/*
 * User: lgermain
 * Date: 08/10/2008 08:59
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using LuGe.Common;
using LuGe.Common.Forms;

namespace LuGe.AutoUpdate
{
	/// <summary>
	/// Allow auto update of an application.
	/// </summary>
	public class AutoUpdater
	{
		private const string UNIQUE_KEY = "&**#@!"; // Any unique sequence of characters.
		private const string UPDATEINFO_FILENAME = "update.dat"; // The file with the update information.
		private const string AUTOUPDATE_PROG = "LuGe.AutoUpdateTool.exe"; // File name of the auto update program.
		
		private string _fullRemoteUri; // Full remote path where updates are stored.
		private List<string> _args; // Arguments passed to the application.
		private int _processId; // Id of the process use by the application.
		private LIWebClient _webClient; // Web client used to access the remote server.
		private bool _mustEndApplication; // value indicating if the application is updated and must be stopped.
		private UpdateSettings _settings; // update settings.

		/// <summary>
		/// Creates a new instance of the class.
		/// </summary>
		/// <param name="args">Arguments passed to the application.</param>
		/// <param name="processId">Id of the process use by the application.</param>
		public AutoUpdater(string[] args, int processId)
		{
			if (args == null) throw new NullReferenceException("args");
			
			_args = new List<string>(args);
			_processId = processId;
			
			_settings = new UpdateSettings();
			UpdateRemoteUri();
			
			_webClient = new LIWebClient();
		}
		
		/// <summary>
		/// Gets or sets the update settings.
		/// </summary>
		public UpdateSettings Settings
		{
			get { return _settings; }
			set
			{
				_settings = value;
				UpdateRemoteUri();
			}
		}

		/// <summary>
		/// Gets or sets the remote path where updates are stored.
		/// </summary>
		public string RemotePath
		{
			get { return _settings.Url; }
			set
			{
				if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("value");
				
				_settings.Url = value;
				UpdateRemoteUri();
			}
		}

		/// <summary>
		/// Gets a value indicating if the application is updated and must be stopped.
		/// </summary>
		public bool MustEndApplication
		{
			get { return _mustEndApplication; }
		}
		
		/// <summary>
		/// Update the application.
		/// </summary>
		/// <param name="args">Arguments passed to the application.</param>
		/// <returns>True if the application must be stopped; otherwise False.</returns>
		public static bool Update(string[] args)
		{
			UpdateSettings settings = LIConfiguration<UpdateSettings>.Load();
			
			if (settings.Enable == false) return false;
			
			SplashForm.ReportProgress(1, "Checking for updates ...");
			
			AutoUpdater updater = new AutoUpdater(args, Process.GetCurrentProcess().Id);
			updater.Settings = settings;
			
			Thread updaterThread = new Thread(updater.Update);
			updaterThread.Start();
			
			Trace.WriteLine("Waiting end of update ...");
			while (updaterThread.ThreadState != System.Threading.ThreadState.Stopped)
			{
				Application.DoEvents();
				System.Threading.Thread.Sleep(10);
			};
			
			Trace.WriteLine("Checking for updates end (" + updater.MustEndApplication.ToString() + ")");
			if (updater.MustEndApplication) return true;
			
			return false;
		}
		
		/// <summary>
		/// Test if the computer is connected to the update server.
		/// </summary>
		/// <returns>True if connected; otherwise false.</returns>
		private bool IsConnected()
		{
			SplashForm.ReportProgress(5, "Testing computer connection ...");
			
			if (string.IsNullOrEmpty(RemotePath)) return false;
			
			TcpClient server;
			
			try
			{
				Uri url = new Uri(RemotePath);
				Trace.WriteLine("AutoUpdate server : " + url.Host + ":" + url.Port);
				server = new TcpClient(url.Host, url.Port);
			} 
			catch (SocketException)
			{
				Console.WriteLine("Unable to connect to server");
				return false;
			}			
			
			return server.Connected;
		}
		
		/// <summary>
		/// Set the full remote URI to use.
		/// </summary>
		private void UpdateRemoteUri()
		{
			string AssemblyName =
				Assembly.GetEntryAssembly().GetName().Name;
			_fullRemoteUri = RemotePath + AssemblyName + "/";
		}
		
		/// <summary>
		/// Download the information file about the update from
		/// the remote URI.
		/// </summary>
		/// <returns>The informations about the update.
		/// Returns String.Empty if an error occured.</returns>
		private string DownloadInfoFile()
		{
			SplashForm.ReportProgress(10, "Downloading update informations ...");
			
			string contents;
			
			try
			{
				string localFileName = Path.Combine(
					Application.StartupPath,
					UPDATEINFO_FILENAME);
				
				Trace.WriteLine("AutoUpdate Info File : " + _fullRemoteUri + UPDATEINFO_FILENAME);
				
				_webClient.DownloadFile(
					_fullRemoteUri + UPDATEINFO_FILENAME,
					localFileName);
				
				if (_webClient.IsError) return string.Empty;
				
				contents = File.ReadAllText(localFileName);
				File.Delete(localFileName);
			}
			catch (Exception)
			{
				contents = string.Empty;
			}
			
			return contents;
		}
		
		/// <summary>
		/// Download the auto update program to keep it up to date.
		/// </summary>
		/// <returns>True if download is ok; otherwise False.</returns>
		private bool DownloadAutoUpdateProg()
		{
			SplashForm.ReportProgress(15, "Downloading auto-update program ...");
			
			try
			{
				System.IO.File.Delete(Path.Combine(Application.StartupPath,
				                                   AUTOUPDATE_PROG));
				System.IO.File.Delete(Path.Combine(Application.StartupPath,
				                                   "Interop.Shell32.dll"));
				
				Trace.WriteLine("AutoUpdate Program : " + RemotePath + AUTOUPDATE_PROG);
				
				_webClient.DownloadFile(
					RemotePath + AUTOUPDATE_PROG,
					Path.Combine(Application.StartupPath, AUTOUPDATE_PROG));
				_webClient.DownloadFile(
					RemotePath + "Interop.Shell32.dll",
					Path.Combine(Application.StartupPath, "Interop.Shell32.dll"));
				
				if (_webClient.IsError) return false;
			}
			catch (Exception)
			{
				return false;
			}
			
			return true;
		}
		
		/// <summary>
		/// Start the update by launching the auto update program.
		/// </summary>
		private void StartUpdate()
		{
			SplashForm.CloseSplashScreen();
			
			List<string> args = new List<string>();
			args.Add(Application.ExecutablePath);
			args.Add(_fullRemoteUri);
			args.Add(UNIQUE_KEY);
			args.Add(_processId.ToString());
			
			LIProcess process = new LIProcess();
			process.FileName = Path.Combine(Application.StartupPath, AUTOUPDATE_PROG);
			process.Arguments = LIProcess.BuildArgumentsString(args.ToArray());
			process.MustWait = false;
			process.Start();
		}
		
		/// <summary>
		/// Update the application.
		/// </summary>
		public void Update()
		{
			if (_args.Contains(UNIQUE_KEY))
			{
				Trace.WriteLine("Update made. Launch application.");
				_mustEndApplication = false;
				return;
			}
			
			if (IsConnected() == false)
			{
				Trace.WriteLine("Warning - Not connected to update server.");
				_mustEndApplication = false;
				return;
			}
			
			string info = DownloadInfoFile();
			if (string.IsNullOrEmpty(info))
			{
				Trace.WriteLine("Warning - Not info file.");
				_mustEndApplication = false;
				return;
			}
			
			Version oldVersion = new Version(Application.ProductVersion);
			Version newVersion = new Version(info);
			if (newVersion <= oldVersion)
			{
				Trace.WriteLine("No new version to update.");
				_mustEndApplication = false;
				return;
			}
			
			if (_settings.AskBefore)
			{
				DialogResult result = SplashForm.ShowMessageBox(
					"A new update is avaible for the application.\r\n\r\n" +
					"Your version : " + oldVersion.ToString() + "\r\n" +
					"New version : " + newVersion.ToString() + "\r\n\r\n" +
					"Do you wants to update the application ?",
					"Update application",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				
				_mustEndApplication = false;
				if (result == DialogResult.No) return;
			}
			
			if (DownloadAutoUpdateProg() == false)
			{
				Trace.WriteLine("Warning - Download auto-update program failed.");
				_mustEndApplication = false;
				return;
			}
			
			StartUpdate();
			_mustEndApplication = true;
			
			return;
		}
	}
}
