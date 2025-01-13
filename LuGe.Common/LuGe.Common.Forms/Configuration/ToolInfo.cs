/*
 * User: lgermain
 * Date: 08/08/2008 14:49
 */

using System;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;
using LuGe.Common;
using LuGe.Common.Collection;

namespace LuGe.Common.Forms.Configuration
{
	/// <summary>
	/// Settings for a tool information.
	/// </summary>
	public class ToolInfo : IKeyedItem, IComparable<ToolInfo>
	{
		#region Fields
		
		private int _position;  // Position of the tool in the list.
		private string _title; // the title of the tool.
		private string _command; // the command to execute the tool.
		private string _arguments; // the arguments to use when executing the tool.
		private string _workingDirectory;  // the working directory to use when executing the tool.
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public ToolInfo()
		{
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the unique key to identified this item 
		/// in a keyed collection.
		/// </summary>
		public string Key 
		{
			get { return Title; }
		}
		
		/// <summary>
		/// Gets or sets the title of the tool.
		/// </summary>
		public int Position 
		{
			get { return _position; }
			set { _position = value; }
		}

		/// <summary>
		/// Gets or sets the title of the tool.
		/// </summary>
		public string Title 
		{
			get { return _title; }
			set { _title = value; }
		}
		
		/// <summary>
		/// Gets or sets the command to execute the tool.
		/// </summary>
		public string Command 
		{
			get { return _command; }
			set	{ _command = value; }
		}
		
		/// <summary>
		/// Gets or sets the arguments to use when executing the tool.
		/// </summary>
		public string Arguments 
		{
			get { return _arguments; }
			set { _arguments = value; }
		}
		
		/// <summary>
		/// Gets or sets the working directory to use when executing the tool.
		/// </summary>
		public string WorkingDirectory 
		{
			get { return _workingDirectory; }
			set { _workingDirectory = value; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Execute the tool.
		/// </summary>
		public void ExecuteTool()
		{
			Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
			if (File.Exists(this.Command) == false) return;
			
			LIProcess process = new LIProcess();
			
			process.FileName = this.Command;
			process.Arguments = this.Arguments;
			process.WorkingDirectory = this.WorkingDirectory;
			process.MustWait = false;
			
			process.Start();
		}
		
		/// <summary>
		/// Return the title of the tool.
		/// </summary>
		/// <returns>The title of the tool.</returns>
		public override string ToString()
		{
			return this.Title;
		}
		
		/// <summary>
		/// Compares the current instance with another object 
		/// of the same type and returns an integer that indicates 
		/// whether the current instance precedes, follows, 
		/// or occurs in the same position in the sort order 
		/// as the other object. 
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// <para>
		/// A 32-bit signed integer that indicates the relative order 
		/// of the objects being compared. The return value has these meanings :
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item><term>Less than zero</term>
		/// <description>this instance is less than obj</description></item>
		/// 
		/// <item><term>Zero</term>
		/// <description>this instance is equal to obj</description></item>
		/// 
		/// <item><term>Greater than zero</term>
		/// <description>this instance is greater than obj</description></item>
		/// </list>
		/// </para>
		/// </returns>
		public int CompareTo(ToolInfo obj)
		{
			if (obj == null) throw new ArgumentNullException("obj");
			
			return this.Position.CompareTo(obj.Position);
		}
		
		#endregion
		
	}
}
