/*
 * User: lgermain
 * Date: 21/11/2008 14:53
 */

using System;
using LuGe.Common;

namespace LuGe.DatabaseQuery
{
	/// <summary>
	/// Settings of the application.
	/// </summary>
	public class AppSettings: IConfigurationFile
	{
		
		#region Fields
		
		private bool _useTransaction; // must use a global transaction.
		
		#endregion

		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public AppSettings()
		{
		}
		
		#endregion

		#region Properties
		
		/// <summary>
		/// Gets or sets a value indicatinfg if we must use a global transaction.
		/// </summary>
		public bool UseTransaction 
		{
			get { return _useTransaction; }
			set { _useTransaction = value; }
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Load the default values of all settings.
		/// </summary>
		public void LoadDefault()
		{
			_useTransaction = false;
		}
		
		#endregion

	}
}
