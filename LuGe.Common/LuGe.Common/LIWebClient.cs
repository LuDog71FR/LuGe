/*
 * User: lgermain
 * Date: 13/10/2008 10:15
 */

using System;
using System.Net;

namespace LuGe.Common
{
	/// <summary>
	/// Asynchronous web client with delay.
	/// </summary>
	public class LIWebClient : IDisposable
	{
		
		#region Fields
		
		private WebClient _webClient; // internal web client.
		private int _delay; // amount of time, in seconds, to wait for the web request to end.
		private bool _isError; // value indicating if an error occured during the last request.
		
		#endregion

		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the <see cref="LIWebClient"/> class.
		/// </summary>
		public LIWebClient()
		{
			_delay = 10;
			
			_webClient = new WebClient();
		}
		
		#endregion

		#region Properties
		
		/// <summary>
		/// Gets or sets the amount of time, in seconds, to wait for
		/// the web request to end.
		/// </summary>
		/// <remarks>Default to 10 seconds.</remarks>
		public int Delay
		{
			get { return _delay; }
			set { _delay = value; }
		}
		
		/// <summary>
		/// Gets a value indicating if an error occured during the last request.
		/// </summary>
		public bool IsError
		{
			get { return _isError; }
		}

		#endregion

		#region Methods
		
		/// <summary>
		/// Download the file specified.
		/// </summary>
		/// <param name="address">URI of the file.</param>
		/// <param name="fileName">Local file name.</param>
		/// <returns>True if the file is download; otherwise False.</returns>
		public void DownloadFile(string address, string fileName)
		{
			_isError = true;
			
			DateTime beginDate = DateTime.Now;
			
			WebClient myWebClient = new WebClient();
			myWebClient.DownloadFileAsync(new Uri(address), fileName);
			
			while (myWebClient.IsBusy)
			{
				if (DateTime.Compare(DateTime.Now, beginDate.AddSeconds(_delay)) > 0)
				{
					myWebClient.CancelAsync();
					return;
				}
				
				System.Threading.Thread.Sleep(200);
			}
			
			_isError = false;
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
				if (_webClient != null) _webClient.Dispose();
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
		
		#endregion

	}
}
