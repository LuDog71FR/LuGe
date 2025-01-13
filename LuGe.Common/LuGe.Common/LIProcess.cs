/*
 * User: Ludovic Germain
 * Date: 03/10/2007 15:39:12
 */

using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Management;

namespace LuGe.Common
{
	/// <summary>
	/// Allows starting of local system processes.
	/// </summary>
	public class LIProcess : IDisposable
	{

		#region Fields

		private Process _process;
		private string _message;
		private int _delay;
		private bool _mustWait;

		#endregion

		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the <see cref="LIProcess"/> class.
		/// </summary>
		public LIProcess()
		{
			_delay = 10000;
			_mustWait = true;

			_process = new Process();

			_process.StartInfo.CreateNoWindow = true;
			_process.StartInfo.UseShellExecute = false;
			_process.StartInfo.RedirectStandardOutput = true;
			_process.StartInfo.RedirectStandardError = true;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the output message from the process.
		/// </summary>
		/// <value>The message.</value>
		/// <remarks>If the <see cref="MustWait"/> property is set to
		/// False then the message is always empty.</remarks>
		public string Message
		{
			get { return _message; }
		}

		/// <summary>
		/// Gets or sets the amount of time, in milliseconds, to wait for
		/// the associated process to exit.
		/// </summary>
		/// <value>The delay.</value>
		/// <remarks>The delay is fixed to 10s by default.</remarks>
		public int Delay
		{
			get { return _delay; }
			set { _delay = value; }
		}

		/// <summary>
		/// Gets or sets the working directory.
		/// </summary>
		/// <value>The working directory.</value>
		public string WorkingDirectory
		{
			get { return _process.StartInfo.WorkingDirectory; }
			set { _process.StartInfo.WorkingDirectory = value; }
		}

		/// <summary>
		/// Gets or sets the file name execute.
		/// </summary>
		/// <value>The name of the file.</value>
		public string FileName
		{
			get { return _process.StartInfo.FileName; }
			set { _process.StartInfo.FileName = value; }
		}

		/// <summary>
		/// Gets or sets the arguments.
		/// </summary>
		/// <value>The arguments.</value>
		public string Arguments
		{
			get { return _process.StartInfo.Arguments; }
			set { _process.StartInfo.Arguments = value; }
		}

		/// <summary>
		/// Gets the exit code of the process.
		/// </summary>
		/// <value>The exit code.</value>
		public int ExitCode
		{
			get { return _process.ExitCode; }
		}

		/// <summary>
		/// Gets or sets a value indicating if the end of the process
		/// must be waited.
		/// </summary>
		/// <value>A boolean whose value True indicates that the
		/// <see cref="Start"/> method must wait the end of the process.</value>
		/// <remarks>The property is set to True by default.</remarks>
		public bool MustWait
		{
			get { return _mustWait; }
			set { _mustWait = value; }
		}
		
		/// <summary>
		/// Gets a value indicating if the process has exited.
		/// </summary>
		/// <value>A boolean whose value True indicates that the process
		/// has exited.</value>
		public bool HasExited
		{
			get { return _process.HasExited; }
		}
		
		#endregion

		#region Methods

		/// <summary>
		/// Builds the arguments string.
		/// </summary>
		/// <param name="arguments">The arguments.</param>
		/// <returns>Return the arguments specified concated.</returns>
		public static string BuildArgumentsString(params string[] arguments)
		{
			if (arguments == null)
			{
				throw new ArgumentNullException("arguments");
			}

			StringBuilder chaineArg = new StringBuilder();

			foreach (string arg in arguments)
			{
				chaineArg.Append("\"");
				chaineArg.Append(arg);
				chaineArg.Append("\"");
				chaineArg.Append(" ");
			}

			return chaineArg.ToString();
		}

		/// <summary>
		/// <para>Start the process and wait the end of it.</para>
		/// </summary>
		/// <remarks>
		/// <para>You must specified a file to execute before calling this method.
		/// If you don't no error is raised.</para>
		/// 
		/// <para>The method blocks the current thread execution until
		/// the process end or until the <see cref="Delay"/> has elapsed.
		/// </para>
		/// </remarks>
		public void Start()
		{
			if (string.IsNullOrEmpty(FileName)) return;

			_message = string.Empty;

			_process.Start();
			
			if (_mustWait == false) return;
			
			_message = _process.StandardOutput.ReadToEnd();
			_message += _process.StandardError.ReadToEnd();
			_process.WaitForExit(_delay);
		}

		/// <summary>
		/// Stop the process immediately and wait the end of it.
		/// </summary>
		/// <remarks>
		/// The method blocks the current thread execution until
		/// the process end or until the <see cref="Delay"/> has elapsed.
		/// </remarks>
		public void Stop()
		{
			if (_process.HasExited) return;
			
			_process.Kill();
			_process.WaitForExit(_delay);
		}
		
		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources;
		/// <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose managed resources
				if (_process != null) _process.Dispose();
			}

			// free native resources
		}

		/// <summary>
		/// Releases unmanaged and managed resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Kill a process by name.
		/// </summary>
		/// <remarks>
		/// The function is not case sensitive.
		/// </remarks>
		/// <param name="name">The process name.</param>
		/// <returns>True if the process is find; otherwise false.</returns>
		public static bool KillProcess(string name)
		{
			foreach (Process process in Process.GetProcesses())
			{
				if (process.ProcessName.StartsWith(name, true, CultureInfo.InvariantCulture))
				{
					process.Kill();
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// Kill ther service specified.
		/// </summary>
		/// <param name="serviceName">The name of the service to kill.</param>
		public static void KillService(string serviceName) 
		{
			string query = string.Format("SELECT ProcessId FROM Win32_Service WHERE Name='{0}'", serviceName);
			
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
			
			foreach (ManagementObject obj in searcher.Get()) 
			{
				uint processId = (uint) obj["ProcessId"];
				Process process = null;
				try
				{
					process = Process.GetProcessById((int)processId);
				}
				catch (ArgumentException)
				{
					// Thrown if the process specified by processId
					// is no longer running.
				}
				try
				{
					if (process != null) process.Kill();
				}
				catch (Win32Exception)
				{
					// Thrown if process is already terminating,
					// the process is a Win16 exe or the process
					// could not be terminated.
				}
				catch (InvalidOperationException)
				{
					// Thrown if the process has already terminated.
				}
			}
		}
	
	#endregion
	}
}
