/*
 * User: lgermain
 * Date: 21/11/2008 15:13
 */

using System;
using System.Collections.Generic;
using LuGe.Common.Collection;

namespace LuGe.Common.Forms.Configuration
{
	/// <summary>
	/// Settings of all information tools.
	/// </summary>
	public class ToolInfoSettings: IConfigurationFile
	{
		
		#region Fields
		
		private LICollection<ToolInfo> _tools; // all tools.
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public ToolInfoSettings()
		{
			_tools = new LICollection<ToolInfo>();
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets all tools.
		/// </summary>
		public LICollection<ToolInfo> Tools 
		{
			get { return _tools; }
		}

		#endregion

		#region Methods
		
		/// <summary>
		/// Load the default values of all settings.
		/// </summary>
		public void LoadDefault()
		{
			ToolInfo tool = new ToolInfo();
			tool.Position = 1;
			tool.Title = "WordPad";
			tool.Command = "C:\\Program Files\\Windows NT\\Accessoires\\wordpad.exe";
			_tools.Add(tool);
			
			tool = new ToolInfo();
			tool.Position = 2;
			tool.Title = "Calculator";
			tool.Command = "c:\\windows\\system32\\calc.exe";
			_tools.Add(tool);
		}
		
		#endregion

	}
}
