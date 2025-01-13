/*
 * User: lgermain
 * Date: 14/10/2008 12:24
 */

using System;
using LuGe.Common.Collection;

namespace LuGe.Common.Forms.Configuration
{
	/// <summary>
	/// Class that hold informations about the recent files used by the application.
	/// </summary>
	public class RecentFileInfo : IKeyedItem
	{
		#region Fields
		
		private string _fileName;  // name of the file.
		private string _pluginName;  // Name of the plugin to use to open the file.
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public RecentFileInfo()
		{
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the unique key to identified this item 
		/// in a keyed collection.
		/// </summary>
		public string Key {
			get { return FileName; }
		}
		
		/// <summary>
		/// Gets or sets the name of the file.
		/// </summary>
		public string FileName 
		{
			get { return _fileName; }
			set { _fileName = value; }
		}

		/// <summary>
		/// Gets or sets the name of the plugin to use to open the file.
		/// </summary>
		public string PluginName 
		{
			get { return _pluginName; }
			set { _pluginName = value; }
		}
		
		#endregion
		
		#region Methods

		/// <summary>
		/// Return the name of the file.
		/// </summary>
		/// <returns>The name of the file.</returns>
		public override string ToString()
		{
			return this.FileName;
		}
		
		#endregion
		
	}
}
