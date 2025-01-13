/*
 * User: lgermain
 * Date: 14/10/2008 14:13
 */

using System;

namespace LuGe.Common.Forms.Configuration
{
	/// <summary>
	/// This class contains event data to identify a file and the plugin to open it.
	/// </summary>
	public class RecentFileEventArgs : EventArgs
	{
		
		#region Fields
		
		private RecentFileInfo _element; // file element.
		
		#endregion

		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of 
		/// <see cref="RecentFileEventArgs">RecentFileEventArgs</see> class.
		/// </summary>
		/// <param name="element">File element.</param>
		public RecentFileEventArgs(RecentFileInfo element)
		{
			_element = element;
		}
		
		#endregion

		#region Properties
		
		/// <summary>
		/// Gets the file element.
		/// </summary>
		public RecentFileInfo Element 
		{
			get { return _element; }
		}

		#endregion

		#region Methods
		
		#endregion

	}
}
