using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace LuGe.Common.Forms
{
	/// <summary>
	/// Represents the splash screen of the application.
	/// </summary>
	public partial class SplashForm : Form
	{
		private delegate void ReportProgressDelegate(byte percent, string message);
		private delegate DialogResult ShowMessageDelegate(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
		
		private static ApplicationContext _context;
		
		/// <summary>
		/// The Instance of the splash form.
		/// </summary>
		public static SplashForm _instance;
		
		/// <summary>
		/// The thread used to display the splash form.
		/// </summary>
		private static Thread _splashThread;
		
		/// <summary>
		/// The delegate the report progress method.
		/// </summary>
		private ReportProgressDelegate reportDelegate;
		
		private ShowMessageDelegate showMessageDelegate;

		/// <summary>
		/// Initializes a new Instance of the <see cref="SplashForm" /> class.
		/// </summary>
		private SplashForm()
		{
			this.InitializeComponent();
			
			this.reportDelegate = new ReportProgressDelegate(this.ReportProgressReal);
			this.showMessageDelegate = new ShowMessageDelegate(this.ShowMessageBoxReal);
		}

		/// <summary>
		/// Gets the application version number.
		/// </summary>
		public static string AppVersion
		{
			get
			{
				return Assembly.GetEntryAssembly().GetName().Version.ToString(3);
			}
		}

		public static string AppTitle
		{
			get
			{
				Assembly assembly = Assembly.GetEntryAssembly();

				object[] customAttributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				return ((AssemblyTitleAttribute)customAttributes[0]).Title;
			}
		}
		
		/// <summary>
		/// Shows the splash screen.
		/// </summary>
		public static void ShowSplashScreen(ApplicationContext context)
		{
			if (_instance != null) return;
			
			_context = context;
			
			_splashThread = new Thread(new ThreadStart(SplashForm.ShowForm));
			_splashThread.IsBackground = false;
			_splashThread.SetApartmentState(ApartmentState.STA);
			_splashThread.Start();
		}
		
		/// <summary>
		/// Close the splash screen.
		/// </summary>
		public static void CloseSplashScreen()
		{
			if ((_instance == null) || (_instance.IsDisposed)) return;
			
			_instance.Invoke((MethodInvoker) delegate { _instance.Close(); });
			
			_instance = null;
			_splashThread = null;
		}
		
		/// <summary>
		/// Reports the progression of the loading.
		/// </summary>
		/// <param name="percent">The percentage value representing the progression.</param>
		/// <param name="message">The message to display.</param>
		public static void ReportProgress(byte percent, string message)
		{
			if ((_instance == null) || (_instance.IsDisposed)) return;
			
			object[] a = new object[] {percent, message};
			_instance.Invoke(_instance.reportDelegate, a);
		}
		
		private void ReportProgressReal(byte percent, string message)
		{
			_instance.progressBar1.Value = percent;
			_instance.labMessage.Text = message;
			
			Trace.WriteLine(message);
		}

		/// <summary>
		/// Display message box on top of the splash screen.
		/// </summary>
		/// <param name="text">Body of the message.</param>
		/// <param name="caption">Title of the message.</param>
		/// <param name="buttons">Buttons to display.</param>
		/// <param name="icon">Icon of the dialog box.</param>
		/// <returns>The dialog result.</returns>
		public static DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			if ((_instance == null) || (_instance.IsDisposed)) return DialogResult.None;
			
			object[] a = new object[] {text, caption, buttons, icon};
			return (DialogResult)_instance.Invoke(_instance.showMessageDelegate, a);
		}

		private DialogResult ShowMessageBoxReal(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			return MessageBox.Show(this, text, caption, buttons, icon);
		}
		
		/// <summary>
		/// Displays the form and run it.
		/// </summary>
		private static void ShowForm()
		{
			_instance = new SplashForm();
			_instance.labVersion.Text = "Version " + AppVersion;
			_instance.labAppName.Text = AppTitle;
			
			_instance.Show();
			
			Application.Run(_context);
		}
	}
}
