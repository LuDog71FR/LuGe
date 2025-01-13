/*
 * User: lgermain
 * Date: 14/10/2008 10:56
 */

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using LuGe.Common.Collection;

namespace LuGe.Common.Forms.Configuration
{
	/// <summary>
	/// Manage recent files list to display in main menu.
	/// </summary>
	/// <remarks>
	/// <para>The menu is composed of several submenus listed below :</para>
	/// <para>
	/// <list type="bullet">
	/// <item><description>A submenu to clear all recent files</description></item>
	/// <item><description>A separator</description></item>
	/// <item><description>A submenu for each recent file</description></item>
	/// </list>
	/// </para>
	/// </remarks>
	public class RecentFilesMenu : IDisposable
	{
		
		#region Events
		
		/// <summary>
		/// Event raised when an recent file must be opened.
		/// </summary>
		public event EventHandler<RecentFileEventArgs> FileMustBeOpened;
		
		#endregion
		
		#region Fields
		
		private ToolStripMenuItem _parentMenu; // Parent menu.
		private List<ToolStripItem> _recentFilesMenus; // List submenu for recent files.
		private ToolStripMenuItem _clearListSubMenu; // Submenu to clear the list.
		private ToolStripSeparator _seperatorSubMenu; // Submenu that display a separator.
		
		private LIKeyedCollection<RecentFileInfo> _recentFiles; // list of recent files.
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		/// <param name="parentMenu">The parent menu where recent files
		/// submenus must be created.</param>
		public RecentFilesMenu(ToolStripMenuItem parentMenu)
		{
			if (parentMenu == null) throw new ArgumentNullException("parentMenu");
			
			_parentMenu = parentMenu;
			_recentFilesMenus = new List<ToolStripItem>();
			
			Refresh();
		}
		
		#endregion

		#region Properties

		#endregion

		#region Methods
		
		/// <summary>
		/// Display the list of available external tools
		/// in the parent menu.
		/// </summary>
		public void Refresh()
		{
			RemoveAll();
			CreateClearListMenu();
			CreateRecentFilesMenu();
		}
		
		/// <summary>
		/// Create the manager and separator submenus.
		/// </summary>
		private void CreateClearListMenu()
		{
			_clearListSubMenu = new ToolStripMenuItem();
			_clearListSubMenu.Image = LIResource.GetEmbeddedImage("Resources.application_lightning.png");
			_clearListSubMenu.Name = "clearRecentFilesListToolStripMenuItem";
			_clearListSubMenu.Text = "Clear recent files list";
			_clearListSubMenu.Click += new System.EventHandler(ClearList_Click);
			_parentMenu.DropDownItems.Add(_clearListSubMenu);
			
			_seperatorSubMenu = new ToolStripSeparator();
			_parentMenu.DropDownItems.Add(_seperatorSubMenu);
		}
		
		/// <summary>
		/// Remove all the items created for each recent file
		/// in the menu.
		/// </summary>
		public void RemoveAll()
		{
			if (_clearListSubMenu != null)
			{
				_parentMenu.DropDownItems.Remove(_clearListSubMenu);
				_clearListSubMenu.Dispose();
				_clearListSubMenu = null;
			}
			
			if (_seperatorSubMenu != null)
			{
				_parentMenu.DropDownItems.Remove(_seperatorSubMenu);
				_seperatorSubMenu.Dispose();
				_seperatorSubMenu = null;
			}
			
			foreach(ToolStripItem item in _recentFilesMenus)
			{
				_parentMenu.DropDownItems.Remove(item);
				item.Dispose();
			}
			
			_recentFilesMenus.Clear();
		}
		
		/// <summary>
		/// Add a recent file to the list and save it to the configuration file.
		/// </summary>
		/// <param name="element">File to add.</param>
		public void AddRecentFile(RecentFileInfo element)
		{
			if (_recentFiles.Contains(element.FileName))
			{
				_recentFiles.Remove(element.FileName);
				_recentFiles.Insert(0, element);
			}
			else
			{
				if (_recentFiles.Count >= 5) _recentFiles.RemoveAt(_recentFiles.Count - 1);
				_recentFiles.Insert(0, element);
			}
			
			SaveList();
			Refresh();
		}
		
		/// <summary>
		/// Save the list to the configuration files.
		/// </summary>
		private void SaveList()
		{
			RecentFileSettings settings = new RecentFileSettings();
			
			settings.RecentFiles.Clear();
			foreach(RecentFileInfo element in _recentFiles)
			{
				settings.RecentFiles.Add(element);
			}
			
			LIConfiguration<RecentFileSettings>.Save(settings);			
		}
		
		/// <summary>
		/// Create a submenu for each recent file.
		/// </summary>
		private void CreateRecentFilesMenu()
		{
			RecentFileSettings settings = LIConfiguration<RecentFileSettings>.Load();
			_recentFiles = new LIKeyedCollection<RecentFileInfo>(settings.RecentFiles);
			
			int fileNum = 1;
			
			foreach(RecentFileInfo element in _recentFiles)
			{
				_recentFilesMenus.Add(
					_parentMenu.DropDownItems.Add(
						fileNum.ToString() + " " + element.FileName, null, RecentFile_Click));
				
				fileNum += 1;
			}
		}
		
		/// <summary>
		/// Raised when a "clear recent files list" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ClearList_Click(object sender, EventArgs e)
		{
			_recentFiles.Clear();
			
			SaveList();
			Refresh();
		}
		
		/// <summary>
		/// Raised when a "recent file" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void RecentFile_Click(object sender, EventArgs e)
		{
			if (FileMustBeOpened == null) return;

			string fileName = (sender as ToolStripItem).Text.Substring(2);
			RecentFileInfo element = _recentFiles[fileName];
			
			FileMustBeOpened(this,
			                 new RecentFileEventArgs(element));
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
