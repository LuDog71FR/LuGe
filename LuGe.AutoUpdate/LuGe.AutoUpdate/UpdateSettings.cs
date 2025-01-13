/*
 * User: lgermain
 * Date: 21/11/2008 13:10
 */

using System;
using LuGe.Common;

namespace LuGe.AutoUpdate
{
	/// <summary>
	/// Settings of the update module.
	/// </summary>
	public class UpdateSettings: IConfigurationFile
	{
		private bool _enable; // is auto-update enable.
		private bool _askBefore; // ask before updating.
		private string _url; // URL where the update are stored.
		private bool _displayChangeLog; // display the change log file after an update.
		
		/// <summary>
		/// Creates a new instance of the class.
		/// </summary>
		public UpdateSettings()
		{
		}
		
		/// <summary>
		/// Gets or sets a value indicating if the auto-update is enable.
		/// </summary>
		public bool Enable 
		{
			get { return _enable; }
			set { _enable = value; }
		}
		
		/// <summary>
		/// Gets or sets a value indicating if the updater must ask before updating.
		/// </summary>
		public bool AskBefore 
		{
			get { return _askBefore; }
			set { _askBefore = value; }
		}

		/// <summary>
		/// Gets or sets the URL where the update are stored.
		/// </summary>
		public string Url 
		{
			get { return _url; }
			set { _url = value; }
		}
		
		/// <summary>
		/// Gets or sets a value indicating if the change log file must
		/// be displayed after an update.
		/// </summary>
		public bool DisplayChangeLog 
		{
			get { return _displayChangeLog; }
			set { _displayChangeLog = value; }
		}
		
		/// <summary>
		/// Load the default values of all settings.
		/// </summary>
		public void LoadDefault()
		{
			_enable = true;
			_askBefore = true;
			_url = "http://80.64.231.120/updates/";
			_displayChangeLog = true;
		}
	}
}
