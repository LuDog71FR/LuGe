/*
 * User: lgermain
 * Date: 09/10/2008 15:48
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace LuGe.AutoUpdateTool
{
	/// <summary>
	/// Update an application.
	/// </summary>
	public class UpdateModule
	{
		private int _processId; // ID of the process use by the application.
		private string _exeFile; // program that called the auto update.
		private string _remoteUri; // web location of the files.
		private string _key; // key used by the program when called back
		// to know that the program was launched by the Auto Update program
		
		private FileStream _fileLog; // Log file of the program.
		private WaitForm _form; // Waiting form.
		
		/// <summary>
		/// Creates a new instance of the class.
		/// </summary>
		/// <param name="form">Waiting form used to display the progression.</param>
		public UpdateModule(WaitForm form)
		{
			_form = form;
		}
		
		/// <summary>
		/// Gets or sets the ID of the process use by the application.
		/// </summary>
		public int ProcessId
		{
			get { return _processId; }
			set { _processId = value; }
		}
		
		/// <summary>
		/// Gets or sets the program that called the auto update.
		/// </summary>
		public string ExeFile
		{
			get { return _exeFile; }
			set { _exeFile = value; }
		}
		
		/// <summary>
		/// Gets or sets the web location of the files.
		/// </summary>
		public string RemoteUri
		{
			get { return _remoteUri; }
			set { _remoteUri = value; }
		}
		
		/// <summary>
		/// Gets or sets the key used by the program when called back to
		/// know that the program was launched by the Auto Update program.
		/// </summary>
		public string Key {
			get { return _key; }
			set { _key = value; }
		}
		
		/// <summary>
		/// Test if the computer is connected to the update server.
		/// </summary>
		/// <returns>True if connected; otherwise false.</returns>
		private bool IsConnected()
		{
			Trace.WriteLine(string.Empty);
			TraceDateTime();
			Trace.WriteLine("Test connection with the remote server ...");
			Trace.WriteLine("Remote server : " + new Uri(_remoteUri).Host);
			
			_form.Message = "Connecting to the remote server ...";
			_form.Value += 1;
			
			if (string.IsNullOrEmpty(_remoteUri))
			{
				Trace.WriteLine("The remote server argument is empty or null !");
				return false;
			}
			
			TcpClient server;
			
			try
			{
				Uri url = new Uri(_remoteUri);
				Trace.WriteLine("AutoUpdate server : " + url.Host + ":" + url.Port);
				server = new TcpClient(url.Host, url.Port);
			} 
			catch (SocketException)
			{
				Console.WriteLine("Unable to connect to server");
				return false;
			}			
			
			Trace.WriteLine("Connection Status : " + server.Connected.ToString());
			return server.Connected;
		}
		
		/// <summary>
		/// Trace date and time in the log file.
		/// </summary>
		private void TraceDateTime()
		{
			Trace.WriteLine(DateTime.Now.ToString());
		}
		
		/// <summary>
		/// Download the file specified.
		/// </summary>
		/// <param name="address">URI of the file.</param>
		/// <param name="fileName">Local file name.</param>
		/// <returns></returns>
		private bool DownloadFile(string address, string fileName)
		{
			DateTime beginDate = DateTime.Now;
			
			WebClient myWebClient = new WebClient();
			myWebClient.DownloadFileAsync(new Uri(address), fileName);
			
			while (myWebClient.IsBusy)
			{
				if (DateTime.Compare(DateTime.Now, beginDate.AddSeconds(60)) > 0)
				{
					Trace.WriteLine("Waiting too long !");
					return false;
				}
				
				_form.Value += 1;
				System.Threading.Thread.Sleep(200);
			}
			
			return true;
		}
		
		/// <summary>
		/// Download the zip file containing the update.
		/// </summary>
		private void DownloadUpdateFile()
		{
			Trace.WriteLine(string.Empty);
			TraceDateTime();
			Trace.WriteLine("Download the zip file containing the update ...");

			string fileName = Path.GetFileNameWithoutExtension(_exeFile) + ".zip";
			string applicationPath = Path.GetDirectoryName(_exeFile);
			string fullLocalName = Path.Combine(applicationPath, fileName);
			
			Trace.WriteLine("Source zip file :" + _remoteUri + fileName);
			Trace.WriteLine("Destination zip file :" + fullLocalName);
			
			_form.Message = "Download zip file ...";
			_form.Value += 1;
			
			Trace.WriteLine("Download zip file ...");
			
			if (DownloadFile(_remoteUri + fileName, fullLocalName) == false)
			{
				Trace.WriteLine("Can't download the zip file !");
				_form.Message = "Cancel update ...";
				return;
			}
			
			Trace.WriteLine("Unzip the update ...");
			ArchiveManager.UnArchive(fullLocalName, applicationPath);
			
			_form.Message = "Delete zip file ...";
			_form.Value += 1;
			
			Trace.WriteLine("Delete zip file ...");
			File.Delete(fullLocalName);
		}
		
		/// <summary>
		/// Launch the updated application.
		/// </summary>
		private void LaunchUpdatedApplication()
		{
			Trace.WriteLine(string.Empty);
			TraceDateTime();
			Trace.WriteLine("Launch the updated application ...");
			
			_form.Message = "Launch the updated application ...";
			_form.Value += 1;
			
			Process.Start(_exeFile, "\"" + _key + "\"");
		}
		
		/// <summary>
		/// Wait the application to exit.
		/// </summary>
		private void WaitApplicationExit()
		{
			Trace.WriteLine(string.Empty);
			TraceDateTime();
			Trace.WriteLine("Wait end of process ...");

			_form.Message = "Wait end of process ...";
			_form.Value += 1;
			
			try
			{
				Process process = Process.GetProcessById(_processId);
				if (process != null)
				{
					Trace.WriteLine("Process not terminate. Waiting ...");
					process.WaitForExit(10000);
				}
			}
			catch (Exception)
			{
			}
		}
		
		/// <summary>
		/// Initialize the logging on a log file.
		/// </summary>
		private void InitLogging()
		{
			_fileLog = new FileStream(
				"autoupdate" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".log",
				FileMode.OpenOrCreate);
			Trace.Listeners.Add(new TextWriterTraceListener(_fileLog));
			Trace.AutoFlush = true;
		}
		
		/// <summary>
		/// Ends the logging.
		/// </summary>
		private void EndLogging()
		{
			Trace.WriteLine(string.Empty);
			Trace.WriteLine("Auto update end !");
			TraceDateTime();
			
			_form.Message = "Auto update end !";
			_form.Value += 1;
			
			Trace.Flush();
			_fileLog.Close();
		}
		
		/// <summary>
		/// Main function of the program.
		/// </summary>
		public void Start()
		{
			InitLogging();
			
			TraceDateTime();
			Trace.WriteLine("Auto update begin !");
			Trace.WriteLine(string.Empty);
			
			_form.Message = "Auto update begin !";
			_form.Value += 1;
			
			Trace.WriteLine("Program version : " + Application.ProductVersion);
			
			Trace.WriteLine(string.Empty);
			Trace.WriteLine("Arguments passed to the program : ");	
			Trace.WriteLine("  - Exe file = " + _exeFile);	
			Trace.WriteLine("  - Remote URI = " + _remoteUri);	
			Trace.WriteLine("  - Key = " + _key);	
			Trace.WriteLine("  - Process ID = " + _processId);			
			
			try
			{
				WaitApplicationExit();
				
				if (IsConnected()) DownloadUpdateFile();
				
				LaunchUpdatedApplication();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.ToString());
				MessageBox.Show("There was a problem runing the auto update program !\r\n" +
				                "Please contact your administrator " +
				                "and give him the informations above :\r\n\r\n" +
				                ex.ToString(),
				                "Auto Update Error",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
				
				LaunchUpdatedApplication();
			}
			finally
			{
				EndLogging();
			}
		}
	}
}
