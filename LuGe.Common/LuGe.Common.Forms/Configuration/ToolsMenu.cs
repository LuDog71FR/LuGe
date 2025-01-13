/*
 * User: lgermain
 * Date: 25/08/2008 15:46
 */

using System;
using System.IO;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using LuGe.Common.Collection;

namespace LuGe.Common.Forms.Configuration
{
	/// <summary>
	/// Class that automatically creates submenus to execute and manage
	/// external tools for the application.
	/// </summary>
	public class ToolsMenu : IDisposable
	{
		#region Fields
		
		private bool _readOnly; // a value indicating if the user can manage the tools.
		private LIKeyedCollection<ToolInfo> _tools; // List of external tools.
		
		private ToolStripMenuItem _parentMenu; // Parent menu.
		private List<ToolStripItem> _toolMenus; // List submenu for external tools.
		private ToolStripMenuItem _managerSubMenu; // Submenu to show the manager tools form.
		private ToolStripSeparator _seperatorSubMenu; // Submenu that display a separator.
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		/// <param name="parentMenu">The parent menu where tool
		/// submenus must be created.</param>
		public ToolsMenu(ToolStripMenuItem parentMenu)
		{
			if (parentMenu == null) throw new ArgumentNullException("parentMenu");
			
			_readOnly = false;
			_parentMenu = parentMenu;
			_toolMenus = new List<ToolStripItem>();
			
			Refresh();
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets or sets a value indicating if the user
		/// can manage the tools.
		/// </summary>
		public bool ReadOnly
		{
			get { return _readOnly; }
			set { _readOnly = value; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Display the list of available external tools
		/// in the parent menu.
		/// </summary>
		public void Refresh()
		{
			RemoveAll();
			if (ReadOnly == false) CreateManagerMenu();
			CreateToolsMenu();
		}
		
		/// <summary>
		/// Create the manager and separator submenus.
		/// </summary>
		private void CreateManagerMenu()
		{
			_managerSubMenu = new ToolStripMenuItem();
			_managerSubMenu.Image = LIResource.GetEmbeddedImage("Resources.brick_edit.png");
			_managerSubMenu.Name = "manageToolsToolStripMenuItem";
			_managerSubMenu.Text = "Manage tools ...";
			_managerSubMenu.Click += new System.EventHandler(ManageToolsToolStripMenuItemClick);
			_parentMenu.DropDownItems.Add(_managerSubMenu);
			
			_seperatorSubMenu = new ToolStripSeparator();
			_parentMenu.DropDownItems.Add(_seperatorSubMenu);
		}
		
		/// <summary>
		/// Create a submenu for each tool.
		/// </summary>
		private void CreateToolsMenu()
		{
			ToolInfoSettings settings = LIConfiguration<ToolInfoSettings>.Load();		
			
			settings.Tools.Sort();
			_tools = new LIKeyedCollection<ToolInfo>(settings.Tools);
			
			foreach(ToolInfo tool in _tools)
			{
				if (File.Exists(tool.Command))
				{
					Icon toolIcon = Icon.ExtractAssociatedIcon(tool.Command);
					_toolMenus.Add(
						_parentMenu.DropDownItems.Add(
							tool.Title, toolIcon.ToBitmap(), ExternalTool_Click));
				}
				else
				{
					_toolMenus.Add(
						_parentMenu.DropDownItems.Add(
							tool.Title, null, ExternalTool_Click));
				}
			}
		}
		
		/// <summary>
		/// Remove all the items created for each external tool
		/// in the menu.
		/// </summary>
		public void RemoveAll()
		{
			if (_managerSubMenu != null)
			{
				_parentMenu.DropDownItems.Remove(_managerSubMenu);
				_managerSubMenu.Dispose();
				_managerSubMenu = null;
			}
			
			if (_seperatorSubMenu != null)
			{
				_parentMenu.DropDownItems.Remove(_seperatorSubMenu);
				_seperatorSubMenu.Dispose();
				_seperatorSubMenu = null;
			}
			
			foreach(ToolStripItem item in _toolMenus)
			{
				_parentMenu.DropDownItems.Remove(item);
				item.Dispose();
			}
			
			_toolMenus.Clear();
		}
		
		/// <summary>
		/// Raised when a "external tool" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ExternalTool_Click(object sender, EventArgs e)
		{
			ToolInfo tool = _tools[(sender as ToolStripItem).Text];
			tool.ExecuteTool();
		}
		
		/// <summary>
		/// Raised when the "Manage tools" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ManageToolsToolStripMenuItemClick(object sender, EventArgs e)
		{
			ManageToolsForm form = new ManageToolsForm();
			form.ShowDialog();
			
			Refresh();
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
				RemoveAll();
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
