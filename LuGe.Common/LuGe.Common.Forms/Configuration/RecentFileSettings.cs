/*
 * User: lgermain
 * Date: 14/10/2008 12:21
 */

using System;
using System.Collections.Generic;
using LuGe.Common.Collection;

namespace LuGe.Common.Forms.Configuration
{
	/// <summary>
	/// Settings of recent files.
	/// </summary>
	public class RecentFileSettings: IConfigurationFile
	{
		#region Fields
		
		private LICollection<RecentFileInfo> _recentFiles; // all recent files.
		
		#endregion
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the class. 
		/// </summary>
		public RecentFileSettings()
		{
			_recentFiles = new LICollection<RecentFileInfo>();
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets all recent files.
		/// </summary>
		public LICollection<RecentFileInfo> RecentFiles 
		{
			get { return _recentFiles; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Load the default values of all settings.
		/// </summary>
		public void LoadDefault()
		{			
		}
		
		#endregion
	}
}
